using System.Diagnostics.CodeAnalysis;

namespace APICalculateTax.DAL
{
    public class UserTaxItem
    {
        public UserTaxItem()
        {
            UserTaxID = 0;
            PostalCode = "";
            TaxType = "";
            AnnualIncome = 0;
            TaxAmount = 0;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            isDeleted = 1;
        }

        public int UserTaxID { get; set; }
        [AllowNull]
        public string PostalCode { get; set; }
        [AllowNull]
        public string TaxType { get; set; }

        public decimal AnnualIncome { get; set; }

        public decimal TaxAmount { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
        [AllowNull]
        public int isDeleted { get; set; }


    }
}
