using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Persistencia;
using UCP.App.Dominio;
namespace UCP.App.Frontend.Pages
{
    public class EditarModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new UCP.App.Persistencia.AppContext());
        [BindProperty]
        public Profesor profesor { get; set; }
        public IActionResult OnGet(int? profesorid)
        {
            if (profesorid.HasValue)
            {
                profesor = _repoProfesor.GetProfesor(profesorid.Value);
            }
            else
            {
                profesor = new Profesor();
            }

            if (profesor == null)
            {
                return RedirectToPage("./Profesores");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if (profesor.id > 0)
                {
                    _repoProfesor.UpdateProfesor(profesor);
                }
                else
                {
                    _repoProfesor.AddProfesor(profesor);
                }
                return RedirectToPage("./Profesores");
            }
        }
    }
}
