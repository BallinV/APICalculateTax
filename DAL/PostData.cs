using System.Diagnostics.CodeAnalysis;

namespace APICalculateTax.DAL
{
    public class PostData
    {
        public PostData()
        {
            Item = new TaxItem();
            Connection = new DBConnection();
        }
        public int PostID { get; set; }
        [AllowNull]
        public TaxItem Item { get; set; }
        [AllowNull]
        public DBConnection Connection { get; set; }

    }
}
