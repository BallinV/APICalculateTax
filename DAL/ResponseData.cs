
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace APICalculateTax.DAL
{

    public class ResponseData
    {

        public ResponseData()
        {
            ResultData = new ResultData();
            RawDataSet = new DataSet();
        }

        [AllowNull]
        public string Message { get; set; }
        [AllowNull]
        public bool Success { get; set; }
        public ResultData ResultData { get; set; }
        public DataSet RawDataSet { get; set; }

          
    }
}
