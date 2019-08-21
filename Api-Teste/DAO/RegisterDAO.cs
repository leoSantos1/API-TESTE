using CoreHelper;
using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAO
{
    public class RegisterDAO
    {
        public int Add(Register pModel)
        {
            using (var con = new SqlConnection(Help.Connectionstring()))
            {
                try
                {
                    con.Open();
                    var query = Help.ModelMapperInsertCommand(pModel);
                    return con.Execute(query, pModel);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao conectar ao banco de dados. Detalhe: {ex.Message} - Stack: {ex.StackTrace}");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Register Get(string pNome)
        {
            using (var connection = new SqlConnection(Help.Connectionstring()))
            {
                try
                {
                    connection.Open();
                    return connection.Query<Register>(Help.ModelMapperSelectCommand<Register>()).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao conectar ao banco de dados. Detalhe: {ex.Message} - Stack: {ex.StackTrace}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<Register> GetAll()
        {
            using (var connection = new SqlConnection(Help.Connectionstring()))
            {
                try
                {
                    connection.Open();
                    return connection.Query<Register>(Help.ModelMapperSelectCommand<Register>());
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao conectar ao banco de dados. Detalhe: {ex.Message} - Stack: {ex.StackTrace}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}