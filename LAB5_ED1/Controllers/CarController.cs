using CsvHelper;
using LAB5_ED1.Árbol2_3;
using LAB5_ED1.Helpers;
using LAB5_ED1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO;


namespace LAB5_ED1.Controllers
{
    public class CarController : Controller
    {
        // GET: CarController
        public ActionResult Index()
        {
            return View(Singleton.Instance.carList);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Busqueda()
        {
            return View(new CarModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Busqueda(IFormCollection collection)
        {
            try
            {
                
                int parametro = (int.Parse(collection["Placa"]));
                CarModel carro_a_buscar = new CarModel();
                carro_a_buscar.Placa = parametro;

                
                return View(Singleton.Instance.carList.buscarNodo_porPlaca(carro_a_buscar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BusquedaA()
        {
            //formulario para busquedas
            return View(new CarModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BusquedaA(IFormCollection collection)
        {
            try
            {


                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CarModel.Guardar(new CarModel
                {
                    Placa = int.Parse(collection["Placa"]),
                    Color = collection["Color"],
                    Propietario = collection["Propietario"],
                    Latitud = int.Parse(collection["Latitud"]),
                    Longitud = int.Parse(collection["Longitud"]),

                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //leer csv
        [HttpGet]
        public IActionResult Index(Arbol2_3<CarModel> clients = null)
        {
            clients = clients == null ? new Arbol2_3<CarModel>() : clients;
            return View(Singleton.Instance.carList);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            // Upload CSV 
            string fileName = $"{ hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            //

            var clients = this.GetClientList(file.FileName);
            return Index(clients);
        }

        private Arbol2_3<CarModel> GetClientList(string fileName)
        {
            Arbol2_3<CarModel> client = new Arbol2_3<CarModel>(); //modificado aqui tambien 

            // Read CSV
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var clients = csv.GetRecord<CarModel>(); //modificado aqui

                    Singleton.Instance.carList.InsertarEnArbol(clients);

                }
            }

            return client;

        }
    }
}