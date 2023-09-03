using APICalculateTax.Controllers;
using APICalculateTax.DAL;
using NUnit.Framework;
namespace APICalculateTax.UnitTest
{
    public class TestCalculateTax
    {
        public ResponseData calculateUserTaxRespons = new ResponseData();
        public PostData postItem = new PostData();
        [SetUp]
        public void Setup()
        {
            DBConnection connection = new DBConnection();
            connection.ServerName = "LAPTOP-1AM23VT2";
            connection.SQLName = "SQLEXPRESS";
            connection.DatabseName = "PaySpaceTaxCalculation";

            //7441    Progressive 
            //A100    Flat Value  
            //7000    Flat Rate  
            //1000    Progressive

            TaxItem testTax = new TaxItem();
            testTax.TaxType = "Progressive";
            testTax.PostalCode = "1000";
            testTax.AnnualIncome = 402350000;

            postItem.Item = testTax;
            postItem.Connection = connection;

        }

        [Test]
        public void CalculateTaxItemPass()
        {

            CalculateTaxController runApiCalculateTaxItem = new CalculateTaxController();
            calculateUserTaxRespons = runApiCalculateTaxItem.Post(postItem);

            Assert.IsTrue(calculateUserTaxRespons.Success, calculateUserTaxRespons.Message);
        }

        [Test]
        public void HasTaxItemPass()
        {
            Assert.Greater(calculateUserTaxRespons.ResultData.ResponseValue, 0, "No Tax Calculated value returned");
        }

        [Test]
        public void UserListListCount()
        {
            Assert.Greater(calculateUserTaxRespons.ResultData.UserTaxItems.Count, 0, "List is not empty");
        }
    }
}
