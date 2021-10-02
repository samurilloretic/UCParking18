using System;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace UCP.App.Dominio

{

    public class Persona
    {
        public int id {get;set;}

        public string nombre{get;set;}

        public string apellidos{get;set;}

        [Required]
        [Range(0,1090000000)]
        public int identificacion{get;set;}

        public string telefono{get; set;}
        
        public string correoElectronico{get;set;}

        public string condicionEspecial{get;set;}

        public Vehiculo Vehiculo_1{get;set;}

        public Vehiculo Vehiculo_2{get;set;}     
    }

}