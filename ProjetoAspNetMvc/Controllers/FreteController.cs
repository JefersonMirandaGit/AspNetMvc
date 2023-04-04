using Newtonsoft.Json;
using ProjetoAspNetMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAspNetMvc.Controllers
{
    public class FreteController : Controller
    {
        // GET: Frete
        public async Task<Frete> GetAsyncAll(string rota)
        {

            var tokenApi = ObterToken();
            var client = new HttpClient();

            client.BaseAddress = new Uri(_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenApi.Result.Token);
            HttpResponseMessage response = await client.GetAsync(rota);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return new Frete { Sucesso = true, Retorno = JsonConvert.DeserializeObject<Frete>(json) };
            }
            else
            {
                return new ModeloFrete { Sucesso = false, Retorno = null };
            }



            return View();
        }

        // GET: Frete/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Frete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Frete/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Frete/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Frete/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Frete/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Frete/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
