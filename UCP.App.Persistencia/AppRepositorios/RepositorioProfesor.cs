using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace UCP.App.Persistencia
{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private readonly AppContext _appContext;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD
        //GetAllProfesores
        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            return _appContext.profesores;
        }
        //GetProfesor
        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id == idProfesor);
            return profesorEncontrado;
        }
        //AddProfesor
        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            var profesorAdicionado = _appContext.profesores.Add(profesor);
            _appContext.SaveChanges();
            return profesorAdicionado.Entity;
        }
        //UpdateProfesor
        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id == profesor.id);
            if (profesorEncontrado != null)
            {
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellidos = profesor.apellidos;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.telefono = profesor.telefono;
                profesorEncontrado.correoElectronico = profesor.correoElectronico;
                profesorEncontrado.condicionEspecial = profesor.condicionEspecial;
                profesorEncontrado.Vehiculo_1 = profesor.Vehiculo_1;
                profesorEncontrado.Vehiculo_2 = profesor.Vehiculo_2;
                profesorEncontrado.tarifaProfesor = profesor.tarifaProfesor;
                profesorEncontrado.cubiculo = profesor.cubiculo;
                profesorEncontrado.facultad = profesor.facultad;

                _appContext.SaveChanges();
            }
            return profesorEncontrado;
        }
        //DeleteProfesor
        Profesor IRepositorioProfesor.DeleteProfesor(Profesor profesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id == profesor.id);
            if (profesorEncontrado == null)
                return null;
            _appContext.profesores.Remove(profesorEncontrado);
            Console.WriteLine("Se eliminó un profesor");
            _appContext.SaveChanges();
            return profesorEncontrado;
        }

        Profesor IRepositorioProfesor.GetProfesorPorCarro(int idProfesor)
        {
            //Profesor profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id == idProfesor);
            //Profesor profesorEncontrado = _appContext.profesores.Include("Vehiculo_1").FirstOrDefault(p => p.id == idProfesor);
            //List<Profesor> profesores = _appContext.profesores.Include(p=>p.Vehiculo_1).ToList();
            //Console.WriteLine(profesores[0].Vehiculo_1.marca);
            //var profesoresEncontrados = _appContext.profesores.Include(profesor => profesor.Vehiculo_1).Include(profesor => profesor.Vehiculo_2).ToList();
            var profesorEncontrado = _appContext.profesores.Include(profesor => profesor.Vehiculo_1).Include(profesor => profesor.Vehiculo_2).FirstOrDefault(profesor => profesor.id == idProfesor);
            /*foreach (var profesor in profesoresEncontrados)
            {
                if(profesor.id ==idProfesor)
                    return profesor;
                if(profesor.Vehiculo_1!=null)
                {
                    /*Console.WriteLine(profesor.Vehiculo_1.id);
                    Console.WriteLine(_appContext.vehiculos.FirstOrDefault(v=>v.id==profesor.Vehiculo_1.id).marca);
                    Console.WriteLine(_appContext.vehiculos.FirstOrDefault(v=>v.id==profesor.Vehiculo_1.id).modelo);
                    Console.WriteLine(_appContext.vehiculos.FirstOrDefault(v=>v.id==profesor.Vehiculo_1.id).placa);
                    Console.WriteLine(_appContext.vehiculos.FirstOrDefault(v=>v.id==profesor.Vehiculo_1.id).tipoVehiculo);

                    Console.WriteLine(profesor.nombre);
                    
                    
                }
            }*/
            //var vehiculo = _appContext.Entry(profesorEncontrado).Collection(b=>b.Vehiculo_1).Query().ToList();
            //Vehiculo vehiculo = _appContext.profesores.Include(p=>p.Vehiculo_1);
            //Console.WriteLine(vehiculo.marca);
            //Console.WriteLine(profesorEncontrado.Vehiculo_1.marca);
            //_appContext.Entry(profesorEncontrado).Reference(s=>s.Vehiculo_1).Load();
            return profesorEncontrado;
        }
    }
}