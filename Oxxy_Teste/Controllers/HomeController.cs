using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oxxy_API.Controllers;
using OxxyDataAccess;
using Oxxy_Teste.Services;
using RestSharp;
using Oxxy_Teste.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace Oxxy_Teste.Controllers
{
    public class HomeController : Controller
    {
        private static readonly DataService dataService;
        static HomeController()
        {
            dataService = new DataService();
        }

        public ActionResult Index()
        {
            var listaVeiculos = dataService.GetVeiculosAsync(); 
            return View(listaVeiculos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Update(int id)
        {
            var listaProp = new VeiculosVM();
            listaProp = dataService.GetVeiculosByIdAsync(id);
            listaProp.ListaProprietarios = dataService.GetProprietariosAsync();
            return View(listaProp);
        }

        [HttpPost]
        public async Task<ActionResult> Update(VeiculosVM veiculo)
        {
            try
            {
                await dataService.UpdateVeiculoAsync(veiculo);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }

        }

        public ActionResult Create()
        {
            var listaProp = new VeiculosVM();
            listaProp.ListaProprietarios = dataService.GetProprietariosAsync();
            return View(listaProp);
        }

        [HttpPost]
        public async Task<ActionResult> Create(VeiculosVM veiculo)
        {
            var ultimo = dataService.GetVeiculosAsync().FirstOrDefault();
            try
            {
                
                if (ultimo != null)
                {
                    var ultimoId = dataService.GetVeiculosAsync().Last().id +1;
                    veiculo.id = ultimoId;
                }

                await dataService.AddVeiculoAsync(veiculo);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await dataService.DeletaVeiculoAsync(id);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}