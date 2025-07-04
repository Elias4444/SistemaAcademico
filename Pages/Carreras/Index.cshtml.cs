using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Carreras
{
    public class IndexModel : PageModel
    {
        public List<Carrera> Carreras { get; set; }

        private readonly ServicioCarrera servicio;
        public IndexModel()
        {
            servicio = new ServicioCarrera();
        }
        public void OnGet()
        {
            Carreras = servicio.ObtenerTodos();
        }
    }
}
