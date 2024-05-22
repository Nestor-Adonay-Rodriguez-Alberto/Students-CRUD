using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI_Students_CRUD.Controllers
{
    public class EstudianteController : Controller
    {
        // Puente Con DB y UI:
        private readonly EstudianteBL _EstudianteBL;

        // Constructor:
        public EstudianteController(EstudianteBL estudianteBL)
        {
            _EstudianteBL = estudianteBL;
        }

        // Manda Todos Los Registros De La Tabla:
        public async Task<ActionResult> Index()
        {
            List<Estudiante> Objetos_Obtenidos = await _EstudianteBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            Estudiante Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(new Estudiante() { Id_Estudiante = id });

            return View(Objeto_Obtenido);
        }

        // Manda Un ViewData Con Una Lista De Materia
        public async Task<ActionResult> Create()
        {
            List<Materia> Lista_Materias = await _EstudianteBL.Lista_Materias();
            ViewData["Lista_Materias"] = new SelectList(Lista_Materias, "Id_Materia", "Nombre");
            
            return View();
        }

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Estudiante estudiante, IFormFile Fotografia)
        {
            // Convirtiendo a Arreglo De Bytes:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    estudiante.Fotografia = memoryStream.ToArray();
                }
            }

            await _EstudianteBL.Create(estudiante);

            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla
        public async Task<ActionResult> Edit(int id)
        {
            Estudiante Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(new Estudiante() { Id_Estudiante = id });

            List<Materia> Lista_Materias = await _EstudianteBL.Lista_Materias();
            ViewData["Lista_Materias"] = new SelectList(Lista_Materias, "Id_Materia", "Nombre",Objeto_Obtenido.IdMateriaEnEstudiante);

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Estudiante estudiante, IFormFile Fotografia)
        {
            // Busco El Objeto Ya Existente Que Ahora Se Modificara:
            Estudiante Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(estudiante);

            // Convirtiendo a Arreglo De Bytes:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    estudiante.Fotografia = memoryStream.ToArray();
                }
            }
            else
            {
                estudiante.Fotografia = Objeto_Obtenido.Fotografia;
            }

            await _EstudianteBL.Edit(estudiante);

            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Delete(int id)
        {
            Estudiante Objeto_Obtenido = await _EstudianteBL.Obtener_PorId(new Estudiante() { Id_Estudiante = id });

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Se Le Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Estudiante estudiante)
        {
            await _EstudianteBL.Delete(estudiante);
            return RedirectToAction(nameof(Index));
        }
    }
}
