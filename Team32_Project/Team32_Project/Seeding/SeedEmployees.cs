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
    public static class SeedEmployees
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