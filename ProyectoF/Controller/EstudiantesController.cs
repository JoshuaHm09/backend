using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoF.Models;

namespace ProyectoF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {

        ProyectFinal1Context _db = new ProyectFinal1Context();
        public EstudiantesController(ProyectFinal1Context db)
        {
            _db = db;

        }



        [HttpGet]
        [Route("ListaEstudiantes")]
        public IEnumerable<Estudiante> Get()
        {

            using (var context = new ProyectFinal1Context())
            {
                return context.Estudiantes.ToList();
            }
        }

        [HttpPost]
        [Route("Crear Estudiante")]

        public void CrearEstudiante(string Nombre, string Apellido, string Genero, string Telefono)
        {

            _db.Estudiantes.Add(new Estudiante()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Genero = Genero,
                Telefono = Telefono
            });
            _db.SaveChanges();

        }
        [HttpPut]
        [Route("Actualizar Estudiante")]
        public void ActualizarEstudiante(int ID, string Nombre, string Apellido, string Genero, string Telefono)
        {
            var actEstudiante = _db.Estudiantes.ToList().Find(x => x.IdEstudiante == ID);

            if (actEstudiante != null)
            {
                actEstudiante.Nombre = Nombre;
                actEstudiante.Apellido = Apellido;
                actEstudiante.Genero = Genero;
                actEstudiante.Telefono = Telefono;

                _db.Entry(actEstudiante).State = EntityState.Modified;
                _db.SaveChanges();

            }

        }
        [HttpDelete, ActionName("Delete")]
        [Route("Borrar Estudiante")]

        public void BorrarEstudiante(int ID)
        {
            var borrarEstudiante = _db.Estudiantes.ToList().Find(x => x.IdEstudiante == ID);

            if (borrarEstudiante != null)
            {
                _db.Estudiantes.Remove(borrarEstudiante);
                _db.SaveChanges();
            }



        }

    }
}
