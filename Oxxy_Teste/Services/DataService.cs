using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Oxxy_Teste.ViewModels;
using System.Linq;
using System.Web.Http.ModelBinding;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Oxxy_API.Controllers;
using OxxyDataAccess;
using Oxxy_Teste.Services;
using RestSharp;

namespace Oxxy_Teste.Services
{
    public class DataService
    {
        private static readonly HttpClient client;
        static DataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44342/api/");
        }
        public List<VeiculosVM> GetVeiculosAsync()
        {
            IEnumerable<VeiculosVM> veiculos = null;
            var responseTask = client.GetAsync("Veiculos");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<VeiculosVM>>();
                readTask.Wait();
                veiculos = readTask.Result;
            }
            else
            {
                veiculos = Enumerable.Empty<VeiculosVM>();
            }
            return veiculos.ToList();
        }

        public VeiculosVM GetVeiculosByIdAsync(int id)
        {
            VeiculosVM veiculos = null;
            var responseTask = client.GetAsync("Veiculos/"+id+"");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<VeiculosVM>();
                readTask.Wait();
                veiculos = readTask.Result;
            }
            else
            {
                veiculos = null;
            }

            return veiculos;
        }

        public async Task AddVeiculoAsync(VeiculosVM veiculo)
        {
            try
            {
                string url = "https://localhost:44342/api/Veiculos/{0}";
                var uri = new Uri(string.Format(url, veiculo.id));
                var data = JsonConvert.SerializeObject(veiculo);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir veículo");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateVeiculoAsync(VeiculosVM veiculo)
        {
            string url = "https://localhost:44342/api/Veiculos/{0}";
            var uri = new Uri(string.Format(url, veiculo.id));
            var data = JsonConvert.SerializeObject(veiculo);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar veiculo");
            }
        }

        public async Task DeletaVeiculoAsync(int id)
        {
            string url = "https://localhost:44342/api/Veiculos/{0}";
            var uri = new Uri(string.Format(url, id));
            await client.DeleteAsync(uri);
        }

        //PROPRIETARIOS

        public List<ProprietariosVM> GetProprietariosAsync()
        {
            IEnumerable<ProprietariosVM> proprietarios = null;
            var responseTask = client.GetAsync("Proprietarios");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ProprietariosVM>>();
                readTask.Wait();
                proprietarios = readTask.Result;
            }
            else
            {
                proprietarios = Enumerable.Empty<ProprietariosVM>();
            }
            return proprietarios.ToList();
        }
    }
}