using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB.Models.DBModels;
using LIB.Models.Agreement;

namespace LIB.BL.Interface
{
    public interface IAgreementRequest
    {
        ErrorMessage Get_old(SearchModel model);
        List<GetAgreementList_Result> Get(SearchModel model);

        ErrorMessage Detail(long? id);

        ErrorMessage CreateUpdate(AgreementBindingModel model);

        bool Delete(long? id);

        List<Product> GetProductList(long? GroupId);

    }
}
