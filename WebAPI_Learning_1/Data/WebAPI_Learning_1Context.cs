using System.Data.Entity;

namespace WebAPI_Learning_1.Data
{
    public class WebAPI_Learning_1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
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
