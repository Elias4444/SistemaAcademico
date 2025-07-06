using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.AccesoAdatos;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Repositorios;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Carreras
{
    public class IndexModel : PageModel
    {
        public List<Carrera> Carreras { get; set; }

        private readonly ServicioCarrera servicio;
        public IndexModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatosJson<Carrera>("carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            servicio = new ServicioCarrera(repo);
        }
        public void OnGet()
        {
            Carreras = servicio.ObtenerTodos();
        }
    }
}
