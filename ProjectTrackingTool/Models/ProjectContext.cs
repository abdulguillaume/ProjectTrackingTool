using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;



namespace ProjectTrackingTool.Models
{
    public class ProjectContext: DbContext
    {
        public DbSet<Project> projects { get; set; }

        public DbSet<ProjectTask> tasks { get; set; }

        public DbSet<APriority> priorities { get; set; }

        public DbSet<AStatus> statuses { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<CustomerType> customer_types { get; set; }

        public DbSet<ContactType> contact_types { get; set; }

        public DbSet<ContactInfo> contact_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}