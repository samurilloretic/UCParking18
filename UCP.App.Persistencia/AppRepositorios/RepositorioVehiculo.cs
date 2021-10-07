using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
namespace UCP.App.Persistencia
{
    public class RepositorioVehiculo: IRepositorioVehiculo
    {
        private readonly AppContext _appContext;

        public RepositorioVehiculo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD
        //GetAllProfesores
        IEnumerable<Vehiculo> IRepositorioVehiculo.GetAllVehiculos()
        {
            return _appContext.vehiculos;
        }
        //GetProfesor
        Vehiculo IRepositorioVehiculo.GetVehiculo(int idVehiculo)
        {
            var VehiculoEncontrado = _appContext.vehiculos.FirstOrDefault(p => p.id==idVehiculo);
            return VehiculoEncontrado;
        }
        //AddProfesor
        Vehiculo IRepositorioVehiculo.AddVehiculo(Vehiculo Vehiculo)
        {
            var VehiculoAdicionado = _appContext.vehiculos.Add(Vehiculo);
            _appContext.SaveChanges();
            return VehiculoAdicionado.Entity;
        }
        //UpdateProfesor
        Vehiculo IRepositorioVehiculo.UpdateVehiculo(Vehiculo Vehiculo)
        {
            var VehiculoEncontrado = _appContext.vehiculos.FirstOrDefault(p => p.id==Vehiculo.id);
            if (VehiculoEncontrado != null)
            {
                VehiculoEncontrado.marca = Vehiculo.marca;
                VehiculoEncontrado.modelo = Vehiculo.modelo;
                VehiculoEncontrado.placa = Vehiculo.placa;
                VehiculoEncontrado.tipoVehiculo = Vehiculo.tipoVehiculo;
                              
                _appContext.SaveChanges();
            }
            return VehiculoEncontrado;
        }
        //DeleteProfesor
        Vehiculo IRepositorioVehiculo.DeleteVehiculo(Vehiculo Vehiculo)
        {
            var VehiculoEncontrado = _appContext.vehiculos.FirstOrDefault(p=>p.id==Vehiculo.id);
            if (VehiculoEncontrado == null)
                return null;
            _appContext.vehiculos.Remove(VehiculoEncontrado);
            Console.WriteLine("Se eliminó un profesor");
            _appContext.SaveChanges();
            return VehiculoEncontrado;
        }
    }
}