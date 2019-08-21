using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Configuration
    {
        ConfigurationDAO DAO;
        public Configuration()
        {
            DAO = new ConfigurationDAO();
        }

        public int Add(Model.Configuration pModel)
        {
            return DAO.Add(pModel);
        }
        public void Update(Model.Configuration pModel)
        {
            DAO.Update(pModel);
        }

        public Model.Configuration Get()
        {
            return DAO.Get();
        }
    }
}
