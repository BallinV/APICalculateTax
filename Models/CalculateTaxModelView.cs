using APICalculateTax.DAL;
using System.Data.SqlClient;
using System.Data;

namespace APICalculateTax.Models
{
    public class CalculateTaxModelView
    {
        public CalculateTaxModelView()
        {

        }

        public ResponseData GetTaxAmount(PostData postData)
        {
            try
            {
                DataAccessLayerClass DB = new(postData.Connection);

                List<SqlParameter> spList = new List<SqlParameter>()
                {
                    new SqlParameter("TaxType", postData.Item.TaxType),
                    new SqlParameter("AnnualIncome", postData.Item.AnnualIncome)
                };

                ResponseData res = DB.GetSP("spCalculateTax", spList);

                res.ResultData.ResponseValue = FillResponseValue(res.RawDataSet);
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

        private static decimal FillResponseValue(DataSet rawDataSet)
        {
            decimal resVal = 0;
            foreach (DataTable tb in rawDataSet.Tables)
            {
                foreach (DataRow row in tb.Rows)
                {
                    resVal = row.Field<decimal>(0);
                }
            }
            return resVal;
        }
    }
}
