using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CoreHelper
{
    public static class Help
    {
        public static string Connectionstring()
        {
            string db = System.Configuration.ConfigurationManager.AppSettings["DBConnection"].ToString();
            if (string.IsNullOrEmpty(db))
                throw new Exception("String de conexão não informada, verifique a tag DBConnection do arquivo web.config");
            return db;
        }

        public static string ModelMapperInsertCommand<TEntity>(TEntity Instance)
        {
            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
            string select = $"INSERT INTO {Instance.GetType().Name} (";
            select += PropertiesLoop(propertyInfos, false);
            select += ") VALUES( ";
            select += PropertiesLoop(propertyInfos, true);
            select += ");";
            select += "SELECT CAST(SCOPE_IDENTITY() as INT); ";
            return select;
        }

        public static string ModelMapperUpdateCommand<TEntity>(TEntity Instance)
        {
            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
            string update = $"UPDATE {Instance.GetType().Name} SET ";

            foreach (PropertyInfo pInfo in propertyInfos)
                update += UpdatePattern(pInfo.Name);

            return update.TrimEnd(',');
        }

        private static string UpdatePattern(string pColunm)
        {
            return $" {pColunm}  = @{pColunm},";
        }

        public static string ModelMapperSelectCommand<TEntity>() where TEntity : class, new()
        {
            TEntity instance = new TEntity();
            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
            string select = "SELECT ";
            select += PropertiesLoop(propertyInfos, false);
            select += $" FROM {instance.GetType().Name}";
            return select;
        }

        private static string PropertiesLoop(PropertyInfo[] pPropertyInfos, bool pParam)
        {
            string commando = "";
            foreach (PropertyInfo pInfo in pPropertyInfos)
                commando += pParam ? $"@{pInfo.Name}," : $"{pInfo.Name},";

            return commando.TrimEnd(',');
        }
    }
}
