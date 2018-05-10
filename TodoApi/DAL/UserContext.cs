using System.Data.Entity;

namespace AADx.TodoApi.DAL
{
    public class UserContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UserContext() : base("name=UserContext")
        {
        }

        public System.Data.Entity.DbSet<AADx.Common.Models.UserProfile> UserProfiles { get; set; }
    }
}
