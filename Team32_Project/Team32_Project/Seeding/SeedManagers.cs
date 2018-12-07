using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


using Team32_Project.DAL;
using Team32_Project.Models;

namespace Team32_Project.Seeding
{
    //add identity data
    public static class SeedManagers
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            if (await _roleManager.RoleExistsAsync("Manager") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            //check to see if the manager has been added
            AppUser manager1 = _db.Users.FirstOrDefault(u => u.Email == "c.baker@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager1 == null)
            {
                manager1 = new AppUser();
                manager1.UserName = "c.baker@bevosbooks.com";
                manager1.Email = "c.baker@bevosbooks.com";
                manager1.LastName = "Baker";
                manager1.FirstName = "Christopher";
                manager1.MiddleInitial = "E";
                manager1.SocialSecurity = "401661146";
                manager1.StreetAddress = "1245 Lake Libris Dr.";
                manager1.City = "Cedar Park";
                manager1.State = "TX";
                manager1.ZipCode = "78613";
                manager1.PhoneNumber = "(339) 532-5649";


                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(manager1, "dewey4");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager1 = _db.Users.FirstOrDefault(u => u.UserName == "c.baker@bevosbooks.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager1, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager1, "Manager");
            }

            //start new manager
            //check to see if the manager has been added
            AppUser manager2 = _db.Users.FirstOrDefault(u => u.Email == "e.rice@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager2 == null)
            {
                manager2 = new AppUser();
                manager2.UserName = "e.rice@bevosbooks.com";
                manager2.Email = "e.rice@bevosbooks.com";
                manager2.LastName = "Rice";
                manager2.FirstName = "Eryn";
                manager2.MiddleInitial = "M";
                manager2.SocialSecurity = "454776657";
                manager2.StreetAddress = "3405 Rio Grande";
                manager2.City = "Austin";
                manager2.State = "TX";
                manager2.ZipCode = "78746";
                manager2.PhoneNumber = "(270) 660-2803";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(manager2, "arched");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager2 = _db.Users.FirstOrDefault(u => u.UserName == "e.rice@bevosbooks.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager2, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager2, "Manager");
            }

            //new manager
            //check to see if the manager has been added
            AppUser manager3 = _db.Users.FirstOrDefault(u => u.Email == "a.rogers@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager3 == null)
            {
                manager3 = new AppUser();
                manager3.UserName = "a.rogers@bevosbooks.com";
                manager3.Email = "a.rogers@bevosbooks.com";
                manager3.LastName = "Rogers";
                manager3.FirstName = "Allen";
                manager3.MiddleInitial = "H";
                manager3.SocialSecurity = "700002943";
                manager3.StreetAddress = "4965 Oak Hill";
                manager3.City = "Austin";
                manager3.State = "TX";
                manager3.ZipCode = "78705";
                manager3.PhoneNumber = "(413) 964-5586";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(manager3, "lottery");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager3 = _db.Users.FirstOrDefault(u => u.UserName == "a.rogers@bevosbooks.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager3, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager3, "Manager");
            }

            //new manager
            //check to see if the manager has been added
            AppUser manager4 = _db.Users.FirstOrDefault(u => u.Email == "w.sewell@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager4 == null)
            {
                manager4 = new AppUser();
                manager4.UserName = "w.sewell@bevosbooks.com";
                manager4.Email = "w.sewell@bevosbooks.com";
                manager4.LastName = "Sewell";
                manager4.FirstName = "William";
                manager4.MiddleInitial = "G";
                manager4.SocialSecurity = "500830084";
                manager4.StreetAddress = "2365 51st St.";
                manager4.City = "Austin";
                manager4.State = "TX";
                manager4.ZipCode = "78755";
                manager4.PhoneNumber = "(722) 430-8314";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(manager4, "offbeat");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager4 = _db.Users.FirstOrDefault(u => u.UserName == "w.sewell@bevosbooks.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager4, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager4, "Manager");
            }

            //new manager
            //check to see if the manager has been added
            AppUser manager5 = _db.Users.FirstOrDefault(u => u.Email == "r.taylor@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager5 == null)
            {
                manager5 = new AppUser();
                manager5.UserName = "r.taylor@bevosbooks.com";
                manager5.Email = "r.taylor@bevosbooks.com";
                manager5.LastName = "Taylor";
                manager5.FirstName = "Rachel";
                manager5.MiddleInitial = "O";
                manager5.SocialSecurity = "393412631";
                manager5.StreetAddress = "345 Longview Dr.";
                manager5.City = "Austin";
                manager5.State = "TX";
                manager5.ZipCode = "78746";
                manager5.PhoneNumber = "(907) 123-6087";

                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(manager5, "landus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager5 = _db.Users.FirstOrDefault(u => u.UserName == "r.taylor@bevosbooks.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager5, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager5, "Manager");
            }


            //save changes
            _db.SaveChanges();
        }

    }
}