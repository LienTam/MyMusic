using MyMusic.Models;
using System.Data.Entity;
namespace MyMusic.Context
{
    public class ModelContext :DbContext
    {       
        
        public  DbSet<Genre> Genres { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public  DbSet<GroupRoles> GroupRoles { get; set; }
        public DbSet<Image> Images { get; set; }
        public  DbSet<Singer> Singers { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<Post> Posts { get; set; }
        public  DbSet<Comment> Comments { get; set; }   
        public  DbSet<Likes> Likes { get; set; }        
        
        public  DbSet<Share> Shares { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Map<Manager>(m => m.Requires("Dtype").HasValue("Manager"))
                .Map<Member>(m => m.Requires("Dtype").HasValue("Member"));
            
            modelBuilder.Entity<Manager>()
                .Map<Admin>(m => m.Requires("Dtype").HasValue("Admin"))
                .Map<Editor>(m => m.Requires("Dtype").HasValue("Editor"));
            modelBuilder.Entity<Post>()
                .Map<Audio>(m => m.Requires("Dtype").HasValue("Audio"))
                .Map<Video>(m => m.Requires("Dtype").HasValue("Video"));
            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Favorite> Favorite { get; set; }
    }
}