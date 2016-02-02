using System.Data.Entity;
using WebAPI_Learning_1.Data.Users;

namespace WebAPI_Learning_1.Data
{
    public class WebAPI_Learning_1Context : DbContext
    {   
        public WebAPI_Learning_1Context() : base("name=WebAPI_Learning_1Context")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WebAPI_Learning_1Context).Assembly);
        }

        //This is here only for unit testing purposes
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbSet<User> Users { get; set; }
    }
}
