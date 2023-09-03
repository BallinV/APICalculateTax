using APICalculateTax.DAL;
using System.Data.SqlClient;

namespace APICalculateTax.Models
{
    public class AddUserTaxItemModelView
    {
        public AddUserTaxItemModelView()
        {

        }

        public ResponseData AddUserItem(DBConnection connection, UserTaxItem item)
        {

            DataAccessLayerClass DB = new(connection);

            List<SqlParameter> spList = new List<SqlParameter>()
            {
                new SqlParameter("PostalCode", item.PostalCode),
                new SqlParameter("TaxType", item.TaxType),
                new SqlParameter("AnnualIncome", item.AnnualIncome),
                new SqlParameter("TaxAmount", item.TaxAmount)
            };

            ResponseData res = DB.RunSP("spAddUserTaxList", spList);
            return res;

        }
    }
}
