using LIB.Models.DBModels;
using LIB.Models.Agreement;
using LIB.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB.BL.Repository
{
    public class AgreementRequest : IAgreementRequest
    {
        private AgreementManagementEntities _db = null;
        public AgreementRequest(AgreementManagementEntities context = null)
        {
            if (context == null)
                _db = new AgreementManagementEntities();
            else
                _db = context;
        }

        //public ErrorMessage Get(SearchModel model)
        //{
        //    //if (string.IsNullOrWhiteSpace(model))
        //    //    model = null;

        //    //return _db.GetAgreementList(Name).ToList();
        //    var Data = new AgreementListViewModel();

        //    Data.DataList = _db.GetAgreementList(
        //        pageNumber: model.PageNumber,
        //        pageSize: model.PageSize,
        //        sortColumn: model.SortColumn,
        //        sortOrder: model.SortOrder,
        //        productNumber: model.ProductNumber,
        //        groupCode: model.GroupCode,
        //        userName: string.IsNullOrEmpty(model.@UserName) ? "" : model.@UserName.Trim()
        //        ).ToList();

        //    var totalCount = 0;
        //    if (Data.DataList.Any())
        //        totalCount = (int)Data.DataList[0].TotalCount;
        //    Data.Pagination.TotalPages = (int)Math.Ceiling((totalCount * 1.00) / model.PageSize);
        //    Data.Pagination.CurrentPage = model.PageNumber;
        //    Data.Pagination.FirstRecord = (Data.DataList.FirstOrDefault() == null ? 0 : (int)Data.DataList.FirstOrDefault().RowNo);
        //    Data.Pagination.LastRecord = (Data.DataList.LastOrDefault() == null ? 0 : (int)Data.DataList.LastOrDefault().RowNo);
        //    Data.Pagination.TotalRecord = totalCount;
        //    Data.Pagination.SortColumn = model.SortColumn;
        //    Data.Pagination.SortOrder = model.SortOrder;
        //    return new ErrorMessage { Status = 0, Data = Data };
        //}

        //public ErrorMessage Get(SearchModel model)
        //{
        //    //if (string.IsNullOrWhiteSpace(model))
        //    //    model = null;

        //    //return _db.GetAgreementList(Name).ToList();
        //    var Data = new AgreementListViewModel();

        //    Data.DataList = _db.GetAgreementList(
        //        pageNumber: model.PageNumber,
        //        pageSize: model.PageSize,
        //        sortColumn: model.SortColumn,
        //        sortOrder: model.SortOrder,
        //        productNumber: model.ProductNumber,
        //        groupCode: model.GroupCode,
        //        userName: string.IsNullOrEmpty(model.@UserName) ? "" : model.@UserName.Trim()
        //        ).ToList();

        //    var totalCount = 0;
        //    if (Data.DataList.Any())
        //        totalCount = (int)Data.DataList[0].TotalCount;
        //    Data.Pagination.TotalPages = (int)Math.Ceiling((totalCount * 1.00) / model.PageSize);
        //    Data.Pagination.CurrentPage = model.PageNumber;
        //    Data.Pagination.FirstRecord = (Data.DataList.FirstOrDefault() == null ? 0 : (int)Data.DataList.FirstOrDefault().RowNo);
        //    Data.Pagination.LastRecord = (Data.DataList.LastOrDefault() == null ? 0 : (int)Data.DataList.LastOrDefault().RowNo);
        //    Data.Pagination.TotalRecord = totalCount;
        //    Data.Pagination.SortColumn = model.SortColumn;
        //    Data.Pagination.SortOrder = model.SortOrder;
        //    return new ErrorMessage { Status = 0, Data = Data };
        //}

        public ErrorMessage Get_old(SearchModel model)
        {
            //if (string.IsNullOrWhiteSpace(model))
            //    model = null;

            //return _db.GetAgreementList(Name).ToList();
            var Data = new AgreementListsViewModel();

            Data.DataList = _db.GetAgreementList(
                pageNumber: model.PageNumber,
                pageSize: model.PageSize,
                sortColumn: model.SortColumn,
                sortOrder: model.SortOrder,
                productNumber: model.ProductNumber,
                groupCode: model.GroupCode,
                userName: string.IsNullOrEmpty(model.@UserName) ? "" : model.@UserName.Trim(),
                userId: model.UserId
                ).ToList();

            var totalCount = 0;
            if (Data.DataList.Any())
                totalCount = (int)Data.DataList[0].TotalCount;
            //Data.Pagination.TotalPages = (int)Math.Ceiling((totalCount * 1.00) / model.PageSize);
            //Data.Pagination.CurrentPage = model.PageNumber;
            //Data.Pagination.FirstRecord = (Data.DataList.FirstOrDefault() == null ? 0 : (int)Data.DataList.FirstOrDefault().RowNo);
            //Data.Pagination.LastRecord = (Data.DataList.LastOrDefault() == null ? 0 : (int)Data.DataList.LastOrDefault().RowNo);
            //Data.Pagination.TotalRecord = totalCount;
            //Data.Pagination.SortColumn = model.SortColumn;
            //Data.Pagination.SortOrder = model.SortOrder;
            return new ErrorMessage { Status = 0, Data = Data };
        }
        public List<GetAgreementList_Result> Get(SearchModel model)
        {
            // List<GetAgreementList_Result> DataList = new List<GetAgreementList_Result>();
            //if (string.IsNullOrWhiteSpace(model))
            //    model = null;

            //return _db.GetAgreementList(Name).ToList();
            // var Data = new AgreementListViewModel();

            var DataList = _db.GetAgreementList(
                pageNumber: model.PageNumber,
                pageSize: model.PageSize,
                sortColumn: model.SortColumn,
                sortOrder: model.SortOrder,
                productNumber: model.ProductNumber,
                groupCode: model.GroupCode,
                userName: string.IsNullOrEmpty(model.@UserName) ? "" : model.@UserName.Trim(),
                userId: model.UserId
                ).ToList();

            //var totalCount = 0;
            //if (Data.DataList.Any())
            //    totalCount = (int)Data.DataList[0].TotalCount;
            //Data.Pagination.TotalPages = (int)Math.Ceiling((totalCount * 1.00) / model.PageSize);
            //Data.Pagination.CurrentPage = model.PageNumber;
            //Data.Pagination.FirstRecord = (Data.DataList.FirstOrDefault() == null ? 0 : (int)Data.DataList.FirstOrDefault().RowNo);
            //Data.Pagination.LastRecord = (Data.DataList.LastOrDefault() == null ? 0 : (int)Data.DataList.LastOrDefault().RowNo);
            //Data.Pagination.TotalRecord = totalCount;
            //Data.Pagination.SortColumn = model.SortColumn;
            //Data.Pagination.SortOrder = model.SortOrder;
            return DataList;
        }
        public ErrorMessage Detail(long? id)
        {
            var _Detail = new AgreementBindingModel();

            _Detail.GroupList = new List<Group>();
            _Detail.ProductList = new List<Product>();
            _Detail.GroupList = GetProductGroupLists();

            if (id.HasValue)
            {
                var dataResult = _db.GetAgreementDetail(id).FirstOrDefault();
                if (dataResult != null)
                {
                    _Detail.Id = dataResult.Id;
                    _Detail.UserId = dataResult.UserId;
                    _Detail.ProductGroupId = dataResult.ProductGroupId;
                    _Detail.ProductId = dataResult.ProductId;
                    _Detail.EffectiveDate = dataResult.EffectiveDate;
                    _Detail.ExpirationDate = dataResult.ExpirationDate;
                    _Detail.ProductPrice = dataResult.ProductPrice;
                    _Detail.NewPrice = dataResult.NewPrice;
                    _Detail.Active = dataResult.Active == null ? false : true;
                    _Detail.ProductList = GetProductList(_Detail.ProductGroupId);
                }
            }
            //if (_Detail.ProductGroupId != null)
            //    _Detail.ProductList = _db.ProductMasters.Where(a => a.ProductGroupId == _Detail.ProductGroupId).ToList();

            return new ErrorMessage { Status = 0, Data = _Detail };
        }
        public List<Group> GetProductGroupLists()
        {
            var Data = new List<Group>();
            var list = _db.ProductGroupMasters.ToList();
            Data = (from item in list
                    select new Group
                    {
                        Id = item.Id,
                        GroupCode = item.GroupCode,
                        GroupDescription = item.GroupDescription
                    }).OrderBy(x => x.Id).ToList();
            return Data;
        }
        public List<Product> GetProductList(long? ProductGroupId)
        {
            var Data = new List<Product>();
            var list = _db.ProductMasters.ToList();
            Data = (from item in list.Where(x => x.ProductGroupId == ProductGroupId)
                    select new Product
                    {
                        Id = item.Id,
                        ProductNumber = item.ProductNumber,
                        ProductDescription = item.ProductDescription
                    }).OrderBy(x => x.Id).ToList();
            return Data;
        }
        public ErrorMessage CreateUpdate(AgreementBindingModel model)
        {
            try
            {
                _db.Create_Update_Agreement(id: model.Id, userId: model.UserId, productGroupId: model.ProductGroupId,
                    productId: model.ProductId, effectiveDate: model.EffectiveDate, expirationDate: model.ExpirationDate,
                    productPrice: model.ProductPrice, newPrice: model.NewPrice, active: model.Active).FirstOrDefault();
            }
            catch (System.Data.DataException e)
            {
                return new ErrorMessage { Message = e.Message };
            }
            return new ErrorMessage { Status = 0, Message = "Sucess" };
        }
        public bool Delete(long? id)
        {
            var empDetail = _db.Agreements.Where(x => x.Id == id).FirstOrDefault();
            if (empDetail != null)
            {
                try
                {
                    _db.Agreements.Remove(empDetail);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
