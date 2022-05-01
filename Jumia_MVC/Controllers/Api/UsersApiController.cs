

namespace Jumia_MVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles ="Admin")]

    public class UsersApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;



        public UsersApiController(
             UserManager<ApplicationUser> userManager
             )
        {
            _userManager = userManager;


        }
        // [HttpDelete("{userId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception();
            }
            return Ok();
        }
    }
}
