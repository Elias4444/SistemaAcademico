using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Helpers;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalidades { get; set; } = new();

        private readonly ServicioCarrera servicio;
        public CreateModel()
        {
            servicio = new ServicioCarrera();
        }
        public void OnGet()
        {
            Modalidades = OpcionesModalidad.Lista;
        }
        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.Lista;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            servicio.Agregar(Carrera);
            return RedirectToPage("Index");
        }
    }
}
