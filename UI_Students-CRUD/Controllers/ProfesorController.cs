using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace UI_Students_CRUD.Controllers
{
    public class ProfesorController : Controller
    {
        // Puente Con DB y UI:
        private readonly ProfesorBL _ProfesorBL;

        // Constructor:
        public ProfesorController(ProfesorBL profesorBL)
        {
            _ProfesorBL = profesorBL;
        }

        // Manda Todos Los Registros De La Tabla:
        public async Task<ActionResult> Index()
        {
            List<Profesor> Objetos_Obtenidos = await _ProfesorBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            Profesor Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(new Profesor() { Id_Profesor = id });

            return View(Objeto_Obtenido);
        }

        // Manda Un ViewData Con Una Lista De Rol
        public async Task<ActionResult> Create()
        {
            List<Rol> Lista_Roles = await _ProfesorBL.Lista_Roles();
            ViewData["Lista_Roles"] = new SelectList(Lista_Roles, "Id_Rol", "Nombre");

            return View();
        }

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Profesor profesor,IFormFile Fotografia)
        {
            // Convirtiendo a Arreglo De Bytes:
            if(Fotografia!=null && Fotografia.Length>0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    profesor.Fotografia = memoryStream.ToArray();
                }
            }
            await _ProfesorBL.Create(profesor);
            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla
        public async Task<ActionResult> Edit(int id)
        {
            Profesor Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(new Profesor() { Id_Profesor = id });
            
            List<Rol> Lista_Roles = await _ProfesorBL.Lista_Roles();
            ViewData["Lista_Roles"] = new SelectList(Lista_Roles, "Id_Rol", "Nombre",Objeto_Obtenido.IdRolEnProfesor);

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Profesor profesor, IFormFile Fotografia)
        {
            // Busco El Objeto Ya Existente Que Ahora Se Modificara:
            Profesor Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(profesor);

            // Convirtiendo a Arreglo De Bytes:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    profesor.Fotografia = memoryStream.ToArray();
                }
            }
            else
            {
                profesor.Fotografia = Objeto_Obtenido.Fotografia;
            }

            await _ProfesorBL.Edit(profesor);

            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Delete(int id)
        {
            Profesor Objeto_Obtenido = await _ProfesorBL.Obtener_PorId(new Profesor() { Id_Profesor = id });

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Se Le Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Profesor profesor)
        {
            await _ProfesorBL.Delete(profesor);

            return RedirectToAction(nameof(Index));
        }
    }
}
