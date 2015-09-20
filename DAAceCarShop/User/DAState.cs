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
    public class DAState
    {
        public List<UsState> getStateAll() 
        {
            OracleConnection connection = null;
            OracleDataReader dr = null;
            List<UsState> list = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_STATE_GETALL", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (dr = command.ExecuteReader())
                        {
                            list = new List<UsState>();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(
                                        new UsState()
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
