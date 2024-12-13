using System.IdentityModel.Tokens.Jwt;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.API.Attributes;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystemBackend.API.Middlewares
{
    public class PermissionRequirementMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PermissionRequirementMiddleware> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PermissionRequirementMiddleware(RequestDelegate next, ILogger<PermissionRequirementMiddleware> logger, IServiceScopeFactory serviceScopeFactory)
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

                // PermissionRequirementAttribute yoksa kontrol yapma
                var hasPermissionAttribute = endpoint?.Metadata?.GetOrderedMetadata<PermissionRequirementAttribute>().Any() ?? false;
                if (!hasPermissionAttribute)
                {
                    await _next(context);
                    return;
                }

                var organizationId = context.Request.Headers["Organization-Id"].ToString();
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(organizationId))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { message = "Authorization header missing." });
                    return;
                }

                using var scope = _serviceScopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var handler = new JwtSecurityTokenHandler();
                if (handler.CanReadToken(token))
                {
                    var jwtToken = handler.ReadJwtToken(token);
                    var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
                    if (userIdClaim == null)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsJsonAsync(new { message = "User ID missing in token." });
                        return;
                    }

                    var user = await dbContext.Users.FindAsync(int.Parse(userIdClaim));
                    if (user == null)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsJsonAsync(new { message = "User not found." });
                        return;
                    }

                    var organization = await dbContext.Organizations.FindAsync(int.Parse(organizationId));
                    if (organization == null)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync(new { message = "Organization not found." });
                        return;
                    }

                    if (organization.OwnerId == user.Id)
                    {
                        await _next(context);
                        return;
                    }

                    // Metadata Permissions
                    var requiredPermissions = endpoint.Metadata.GetOrderedMetadata<PermissionRequirementAttribute>()
                        .Select(attr => attr.Permission)
                        .ToList();

                    if (requiredPermissions.Any())
                    {
                        var userOrganizationRoles = await dbContext.UserOrganizationRoles
                            .Where(or => or.UserId == user.Id && or.OrganizationRole.OrganizationId == int.Parse(organizationId))
                            .ToListAsync();
                        var hasPermission = userOrganizationRoles.Any(uor => requiredPermissions.Contains(uor.OrganizationRole.Name));
                        if (!hasPermission)
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            await context.Response.WriteAsJsonAsync(new { message = "Insufficient permissions." });
                            return;
                        }
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { message = "Invalid token." });
                    return;
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Authorization failed.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { message = "Internal server error." });
            }
        }


    }
}
