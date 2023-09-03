using APICalculateTax.Controllers;
using APICalculateTax.DAL;
using NUnit.Framework;

namespace APICalculateTax.UnitTest
{
    public class TestDeleteUserTaxItem
    {
        public ResponseData deleteUserItemRespons = new ResponseData();
        public PostData postItem = new PostData();
        [SetUp]
        public void Setup()
        {
            DBConnection connection = new DBConnection();
            connection.ServerName = "LAPTOP-1AM23VT2";
            connection.SQLName = "SQLEXPRESS";
            connection.DatabseName = "PaySpaceTaxCalculation";

            postItem.PostID = 1;
            postItem.Connection = connection;

        }

        [Test]
        public void DeleteUserTaxItem()
        {
            DeleteUserTaxItemController runApiDeleteUserItem = new DeleteUserTaxItemController();
            deleteUserItemRespons = runApiDeleteUserItem.Post(postItem);
            //Test if Delete Passed
            Assert.IsTrue(deleteUserItemRespons.Success, deleteUserItemRespons.Message);
        }


    }
}
