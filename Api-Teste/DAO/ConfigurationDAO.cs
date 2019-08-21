using CoreHelper;
using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConfigurationDAO
    {
        public int Add(Configuration pModel)
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

        public void Update(Configuration pModel)
        {
            using (var con = new SqlConnection(Help.Connectionstring()))
            {
                try
                {
                    con.Open();
                    var query = Help.ModelMapperUpdateCommand(pModel);
                    con.Execute(query, pModel);
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

        public Configuration Get()
        {
            using (var connection = new SqlConnection(Help.Connectionstring()))
            {
                try
                {
                    connection.Open();
                    return connection.Query<Configuration>(Help.ModelMapperSelectCommand<Configuration>()).FirstOrDefault();
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
