namespace ModelsDb
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbContextMigration : DbContext
    {
        // Your context has been configured to use a 'DbContextMigration' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ModelsDb.DbContextMigration' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContextMigration' 
        // connection string in the application configuration file.
        public DbContextMigration()
            : base("name=DbContextMigration")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}