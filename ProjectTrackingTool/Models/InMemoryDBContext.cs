using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;



namespace ProjectTrackingTool.Models
{
    public class InMemoryDBContext: DbContext
    {
        public DbSet<Project> projects { get; set; }

        public DbSet<ProjectTask> tasks { get; set; }

        public DbSet<TaskPriority> task_priorities { get; set; }

        public DbSet<TaskStatus> task_status { get; set; }

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