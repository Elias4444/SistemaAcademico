using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Helpers;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Carreras
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalidades { get; set; } = new();

        private readonly ServicioCarrera servicio;
        public EditModel()
        {
            servicio = new ServicioCarrera();
        }
        public void OnGet(int id)
        {
            Modalidades = OpcionesModalidad.Lista;

            Carrera carrera = servicio.BuscarPorId(id);
            if (carrera != null )
            {
                Carrera = carrera;
            }
        }
        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.Lista;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            servicio.Editar(Carrera);

            return RedirectToPage("Index");
        }
    }
}
