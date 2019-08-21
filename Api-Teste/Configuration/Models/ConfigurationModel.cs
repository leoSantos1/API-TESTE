using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Configuration.Models
{
    public class ConfigurationModel
    {
        [DisplayName("E-mail de anexo")]
        public string Email { get; set; }
        [DisplayName("Texto do email")]
        public string TextoEmail { get; set; }
        [DisplayName("Idade para integração")]
        public int IdadeIntegracao { get; set; }
        [DisplayName("Idade para envio de email de integração")]
        public int IdadeEmail { get; set; }
    }
}