using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using TaskManagementSystemBackend.DataAccess;

namespace TaskManagementSystemBackend.API.Middlewares
{
    public class OrganizationUserValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<OrganizationUserValidationMiddleware> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OrganizationUserValidationMiddleware(RequestDelegate next, ILogger<OrganizationUserValidationMiddleware> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var endpoint = context.GetEndpoint();
                if (endpoint?.Metadata?.GetMetadata<Attributes.OrganizationUserValidationAttribute>() == null)
                {
                    await _next(context);
                    return;
                }

                var organizationId = context.Request.Headers["Organization-Id"].FirstOrDefault();
                if (string.IsNullOrEmpty(organizationId))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(new { message = "Organization-Id header is missing." });
                    return;
                }
                var userId = context.Items["UserId"] as int?;
                if (!userId.HasValue)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { message = "User ID is missing." });
                    return;
                }

                using var scope = _serviceScopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var isUserInOrganization = await dbContext.OrganizationUsers.AnyAsync(uo => uo.UserId == userId && uo.OrganizationId == int.Parse(organizationId));
                var isUserAdminInOrganization = await dbContext.Organizations.AnyAsync(o => o.Id == int.Parse(organizationId) && o.OwnerId == userId);

                if (!isUserInOrganization && !isUserAdminInOrganization)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsJsonAsync(new { message = "User is not a member of the organization." });
                    return;
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in OrganizationUserValidationMiddleware.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { message = "Internal server error." });
            }
        }
    }
}
