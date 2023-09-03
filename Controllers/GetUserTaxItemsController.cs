using APICalculateTax.DAL;
using APICalculateTax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APICalculateTax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserTaxItemsController : ControllerBase
    {
        
        [HttpPost]
        public ResponseData Post([FromBody] PostData postItem)
        {

            GetUserTaxItemsModelView getTaxList = new GetUserTaxItemsModelView();

            ResponseData getTaxListResponse = new ResponseData();

            getTaxListResponse = getTaxList.GetUserItems(postItem.Connection);

            return getTaxListResponse;
        }
    }
}
