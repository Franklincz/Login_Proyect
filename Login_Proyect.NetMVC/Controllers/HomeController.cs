using Login_Proyect.NetMVC.Helper;
using Login_Proyect.NetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Proyect.NetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReclutamientoUsuariosDBContext context;



        public HomeController(ReclutamientoUsuariosDBContext _context)
        {
            context = _context;
        }






       








        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [BindProperty]
      public   Usuario Usuario { get; set; }
        [HttpPost]
        public async Task<IActionResult> Registrar()
        {
            var result = await context.Usuario.Where(x => x.Nombre == Usuario.Nombre).SingleOrDefaultAsync();
            if (result != null)
            {

                return BadRequest(new JObject(){


                    {"StatusCode",400},
                     {"Message","El usuario ya existe , seleccione otro"}

                });

            }
            else
            {
                if (!ModelState.IsValid)
                {
                   
                    
                    


                    
                    
                    //del modelo estate hago un select many y selecciono todos los errores para que me los muestre en una lista , y esto la va a hacer en el basrequest
                    return BadRequest(ModelState.SelectMany(x=>x.Value.Errors.Select(y=>y.ErrorMessage)).ToList());
                }
                else
                {
                    // hasheo de clave
                    var hash = HashHelper.Hash(Usuario.Clave);
                    
                    
                    Usuario.Clave=hash.Password;
                    Usuario.Sal = hash.Salt;

                    //add el usuario

                    context.Usuario.Add(Usuario);
                   await  context.SaveChangesAsync();
                    Usuario.Sal = "";
                    return Created($"/Usuario/{Usuario.Id}", Usuario);
                }

            }


        }




        public IActionResult Login()
        {

            return View();

        } 





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
