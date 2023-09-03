using APICalculateTax.DAL;
using System.Data.SqlClient;

namespace APICalculateTax.Models
{
    public class DeleteUserTaxItemModelView
    {
        public DeleteUserTaxItemModelView()
        {

        }

        public ResponseData DeleteUserItem(PostData postItem)
        {
            DataAccessLayerClass DB = new(postItem.Connection);
            List<SqlParameter> spList = new List<SqlParameter>()
            { new SqlParameter("ID", postItem.PostID) };

            ResponseData res = DB.RunSP("spDeleteUserTaxList", spList);

            return res;

        }
    }
}
