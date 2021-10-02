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
        public Profesor profesor{get;set;}
        public IActionResult OnGet(int profesorid)
        {
            profesor = _repoProfesor.GetProfesor(profesorid);
            if(profesor==null)
            {
                return RedirectToPage("./Profesores");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            _repoProfesor.UpdateProfesor(profesor);
            return RedirectToPage("./Profesores");
        }
    }
}
