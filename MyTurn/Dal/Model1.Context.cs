﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyTurnEntities : DbContext
    {
        public MyTurnEntities()
            : base("name=MyTurnEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cancelation> Cancelations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
    }
}