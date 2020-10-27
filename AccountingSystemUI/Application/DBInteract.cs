using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;

namespace AccountingSystemUI.Application
{
    public class DBInteract : IDBInteract
    {
        public bool IsDBExist(string dbName)
        {
            var cString = $"data source=(Local)\\SQLEXPRESS;initial catalog={dbName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            using (SqlConnection cnn = new SqlConnection(cString))
            {
                try
                {
                    cnn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool SetAccessRights(string dbName)
        {
            var cString = $"data source=(Local)\\SQLEXPRESS;initial catalog={dbName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection cnn = new SqlConnection(cString))
            {
                string createRuleStr = $"USE [{dbName}] CREATE USER[BUILTIN\\Users] FOR LOGIN[BUILTIN\\Users]"
                                               + "ALTER ROLE[db_datareader] ADD MEMBER[BUILTIN\\Users] "
                                               + "ALTER ROLE[db_datawriter] ADD MEMBER[BUILTIN\\Users]";
                try
                {
                    SqlCommand cmdCreateRule = new SqlCommand(createRuleStr, cnn);
                    cnn.Open();
                    cmdCreateRule.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }

}
