﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestMasterdDBEntities : DbContext
    {
        public TestMasterdDBEntities()
            : base("name=TestMasterdDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<answer_option> answer_option { get; set; }
        public virtual DbSet<assigned_test> assigned_test { get; set; }
        public virtual DbSet<@class> classes { get; set; }
        public virtual DbSet<correct_answer> correct_answer { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<subject> subjects { get; set; }
        public virtual DbSet<teacher_subject> teacher_subject { get; set; }
        public virtual DbSet<test> tests { get; set; }
        public virtual DbSet<test_result> test_result { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
