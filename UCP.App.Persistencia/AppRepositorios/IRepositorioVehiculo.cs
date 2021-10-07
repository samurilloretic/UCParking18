using System.Collections.Generic;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public interface IRepositorioVehiculo
    {
                //CRUD 
        //GetAllProfesores
        IEnumerable<Vehiculo> GetAllVehiculos();
        //GetProfesor 
        Vehiculo GetVehiculo(int idVehiculo);
        //AddProfesor
        Vehiculo AddVehiculo(Vehiculo vehiculo);
        //UpdateProfesor
        Vehiculo UpdateVehiculo(Vehiculo vehiculo);
        //DeleteProfesor
        Vehiculo DeleteVehiculo(Vehiculo vehiculo);
    }
}