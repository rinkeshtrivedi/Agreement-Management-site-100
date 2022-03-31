﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LIB.Models.DBModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AgreementManagementEntities : DbContext
    {
        public AgreementManagementEntities()
            : base("name=AgreementManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Agreement> Agreements { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ProductGroupMaster> ProductGroupMasters { get; set; }
        public virtual DbSet<ProductMaster> ProductMasters { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> Create_Update_Agreement(Nullable<long> id, string userId, Nullable<long> productGroupId, Nullable<long> productId, Nullable<System.DateTime> effectiveDate, Nullable<System.DateTime> expirationDate, Nullable<decimal> productPrice, Nullable<decimal> newPrice, Nullable<bool> active)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var productGroupIdParameter = productGroupId.HasValue ?
                new ObjectParameter("ProductGroupId", productGroupId) :
                new ObjectParameter("ProductGroupId", typeof(long));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(long));
    
            var effectiveDateParameter = effectiveDate.HasValue ?
                new ObjectParameter("EffectiveDate", effectiveDate) :
                new ObjectParameter("EffectiveDate", typeof(System.DateTime));
    
            var expirationDateParameter = expirationDate.HasValue ?
                new ObjectParameter("ExpirationDate", expirationDate) :
                new ObjectParameter("ExpirationDate", typeof(System.DateTime));
    
            var productPriceParameter = productPrice.HasValue ?
                new ObjectParameter("ProductPrice", productPrice) :
                new ObjectParameter("ProductPrice", typeof(decimal));
    
            var newPriceParameter = newPrice.HasValue ?
                new ObjectParameter("NewPrice", newPrice) :
                new ObjectParameter("NewPrice", typeof(decimal));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("Create_Update_Agreement", idParameter, userIdParameter, productGroupIdParameter, productIdParameter, effectiveDateParameter, expirationDateParameter, productPriceParameter, newPriceParameter, activeParameter);
        }
    
        public virtual ObjectResult<GetAgreementDetail_Result> GetAgreementDetail(Nullable<long> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAgreementDetail_Result>("GetAgreementDetail", idParameter);
        }
    
        public virtual ObjectResult<GetAgreementList_Result> GetAgreementList(Nullable<int> pageNumber, Nullable<int> pageSize, string sortColumn, string sortOrder, string productNumber, string groupCode, string userName, string userId)
        {
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("PageNumber", pageNumber) :
                new ObjectParameter("PageNumber", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn != null ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(string));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            var productNumberParameter = productNumber != null ?
                new ObjectParameter("ProductNumber", productNumber) :
                new ObjectParameter("ProductNumber", typeof(string));
    
            var groupCodeParameter = groupCode != null ?
                new ObjectParameter("GroupCode", groupCode) :
                new ObjectParameter("GroupCode", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAgreementList_Result>("GetAgreementList", pageNumberParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter, productNumberParameter, groupCodeParameter, userNameParameter, userIdParameter);
        }
    }
}
