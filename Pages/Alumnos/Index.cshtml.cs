using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        public List<Alumno> Alumnos { get; set; }

        private readonly ServicioAlumno servicio;
        public IndexModel()
        {
            servicio = new ServicioAlumno();
        }
        public void OnGet()
        {
            Alumnos = servicio.ObtenerTodos();
        }
    }
}
