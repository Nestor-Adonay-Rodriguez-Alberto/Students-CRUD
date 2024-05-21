using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace UI_Students_CRUD.Controllers
{
    public class MateriaController : Controller
    {
        // Puentre Con DB y UI:
        private readonly MateriaBL _MateriaBL;

        // Constructor:
        public MateriaController(MateriaBL materiaBL)
        {
            _MateriaBL = materiaBL;
        }

        // Manda Todos Los Registros De La Tabla:
        public async Task<ActionResult> Index()
        {
            List<Materia> Objetos_Obtenidos = await _MateriaBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            Materia Objeto_Obtenido = await _MateriaBL.Obtener_PorId(new Materia() { Id_Materia = id });

            return View(Objeto_Obtenido);
        }

        // Manda Un ViewData Con Una Lista De Profesor
        public async Task<ActionResult> Create()
        {
            List<Profesor> Lista_Profesores = await _MateriaBL.Lista_Profesores();
            ViewData["Lista_Profesores"] = new SelectList(Lista_Profesores, "Id_Materia","Nombre");

            return View();
        }

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Materia materia)
        {
            await _MateriaBL.Create(materia);
            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla
        public async Task<ActionResult> Edit(int id)
        {
            Materia Objeto_Obtenido = await _MateriaBL.Obtener_PorId(new Materia() { Id_Materia = id });

            List<Profesor> Lista_Profesores = await _MateriaBL.Lista_Profesores();
            ViewData["Lista_Profesores"] = new SelectList(Lista_Profesores, "Id_Materia", "Nombre",Objeto_Obtenido.IdProfesorEnMateria);


            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Materia materia)
        {
            await _MateriaBL.Edit(materia);
            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Delete(int id)
        {
            Materia Objeto_Obtenido = await _MateriaBL.Obtener_PorId(new Materia() { Id_Materia = id });

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Se Le Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Materia materia)
        {
            await _MateriaBL.Delete(materia);
            return RedirectToAction(nameof(Index));
        }
    }
}
