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
    public static class SeedIdentity
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

            if (await _roleManager.RoleExistsAsync("Employee") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
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




            //now add customers
            //TODO: Add Customers



            AppUser customer1 = new AppUser();
            if (customer1 == null)
            {
                customer1 = new AppUser();
                //customer1.CustomerID = "9010";
                customer1.UserName = "cbaker@example.com";
                customer1.Email = "cbaker@example.com";
                customer1.LastName = "Baker";
                customer1.FirstName = "Christopher";
                customer1.MiddleInitial = "L.";
                //customer1.Birthday = new DateTime(1949, 11, 23);
                customer1.SocialSecurity = "477 - 44 - 9589";
                customer1.StreetAddress = "1898 Schurz Alley";
                customer1.City = "Austin";
                customer1.State = "TX";
                customer1.ZipCode = "78705";
                customer1.PhoneNumber = "5725458641";
                var result = await _userManager.CreateAsync(customer1, "bookworm");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer1 = _db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com");
            }
            if (await _userManager.IsInRoleAsync(customer1, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer1, "Customer");
            }


            AppUser customer2 = new AppUser();
            if (customer2 == null)
            {
                customer2 = new AppUser();
                //customer2.CustomerID = "9011";
                customer2.UserName = "banker@longhorn.net";
                customer2.Email = "banker@longhorn.net";
                customer2.LastName = "Banks";
                customer2.FirstName = "Michelle";
                customer2.MiddleInitial = "";
                //customer2.Birthday = new DateTime(11 / 27 / 62);
                customer2.SocialSecurity = "247 - 31 - 0787";
                customer2.StreetAddress = "97 Elmside Pass";
                customer2.City = "Austin";
                customer2.State = "TX";
                customer2.ZipCode = "78712";
                customer2.PhoneNumber = "9867048435";
                var result = await _userManager.CreateAsync(customer2, "potato");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer2 = _db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
            }
            if (await _userManager.IsInRoleAsync(customer2, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer2, "Customer");
            }


            AppUser customer3 = new AppUser();
            if (customer3 == null)
            {
                customer3 = new AppUser();
                //customer3.CustomerID = "9012";
                customer3.UserName = "franco@example.com";
                customer3.Email = "franco@example.com";
                customer3.LastName = "Broccolo";
                customer3.FirstName = "Franco";
                customer3.MiddleInitial = "V";
                //customer3.Birthday = new DateTime(10 / 11 / 92);
                customer3.SocialSecurity = "486 - 47 - 8748";
                customer3.StreetAddress = "88 Crowley Circle";
                customer3.City = "Austin";
                customer3.State = "TX";
                customer3.ZipCode = "78786";
                customer3.PhoneNumber = "6836109514";
                var result = await _userManager.CreateAsync(customer3, "painting");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer3 = _db.Users.FirstOrDefault(u => u.UserName == "franco@example.com");
            }
            if (await _userManager.IsInRoleAsync(customer3, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer3, "Customer");
            }


            AppUser customer4 = new AppUser();
            if (customer4 == null)
            {
                customer4 = new AppUser();
                //customer4.CustomerID = "9013";
                customer4.UserName = "wchang@example.com";
                customer4.Email = "wchang@example.com";
                customer4.LastName = "Chang";
                customer4.FirstName = "Wendy";
                customer4.MiddleInitial = "L";
                //customer4.Birthday = new DateTime(5 / 16 / 97);
                customer4.SocialSecurity = "182 - 52 - 9193";
                customer4.StreetAddress = "56560 Sage Junction";
                customer4.City = "Eagle Pass";
                customer4.State = "TX";
                customer4.ZipCode = "78852";
                customer4.PhoneNumber = "7070911071";
                var result = await _userManager.CreateAsync(customer4, "texas1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer4 = _db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com");
            }
            if (await _userManager.IsInRoleAsync(customer4, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer4, "Customer");
            }


            AppUser customer5 = new AppUser();
            if (customer5 == null)
            {
                customer5 = new AppUser();
                //customer5.CustomerID = "9014";
                customer5.UserName = "limchou@gogle.com";
                customer5.Email = "limchou@gogle.com";
                customer5.LastName = "Chou";
                customer5.FirstName = "Lim";
                customer5.MiddleInitial = "";
                //customer5.Birthday = new DateTime(4 / 6 / 70);
                customer5.SocialSecurity = "679 - 75 - 0653";
                customer5.StreetAddress = "60 Lunder Point";
                customer5.City = "Austin";
                customer5.State = "TX";
                customer5.ZipCode = "78729";
                customer5.PhoneNumber = "1488907687";
                var result = await _userManager.CreateAsync(customer5, "Anchorage");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer5 = _db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer5, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer5, "Customer");
            }


            AppUser customer6 = new AppUser();
            if (customer6 == null)
            {
                customer6 = new AppUser();
                //customer6.CustomerID = "9015";
                customer6.UserName = "shdixon@aoll.com";
                customer6.Email = "shdixon@aoll.com";
                customer6.LastName = "Dixon";
                customer6.FirstName = "Shan";
                customer6.MiddleInitial = "D";
                //customer6.Birthday = new DateTime(1 / 12 / 84);
                customer6.SocialSecurity = "593 - 06 - 9800";
                customer6.StreetAddress = "9448 Pleasure Avenue";
                customer6.City = "Georgetown";
                customer6.State = "TX";
                customer6.ZipCode = "78628";
                customer6.PhoneNumber = "6899701824";
                var result = await _userManager.CreateAsync(customer6, "aggies");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer6 = _db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com");
            }
            if (await _userManager.IsInRoleAsync(customer6, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer6, "Customer");
            }


            AppUser customer7 = new AppUser();
            if (customer7 == null)
            {
                customer7 = new AppUser();
                //customer7.CustomerID = "9016";
                customer7.UserName = "j.b.evans@aheca.org";
                customer7.Email = "j.b.evans@aheca.org";
                customer7.LastName = "Evans";
                customer7.FirstName = "Jim Bob";
                customer7.MiddleInitial = "";
                //customer7.Birthday = new DateTime(9 / 9 / 59);
                customer7.SocialSecurity = "647 - 72 - 4711";
                customer7.StreetAddress = "51 Emmet Parkway";
                customer7.City = "Austin";
                customer7.State = "TX";
                customer7.ZipCode = "78705";
                customer7.PhoneNumber = "9986825917";
                var result = await _userManager.CreateAsync(customer7, "hampton1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer7 = _db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
            }
            if (await _userManager.IsInRoleAsync(customer7, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer7, "Customer");
            }


            AppUser customer8 = new AppUser();
            if (customer8 == null)
            {
                customer8 = new AppUser();
                //customer8.CustomerID = "9017";
                customer8.UserName = "feeley@penguin.org";
                customer8.Email = "feeley@penguin.org";
                customer8.LastName = "Feeley";
                customer8.FirstName = "Lou Ann";
                customer8.MiddleInitial = "K";
                //customer8.Birthday = new DateTime(1 / 12 / 01);
                customer8.SocialSecurity = "577 - 89 - 2279";
                customer8.StreetAddress = "65 Darwin Crossing";
                customer8.City = "Austin";
                customer8.State = "TX";
                customer8.ZipCode = "78704";
                customer8.PhoneNumber = "3464121966";
                var result = await _userManager.CreateAsync(customer8, "longhorns");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer8 = _db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
            }
            if (await _userManager.IsInRoleAsync(customer8, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer8, "Customer");
            }


            AppUser customer9 = new AppUser();
            if (customer9 == null)
            {
                customer9 = new AppUser();
                //customer9.CustomerID = "9018";
                customer9.UserName = "tfreeley@minnetonka.ci.us";
                customer9.Email = "tfreeley@minnetonka.ci.us";
                customer9.LastName = "Freeley";
                customer9.FirstName = "Tesa";
                customer9.MiddleInitial = "P";
                //customer9.Birthday = new DateTime(2 / 4 / 91);
                customer9.SocialSecurity = "853 - 72 - 9538";
                customer9.StreetAddress = "7352 Loftsgordon Court";
                customer9.City = "College Station";
                customer9.State = "TX";
                customer9.ZipCode = "77840";
                customer9.PhoneNumber = "6581357270";
                var result = await _userManager.CreateAsync(customer9, "mustangs");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer9 = _db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
            }
            if (await _userManager.IsInRoleAsync(customer9, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer9, "Customer");
            }


            AppUser customer10 = new AppUser();
            if (customer10 == null)
            {
                customer10 = new AppUser();
                //customer10.CustomerID = "9019";
                customer10.UserName = "mgarcia@gogle.com";
                customer10.Email = "mgarcia@gogle.com";
                customer10.LastName = "Garcia";
                customer10.FirstName = "Margaret";
                customer10.MiddleInitial = "L";
                //customer10.Birthday = new DateTime(10 / 2 / 91);
                customer10.SocialSecurity = "887 - 12 - 0229";
                customer10.StreetAddress = "7 International Road";
                customer10.City = "Austin";
                customer10.State = "TX";
                customer10.ZipCode = "78756";
                customer10.PhoneNumber = "3767347949";
                var result = await _userManager.CreateAsync(customer10, "onetime");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer10 = _db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer10, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer10, "Customer");
            }


            AppUser customer11 = new AppUser();
            if (customer11 == null)
            {
                customer11 = new AppUser();
                //customer11.CustomerID = "9020";
                customer11.UserName = "chaley@thug.com";
                customer11.Email = "chaley@thug.com";
                customer11.LastName = "Haley";
                customer11.FirstName = "Charles";
                customer11.MiddleInitial = "E";
                //customer11.Birthday = new DateTime(7 / 10 / 74);
                customer11.SocialSecurity = "528 - 58 - 6911";
                customer11.StreetAddress = "8 Warrior Trail";
                customer11.City = "Austin";
                customer11.State = "TX";
                customer11.ZipCode = "78746";
                customer11.PhoneNumber = "2198604221";
                var result = await _userManager.CreateAsync(customer11, "pepperoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer11 = _db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
            }
            if (await _userManager.IsInRoleAsync(customer11, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer11, "Customer");
            }


            AppUser customer12 = new AppUser();
            if (customer12 == null)
            {
                customer12 = new AppUser();
                //customer12.CustomerID = "9021";
                customer12.UserName = "jeffh@sonic.com";
                customer12.Email = "jeffh@sonic.com";
                customer12.LastName = "Hampton";
                customer12.FirstName = "Jeffrey";
                customer12.MiddleInitial = "T.";
                //customer12.Birthday = new DateTime(3 / 10 / 04);
                customer12.SocialSecurity = "658 - 45 - 9102";
                customer12.StreetAddress = "9107 Lighthouse Bay Road";
                customer12.City = "Austin";
                customer12.State = "TX";
                customer12.ZipCode = "78756";
                customer12.PhoneNumber = "1222185888";
                var result = await _userManager.CreateAsync(customer12, "raiders");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer12 = _db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
            }
            if (await _userManager.IsInRoleAsync(customer12, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer12, "Customer");
            }


            AppUser customer13 = new AppUser();
            if (customer13 == null)
            {
                customer13 = new AppUser();
                //customer13.CustomerID = "9022";
                customer13.UserName = "wjhearniii@umich.org";
                customer13.Email = "wjhearniii@umich.org";
                customer13.LastName = "Hearn";
                customer13.FirstName = "John";
                customer13.MiddleInitial = "B";
                //customer13.Birthday = new DateTime(8 / 5 / 50);
                customer13.SocialSecurity = "712 - 69 - 1666";
                customer13.StreetAddress = "59784 Pierstorff Center";
                customer13.City = "Liberty";
                customer13.State = "TX";
                customer13.ZipCode = "77575";
                customer13.PhoneNumber = "5123071976";
                var result = await _userManager.CreateAsync(customer13, "jhearn22");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer13 = _db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
            }
            if (await _userManager.IsInRoleAsync(customer13, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer13, "Customer");
            }


            AppUser customer14 = new AppUser();
            if (customer14 == null)
            {
                customer14 = new AppUser();
                //customer14.CustomerID = "9023";
                customer14.UserName = "ahick@yaho.com";
                customer14.Email = "ahick@yaho.com";
                customer14.LastName = "Hicks";
                customer14.FirstName = "Anthony";
                customer14.MiddleInitial = "J";
                //customer14.Birthday = new DateTime(12 / 8 / 04);
                customer14.SocialSecurity = "179 - 94 - 2233";
                customer14.StreetAddress = "932 Monica Way";
                customer14.City = "San Antonio";
                customer14.State = "TX";
                customer14.ZipCode = "78203";
                customer14.PhoneNumber = "1211949601";
                var result = await _userManager.CreateAsync(customer14, "hickhickup");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer14 = _db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
            }
            if (await _userManager.IsInRoleAsync(customer14, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer14, "Customer");
            }


            AppUser customer15 = new AppUser();
            if (customer15 == null)
            {
                customer15 = new AppUser();
                //customer15.CustomerID = "9024";
                customer15.UserName = "ingram@jack.com";
                customer15.Email = "ingram@jack.com";
                customer15.LastName = "Ingram";
                customer15.FirstName = "Brad";
                customer15.MiddleInitial = "S.";
                //customer15.Birthday = new DateTime(9 / 5 / 01);
                customer15.SocialSecurity = "126 - 14 - 4287";
                customer15.StreetAddress = "4 Lukken Court";
                customer15.City = "New Braunfels";
                customer15.State = "TX";
                customer15.ZipCode = "78132";
                customer15.PhoneNumber = "1372121569";
                var result = await _userManager.CreateAsync(customer15, "ingram2015");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer15 = _db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
            }
            if (await _userManager.IsInRoleAsync(customer15, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer15, "Customer");
            }


            AppUser customer16 = new AppUser();
            if (customer16 == null)
            {
                customer16 = new AppUser();
                //customer16.CustomerID = "9025";
                customer16.UserName = "toddj@yourmom.com";
                customer16.Email = "toddj@yourmom.com";
                customer16.LastName = "Jacobs";
                customer16.FirstName = "Todd";
                customer16.MiddleInitial = "L.";
                //customer16.Birthday = new DateTime(1 / 20 / 99);
                customer16.SocialSecurity = "355 - 61 - 0890";
                customer16.StreetAddress = "7 Susan Junction";
                customer16.City = "New York";
                customer16.State = "NY";
                customer16.ZipCode = "10101";
                customer16.PhoneNumber = "8543163836";
                var result = await _userManager.CreateAsync(customer16, "toddy25");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer16 = _db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
            }
            if (await _userManager.IsInRoleAsync(customer16, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer16, "Customer");
            }


            AppUser customer17 = new AppUser();
            if (customer17 == null)
            {
                customer17 = new AppUser();
                //customer17.CustomerID = "9026";
                customer17.UserName = "thequeen@aska.net";
                customer17.Email = "thequeen@aska.net";
                customer17.LastName = "Lawrence";
                customer17.FirstName = "Victoria";
                customer17.MiddleInitial = "M.";
                //customer17.Birthday = new DateTime(4 / 14 / 00);
                customer17.SocialSecurity = "840 - 91 - 4997";
                customer17.StreetAddress = "669 Oak Junction";
                customer17.City = "Lockhart";
                customer17.State = "TX";
                customer17.ZipCode = "78644";
                customer17.PhoneNumber = "3214163359";
                var result = await _userManager.CreateAsync(customer17, "something");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer17 = _db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
            }
            if (await _userManager.IsInRoleAsync(customer17, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer17, "Customer");
            }


            AppUser customer18 = new AppUser();
            if (customer18 == null)
            {
                customer18 = new AppUser();
                //customer18.CustomerID = "9027";
                customer18.UserName = "linebacker@gogle.com";
                customer18.Email = "linebacker@gogle.com";
                customer18.LastName = "Lineback";
                customer18.FirstName = "Erik";
                customer18.MiddleInitial = "W";
                //customer18.Birthday = new DateTime(12 / 2 / 03);
                customer18.SocialSecurity = "303 - 25 - 5592";
                customer18.StreetAddress = "099 Luster Point";
                customer18.City = "Kingwood";
                customer18.State = "TX";
                customer18.ZipCode = "77325";
                customer18.PhoneNumber = "2505265350";
                var result = await _userManager.CreateAsync(customer18, "Password1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer18 = _db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer18, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer18, "Customer");
            }


            AppUser customer19 = new AppUser();
            if (customer19 == null)
            {
                customer19 = new AppUser();
                //customer19.CustomerID = "9028";
                customer19.UserName = "elowe@netscare.net";
                customer19.Email = "elowe@netscare.net";
                customer19.LastName = "Lowe";
                customer19.FirstName = "Ernest";
                customer19.MiddleInitial = "S";
                //customer19.Birthday = new DateTime(12 / 7 / 77);
                customer19.SocialSecurity = "547 - 72 - 1592";
                customer19.StreetAddress = "35473 Hansons Hill";
                customer19.City = "Beverly Hills";
                customer19.State = "CA";
                customer19.ZipCode = "90210";
                customer19.PhoneNumber = "4070619503";
                var result = await _userManager.CreateAsync(customer19, "aclfest2017");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer19 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
            }
            if (await _userManager.IsInRoleAsync(customer19, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer19, "Customer");
            }


            AppUser customer20 = new AppUser();
            if (customer20 == null)
            {
                customer20 = new AppUser();
                //customer20.CustomerID = "9029";
                customer20.UserName = "cluce@gogle.com";
                customer20.Email = "cluce@gogle.com";
                customer20.LastName = "Luce";
                customer20.FirstName = "Chuck";
                customer20.MiddleInitial = "B";
                //customer20.Birthday = new DateTime(3 / 16 / 49);
                customer20.SocialSecurity = "434 - 46 - 8800";
                customer20.StreetAddress = "4 Emmet Junction";
                customer20.City = "Navasota";
                customer20.State = "TX";
                customer20.ZipCode = "77868";
                customer20.PhoneNumber = "7358436110";
                var result = await _userManager.CreateAsync(customer20, "nothinggood");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer20 = _db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer20, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer20, "Customer");
            }


            AppUser customer21 = new AppUser();
            if (customer21 == null)
            {
                customer21 = new AppUser();
                //customer21.CustomerID = "9030";
                customer21.UserName = "mackcloud@george.com";
                customer21.Email = "mackcloud@george.com";
                customer21.LastName = "MacLeod";
                customer21.FirstName = "Jennifer";
                customer21.MiddleInitial = "D.";
                //customer21.Birthday = new DateTime(2 / 21 / 47);
                customer21.SocialSecurity = "219 - 58 - 3683";
                customer21.StreetAddress = "3 Orin Road";
                customer21.City = "Austin";
                customer21.State = "TX";
                customer21.ZipCode = "78712";
                customer21.PhoneNumber = "7240178229";
                var result = await _userManager.CreateAsync(customer21, "whatever");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer21 = _db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
            }
            if (await _userManager.IsInRoleAsync(customer21, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer21, "Customer");
            }


            AppUser customer22 = new AppUser();
            if (customer22 == null)
            {
                customer22 = new AppUser();
                //customer22.CustomerID = "9031";
                customer22.UserName = "cmartin@beets.com";
                customer22.Email = "cmartin@beets.com";
                customer22.LastName = "Markham";
                customer22.FirstName = "Elizabeth";
                customer22.MiddleInitial = "P.";
                //customer22.Birthday = new DateTime(3 / 20 / 72);
                customer22.SocialSecurity = "116 - 38 - 6529";
                customer22.StreetAddress = "8171 Commercial Crossing";
                customer22.City = "Austin";
                customer22.State = "TX";
                customer22.ZipCode = "78712";
                customer22.PhoneNumber = "2495200223";
                var result = await _userManager.CreateAsync(customer22, "snowsnow");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer22 = _db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
            }
            if (await _userManager.IsInRoleAsync(customer22, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer22, "Customer");
            }


            AppUser customer23 = new AppUser();
            if (customer23 == null)
            {
                customer23 = new AppUser();
                //customer23.CustomerID = "9032";
                customer23.UserName = "clarence@yoho.com";
                customer23.Email = "clarence@yoho.com";
                customer23.LastName = "Martin";
                customer23.FirstName = "Clarence";
                customer23.MiddleInitial = "A";
                //customer23.Birthday = new DateTime(7 / 19 / 92);
                customer23.SocialSecurity = "220 - 24 - 4049";
                customer23.StreetAddress = "96 Anthes Place";
                customer23.City = "Schenectady";
                customer23.State = "NY";
                customer23.ZipCode = "12345";
                customer23.PhoneNumber = "4086179161";
                var result = await _userManager.CreateAsync(customer23, "whocares");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer23 = _db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
            }
            if (await _userManager.IsInRoleAsync(customer23, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer23, "Customer");
            }


            AppUser customer24 = new AppUser();
            if (customer24 == null)
            {
                customer24 = new AppUser();
                //customer24.CustomerID = "9033";
                customer24.UserName = "gregmartinez@drdre.com";
                customer24.Email = "gregmartinez@drdre.com";
                customer24.LastName = "Martinez";
                customer24.FirstName = "Gregory";
                customer24.MiddleInitial = "R.";
                //customer24.Birthday = new DateTime(1947, 5, 28);
                customer24.SocialSecurity = "559 - 67 - 5740";
                customer24.StreetAddress = "10 Northridge Plaza";
                customer24.City = "Austin";
                customer24.State = "TX";
                customer24.ZipCode = "78717";
                customer24.PhoneNumber = "9371927523";
                var result = await _userManager.CreateAsync(customer24, "xcellent");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer24 = _db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
            }
            if (await _userManager.IsInRoleAsync(customer24, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer24, "Customer");
            }


            AppUser customer25 = new AppUser();
            if (customer25 == null)
            {
                customer25 = new AppUser();
                //customer25.CustomerID = "9034";
                customer25.UserName = "cmiller@bob.com";
                customer25.Email = "cmiller@bob.com";
                customer25.LastName = "Miller";
                customer25.FirstName = "Charles";
                customer25.MiddleInitial = "R.";
                //customer25.Birthday = new DateTime(1990, 10, 15);
                customer25.SocialSecurity = "209 - 79 - 0473";
                customer25.StreetAddress = "87683 Schmedeman Circle";
                customer25.City = "Austin";
                customer25.State = "TX";
                customer25.ZipCode = "78727";
                customer25.PhoneNumber = "5954063857";
                var result = await _userManager.CreateAsync(customer25, "mydogspot");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer25 = _db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
            }
            if (await _userManager.IsInRoleAsync(customer25, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer25, "Customer");
            }


            AppUser customer26 = new AppUser();
            if (customer26 == null)
            {
                customer26 = new AppUser();
                //customer26.CustomerID = "9035";
                customer26.UserName = "knelson@aoll.com";
                customer26.Email = "knelson@aoll.com";
                customer26.LastName = "Nelson";
                customer26.FirstName = "Kelly";
                customer26.MiddleInitial = "T";
                //customer26.Birthday = new DateTime(1971, 7, 13);
                customer26.SocialSecurity = "227 - 64 - 1445";
                customer26.StreetAddress = "3244 Ludington Court";
                customer26.City = "Beaumont";
                customer26.State = "TX";
                customer26.ZipCode = "77720";
                customer26.PhoneNumber = "8929209512";
                var result = await _userManager.CreateAsync(customer26, "spotmydog");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer26 = _db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
            }
            if (await _userManager.IsInRoleAsync(customer26, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer26, "Customer");
            }


            AppUser customer27 = new AppUser();
            if (customer27 == null)
            {
                customer27 = new AppUser();
                //customer27.CustomerID = "9036";
                customer27.UserName = "joewin@xfactor.com";
                customer27.Email = "joewin@xfactor.com";
                customer27.LastName = "Nguyen";
                customer27.FirstName = "Joe";
                customer27.MiddleInitial = "C";
                //customer27.Birthday = new DateTime(1984, 3, 17);
                customer27.SocialSecurity = "480 - 18 - 2513";
                customer27.StreetAddress = "4780 Talisman Court";
                customer27.City = "San Marcos";
                customer27.State = "TX";
                customer27.ZipCode = "78667";
                customer27.PhoneNumber = "9226301774";
                var result = await _userManager.CreateAsync(customer27, "joejoejoe");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer27 = _db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
            }
            if (await _userManager.IsInRoleAsync(customer27, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer27, "Customer");
            }


            AppUser customer28 = new AppUser();
            if (customer28 == null)
            {
                customer28 = new AppUser();
                //customer28.CustomerID = "9037";
                customer28.UserName = "orielly@foxnews.cnn";
                customer28.Email = "orielly@foxnews.cnn";
                customer28.LastName = "O'Reilly";
                customer28.FirstName = "Bill";
                customer28.MiddleInitial = "T";
                //customer28.Birthday = new DateTime(1959, 7, 8);
                customer28.SocialSecurity = "505 - 04 - 1746";
                customer28.StreetAddress = "4154 Delladonna Plaza";
                customer28.City = "Bergheim";
                customer28.State = "TX";
                customer28.ZipCode = "78004";
                customer28.PhoneNumber = "2537646912";
                var result = await _userManager.CreateAsync(customer28, "billyboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer28 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
            }
            if (await _userManager.IsInRoleAsync(customer28, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer28, "Customer");
            }


            AppUser customer29 = new AppUser();
            if (customer29 == null)
            {
                customer29 = new AppUser();
                //customer29.CustomerID = "9038";
                customer29.UserName = "ankaisrad@gogle.com";
                customer29.Email = "ankaisrad@gogle.com";
                customer29.LastName = "Radkovich";
                customer29.FirstName = "Anka";
                customer29.MiddleInitial = "L";
                //customer29.Birthday = new DateTime(1966, 5, 19);
                customer29.SocialSecurity = "772 - 85 - 3188";
                customer29.StreetAddress = "72361 Bayside Drive";
                customer29.City = "Austin";
                customer29.State = "TX";
                customer29.ZipCode = "78789";
                customer29.PhoneNumber = "2182889379";
                var result = await _userManager.CreateAsync(customer29, "radgirl");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer29 = _db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer29, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer29, "Customer");
            }


            AppUser customer30 = new AppUser();
            if (customer30 == null)
            {
                customer30 = new AppUser();
                //customer30.CustomerID = "9039";
                customer30.UserName = "megrhodes@freserve.co.uk";
                customer30.Email = "megrhodes@freserve.co.uk";
                customer30.LastName = "Rhodes";
                customer30.FirstName = "Megan";
                customer30.MiddleInitial = "C.";
                //customer30.Birthday = new DateTime(1965, 3, 12);
                customer30.SocialSecurity = "855 - 90 - 6552";
                customer30.StreetAddress = "76875 Hoffman Point";
                customer30.City = "Orlando";
                customer30.State = "FL";
                customer30.ZipCode = "32830";
                customer30.PhoneNumber = "9532396075";
                var result = await _userManager.CreateAsync(customer30, "meganr34");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer30 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
            }
            if (await _userManager.IsInRoleAsync(customer30, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer30, "Customer");
            }


            AppUser customer31 = new AppUser();
            if (customer31 == null)
            {
                customer31 = new AppUser();
                //customer31.CustomerID = "9040";
                customer31.UserName = "erynrice@aoll.com";
                customer31.Email = "erynrice@aoll.com";
                customer31.LastName = "Rice";
                customer31.FirstName = "Eryn";
                customer31.MiddleInitial = "M.";
                //customer31.Birthday = new DateTime(1975, 4, 28);
                customer31.SocialSecurity = "208 - 34 - 2385";
                customer31.StreetAddress = "048 Elmside Park";
                customer31.City = "South Padre Island";
                customer31.State = "TX";
                customer31.ZipCode = "78597";
                customer31.PhoneNumber = "7303815953";
                var result = await _userManager.CreateAsync(customer31, "ricearoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer31 = _db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
            }
            if (await _userManager.IsInRoleAsync(customer31, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer31, "Customer");
            }


            AppUser customer32 = new AppUser();
            if (customer32 == null)
            {
                customer32 = new AppUser();
                //customer32.CustomerID = "9041";
                customer32.UserName = "jorge@noclue.com";
                customer32.Email = "jorge@noclue.com";
                customer32.LastName = "Rodriguez";
                customer32.FirstName = "Jorge";
                customer32.MiddleInitial = "";
                //customer32.Birthday = new DateTime(1953, 12, 8);
                customer32.SocialSecurity = "391 - 71 - 4611";
                customer32.StreetAddress = "01 Browning Pass";
                customer32.City = "Austin";
                customer32.State = "TX";
                customer32.ZipCode = "78744";
                customer32.PhoneNumber = "3677322422";
                var result = await _userManager.CreateAsync(customer32, "alaskaboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer32 = _db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
            }
            if (await _userManager.IsInRoleAsync(customer32, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer32, "Customer");
            }


            AppUser customer33 = new AppUser();
            if (customer33 == null)
            {
                customer33 = new AppUser();
                //customer33.CustomerID = "9042";
                customer33.UserName = "mrrogers@lovelyday.com";
                customer33.Email = "mrrogers@lovelyday.com";
                customer33.LastName = "Rogers";
                customer33.FirstName = "Allen";
                customer33.MiddleInitial = "B.";
                //customer33.Birthday = new DateTime(1973, 4, 22);
                customer33.SocialSecurity = "308 - 74 - 1186";
                customer33.StreetAddress = "844 Anderson Alley";
                customer33.City = "Canyon Lake";
                customer33.State = "TX";
                customer33.ZipCode = "78133";
                customer33.PhoneNumber = "3911705385";
                var result = await _userManager.CreateAsync(customer33, "bunnyhop");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer33 = _db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
            }
            if (await _userManager.IsInRoleAsync(customer33, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer33, "Customer");
            }


            AppUser customer34 = new AppUser();
            if (customer34 == null)
            {
                customer34 = new AppUser();
                //customer34.CustomerID = "9043";
                customer34.UserName = "stjean@athome.com";
                customer34.Email = "stjean@athome.com";
                customer34.LastName = "Saint - Jean";
                customer34.FirstName = "Olivier";
                customer34.MiddleInitial = "M";
                //customer34.Birthday = new DateTime(1995, 2, 19);
                customer34.SocialSecurity = "832 - 08 - 8657";
                customer34.StreetAddress = "1891 Docker Point";
                customer34.City = "Austin";
                customer34.State = "TX";
                customer34.ZipCode = "78779";
                customer34.PhoneNumber = "7351610920";
                var result = await _userManager.CreateAsync(customer34, "dustydusty");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer34 = _db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
            }
            if (await _userManager.IsInRoleAsync(customer34, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer34, "Customer");
            }


            AppUser customer35 = new AppUser();
            if (customer35 == null)
            {
                customer35 = new AppUser();
                //customer35.CustomerID = "9044";
                customer35.UserName = "saunders@pen.com";
                customer35.Email = "saunders@pen.com";
                customer35.LastName = "Saunders";
                customer35.FirstName = "Sarah";
                customer35.MiddleInitial = "J.";
                //customer35.Birthday = new DateTime(1978, 2, 19);
                customer35.SocialSecurity = "485 - 81 - 2960";
                customer35.StreetAddress = "1469 Upham Road";
                customer35.City = "Austin";
                customer35.State = "TX";
                customer35.ZipCode = "78720";
                customer35.PhoneNumber = "5269661692";
                var result = await _userManager.CreateAsync(customer35, "jrod2017");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer35 = _db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
            }
            if (await _userManager.IsInRoleAsync(customer35, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer35, "Customer");
            }


            AppUser customer36 = new AppUser();
            if (customer36 == null)
            {
                customer36 = new AppUser();
                //customer36.CustomerID = "9045";
                customer36.UserName = "willsheff@email.com";
                customer36.Email = "willsheff@email.com";
                customer36.LastName = "Sewell";
                customer36.FirstName = "William";
                customer36.MiddleInitial = "T.";
                //customer36.Birthday = new DateTime(2004, 12, 23);
                customer36.SocialSecurity = "845 - 76 - 6886";
                customer36.StreetAddress = "1672 Oak Valley Circle";
                customer36.City = "Austin";
                customer36.State = "TX";
                customer36.ZipCode = "78705";
                customer36.PhoneNumber = "1875727246";
                var result = await _userManager.CreateAsync(customer36, "martin1234");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer36 = _db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
            }
            if (await _userManager.IsInRoleAsync(customer36, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer36, "Customer");
            }


            AppUser customer37 = new AppUser();
            if (customer37 == null)
            {
                customer37 = new AppUser();
                //customer37.CustomerID = "9046";
                customer37.UserName = "sheffiled@gogle.com";
                customer37.Email = "sheffiled@gogle.com";
                customer37.LastName = "Sheffield";
                customer37.FirstName = "Martin";
                customer37.MiddleInitial = "J.";
                //customer37.Birthday = new DateTime(1960, 5, 8);
                customer37.SocialSecurity = "786 - 58 - 8427";
                customer37.StreetAddress = "816 Kennedy Place";
                customer37.City = "Round Rock";
                customer37.State = "TX";
                customer37.ZipCode = "78680";
                customer37.PhoneNumber = "1394323615";
                var result = await _userManager.CreateAsync(customer37, "penguin12");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer37 = _db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer37, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer37, "Customer");
            }


            AppUser customer38 = new AppUser();
            if (customer38 == null)
            {
                customer38 = new AppUser();
                //customer38.CustomerID = "9047";
                customer38.UserName = "johnsmith187@aoll.com";
                customer38.Email = "johnsmith187@aoll.com";
                customer38.LastName = "Smith";
                customer38.FirstName = "John";
                customer38.MiddleInitial = "A";
                //customer38.Birthday = new DateTime(1955, 6, 25);
                customer38.SocialSecurity = "833 - 36 - 3857";
                customer38.StreetAddress = "0745 Golf Road";
                customer38.City = "Austin";
                customer38.State = "TX";
                customer38.ZipCode = "78760";
                customer38.PhoneNumber = "6645937874";
                var result = await _userManager.CreateAsync(customer38, "rogerthat");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer38 = _db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
            }
            if (await _userManager.IsInRoleAsync(customer38, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer38, "Customer");
            }


            AppUser customer39 = new AppUser();
            if (customer39 == null)
            {
                customer39 = new AppUser();
                //customer39.CustomerID = "9048";
                customer39.UserName = "dustroud@mail.com";
                customer39.Email = "dustroud@mail.com";
                customer39.LastName = "Stroud";
                customer39.FirstName = "Dustin";
                customer39.MiddleInitial = "P";
                //customer39.Birthday = new DateTime(1967, 7, 26);
                customer39.SocialSecurity = "862 - 95 - 5935";
                customer39.StreetAddress = "505 Dexter Plaza";
                customer39.City = "Sweet Home";
                customer39.State = "TX";
                customer39.ZipCode = "77987";
                customer39.PhoneNumber = "6470254680";
                var result = await _userManager.CreateAsync(customer39, "smitty444");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer39 = _db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
            }
            if (await _userManager.IsInRoleAsync(customer39, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer39, "Customer");
            }


            AppUser customer40 = new AppUser();
            if (customer40 == null)
            {
                customer40 = new AppUser();
                //customer40.CustomerID = "9049";
                customer40.UserName = "estuart@anchor.net";
                customer40.Email = "estuart@anchor.net";
                customer40.LastName = "Stuart";
                customer40.FirstName = "Eric";
                customer40.MiddleInitial = "D.";
                //customer40.Birthday = new DateTime(1947, 12, 4);
                customer40.SocialSecurity = "401 - 87 - 6781";
                customer40.StreetAddress = "585 Claremont Drive";
                customer40.City = "Corpus Christi";
                customer40.State = "TX";
                customer40.ZipCode = "78412";
                customer40.PhoneNumber = "7701621022";
                var result = await _userManager.CreateAsync(customer40, "stewball");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer40 = _db.Users.FirstOrDefault(u => u.UserName == "estuart@anchor.net");
            }
            if (await _userManager.IsInRoleAsync(customer40, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer40, "Customer");
            }


            AppUser customer41 = new AppUser();
            if (customer41 == null)
            {
                customer41 = new AppUser();
                //customer41.CustomerID = "9050";
                customer41.UserName = "peterstump@noclue.com";
                customer41.Email = "peterstump@noclue.com";
                customer41.LastName = "Stump";
                customer41.FirstName = "Peter";
                customer41.MiddleInitial = "L";
                //customer41.Birthday = new DateTime(1974, 7, 10);
                customer41.SocialSecurity = "414 - 55 - 9948";
                customer41.StreetAddress = "89035 Welch Circle";
                customer41.City = "Pflugerville";
                customer41.State = "TX";
                customer41.ZipCode = "78660";
                customer41.PhoneNumber = "2181960061";
                var result = await _userManager.CreateAsync(customer41, "slowwind");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer41 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
            }
            if (await _userManager.IsInRoleAsync(customer41, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer41, "Customer");
            }


            AppUser customer42 = new AppUser();
            if (customer42 == null)
            {
                customer42 = new AppUser();
                //customer42.CustomerID = "9051";
                customer42.UserName = "jtanner@mustang.net";
                customer42.Email = "jtanner@mustang.net";
                customer42.LastName = "Tanner";
                customer42.FirstName = "Jeremy";
                customer42.MiddleInitial = "S.";
                //customer42.Birthday = new DateTime(1944, 1, 11);
                customer42.SocialSecurity = "215 - 59 - 9614";
                customer42.StreetAddress = "4 Stang Trail";
                customer42.City = "Austin";
                customer42.State = "TX";
                customer42.ZipCode = "78702";
                customer42.PhoneNumber = "9908469499";
                var result = await _userManager.CreateAsync(customer42, "tanner5454");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer42 = _db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
            }
            if (await _userManager.IsInRoleAsync(customer42, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer42, "Customer");
            }


            AppUser customer43 = new AppUser();
            if (customer43 == null)
            {
                customer43 = new AppUser();
                //customer43.CustomerID = "9052";
                customer43.UserName = "taylordjay@aoll.com";
                customer43.Email = "taylordjay@aoll.com";
                customer43.LastName = "Taylor";
                customer43.FirstName = "Allison";
                customer43.MiddleInitial = "R.";
                //customer43.Birthday = new DateTime(1990, 11, 14);
                customer43.SocialSecurity = "263 - 91 - 7172";
                customer43.StreetAddress = "726 Twin Pines Avenue";
                customer43.City = "Austin";
                customer43.State = "TX";
                customer43.ZipCode = "78713";
                customer43.PhoneNumber = "7011918647";
                var result = await _userManager.CreateAsync(customer43, "allyrally");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer43 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
            }
            if (await _userManager.IsInRoleAsync(customer43, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer43, "Customer");
            }


            AppUser customer44 = new AppUser();
            if (customer44 == null)
            {
                customer44 = new AppUser();
                //customer44.CustomerID = "9053";
                customer44.UserName = "rtaylor@gogle.com";
                customer44.Email = "rtaylor@gogle.com";
                customer44.LastName = "Taylor";
                customer44.FirstName = "Rachel";
                customer44.MiddleInitial = "K.";
                //customer44.Birthday = new DateTime(1976, 1, 18);
                customer44.SocialSecurity = "774 - 06 - 1511";
                customer44.StreetAddress = "06605 Sugar Drive";
                customer44.City = "Austin";
                customer44.State = "TX";
                customer44.ZipCode = "78712";
                customer44.PhoneNumber = "8937910053";
                var result = await _userManager.CreateAsync(customer44, "taylorbaylor");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer44 = _db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer44, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer44, "Customer");
            }


            AppUser customer45 = new AppUser();
            if (customer45 == null)
            {
                customer45 = new AppUser();
                //customer45.CustomerID = "9054";
                customer45.UserName = "teefrank@noclue.com";
                customer45.Email = "teefrank@noclue.com";
                customer45.LastName = "Tee";
                customer45.FirstName = "Frank";
                customer45.MiddleInitial = "J";
                //customer45.Birthday = new DateTime(1998, 9, 6);
                customer45.SocialSecurity = "522 - 65 - 3064";
                customer45.StreetAddress = "3567 Dawn Plaza";
                customer45.City = "Austin";
                customer45.State = "TX";
                customer45.ZipCode = "78786";
                customer45.PhoneNumber = "6394568913";
                var result = await _userManager.CreateAsync(customer45, "teeoff22");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer45 = _db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
            }
            if (await _userManager.IsInRoleAsync(customer45, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer45, "Customer");
            }


            AppUser customer46 = new AppUser();
            if (customer46 == null)
            {
                customer46 = new AppUser();
                //customer46.CustomerID = "9055";
                customer46.UserName = "ctucker@alphabet.co.uk";
                customer46.Email = "ctucker@alphabet.co.uk";
                customer46.LastName = "Tucker";
                customer46.FirstName = "Clent";
                customer46.MiddleInitial = "J";
                //customer46.Birthday = new DateTime(1943, 2, 25);
                customer46.SocialSecurity = "876 - 29 - 4912";
                customer46.StreetAddress = "704 Northland Alley";
                customer46.City = "San Antonio";
                customer46.State = "TX";
                customer46.ZipCode = "78279";
                customer46.PhoneNumber = "2676838676";
                var result = await _userManager.CreateAsync(customer46, "tucksack1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer46 = _db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
            }
            if (await _userManager.IsInRoleAsync(customer46, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer46, "Customer");
            }


            AppUser customer47 = new AppUser();
            if (customer47 == null)
            {
                customer47 = new AppUser();
                //customer47.CustomerID = "9056";
                customer47.UserName = "avelasco@yoho.com";
                customer47.Email = "avelasco@yoho.com";
                customer47.LastName = "Velasco";
                customer47.FirstName = "Allen";
                customer47.MiddleInitial = "G";
                //customer47.Birthday = new DateTime(1985, 9, 10);
                customer47.SocialSecurity = "216 - 67 - 9243";
                customer47.StreetAddress = "72 Harbort Point";
                customer47.City = "Navasota";
                customer47.State = "TX";
                customer47.ZipCode = "77868";
                customer47.PhoneNumber = "3452909754";
                var result = await _userManager.CreateAsync(customer47, "meow88");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer47 = _db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
            }
            if (await _userManager.IsInRoleAsync(customer47, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer47, "Customer");
            }


            AppUser customer48 = new AppUser();
            if (customer48 == null)
            {
                customer48 = new AppUser();
                //customer48.CustomerID = "9057";
                customer48.UserName = "vinovino@grapes.com";
                customer48.Email = "vinovino@grapes.com";
                customer48.LastName = "Vino";
                customer48.FirstName = "Janet";
                customer48.MiddleInitial = "E";
                //customer48.Birthday = new DateTime(1985, 2, 7);
                customer48.SocialSecurity = "565 - 57 - 4107";
                customer48.StreetAddress = "1 Oak Valley Place";
                customer48.City = "Boston";
                customer48.State = "MA";
                customer48.ZipCode = "02114";
                customer48.PhoneNumber = "8567089194";
                var result = await _userManager.CreateAsync(customer48, "vinovino");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer48 = _db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
            }
            if (await _userManager.IsInRoleAsync(customer48, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer48, "Customer");
            }


            AppUser customer49 = new AppUser();
            if (customer49 == null)
            {
                customer49 = new AppUser();
                //customer49.CustomerID = "9058";
                customer49.UserName = "westj@pioneer.net";
                customer49.Email = "westj@pioneer.net";
                customer49.LastName = "West";
                customer49.FirstName = "Jake";
                customer49.MiddleInitial = "T";
                //customer49.Birthday = new DateTime(1976, 1, 9);
                customer49.SocialSecurity = "390 - 37 - 6155";
                customer49.StreetAddress = "48743 Banding Parkway";
                customer49.City = "Marble Falls";
                customer49.State = "TX";
                customer49.ZipCode = "78654";
                customer49.PhoneNumber = "6260784394";
                var result = await _userManager.CreateAsync(customer49, "gowest");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer49 = _db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
            }
            if (await _userManager.IsInRoleAsync(customer49, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer49, "Customer");
            }


            AppUser customer50 = new AppUser();
            if (customer50 == null)
            {
                customer50 = new AppUser();
                //customer50.CustomerID = "9059";
                customer50.UserName = "winner@hootmail.com";
                customer50.Email = "winner@hootmail.com";
                customer50.LastName = "Winthorpe";
                customer50.FirstName = "Louis";
                customer50.MiddleInitial = "L";
                //customer50.Birthday = new DateTime(1953, 4, 19);
                customer50.SocialSecurity = "445 - 77 - 2754";
                customer50.StreetAddress = "96850 Summit Crossing";
                customer50.City = "Austin";
                customer50.State = "TX";
                customer50.ZipCode = "78730";
                customer50.PhoneNumber = "3733971174";
                var result = await _userManager.CreateAsync(customer50, "louielouie");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer50 = _db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
            }
            if (await _userManager.IsInRoleAsync(customer50, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer50, "Customer");
            }


            AppUser customer51 = new AppUser();
            if (customer51 == null)
            {
                customer51 = new AppUser();
                //customer51.CustomerID = "9060";
                customer51.UserName = "rwood@voyager.net";
                customer51.Email = "rwood@voyager.net";
                customer51.LastName = "Wood";
                customer51.FirstName = "Reagan";
                customer51.MiddleInitial = "B.";
                //customer51.Birthday = new DateTime(2002, 12, 28);
                customer51.SocialSecurity = "805 - 38 - 7710";
                customer51.StreetAddress = "18354 Bluejay Street";
                customer51.City = "Austin";
                customer51.State = "TX";
                customer51.ZipCode = "78712";
                customer51.PhoneNumber = "8433359800";
                var result = await _userManager.CreateAsync(customer51, "woodyman1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer51 = _db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
            }
            if (await _userManager.IsInRoleAsync(customer51, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer51, "Customer");
            }




            //now employees
            //TODO: Add Employees


            AppUser employee1 = new AppUser();
            if (employee1 == null)
            {
                employee1 = new AppUser();
                employee1.UserName = "s.barnes@bevosbooks.com";
                employee1.Email = "s.barnes@bevosbooks.com";
                employee1.LastName = "Barnes";
                employee1.FirstName = "Susan";
                employee1.MiddleInitial = "M";
                employee1.SocialSecurity = "1112221212";
                employee1.StreetAddress = "888 S.Main";
                employee1.City = "Kyle";
                employee1.State = "TX";
                employee1.ZipCode = "78640";
                employee1.PhoneNumber = "9636389416";


                var result = await _userManager.CreateAsync(employee1, "smitty");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee1 = _db.Users.FirstOrDefault(u => u.UserName == "s.barnes@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee1, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee1, "Employee");
            }


            AppUser employee2 = new AppUser();
            if (employee2 == null)
            {
                employee2 = new AppUser();
                employee2.UserName = "h.garcia@bevosbooks.com";
                employee2.Email = "h.garcia@bevosbooks.com";
                employee2.LastName = "Garcia";
                employee2.FirstName = "Hector";
                employee2.MiddleInitial = "W";
                employee2.SocialSecurity = "4445554343";
                employee2.StreetAddress = "777 PBR Drive";
                employee2.City = "Austin";
                employee2.State = "TX";
                employee2.ZipCode = "78712";
                employee2.PhoneNumber = "4547135738";
                var result = await _userManager.CreateAsync(employee2, "squirrel");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee2 = _db.Users.FirstOrDefault(u => u.UserName == "h.garcia@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee2, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee2, "Employee");
            }


            AppUser employee3 = new AppUser();
            if (employee3 == null)
            {
                employee3 = new AppUser();
                employee3.UserName = "b.ingram@bevosbooks.com";
                employee3.Email = "b.ingram@bevosbooks.com";
                employee3.LastName = "Ingram";
                employee3.FirstName = "Brad";
                employee3.MiddleInitial = "S";
                employee3.SocialSecurity = "797348821";
                employee3.StreetAddress = "6548 La Posada Ct.";
                employee3.City = "Austin";
                employee3.State = "TX";
                employee3.ZipCode = "78705";
                employee3.PhoneNumber = "5817343315";
                var result = await _userManager.CreateAsync(employee3, "changalang");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee3 = _db.Users.FirstOrDefault(u => u.UserName == "b.ingram@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee3, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee3, "Employee");
            }


            AppUser employee4 = new AppUser();
            if (employee4 == null)
            {
                employee4 = new AppUser();
                employee4.UserName = "j.jackson@bevosbooks.com";
                employee4.Email = "j.jackson@bevosbooks.com";
                employee4.LastName = "Jackson";
                employee4.FirstName = "Jack";
                employee4.MiddleInitial = "J";
                employee4.SocialSecurity = "8889993434";
                employee4.StreetAddress = "222 Main";
                employee4.City = "Austin";
                employee4.State = "TX";
                employee4.ZipCode = "78760";
                employee4.PhoneNumber = "8241915317";
                var result = await _userManager.CreateAsync(employee4, "rhythm");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee4 = _db.Users.FirstOrDefault(u => u.UserName == "j.jackson@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee4, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee4, "Employee");
            }


            AppUser employee5 = new AppUser();
            if (employee5 == null)
            {
                employee5 = new AppUser();
                employee5.UserName = "t.jacobs@bevosbooks.com";
                employee5.Email = "t.jacobs@bevosbooks.com";
                employee5.LastName = "Jacobs";
                employee5.FirstName = "Todd";
                employee5.MiddleInitial = "L";
                employee5.SocialSecurity = "341553365";
                employee5.StreetAddress = "4564 Elm St.";
                employee5.City = "Georgetown";
                employee5.State = "TX";
                employee5.ZipCode = "78628";
                employee5.PhoneNumber = "2477822475";
                var result = await _userManager.CreateAsync(employee5, "approval");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee5 = _db.Users.FirstOrDefault(u => u.UserName == "t.jacobs@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee5, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee5, "Employee");
            }


            AppUser employee6 = new AppUser();
            if (employee6 == null)
            {
                employee6 = new AppUser();
                employee6.UserName = "l.jones@bevosbooks.com";
                employee6.Email = "l.jones@bevosbooks.com";
                employee6.LastName = "Jones";
                employee6.FirstName = "Lester";
                employee6.MiddleInitial = "L";
                employee6.SocialSecurity = "9099099999";
                employee6.StreetAddress = "999 LeBlat";
                employee6.City = "Austin";
                employee6.State = "TX";
                employee6.ZipCode = "78747";
                employee6.PhoneNumber = "4764966462";
                var result = await _userManager.CreateAsync(employee6, "society");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee6 = _db.Users.FirstOrDefault(u => u.UserName == "l.jones@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee6, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee6, "Employee");
            }


            AppUser employee7 = new AppUser();
            if (employee7 == null)
            {
                employee7 = new AppUser();
                employee7.UserName = "b.larson@bevosbooks.com";
                employee7.Email = "b.larson@bevosbooks.com";
                employee7.LastName = "Larson";
                employee7.FirstName = "Bill";
                employee7.MiddleInitial = "B";
                employee7.SocialSecurity = "5554443333";
                employee7.StreetAddress = "1212 N.First Ave";
                employee7.City = "Round Rock";
                employee7.State = "TX";
                employee7.ZipCode = "78665";
                employee7.PhoneNumber = "3355258855";
                var result = await _userManager.CreateAsync(employee7, "tanman");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee7 = _db.Users.FirstOrDefault(u => u.UserName == "b.larson@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee7, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee7, "Employee");
            }


            AppUser employee8 = new AppUser();
            if (employee8 == null)
            {
                employee8 = new AppUser();
                employee8.UserName = "v.lawrence@bevosbooks.com";
                employee8.Email = "v.lawrence@bevosbooks.com";
                employee8.LastName = "Lawrence";
                employee8.FirstName = "Victoria";
                employee8.MiddleInitial = "Y";
                employee8.SocialSecurity = "770097399";
                employee8.StreetAddress = "6639 Bookworm Ln.";
                employee8.City = "Austin";
                employee8.State = "TX";
                employee8.ZipCode = "78712";
                employee8.PhoneNumber = "7511273054";
                var result = await _userManager.CreateAsync(employee8, "longhorns");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee8 = _db.Users.FirstOrDefault(u => u.UserName == "v.lawrence@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee8, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee8, "Employee");
            }


            AppUser employee9 = new AppUser();
            if (employee9 == null)
            {
                employee9 = new AppUser();
                employee9.UserName = "m.lopez@bevosbooks.com";
                employee9.Email = "m.lopez@bevosbooks.com";
                employee9.LastName = "Lopez";
                employee9.FirstName = "Marshall";
                employee9.MiddleInitial = "T";
                employee9.SocialSecurity = "2223332222";
                employee9.StreetAddress = "90 SW North St";
                employee9.City = "Austin";
                employee9.State = "TX";
                employee9.ZipCode = "78729";
                employee9.PhoneNumber = "7477907070";
                var result = await _userManager.CreateAsync(employee9, "swansong");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee9 = _db.Users.FirstOrDefault(u => u.UserName == "m.lopez@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee9, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee9, "Employee");
            }


            AppUser employee10 = new AppUser();
            if (employee10 == null)
            {
                employee10 = new AppUser();
                employee10.UserName = "j.macleod@bevosbooks.com";
                employee10.Email = "j.macleod@bevosbooks.com";
                employee10.LastName = "MacLeod";
                employee10.FirstName = "Jennifer";
                employee10.MiddleInitial = "D";
                employee10.SocialSecurity = "775908138";
                employee10.StreetAddress = "2504 Far West Blvd.";
                employee10.City = "Austin";
                employee10.State = "TX";
                employee10.ZipCode = "78705";
                employee10.PhoneNumber = "2621216845";
                var result = await _userManager.CreateAsync(employee10, "fungus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee10 = _db.Users.FirstOrDefault(u => u.UserName == "j.macleod@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee10, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee10, "Employee");
            }


            AppUser employee11 = new AppUser();
            if (employee11 == null)
            {
                employee11 = new AppUser();
                employee11.UserName = "e.markham@bevosbooks.com";
                employee11.Email = "e.markham@bevosbooks.com";
                employee11.LastName = "Markham";
                employee11.FirstName = "Elizabeth";
                employee11.MiddleInitial = "K";
                employee11.SocialSecurity = "101529845";
                employee11.StreetAddress = "7861 Chevy Chase";
                employee11.City = "Austin";
                employee11.State = "TX";
                employee11.ZipCode = "78785";
                employee11.PhoneNumber = "5028075807";
                var result = await _userManager.CreateAsync(employee11, "median");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee11 = _db.Users.FirstOrDefault(u => u.UserName == "e.markham@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee11, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee11, "Employee");
            }


            AppUser employee12 = new AppUser();
            if (employee12 == null)
            {
                employee12 = new AppUser();
                employee12.UserName = "g.martinez@bevosbooks.com";
                employee12.Email = "g.martinez@bevosbooks.com";
                employee12.LastName = "Martinez";
                employee12.FirstName = "Gregory";
                employee12.MiddleInitial = "R";
                employee12.SocialSecurity = "463566718";
                employee12.StreetAddress = "8295 Sunset Blvd.";
                employee12.City = "Austin";
                employee12.State = "TX";
                employee12.ZipCode = "78712";
                employee12.PhoneNumber = "1994708542";
                var result = await _userManager.CreateAsync(employee12, "decorate");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee12 = _db.Users.FirstOrDefault(u => u.UserName == "g.martinez@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee12, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee12, "Employee");
            }


            AppUser employee13 = new AppUser();
            if (employee13 == null)
            {
                employee13 = new AppUser();
                employee13.UserName = "j.mason@bevosbooks.com";
                employee13.Email = "j.mason@bevosbooks.com";
                employee13.LastName = "Mason";
                employee13.FirstName = "Jack";
                employee13.MiddleInitial = "L";
                employee13.SocialSecurity = "1112223232";
                employee13.StreetAddress = "444 45th St";
                employee13.City = "Austin";
                employee13.State = "TX";
                employee13.ZipCode = "78701";
                employee13.PhoneNumber = "1748136441";
                var result = await _userManager.CreateAsync(employee13, "rankmary");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee13 = _db.Users.FirstOrDefault(u => u.UserName == "j.mason@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee13, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee13, "Employee");
            }


            AppUser employee14 = new AppUser();
            if (employee14 == null)
            {
                employee14 = new AppUser();
                employee14.UserName = "c.miller@bevosbooks.com";
                employee14.Email = "c.miller@bevosbooks.com";
                employee14.LastName = "Miller";
                employee14.FirstName = "Charles";
                employee14.MiddleInitial = "R";
                employee14.SocialSecurity = "353308615";
                employee14.StreetAddress = "8962 Main St.";
                employee14.City = "Austin";
                employee14.State = "TX";
                employee14.ZipCode = "78709";
                employee14.PhoneNumber = "8999319585";
                var result = await _userManager.CreateAsync(employee14, "kindly");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee14 = _db.Users.FirstOrDefault(u => u.UserName == "c.miller@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee14, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee14, "Employee");
            }


            AppUser employee15 = new AppUser();
            if (employee15 == null)
            {
                employee15 = new AppUser();
                employee15.UserName = "m.nguyen@bevosbooks.com";
                employee15.Email = "m.nguyen@bevosbooks.com";
                employee15.LastName = "Nguyen";
                employee15.FirstName = "Mary";
                employee15.MiddleInitial = "J";
                employee15.SocialSecurity = "7776665555";
                employee15.StreetAddress = "465 N.Bear Cub";
                employee15.City = "Austin";
                employee15.State = "TX";
                employee15.ZipCode = "78734";
                employee15.PhoneNumber = "8716746381";
                var result = await _userManager.CreateAsync(employee15, "ricearoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee15 = _db.Users.FirstOrDefault(u => u.UserName == "m.nguyen@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee15, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee15, "Employee");
            }


            AppUser employee16 = new AppUser();
            if (employee16 == null)
            {
                employee16 = new AppUser();
                employee16.UserName = "s.rankin@bevosbooks.com";
                employee16.Email = "s.rankin@bevosbooks.com";
                employee16.LastName = "Rankin";
                employee16.FirstName = "Suzie";
                employee16.MiddleInitial = "R";
                employee16.SocialSecurity = "1911919111";
                employee16.StreetAddress = "23 Dewey Road";
                employee16.City = "Austin";
                employee16.State = "TX";
                employee16.ZipCode = "78712";
                employee16.PhoneNumber = "5239029525";
                var result = await _userManager.CreateAsync(employee16, "walkamile");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee16 = _db.Users.FirstOrDefault(u => u.UserName == "s.rankin@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee16, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee16, "Employee");
            }


            AppUser employee17 = new AppUser();
            if (employee17 == null)
            {
                employee17 = new AppUser();
                employee17.UserName = "m.rhodes@bevosbooks.com";
                employee17.Email = "m.rhodes@bevosbooks.com";
                employee17.LastName = "Rhodes";
                employee17.FirstName = "Megan";
                employee17.MiddleInitial = "C";
                employee17.SocialSecurity = "353904746";
                employee17.StreetAddress = "4587 Enfield Rd.";
                employee17.City = "Austin";
                employee17.State = "TX";
                employee17.ZipCode = "78729";
                employee17.PhoneNumber = "1232139514";
                var result = await _userManager.CreateAsync(employee17, "ingram45");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee17 = _db.Users.FirstOrDefault(u => u.UserName == "m.rhodes@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee17, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee17, "Employee");
            }


            AppUser employee18 = new AppUser();
            if (employee18 == null)
            {
                employee18 = new AppUser();
                employee18.UserName = "s.saunders@bevosbooks.com";
                employee18.Email = "s.saunders@bevosbooks.com";
                employee18.LastName = "Saunders";
                employee18.FirstName = "Sarah";
                employee18.MiddleInitial = "M";
                employee18.SocialSecurity = "500987810";
                employee18.StreetAddress = "332 Avenue C";
                employee18.City = "Austin";
                employee18.State = "TX";
                employee18.ZipCode = "78733";
                employee18.PhoneNumber = "9036349587";
                var result = await _userManager.CreateAsync(employee18, "nostalgic");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee18 = _db.Users.FirstOrDefault(u => u.UserName == "s.saunders@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee18, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee18, "Employee");
            }


            AppUser employee19 = new AppUser();
            if (employee19 == null)
            {
                employee19 = new AppUser();
                employee19.UserName = "m.sheffield@bevosbooks.com";
                employee19.Email = "m.sheffield@bevosbooks.com";
                employee19.LastName = "Sheffield";
                employee19.FirstName = "Martin";
                employee19.MiddleInitial = "J";
                employee19.SocialSecurity = "223449167";
                employee19.StreetAddress = "3886 Avenue A";
                employee19.City = "San Marcos";
                employee19.State = "TX";
                employee19.ZipCode = "78666";
                employee19.PhoneNumber = "9349192978";
                var result = await _userManager.CreateAsync(employee19, "evanescent");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee19 = _db.Users.FirstOrDefault(u => u.UserName == "m.sheffield@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee19, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee19, "Employee");
            }


            AppUser employee20 = new AppUser();
            if (employee20 == null)
            {
                employee20 = new AppUser();
                employee20.UserName = "c.silva@bevosbooks.com";
                employee20.Email = "c.silva@bevosbooks.com";
                employee20.LastName = "Silva";
                employee20.FirstName = "Cindy";
                employee20.MiddleInitial = "S";
                employee20.SocialSecurity = "7776661111";
                employee20.StreetAddress = "900 4th St";
                employee20.City = "Austin";
                employee20.State = "TX";
                employee20.ZipCode = "78758";
                employee20.PhoneNumber = "4874328170";
                var result = await _userManager.CreateAsync(employee20, "stewboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee20 = _db.Users.FirstOrDefault(u => u.UserName == "c.silva@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee20, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee20, "Employee");
            }


            AppUser employee21 = new AppUser();
            if (employee21 == null)
            {
                employee21 = new AppUser();
                employee21.UserName = "e.stuart@bevosbooks.com";
                employee21.Email = "e.stuart@bevosbooks.com";
                employee21.LastName = "Stuart";
                employee21.FirstName = "Eric";
                employee21.MiddleInitial = "F";
                employee21.SocialSecurity = "363998335";
                employee21.StreetAddress = "5576 Toro Ring";
                employee21.City = "Austin";
                employee21.State = "TX";
                employee21.ZipCode = "78758";
                employee21.PhoneNumber = "1967846827";
                var result = await _userManager.CreateAsync(employee21, "instrument");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee21 = _db.Users.FirstOrDefault(u => u.UserName == "e.stuart@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee21, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee21, "Employee");
            }


            AppUser employee22 = new AppUser();
            if (employee22 == null)
            {
                employee22 = new AppUser();
                employee22.UserName = "j.tanner@bevosbooks.com";
                employee22.Email = "j.tanner@bevosbooks.com";
                employee22.LastName = "Tanner";
                employee22.FirstName = "Jeremy";
                employee22.MiddleInitial = "S";
                employee22.SocialSecurity = "904440929";
                employee22.StreetAddress = "4347 Almstead";
                employee22.City = "Austin";
                employee22.State = "TX";
                employee22.ZipCode = "78712";
                employee22.PhoneNumber = "5923026779";
                var result = await _userManager.CreateAsync(employee22, "hecktour");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee22 = _db.Users.FirstOrDefault(u => u.UserName == "j.tanner@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee22, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee22, "Employee");
            }


            AppUser employee23 = new AppUser();
            if (employee23 == null)
            {
                employee23 = new AppUser();
                employee23.UserName = "a.taylor@bevosbooks.com";
                employee23.Email = "a.taylor@bevosbooks.com";
                employee23.LastName = "Taylor";
                employee23.FirstName = "Allison";
                employee23.MiddleInitial = "R";
                employee23.SocialSecurity = "934778452";
                employee23.StreetAddress = "467 Nueces St.";
                employee23.City = "Austin";
                employee23.State = "TX";
                employee23.ZipCode = "78727";
                employee23.PhoneNumber = "7246195827";
                var result = await _userManager.CreateAsync(employee23, "countryrhodes");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee23 = _db.Users.FirstOrDefault(u => u.UserName == "a.taylor@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee23, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee23, "Employee");
            }

            //save changes
            _db.SaveChanges();
        }

    }
}