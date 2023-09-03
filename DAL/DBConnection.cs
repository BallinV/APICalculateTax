using System.Diagnostics.CodeAnalysis;

namespace APICalculateTax.DAL
{
    public class DBConnection
    {
        public DBConnection()
        {
            ServerName = "";
            SQLName = "";
            DatabseName = "";
            UserID = "";
            Password = "";

        }

        [AllowNull]
        public string ServerName { get; set; }
        [AllowNull]
        public string SQLName { get; set; }
        [AllowNull]
        public string DatabseName { get; set; }
        [AllowNull]
        public string UserID { get; set; }
        [AllowNull]
        public string Password { get; set; }

    }
}
