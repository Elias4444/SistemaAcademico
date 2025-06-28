using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        public void OnGet(int id)
        {
            Alumno? alumno = ServicioAlumno.BuscarPorId(id);
            if (alumno != null)
            {
                Alumno = alumno;
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ServicioAlumno.EditarAlumno(Alumno);

            return RedirectToPage("Index");
        }
    }
}
