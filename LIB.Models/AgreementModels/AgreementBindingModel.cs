using LIB.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB.Models.Agreement
{
    public class AgreementBindingModel
    {
        [Key]
        public long? Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Group")]
        [Required(ErrorMessage = "The Group is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "The Group is required.")]
        public long? ProductGroupId { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "The Product is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "The Product is required.")]
        public long? ProductId { get; set; }

        [Display(Name = "Effective Date")]
        [Required(ErrorMessage = "The Effective Date is required.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EffectiveDate { get; set; }

        [Display(Name = "Expiration Date")]
        [Required(ErrorMessage = "The Expiration Date is required.")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "The Product Price is required.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Please enter number.")]
        public decimal? ProductPrice { get; set; }

        [Display(Name = "New Price")]
        [Required(ErrorMessage = "The New Price is required.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Please enter number.")]
        public decimal? NewPrice { get; set; }
        public bool Active { get; set; }

        public List<Group> GroupList { get; set; }

        public List<Product> ProductList { get; set; }

    }

    public class Group
    {
        public long Id { get; set; }
        public string GroupCode { get; set; }
        public string GroupDescription { get; set; }
    }

    public class Product
    {
        public long Id { get; set; }
        public string ProductNumber { get; set; }
        public string ProductDescription { get; set; }
    } 

    public class SearchModel
    {
        public string ProductNumber { get; set; }
        public string GroupCode { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortColumn { get; set; } = "Id";
        public string SortOrder { get; set; } = "DESC";
    }
    public class AgreementListViewModel
    {
        public AgreementListViewModel()
        {
            Pagination = new PaginationModel();
        }
        public List<GetAgreementList_Result> DataList { get; set; }
        public PaginationModel Pagination { get; set; }
    }

    public class AgreementListsViewModel
    {
        public List<GetAgreementList_Result> DataList { get; set; }
    }

    public class DataTablesParam
    {
        public int iDispalyStart { get; set; }
        public int iDispalyLenght { get; set; }
        public int iColumns { get; set; }
        public int isSearch { get; set; }
        public int bEscapeRegex { get; set; }
        public int iSortingCols { get; set; }
        public int isEcho { get; set; }
        public List<string> sColumnNames { get; set; }
        public List<bool> bSortable { get; set; }
        public List<bool> sSearchable { get; set; }
        public List<bool> sSearchValues { get; set; }
        public List<bool> iSortCol { get; set; }
        public List<bool> sSortDir { get; set; }
        public List<bool> bEscapeRegexColumns { get; set; }

        public DataTablesParam()
        {
            sColumnNames = new List<string>();
            bSortable = new List<bool>();
            sColumnNames = new List<string>();
            sColumnNames = new List<string>();
            sColumnNames = new List<string>();
            sColumnNames = new List<string>();
            sColumnNames = new List<string>();
        }

    }


    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; } = 0;
        public int FirstRecord { get; set; }
        public int LastRecord { get; set; }
        public int TotalRecord { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
    }

    public class ErrorMessage
    {
        public string Message { get; set; }
        public int Status { get; set; } = 1;//0=success,1=fail,warning=2,3=record already exist,4=record not found,151=ticket reopen,201=no view permission.....//Extra status use more than 100
        public object Data { get; set; }
    }
}
