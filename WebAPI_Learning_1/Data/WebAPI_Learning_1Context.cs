using System.Data.Entity;

namespace WebAPI_Learning_1.Data
{
    public class WebAPI_Learning_1Context : DbContext
    {   
        public WebAPI_Learning_1Context() : base("name=WebAPI_Learning_1Context")
        {
        }

        //This is here only for unit testing purposes
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbSet<Models.User> Users { get; set; }
    }
}
