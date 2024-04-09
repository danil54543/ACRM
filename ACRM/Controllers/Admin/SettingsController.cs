using ACRM.src.BL.Service;
using ACRM.src.Domain.Entity;
using ACRM.src.Domain.ViewModel.Admin.Branch;
using ACRM.src.Domain.ViewModel.Admin.Employer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACRM.Controllers.Admin
{
    [Route("admin/settings/[action]")]
    [Authorize(Roles = "admin")]

    public class SettingsController(UserManager<Employer> userManager, IUserStore<Employer> userStore, IBranchService branchService) : Controller
    {
        private readonly UserManager<Employer> _userManager = userManager;
        private readonly IUserStore<Employer> _userStore = userStore;
        private readonly IBranchService _branchService = branchService;

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
        [Route("add-employer")]
        public IActionResult AddEmployer()
        {
            return View(new AddEmployerVM());
        }
        [HttpPost]
        [Route("add-employer")]
        public async Task<IActionResult> AddEmployer(AddEmployerVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new Employer { UserName = model.UserName, Email = model.Email };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Employers");//todo
                    }
                }
                return RedirectToAction("Employers");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        [Route("branches")]
        public  IActionResult Branches()
        {
            var branches =_branchService.GetAll().Result;
            return View(branches);

        }
        [HttpGet]
        [Route("add-branch")]
        public IActionResult AddBranch()
        {
            return View(new AddBranchVM());
        }
        [HttpPost]
        [Route("add-branch")]
        public async Task<IActionResult> AddBranch(AddBranchVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _branchService.Create(model);
                }
                return RedirectToAction("Branches");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
