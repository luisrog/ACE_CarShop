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
    public class DARole
    {
        public List<UsRole> getRoleForState(int idState)
        {
            OracleConnection connection = null;
            OracleDataReader dr = null;
            List<UsRole> list = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_ROLE_GETFOR_STATE", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        command.Parameters.Add("ID", idState);

                        using (dr = command.ExecuteReader())
                        {
                            list = new List<UsRole>();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(
                                        new UsRole()
                                        {
                                            Id = Convert.ToInt32(dr["ID"].ToString()),
                                            Name = dr["NAME"].ToString()
                                        }
                                    );
                                }
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
