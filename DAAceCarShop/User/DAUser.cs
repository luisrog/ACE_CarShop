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
    public class DAUser
    {
        public UsUser getUserForID(int id)
        {
            OracleConnection connection = null;
            OracleDataReader dr = null;
            UsUser u = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_USER_GETFOR_ID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        command.Parameters.Add("ID", id);

                        using (dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                u = new UsUser()
                                {
                                    Id = Convert.ToInt32(dr["ID"].ToString()),
                                    Email = dr["EMAIL"].ToString(),
                                    State = new UsState()
                                    {
                                        Id = Convert.ToInt32(dr["IDSTATE"].ToString()),
                                        Name = dr["NAMESTATE"].ToString()
                                    },
                                    Role = new UsRole()
                                    {
                                        Id = Convert.ToInt32(dr["IDROLE"].ToString()),
                                        Name = dr["NAMEROLE"].ToString()
                                    },
                                    FirstName = dr["FIRSTNAME"].ToString(),
                                    LastName = dr["LASTNAME"].ToString(),
                                    Dni = dr["DNI"].ToString(),
                                    Ruc = dr["RUC"].ToString(),
                                    BirthDate = Convert.ToDateTime(dr["BIRTHDATE"].ToString()),
                                    Subscribed = dr["SUBSCRIBED"].ToString(),
                                    Photo = dr["PHOTO"].ToString(),
                                    UserCreate = dr["USERCREATE"].ToString(),
                                    DateCreate = Convert.ToDateTime(dr["DATECREATE"].ToString()),
                                    UserUpdate = dr["USERUPDATE"].ToString(),
                                    DateUpdate = Convert.ToDateTime(dr["DATEUPDATE"].ToString())
                                };
                            }
                        }
                    }
                }

                return u;

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
                u = null;
            }
        }

        public List<UsUser> getUserAll()
        {
            OracleConnection connection = null;
            OracleDataReader dr = null;
            List<UsUser> list = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_USER_GETALL", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("P_CUR_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (dr = command.ExecuteReader())
                        {
                            list = new List<UsUser>();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(
                                        new UsUser()
                                        {
                                            Id = Convert.ToInt32(dr["ID"].ToString()),
                                            Email = dr["EMAIL"].ToString(),
                                            State = new UsState()
                                            {
                                                Id = Convert.ToInt32(dr["IDSTATE"].ToString()),
                                                Name = dr["NAMESTATE"].ToString()
                                            },
                                            Role = new UsRole()
                                            {
                                                Id = Convert.ToInt32(dr["ID"].ToString()),
                                                Name = dr["NAME"].ToString()
                                            },
                                            FirstName = dr["FIRSTNAME"].ToString(),
                                            LastName = dr["LASTNAME"].ToString(),
                                            Dni = dr["DNI"].ToString(),
                                            Ruc = dr["RUC"].ToString(),
                                            BirthDate = Convert.ToDateTime(dr["BIRTHDATE"].ToString()),
                                            Subscribed = dr["SUBSCRIBED"].ToString(),
                                            Photo = dr["PHOTO"].ToString(),
                                            UserCreate = dr["USERCREATE"].ToString(),
                                            DateCreate = Convert.ToDateTime(dr["DATECREATE"].ToString()),
                                            UserUpdate = dr["USERUPDATE"].ToString(),
                                            DateUpdate = Convert.ToDateTime(dr["DATEUPDATE"].ToString())
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

        public bool insertUser(UsUser u)
        {
            OracleConnection connection = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_USER_INSERT"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("ID", u.Id);
                        command.Parameters.Add("EMAIL", u.Email);
                        command.Parameters.Add("PASSWD", u.Passwd);
                        command.Parameters.Add("IDSTATE", u.State.Id);
                        command.Parameters.Add("IDROLE", u.Role.Id);
                        command.Parameters.Add("FIRSTNAME", u.FirstName);
                        command.Parameters.Add("LASTNAME", u.LastName);
                        command.Parameters.Add("DNI", u.Dni);
                        command.Parameters.Add("RUC", u.Ruc);
                        command.Parameters.Add("BIRTHDATE", u.BirthDate);
                        command.Parameters.Add("SUBSCRIBED", u.Subscribed);
                        command.Parameters.Add("PHOTO", u.Photo);
                        command.Parameters.Add("USER_CREATE", u.UserCreate);
                        command.Parameters.Add("DATE_CREATE", u.DateCreate);
                        command.Parameters.Add("USER_UPDATE", u.UserUpdate);
                        command.Parameters.Add("DATE_UPDATE", u.DateUpdate);

                        connection.Open();

                        if (command.ExecuteNonQuery() > 0)
                            return true;

                    }
                }
            }
            catch (Exception e)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Dispose();

                LogHelper.WriteLog(e);
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return false;

        }

        public bool updateUser(UsUser u)
        {
            OracleConnection connection = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_USER_UPDATE"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("ID", u.Id);
                        command.Parameters.Add("EMAIL", u.Email);
                        command.Parameters.Add("PASSWD", u.Passwd);
                        command.Parameters.Add("IDSTATE", u.State.Id);
                        command.Parameters.Add("IDROLE", u.Role.Id);
                        command.Parameters.Add("FIRSTNAME", u.FirstName);
                        command.Parameters.Add("LASTNAME", u.LastName);
                        command.Parameters.Add("DNI", u.Dni);
                        command.Parameters.Add("RUC", u.Ruc);
                        command.Parameters.Add("BIRTHDATE", u.BirthDate);
                        command.Parameters.Add("SUBSCRIBED", u.Subscribed);
                        command.Parameters.Add("PHOTO", u.Photo);
                        command.Parameters.Add("USER_CREATE", u.UserCreate);
                        command.Parameters.Add("DATE_CREATE", u.DateCreate);
                        command.Parameters.Add("USER_UPDATE", u.UserUpdate);
                        command.Parameters.Add("DATE_UPDATE", u.DateUpdate);

                        connection.Open();

                        if (command.ExecuteNonQuery() > 0)
                            return true;

                    }
                }
            }
            catch (Exception e)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Dispose();

                LogHelper.WriteLog(e);
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return false;

        }

        public bool deleteUser(UsUser u)
        {
            OracleConnection connection = null;

            try
            {
                using (connection = new OracleConnection(OracleHelper.connectionString()))
                {
                    using (var command = new OracleCommand("US_USER_DELETE"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("ID", u.Id);

                        connection.Open();

                        if (command.ExecuteNonQuery() > 0)
                            return true;

                    }
                }
            }
            catch (Exception e)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Dispose();

                LogHelper.WriteLog(e);
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return false;

        }
    }
}
