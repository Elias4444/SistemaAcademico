using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;

namespace SistemaAcademico_V2.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        public void OnGet(int id)
        {
            foreach (var a in DatosCompartidos.Alumnos)
            {
                if (a.Id == id)
                {
                    Alumno = a;
                    break;
                }
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var a in DatosCompartidos.Alumnos)
            {
                if (a.Id == Alumno.Id)
                {
                    a.Nombre = Alumno.Nombre;
                    a.Apellido = Alumno.Apellido;
                    a.Dni = Alumno.Dni;
                    a.Email = Alumno.Email;
                    a.FechaDeNacimiento = Alumno.FechaDeNacimiento;
                    break;
                }
            }
            return RedirectToPage("Index");
        }
    }
}
