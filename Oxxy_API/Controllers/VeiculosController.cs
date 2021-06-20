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

    public class VeiculosController : ApiController
    {
        OxxyDbEntities dados = new OxxyDbEntities();

        public IEnumerable<Veiculos> GetAll()
        {
            return dados.Veiculos.ToList();
        }
        public Veiculos GetById(int id)
        {
            return dados.Veiculos.FirstOrDefault(x => x.id == id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                dados.Veiculos.Remove(GetById(id));
                dados.SaveChanges();

            }
            catch(Exception ex)
            {
                
            }
        }
        [HttpPost]
        public void Post(Veiculos veiculo)
        {
            try
            {
                dados.Veiculos.Add(veiculo);
                dados.SaveChanges();
            }
            catch (Exception ex)
            {
               
            }
        }

        [HttpPut]
        public void Put(Veiculos veiculo)
        {
            try
            {
                dados.Veiculos.AddOrUpdate(veiculo);
                dados.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
