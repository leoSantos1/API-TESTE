using DAO;
using Model;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    public class Register
    {
        RegisterDAO DAO;
        public Register()
        {
            DAO = new RegisterDAO();
        }

        public long Add(Model.Register pModel)
        {
            var config = new ConfigurationDAO().Get();
            if (config != null && config.IdadeIntegracao < pModel.Idade)
            {
                int id = DAO.Add(pModel);
                SendMail(pModel, config);
                return id;
            }
            throw new System.Exception("Erro ao cadastrar registro, verifique as configurações.");
        }

        public Model.Register Edit(Model.Register pModel)
        {
            return new Model.Register();
        }

        public Model.Register Get(string pNome)
        {
            return DAO.Get(pNome);
        }

        public IEnumerable<Model.Register> GetAll()
        {
            return DAO.GetAll();
        }

        private void SendMail(Model.Register pModel, Model.Configuration pConfig)
        {
            if (pConfig.IdadeEmail < pModel.Idade)
            {
                CoreHelper.EmailHandler.EnviarEmail(new CoreHelper.EmailHandler.EmailModel()
                {
                    Destinatario = new string[] { pModel.Email, pConfig.Email },
                    Assunto = "Registro",
                    Mensagem = ReplaceText(pConfig.TextoEmail, pModel),
                });
            }
        }

        private string ReplaceText(string pText, Model.Register pModel)
        {
            string newText = pText;
            string[] tags = new string[] { "{nome}", "{idade}", "{telefone}", "{email}" };

            if (!string.IsNullOrEmpty(pModel.Nome))
                newText = newText.Replace(tags[0], pModel.Nome);
            if (pModel.Idade > 0)
                newText = newText.Replace(tags[1], pModel.Idade.ToString());
            if (!string.IsNullOrEmpty(pModel.Telefone))
                newText = newText.Replace(tags[2], pModel.Telefone);
            if (!string.IsNullOrEmpty(pModel.Email))
                newText = newText.Replace(tags[3], pModel.Email);
            return newText;
        }
    }
}
