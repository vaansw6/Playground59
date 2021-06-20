using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxxy_Teste.ViewModels
{
    public class FotosVM
    {
        public int id { get; set; }
        public int idVeiculo { get; set; }
        public string descricao { get; set; }
        public byte[] imagem { get; set; }
    }
}