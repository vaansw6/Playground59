using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxxy_Teste.ViewModels
{
    public class VeiculosVM
    {
        public int id { get; set; }
        public int idProprietario { get; set; }
        public string placa { get; set; }
        public string renavam { get; set; }
        public string cpf { get; set; }
        public bool bloqueado { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase image { get; set; }
        [JsonIgnore]
        public List<ProprietariosVM> ListaProprietarios { get; set; }
    }
}