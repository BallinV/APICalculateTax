using APICalculateTax.DAL;
using APICalculateTax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICalculateTax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteUserTaxItemController : ControllerBase
    {
        [HttpPost]
        public ResponseData Post([FromBody] PostData postItem)
        {
            ResponseData deleteUserResponse = new ResponseData();

            DeleteUserTaxItemModelView deleteUserTaxItem = new DeleteUserTaxItemModelView();

            deleteUserResponse = deleteUserTaxItem.DeleteUserItem(postItem);


            return deleteUserResponse;


        }
    }
}
