using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound(new { message = $"ID {id} ile kullanıcı bulunamadı." });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { message = "Geçersiz model verisi.", details = ModelState });

                var updatedUser = await _userService.UpdateUserAsync(id, updateUserDto);
                if (updatedUser == null)
                    return NotFound(new { message = $"ID {id} ile kullanıcı bulunamadı." });

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var isDeleted = await _userService.DeleteUserAsync(id);
                if (!isDeleted)
                    return NotFound(new { message = $"ID {id} ile kullanıcı bulunamadı." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }
    }
}
