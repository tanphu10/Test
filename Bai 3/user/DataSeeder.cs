using Microsoft.AspNetCore.Identity;
using user.Entities;

namespace user
{
    public class DataSeeder
    {
        public async Task SeedAsync(TestDbContext context)
        {
            var passwordHasher = new PasswordHasher<User>();



            if (context.Users == null)
            {
                var userId = Guid.NewGuid();
                var user = new Entities.User()
                {
                    Id = userId,
                    Name = "Phu",
                    Phont = "admin@gmail.com.vn",
                    Avatar = "avatar.org",
                    Gender = true,
                    CreatedAt = DateTime.Now,
                    birthday=DateTime.Now,
                };
                user.Password = passwordHasher.HashPassword(user, "Admin@123$");
                await context.Users.AddAsync(user);

                await context.SaveChangesAsync();
            }
        }
    }
}
