using ACRM.src.Domain.Entity;
using ACRM.src.Domain.ViewModel.Admin.Employer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACRM.Controllers.Admin
{
    [Route("admin/settings/[action]")]
    [Authorize(Roles = "admin")]
    public class SettingsController(UserManager<Employer> userManager,
        IUserStore<Employer> userStore) : Controller
    {
        private readonly UserManager<Employer> _userManager = userManager;
        private readonly IUserStore<Employer> _userStore = userStore;


        [HttpGet]
        [Route("employers")]
        public async Task<IActionResult> Employers()
        {
            try
            {
                var employers = await _userManager.Users.ToListAsync();
                List<EmployerVM> users = [];
                foreach (var employer in employers)
                {
                    users.Add(new EmployerVM { UserName = employer.UserName}) ;
                }
                return View(users);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View(new AddEmployerVM());
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddEmployerVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new Employer { UserName = model.UserName, Email = model.Email };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Employers");
                    }
                }
                return RedirectToAction("Employers");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
        //public async Task<List<string>> GetOnlineUsersAsync()
        //{
        //    var onlineUsers = new List<string>();

        //    // Получаем список всех активных сессий
        //    var allSessions = await _httpContextAccessor.HttpContext.SessionStore.ListAsync();

        //    // Проходим по каждой сессии и добавляем имя пользователя в список, если сессия аутентифицирована
        //    foreach (var session in allSessions)
        //    {
        //        var principal = await _httpContextAccessor.HttpContext.SessionStore.GetAsync(session);

        //        if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated)
        //        {
        //            onlineUsers.Add(principal.Identity.Name);
        //        }
        //    }

        //    return onlineUsers.Distinct().ToList(); // Возвращаем уникальных пользователей
        //}
    }
}
