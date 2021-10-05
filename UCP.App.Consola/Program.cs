using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Security.Permissions;

namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        private static IRepositorioParqueadero _repoParqueadero = new RepositorioParqueadero(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Persona persona_1 = EncontrarProfesor(8);
            Persona persona_2 = EncontrarProfesor(9);
            List<Persona> personas = new List<Persona>();
            personas.Add(persona_1);
            personas.Add(persona_2);
            Parqueadero parqueadero = AdicionarParqueadero(personas);
            if (parqueadero!=null)
            {
                Console.WriteLine("Se creó un parqueadero");
            }
           
        }

        //CRUD
        //AdicionarProfesor
        private static void AdicionarProfesor()
        {
            var profesor = new Profesor
            {
                nombre = "Felipe",
                apellidos = "Muñoz",
                identificacion = 100003,
                telefono = "30000000300",
                correoElectronico = "felipemuñoz.tic@ucaldas.edu.co",
                condicionEspecial = "fractura",
                Vehiculo_1 = null,
                Vehiculo_2 = null,
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 4
            };
            _repoProfesor.AddProfesor(profesor);
        }

        //ActualizarProfesor
        private static void ActualizarProfesor(int idProfesor)
        {
            var profesor = new Profesor
            {
                id =idProfesor,
                nombre = "Santiago",
                apellidos = "Murillo",
                identificacion = 12345,
                telefono = "30000000000",
                correoElectronico = "santiagomurillo.tic@ucaldas.edu.co",
                condicionEspecial = "Ninguna",
                Vehiculo_1 = null,
                Vehiculo_2 = null,
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 3
            };
            Profesor profesorActualizado=_repoProfesor.UpdateProfesor(profesor);
            if (profesorActualizado!=null)
                Console.WriteLine("Se actualizó el profesor");
            
        }

        //EncontrarProfesor
        private static Profesor EncontrarProfesor(int idProfesor)
        {
            var profesorEncontrado = _repoProfesor.GetProfesor(idProfesor);
            Console.WriteLine(profesorEncontrado.nombre);
            return profesorEncontrado;
        }

        //EncontrarProfesores
        private static void EncontrarProfesores()
        {
            IEnumerable<Profesor> profesores = _repoProfesor.GetAllProfesores();

            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor.nombre+" "+profesor.apellidos+" "+profesor.condicionEspecial);
            }
        }
        //Eliminar Profesor
        private static void EliminarProfesor(Profesor profesor)
        {
            var profesorEliminado=_repoProfesor.DeleteProfesor(profesor);
            if (profesor!=null)
                Console.WriteLine("Se eliminó el profesor");
            else
            {
                Console.WriteLine("Hubo un error al acceder a la base de datos");
            }
        }

        private static Profesor AdicionarProfesorConVehiculo()
        {
            var profesor = new Profesor
            {
                nombre = "Natalia",
                apellidos = "Estrada",
                identificacion = 100010,
                telefono = "30000000310",
                correoElectronico = "nataliaestrada.tic@ucaldas.edu.co",
                condicionEspecial = "fractura",
                Vehiculo_1 = new Vehiculo{marca="Mazda", modelo="Cx-3", placa="AAA123",tipoVehiculo=TipoVehiculo.Automovil},
                Vehiculo_2 = new Vehiculo{marca="GW",modelo="Animal",placa="WXY123",tipoVehiculo=TipoVehiculo.Bicicleta},
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 4
            };
            _repoProfesor.AddProfesor(profesor);
            return profesor;
        }
        
        private static Profesor AdicionarProfesorConVehiculo(Vehiculo vehiculo1,Vehiculo vehiculo2)
        {
            var profesor = new Profesor
            {
                nombre = "Juan ",
                apellidos = "Montoya",
                identificacion = 100014,
                telefono = "30000000314",
                correoElectronico = "juanmontoya.tic@ucaldas.edu.co",
                condicionEspecial = "ninguno",
                Vehiculo_1 = vehiculo1,
                Vehiculo_2 = vehiculo2,
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 4
            };
            _repoProfesor.AddProfesor(profesor);
            return profesor;
        }

        private static Parqueadero AdicionarParqueadero()
        {
            var parqueaderoAdicionado = new Parqueadero
            {
                direccion = "Carrera 12 # 10a-28",
                horario="Lunes 8 a 22 horas",
                picoPlaca= 1,
                numeroPuestos = 100,
                puestos= new List<Puesto> {
                    new Puesto{numero=1,estado=Estado.libre,tipoVehiculo=TipoVehiculo.Automovil},
                    new Puesto{numero=2,estado=Estado.libre,tipoVehiculo=TipoVehiculo.Camionetas},
                    new Puesto{numero=3,estado=Estado.libre,tipoVehiculo=TipoVehiculo.Bicicleta}
                },
                personas=null,
                Transacciones=null
            };
            _repoParqueadero.AddParqueadero(parqueaderoAdicionado);
            return parqueaderoAdicionado;            
        }


        private static Parqueadero AdicionarParqueadero(List<Persona> listaPersonas)
        {
            var parqueaderoAdicionado = new Parqueadero
            {
                direccion = "Carrera 10 # 28b-28",
                horario="Lunes a Sábado 8 a 22 horas",
                picoPlaca= 5,
                numeroPuestos = 50,
                puestos= new List<Puesto> {
                    new Puesto{numero=1,estado=Estado.reservado,tipoVehiculo=TipoVehiculo.Monopatin},
                    new Puesto{numero=2,estado=Estado.libre,tipoVehiculo=TipoVehiculo.Bus},
                    new Puesto{numero=3,estado=Estado.ocupado,tipoVehiculo=TipoVehiculo.Busetas}
                },
                personas=new List<Persona>{
                    new Persona{nombre="Jacobo", apellidos="Reinosa"},
                    new Persona{nombre="Tatiana", apellidos="Pérez"}
                },
                Transacciones=null
            };
            _repoParqueadero.AddParqueadero(parqueaderoAdicionado);
            return parqueaderoAdicionado;            
        }
    }
}
