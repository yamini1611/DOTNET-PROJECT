﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOTNET_PROJECT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DOTNETEntities : DbContext
    {
        public DOTNETEntities()
            : base("name=DOTNETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<Meat> Meats { get; set; }
        public virtual DbSet<packedfood> packedfoods { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<todayoffer> todayoffers { get; set; }
        public virtual DbSet<Vegetable> Vegetables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    
        public virtual ObjectResult<Validate_User_Result> Validate_User(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Validate_User_Result>("Validate_User", usernameParameter, passwordParameter);
        }
    
        
    }
}