using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team32_Project.DAL;
using Team32_Project.Models;


namespace Team32_Project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _db;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signIn;
           
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, 
                model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

       
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    MiddleInitial = model.MiddleInitial,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //This will not work until you have seeded Identity OR added the "Customer" role 
                    //by navigating to the RoleAdmin controller and manually added the "Customer" role
                
                    await _userManager.AddToRoleAsync(user, "Customer");
                    //await _userManager.AddToRoleAsync(user, "Employee");
                    //await _userManager.AddToRoleAsync(user, "Manager");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        //GET: Account/Index
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.FirstName = user.FirstName;
            ivm.MiddleInitial = user.MiddleInitial;
            ivm.LastName = user.LastName;
            ivm.StreetAddress = user.StreetAddress;
            ivm.City = user.City;
            ivm.State = user.State;
            ivm.ZipCode = user.ZipCode;
            ivm.PhoneNumber = user.PhoneNumber;

            return View(ivm);
        }

        //Logic for editing account info
        // GET: /Account/Edit
        public IActionResult Edit()
        {
            return View();
        }

        // POST: /Account/EditAccountInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditAccountInfoViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            userLoggedIn.Email = model.Email;
            userLoggedIn.FirstName = model.FirstName;
            userLoggedIn.MiddleInitial = model.MiddleInitial;
            userLoggedIn.LastName = model.LastName;
            userLoggedIn.StreetAddress = model.StreetAddress;
            userLoggedIn.City = model.City;
            userLoggedIn.State = model.State;
            userLoggedIn.ZipCode = model.ZipCode;
            userLoggedIn.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(userLoggedIn);

            if (result.Succeeded)
            {
                _db.Update(userLoggedIn);
                await _db.SaveChangesAsync();

                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false); 
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }

        //GET:/Account/AccessDenied
        public ActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}