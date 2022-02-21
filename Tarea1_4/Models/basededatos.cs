using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Tarea1_4.Models;
using System.Threading.Tasks;
namespace Tarea1_4.Models
{
    public class basededatos
    {



        readonly SQLiteAsyncConnection db;

        //Contructor de clase vacio

        public basededatos()
        {
        }

        // contructor de parametros
        public basededatos(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // -- Creación de tablas de base de datos
            db.CreateTableAsync<constructor>();

        }


        // procedimientos y funciones necesarias
        //retorna la tabla empleados como lista
        public Task<List<constructor>> listaempleados()
        {

            return db.Table<constructor>().ToListAsync();
        }

        // buscar un empleado especifico por el codigo
        public Task<constructor> ObtenerEmpleado(Int32 pcodigo)
        {
            return db.Table<constructor>().Where(i => i.codigo == pcodigo).FirstOrDefaultAsync();
        }


        // Guardar o actualizar empleado

        public Task<Int32> EmpleadoGuardar(constructor emple)
        {
            if (emple.codigo != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        //Eliminar empleado

        public Task<Int32> EmpleadoBorrar(constructor emple)
        {
            return db.DeleteAsync(emple);
        }






    }
}
