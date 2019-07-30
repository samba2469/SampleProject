﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Regestation : DbContext
    {
        public Regestation()
            : base("name=Regestation")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblRegistration> tblRegistrations { get; set; }
    
        public virtual ObjectResult<RegistarAll_Result> RegistarAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RegistarAll_Result>("RegistarAll");
        }
    
        public virtual int Registration_Insert(Nullable<int> id, string fullname, string email, Nullable<long> phoneNo, string username, string password, string gender)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var fullnameParameter = fullname != null ?
                new ObjectParameter("Fullname", fullname) :
                new ObjectParameter("Fullname", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneNoParameter = phoneNo.HasValue ?
                new ObjectParameter("PhoneNo", phoneNo) :
                new ObjectParameter("PhoneNo", typeof(long));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Registration_Insert", idParameter, fullnameParameter, emailParameter, phoneNoParameter, usernameParameter, passwordParameter, genderParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> checklogin(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("checklogin", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CheckuniqueEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CheckuniqueEmail", emailParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UniQue_Phno(Nullable<long> phoneNo)
        {
            var phoneNoParameter = phoneNo.HasValue ?
                new ObjectParameter("PhoneNo", phoneNo) :
                new ObjectParameter("PhoneNo", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UniQue_Phno", phoneNoParameter);
        }
    }
}
