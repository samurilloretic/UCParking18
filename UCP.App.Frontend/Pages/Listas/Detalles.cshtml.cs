using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Dominio;
using UCP.App.Persistencia;

namespace UCP.App.Frontend.Pages
{

    public class DetallesModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new UCP.App.Persistencia.AppContext());
        public Profesor profesor{get;set;}
        public IActionResult OnGet(int profesorId)
        {
            profesor = _repoProfesor.GetProfesor(profesorId);
            Console.WriteLine(profesor.id);
            if(profesor==null)
            {
                return RedirectToPage("./Profesores");
            }else{
                return Page();
            }
        }
    }
}
