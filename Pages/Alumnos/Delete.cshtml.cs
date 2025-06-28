using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        public IActionResult OnGet(int id)
        {
            var alumno = ServicioAlumno.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("Index");
            }

            Alumno = alumno;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            ServicioAlumno.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
