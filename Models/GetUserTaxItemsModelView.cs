using APICalculateTax.DAL;
using System.Data.SqlClient;
using System.Data;

namespace APICalculateTax.Models
{
    public class GetUserTaxItemsModelView
    {
        public GetUserTaxItemsModelView()
        {

        }

        public ResponseData GetUserItems(DBConnection connection)
        {
            try
            {
                DataAccessLayerClass DB = new(connection);
                ResponseData res = DB.GetSP("spGetUserTaxList", new List<SqlParameter>());
                List<UserTaxItem> getList = FillTaxItems(res.RawDataSet);
                if (getList.Count > 0)
                {
                    res.ResultData.UserTaxItems.AddRange(getList);
                }
                else
                {
                    UserTaxItem taxItem = new UserTaxItem();
                    res.ResultData.UserTaxItems.Add(taxItem);
                }

                return res;
            }
            catch (Exception ex)
            {
                ResponseData res = new ResponseData();
                res.Success = false;
                res.Message = ex.Message;
                return res;
            }

        }

        private List<UserTaxItem> FillTaxItems(DataSet rawDataSet)
        {
            List<UserTaxItem> items = new List<UserTaxItem>();

            foreach (DataTable tb in rawDataSet.Tables)
            {
                foreach (DataRow row in tb.Rows)
                {
                    UserTaxItem taxItem = new UserTaxItem();
                    taxItem.UserTaxID = row.Field<int>("UserTaxID");
                    taxItem.PostalCode = row.Field<string>("PostalCode");
                    taxItem.TaxType = row.Field<string>("TaxType");
                    taxItem.AnnualIncome = row.Field<decimal>("AnnualIncome");
                    taxItem.TaxAmount = row.Field<decimal>("TaxAmount");
                    taxItem.DateCreated = row.Field<DateTime>("DateCreated");
                    taxItem.DateUpdated = row.Field<DateTime>("DateUpdated");
                    taxItem.isDeleted = row.Field<int>("isDeleted");

                    items.Add(taxItem);
                }
            }


            return items;
        }
    }
}
