using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _1911066325_HoangNhatSinh_BigSchool.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Following> Followers { get; set; }
        public ICollection<Following> Followees { get; set; }

        public ApplicationUser()
        {
            Followers = new Collection<Following>();
            Followees = new Collection<Following>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Course> Courses { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Attendance> Attendances { get; set; }
            public DbSet<Following> Followings { get; set; }
            public DbSet<FollowingNotification> FollowingNotifications { get; set; }

            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }   
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Attendance>().HasRequired(a => a.Course)
                    .WithMany()
                    .WillCascadeOnDelete(false);
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<ApplicationUser>()
                    .HasMany(u => u.Followers)
                    .WithRequired(f => f.Followee)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<ApplicationUser>()
                    .HasMany(u => u.Followees)
                    .WithRequired(f => f.Follower)
                    .WillCascadeOnDelete(false);
            }
        }
    }


}