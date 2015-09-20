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
    public class DARoleModule
    {
        public List<UsRoleModule> getRoleModuleForRole(int idRole)
        {
            OracleConnection connection = null;
            OracleDataReader dr = null;
            List<UsRoleModule> list = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_ROLEMODULE_GETFOR_ROLE", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        command.Parameters.Add("IDROLE", idRole);

                        using (dr = command.ExecuteReader())
                        {
                            list = new List<UsRoleModule>();

                            if (dr.HasRows)
                            {
                                list.Add(
                                    new UsRoleModule()
                                    {
                                        Id = Convert.ToInt32(dr["ID"].ToString()),
                                        Role = new UsRole() 
                                        {
                                            Id = Convert.ToInt32(dr["IDROLE"].ToString()),
                                            Name = dr["NAMEROLE"].ToString()
                                        },
                                        Module = new UsModule()
                                        {
                                            Id = Convert.ToInt32(dr["IDMODULE"].ToString()),
                                            Name = dr["NAMEMODULE"].ToString()
                                        }
                                    }
                                );
                            }
                        }
                    }
                }

                return list;

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
                list = null;
            }
        }
    }
}
