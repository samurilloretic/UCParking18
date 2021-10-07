using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Security.Permissions;
using System.ComponentModel;
using System.Reflection;
using System.Net.NetworkInformation;

namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        private static IRepositorioParqueadero _repoParqueadero = new RepositorioParqueadero(new Persistencia.AppContext());
        private static IRepositorioVehiculo _repoVehiculo = new RepositorioVehiculo(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            /*Persona persona_1 = EncontrarProfesor(8);
            Persona persona_2 = EncontrarProfesor(9);
            List<Persona> personas = new List<Persona>();
            personas.Add(persona_1);
            personas.Add(persona_2);
            Parqueadero parqueadero = AdicionarParqueadero(personas);
            if (parqueadero!=null)
            {
                Console.WriteLine("Se creó un parqueadero");
            }*/

            //Profesor profesor = _repoProfesor.GetProfesorPorCarro(16);
            //Profesor profesor = EncontrarProfesor(15);
            /*Console.WriteLine(profesor.nombre);
            Console.WriteLine(profesor.Vehiculo_1.marca);
            Console.WriteLine(profesor.Vehiculo_1.modelo);
            Console.WriteLine(profesor.Vehiculo_2.placa);
            Console.WriteLine(profesor.Vehiculo_2.tipoVehiculo);
            */
            //Vehiculo vehiculo = new Vehiculo{marca="Chevrolet",modelo="Aveo",placa="AVS433",tipoVehiculo=TipoVehiculo.Automovil};
            
            //Vehiculo vehiculo = BuscarVehiculo(1);
            //AgregarVehiculoProfesor(8, vehiculo);

            //Puesto puestonuevo = new Puesto{numero=3,estado=Estado.libre,tipoVehiculo=TipoVehiculo.Bicicleta};
            //AdicionarInformacionParqueadero(4,puestonuevo);

            Profesor nuevoProfesor = AdicionarProfesor();
            Puesto puestonuevo = new Puesto{numero=4,estado=Estado.libre,tipoVehiculo=TipoVehiculo.Bicicleta};
            Vehiculo nuevoVehiculo = new Vehiculo{marca="Toyota",modelo="Prado",placa="DKS999",tipoVehiculo=TipoVehiculo.Automovil};
            Transaccion transaccion = new Transaccion{horaIngreso=new DateTime(2021,10,8),horaSalida=new DateTime(2021,10,9),vehiculo=nuevoVehiculo,persona=nuevoProfesor};
            AdicionarInformacionParqueadero(4,puestonuevo,transaccion,nuevoProfesor);           
        }

        //CRUD
        //AdicionarProfesor
        private static Profesor AdicionarProfesor()
        {
            var profesor = new Profesor
            {
                nombre = "Camila",
                apellidos = "Castrillón",
                identificacion = 10125,
                telefono = "3000100300",
                correoElectronico = "camilacastrillon.tic@ucaldas.edu.co",
                condicionEspecial = "fractura",
                Vehiculo_1 = null,
                Vehiculo_2 = null,
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 8
            };
            _repoProfesor.AddProfesor(profesor);
            return profesor;
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

        private static void AdicionarInformacionParqueadero(int idParqueadero,Puesto puesto,Transaccion transaccion,Profesor profesor)
        {
            
            var parqueaderoEncotrado = _repoParqueadero.GetParqueadero(idParqueadero);
            if (parqueaderoEncotrado.puestos!=null)//Existe lista de puesto
            {
                parqueaderoEncotrado.puestos.Add(puesto);
            }else{
                parqueaderoEncotrado.puestos = new List<Puesto>();
                parqueaderoEncotrado.puestos.Add(puesto);                   
            }

            if (parqueaderoEncotrado.Transacciones!=null)//Existe lista de puesto
            {
                parqueaderoEncotrado.Transacciones.Add(transaccion);
            }else{
                parqueaderoEncotrado.Transacciones = new List<Transaccion>();
                parqueaderoEncotrado.Transacciones.Add(transaccion);                   
            }

            if (parqueaderoEncotrado.personas!=null)//Existe lista de puesto
            {
                parqueaderoEncotrado.personas.Add(profesor);
            }else{
                parqueaderoEncotrado.personas = new List<Persona>();
                parqueaderoEncotrado.personas.Add(profesor);                   
            }
            _repoParqueadero.UpdateParqueadero(parqueaderoEncotrado);
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

        private static void AgregarVehiculoProfesor(int idProfesor, Vehiculo vehiculo)
        {
            var profesorEncotrado = EncontrarProfesor(idProfesor);
            profesorEncotrado.Vehiculo_1 = vehiculo;
            _repoProfesor.UpdateProfesor(profesorEncotrado);
        }

        private static Vehiculo BuscarVehiculo(int idVehiculo)
        {
            return _repoVehiculo.GetVehiculo(idVehiculo);
        }
    }
}
