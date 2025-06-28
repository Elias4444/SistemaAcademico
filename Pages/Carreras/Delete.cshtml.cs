using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico_V2.Data;
using SistemaAcademico_V2.Models;
using SistemaAcademico_V2.Servicios;

namespace SistemaAcademico_V2.Pages.Carreras
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public IActionResult OnGet(int id)
        {
            var carrera = ServicioCarrera.BuscarPorId(id);
            if (carrera == null)
            {
                return RedirectToPage("Index");
            }
            Carrera = carrera;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            ServicioCarrera.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
