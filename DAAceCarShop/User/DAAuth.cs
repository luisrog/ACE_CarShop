using EAceCarShop.User;
using Helper;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAAceCarShop.User
{
    public class DAAuth
    {
        public UsAuth getAuthForIdUser(string email, string passwd) 
        {
            OracleConnection connection = null;
            OracleDataReader dr = null;
            UsAuth auth = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_AUTH_GETFOR_USER", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        command.Parameters.Add("EMAIL", email);
                        command.Parameters.Add("PASWD", passwd);

                        using (dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                auth = new UsAuth()
                                {
                                    IdUser = Convert.ToInt32(dr["IDUSER"].ToString()),
                                    Email = dr["EMAIL"].ToString(),
                                    FirstName = dr["FIRSTNAME"].ToString(),
                                    LastName = dr["LASTNAME"].ToString(),
                                    Role = new UsRole() 
                                    { 
                                        Id = Convert.ToInt32(dr["IDROLE"].ToString()),
                                        Name = dr["NAMEROLE"].ToString()
                                    },
                                    Photo = dr["PHOTO"].ToString(),
                                    ListRoleModule = new DARoleModule().getRoleModuleForRole(Convert.ToInt32(dr["IDROLE"].ToString())),
                                    ListRoleModulePrivilege = new DARoleModulePrivilege().getRoleModulePrivilegeForRole(Convert.ToInt32(dr["IDROLE"].ToString()))
                                };
                            }
                        }
                    }
                }

                return auth;

            }
            catch (Exception e)
            {
                dr.Dispose();

                if (connection.State == ConnectionState.Open)
                    connection.Dispose();

                LogHelper.WriteLog(e);
                throw e;
            }
            finally
            {
                auth = null;
            }
        }
    }
}
