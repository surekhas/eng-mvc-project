﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eng_Part.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Eng_PartEntities : DbContext
    {
        public Eng_PartEntities()
            : base("name=Eng_PartEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOOKUPRole> LOOKUPRoles { get; set; }
        public virtual DbSet<ModulePart> ModuleParts { get; set; }
        public virtual DbSet<SYSUser> SYSUsers { get; set; }
        public virtual DbSet<SYSUserProfile> SYSUserProfiles { get; set; }
        public virtual DbSet<SYSUserRole> SYSUserRoles { get; set; }
        public virtual DbSet<File> Files { get; set; }
    }
}
