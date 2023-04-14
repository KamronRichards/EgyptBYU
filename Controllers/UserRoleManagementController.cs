using System.Linq;
using System.Threading.Tasks;
using EgyptBYU.Data;
using EgyptBYU.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgyptBYU.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserRoleManagementController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext newContext { get; set; }

        public UserRoleManagementController(UserManager<IdentityUser> userManager,
                                            RoleManager<IdentityRole> roleManager,
                                            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            newContext = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //get all users and send to view
            var users = userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            //find user by userId
            //Add UserName to ViewBag
            //get userRole of users and send to view
            var user = await userManager.FindByIdAsync(userId);

            ViewBag.UserName = user.UserName;

            var userRoles = await userManager.GetRolesAsync(user);

            return View(userRoles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return RedirectToAction(nameof(DisplayRoles));
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string role)
        {
            //create new role using roleManager
            //return to displayRoles
            await roleManager.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(DisplayRoles));
        }

        [HttpGet]
        public IActionResult DisplayRoles()
        {
            //get all roles and pass to view
            var roles = roleManager.Roles.ToList();

            return View(roles);
        }

        [HttpGet]
        public IActionResult AddUserToRole()
        {
            //get all users
            //get all roles
            //create selectlist and pass using viewBag
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();

            ViewBag.Users = new SelectList(users, "Id", "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRole userRole)
        {
            //find user from userRole.UserId
            //assign role to user
            //redirect to index

            var user = await userManager.FindByIdAsync(userRole.UserId);

            await userManager.AddToRoleAsync(user, userRole.RoleName);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string role, string userName)
        {
            //get user from userName
            //remove role of user using userManager
            //return to details with parameter userId

            var user = await userManager.FindByNameAsync(userName);

            var result = await userManager.RemoveFromRoleAsync(user, role);

            return RedirectToAction(nameof(Details), new { userId = user.Id });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRole(string role)
        {
            //get role to delete using role Name
            //delete role using roleManager
            //redirect to displayroles

            var roleToDelete = await roleManager.FindByNameAsync(role);
            var result = await roleManager.DeleteAsync(roleToDelete);

            return RedirectToAction(nameof(DisplayRoles));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string userId)
        {
            //find user by userId
            var user = await userManager.FindByIdAsync(userId);

            return View(user);
        }

        //[HttpPost]
        //public IActionResult DeleteUser(IdentityUserRole<string> userId1)
        //{
        //    newContext.UserRoles.Remove(UserId);
        //    newContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            // Find user by userId
            var user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                // Delete user
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    // Redirect to index
                    return RedirectToAction(nameof(Index));
                }
            }

            // If user is not found or delete fails, return to index with error message
            TempData["ErrorMessage"] = $"Failed to delete user with ID {userId}.";
            return RedirectToAction(nameof(Index));
        }


    }
}