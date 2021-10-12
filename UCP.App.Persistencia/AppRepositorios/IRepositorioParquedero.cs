using System.Collections.Generic;
using System.Globalization;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public interface IRepositorioParqueadero
    {
                //CRUD 
        //GetAllProfesores
        IEnumerable<Parqueadero> GetAllParqueaderos();
        //GetProfesor 
        Parqueadero GetParqueadero(int idParqueadero);
        //AddProfesor
        Parqueadero AddParqueadero(Parqueadero parqueadero);
        //UpdateProfesor
        Parqueadero UpdateParqueadero(Parqueadero parqueadero);
        //DeleteProfesor
        Parqueadero DeleteParqueadero(Parqueadero parqueadero);

        IEnumerable<Parqueadero> ParqueaderoConPuesto(Estado estado);
        IEnumerable<Parqueadero> ParqueaderoConPuesto(TipoVehiculo tipoVehiculo);
        IEnumerable<Parqueadero> ParqueaderoConPuesto(Estado estado,TipoVehiculo tipoVehiculo);
    }
}