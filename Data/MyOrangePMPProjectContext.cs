using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Models;

namespace myorange_pmproject.Data
{
    public class MyOrangePMPProjectContext : DbContext
    {
        public MyOrangePMPProjectContext (DbContextOptions<MyOrangePMPProjectContext> options)
            : base(options)
        {
        }

        public DbSet<myorange_pmproject.Models.Manager> Manager { get; set; } = default!;
      
        public DbSet<myorange_pmproject.Models.Menu> Menu { get; set; } = default!;
    
       
        public DbSet<myorange_pmproject.Models.Menu_ruler> Menu_ruler { get; set; } = default!;
  
 
        public DbSet<myorange_pmproject.Models.User_need> User_need { get; set; } = default!;

  

        public DbSet<myorange_pmproject.Models.User_authorize_code> User_authorize_code { get; set; } = default!;

        public DbSet<myorange_pmproject.Models.User> User { get; set; } = default!;
        


        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<News>()
                .Property(b => b.Title)
                .IsRequired();
        
             */
            /*
      
            */ 

        } 

    }

}
