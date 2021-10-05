using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
namespace UCP.App.Persistencia
{
    public class RepositorioParqueadero: IRepositorioParqueadero
    {
        private readonly AppContext _appContext;

        public RepositorioParqueadero(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD
        //GetAllProfesores
        IEnumerable<Parqueadero> IRepositorioParqueadero.GetAllParqueaderos()
        {
            return _appContext.parqueaderos;
        }
        //GetProfesor
        Parqueadero IRepositorioParqueadero.GetParqueadero(int idParqueadero)
        {
            var parqueaderoEncontrado = _appContext.parqueaderos.FirstOrDefault(p => p.id==idParqueadero);
            return parqueaderoEncontrado;
        }
        //AddProfesor
        Parqueadero IRepositorioParqueadero.AddParqueadero(Parqueadero parqueadero)
        {
            var parqueaderoAdicionado = _appContext.parqueaderos.Add(parqueadero);
            _appContext.SaveChanges();
            return parqueaderoAdicionado.Entity;
        }
        //UpdateProfesor
        Parqueadero IRepositorioParqueadero.UpdateParqueadero(Parqueadero parqueadero)
        {
            var parqueaderoEncontrado = _appContext.parqueaderos.FirstOrDefault(p => p.id==parqueadero.id);
            if (parqueaderoEncontrado != null)
            {
                parqueaderoEncontrado.direccion = parqueadero.direccion;
                parqueaderoEncontrado.horario = parqueadero.horario;
                parqueaderoEncontrado.picoPlaca = parqueadero.picoPlaca;
                parqueaderoEncontrado.numeroPuestos = parqueadero.numeroPuestos;
                parqueaderoEncontrado.puestos = parqueadero.puestos;
                parqueaderoEncontrado.personas = parqueadero.personas;
                parqueaderoEncontrado.Transacciones = parqueadero.Transacciones;
                
                
                _appContext.SaveChanges();
            }
            return parqueaderoEncontrado;
        }
        //DeleteProfesor
        Parqueadero IRepositorioParqueadero.DeleteParqueadero(Parqueadero parqueadero)
        {
            var parqueaderoEncontrado = _appContext.parqueaderos.FirstOrDefault(p=>p.id==parqueadero.id);
            if (parqueaderoEncontrado == null)
                return null;
            _appContext.parqueaderos.Remove(parqueaderoEncontrado);
            Console.WriteLine("Se eliminó un profesor");
            _appContext.SaveChanges();
            return parqueaderoEncontrado;
        }
    }
}