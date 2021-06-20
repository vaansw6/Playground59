using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OxxyDataAccess;

namespace Oxxy_API.Controllers
{

    public class UsuariosController : ApiController
    {
        OxxyDbEntities dados = new OxxyDbEntities();
        public IEnumerable<Usuarios> GetAll()
        {
            return dados.Usuarios.ToList();
        }
        public Usuarios GetById(int id)
        {
            return dados.Usuarios.FirstOrDefault(x => x.id == id);
        }
        public bool Delete(int id)
        {
            
            try
            {
                dados.Usuarios.Remove(GetById(id));
                return (true);
            }
            catch(Exception ex)
            {
                return (false);
            }
        }
        public bool Create(Usuarios usuario)
        {
            try
            {
                dados.Usuarios.Add(usuario);
                return (true);
            }
            catch (Exception ex)
            {
                return (false);
            }
        }
    }
}
