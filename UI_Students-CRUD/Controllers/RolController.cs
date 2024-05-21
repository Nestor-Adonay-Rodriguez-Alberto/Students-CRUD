using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Mvc;


namespace UI_Students_CRUD.Controllers
{
    public class RolController : Controller
    {
        // Puente con DB y UI:
        private readonly RolBL _RolBL;

        // Constructor:
        public RolController(RolBL rolBL)
        {
            _RolBL = rolBL;
        }


        // Manda Todos Los Registros De La Tabla:
        public async Task<ActionResult> Index()
        {
            List<Rol> Objetos_Obtenidos = await _RolBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Details(int id)
        {
            Rol Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { Id_Rol = id });

            return View(Objeto_Obtenido);
        }

        public ActionResult Create()
        {
            return View();
        }

        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Rol rol)
        {
            await _RolBL.Create(rol);

            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla
        public async Task<ActionResult> Edit(int id)
        {
            Rol Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { Id_Rol = id });

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Rol rol)
        {
            await _RolBL.Edit(rol);

            return RedirectToAction(nameof(Index));
        }

        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Delete(int id)
        {
            Rol Objeto_Obtenido = await _RolBL.Obtener_PorId(new Rol() { Id_Rol = id });
           
            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Se Le Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Rol rol)
        {
            await _RolBL.Delete(rol);

            return RedirectToAction(nameof(Index));
        }
    }
}
