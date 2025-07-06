using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.AccesoAdatos;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Repositorios;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }

        private readonly ServicioAlumno servicio;
        public DeleteModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatosJson<Alumno>("alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            servicio = new ServicioAlumno(repo);
        }
        public IActionResult OnGet(int id)
        {
            var alumno = servicio.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("Index");
            }

            Alumno = alumno;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
