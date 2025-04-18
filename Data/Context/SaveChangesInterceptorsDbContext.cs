using Microsoft.EntityFrameworkCore;
using Save_Changes_interceptors.Data.Entities;
using Save_Changes_interceptors.Data.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_Changes_interceptors.Data.Context
{
    public class SaveChangesInterceptorsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string 
            optionsBuilder.UseSqlServer(" Server=. ; Database=SaveChangesOverride; Integrated Security=true; Encrypt= false "); 
            optionsBuilder.AddInterceptors( new OverridingSaveChangeInterceptors() ); 
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaveChangesInterceptorsDbContext).Assembly);
            

            foreach( var ForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany( 
                e => e.GetForeignKeys() )  ){
                ForeignKey.DeleteBehavior = DeleteBehavior.Cascade; 
            }
            
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Blog> blogs { get; set; }
        public DbSet<Post> posts { get; set; }

    }
}
