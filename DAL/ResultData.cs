namespace APICalculateTax.DAL
{
    public class ResultData
    {
        public ResultData()
        {
            UserTaxItems = new List<UserTaxItem>();
        }

        public decimal ResponseValue { get; set; }

        public List<UserTaxItem> UserTaxItems { get; set; }

    }
}
