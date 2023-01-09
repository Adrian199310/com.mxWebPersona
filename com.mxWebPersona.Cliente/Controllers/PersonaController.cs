using com.mxWebPersona.Cliente.Models.Response;
using com.mxWebPersona.Cliente.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace com.mxWebPersona.Cliente.Controllers
{

    public class PersonaController : Controller
    {

        private readonly IServicioApi _servicioApi;

        public PersonaController(IServicioApi servicioApi)
        {
            _servicioApi= servicioApi;
        }
        public IActionResult Index()
        {
            List<Persona> listpersona;

            var personas = _servicioApi.GetListPersonas();

            if (personas.code)
            {
               var arrayperson = personas.personas.ToList();
                listpersona =arrayperson;
                return View("Lista",listpersona);
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Persona personaResponse)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _servicioApi.CreatePersona(personaResponse);
                if (respuesta.code)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }

        public IActionResult Editar(int idPersona)
        {
            if (idPersona !=0)
            {
                var persona_encontrada = _servicioApi.getPersona(idPersona);
                if (persona_encontrada.code)
                {
                    return View(persona_encontrada.personas[0]);
                }
            }
           
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public IActionResult Editar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _servicioApi.UpdatePersona(persona);
                if (respuesta.code)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        public IActionResult Eliminar(int idPersona)
        {
            if (idPersona != 0)
            {
                var persona_encontrada = _servicioApi.DeletePersona(idPersona);
                if (persona_encontrada)
                {
                    RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
        
    }
}
