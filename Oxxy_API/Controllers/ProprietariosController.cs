using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OxxyDataAccess;

namespace Oxxy_API.Controllers
{

    public class ProprietariosController : ApiController
    {
        OxxyDbEntities dados = new OxxyDbEntities();
        public IEnumerable<Proprietarios> GetAll()
        {
            return dados.Proprietarios.ToList();
        }
        public Proprietarios GetById(int id)
        {
            return dados.Proprietarios.FirstOrDefault(x => x.id == id);
        }
        public bool Delete(int id)
        {
            
            try
            {
                dados.Proprietarios.Remove(GetById(id));
                return (true);
            }
            catch(Exception ex)
            {
                return (false);
            }
        }
        public bool Create(Proprietarios proprietario)
        {
            try
            {
                dados.Proprietarios.Add(proprietario);
                return (true);
            }
            catch (Exception ex)
            {
                return (false);
            }
        }
    }
}
