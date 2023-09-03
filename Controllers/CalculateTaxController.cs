using APICalculateTax.DAL;
using APICalculateTax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICalculateTax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateTaxController : ControllerBase
    {
        [HttpPost]
        public ResponseData Post([FromBody] PostData postItem)
        {

            ResponseData getTaxRespone = new ResponseData();

            CalculateTaxModelView calculateTax = new CalculateTaxModelView();

            getTaxRespone = calculateTax.GetTaxAmount(postItem);

            if (getTaxRespone.Success)
            {
                UserTaxItem taxItem = new UserTaxItem();
                taxItem.TaxAmount = getTaxRespone.ResultData.ResponseValue;
                taxItem.AnnualIncome = postItem.Item.AnnualIncome;
                taxItem.PostalCode = postItem.Item.PostalCode;
                taxItem.TaxType = postItem.Item.TaxType;

                AddUserTaxItemModelView addUserTaxItem = new AddUserTaxItemModelView();

                ResponseData getAddUserRespone = new ResponseData();

                getAddUserRespone = addUserTaxItem.AddUserItem(postItem.Connection, taxItem);

                if (getAddUserRespone.Success)
                {
                    GetUserTaxItemsModelView getTaxList = new GetUserTaxItemsModelView();
                    ResponseData getTaxListResponse = new ResponseData();
                    getTaxListResponse = getTaxList.GetUserItems(postItem.Connection);

                    getTaxListResponse.ResultData.ResponseValue = getTaxRespone.ResultData.ResponseValue;
                    return getTaxListResponse;
                }
                else
                {
                    return getAddUserRespone;
                }

            }
            else
            {
                return getTaxRespone;
            }

        }
    }
}
