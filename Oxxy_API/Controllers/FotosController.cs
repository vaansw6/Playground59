using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OxxyDataAccess;

namespace Oxxy_API.Controllers
{

    public class FotosController : ApiController
    {
        OxxyDbEntities dados = new OxxyDbEntities();
        public IEnumerable<Fotos> GetAll()
        {
            return dados.Fotos.ToList();
        }
        public Fotos GetById(int id)
        {
            return dados.Fotos.FirstOrDefault(x => x.id == id);
        }
        [HttpPost]
        public bool Delete(int id)
        {
            
            try
            {
                dados.Fotos.Remove(GetById(id));
                return (true);
            }
            catch(Exception ex)
            {
                return (false);
            }
        }
        [HttpPost]
        public bool Create(Fotos foto)
        {
            try
            {
                dados.Fotos.AddOrUpdate(foto);
                return (true);
            }
            catch (Exception ex)
            {
                return (false);
            }
        }
    }
}
