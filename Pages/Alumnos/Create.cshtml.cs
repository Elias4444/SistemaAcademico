using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;

namespace SistemaAcademico_V2.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public Alumno Alumno { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Alumno.Id = DatosCompartidos.ObtenerNuevoIdAlumnos();
            DatosCompartidos.Alumnos.Add(Alumno);
            return RedirectToPage("Index");
        }
    }
}
