using System;
using System.IO;
using System.Net.Mail;

namespace CoreHelper
{
    public class EmailHandler
    {
        public static void EnviarEmail(EmailModel pEnvio)
        {
            string nomeRemetente = System.Configuration.ConfigurationManager.AppSettings["SenderName"].ToString();
            string emailRemetente = System.Configuration.ConfigurationManager.AppSettings["SenderAddress"].ToString();
            string senha = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString();
            string SMTP = System.Configuration.ConfigurationManager.AppSettings["Host"].ToString();

            var objEmail = new MailMessage();
            try
            {
                objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");
                foreach (var email in pEnvio.Destinatario)
                {
                    if (!string.IsNullOrEmpty(email))
                        objEmail.To.Add(email);
                }
                objEmail.Priority = MailPriority.Normal;
                if (pEnvio.ArquivoAnexo != null)
                {
                    var att = new Attachment(new MemoryStream(pEnvio.ArquivoAnexo), pEnvio.NomeArquivoAnexo);
                    objEmail.Attachments.Add(att);
                }
                objEmail.IsBodyHtml = true;
                objEmail.Subject = pEnvio.Assunto;
                objEmail.Body = pEnvio.Mensagem;

                objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                var objSmtp = new SmtpClient();
                objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
                objSmtp.Host = SMTP;
                objSmtp.Port = 587;
                objSmtp.Send(objEmail);
            }
            finally
            {
                objEmail.Dispose();
            }
        }

        #region STRUCT
        public struct EmailModel
        {
            public string[] Destinatario { get; set; }
            public string Assunto { get; set; }
            public string Mensagem { get; set; }
            public byte[] ArquivoAnexo { get; set; }
            public string NomeArquivoAnexo { get; set; }
        }
        #endregion
    }
}
