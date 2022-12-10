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
    public class ProfesorsController : ControllerBase
    {
        private readonly ProyectFinal1Context _context;

        public ProfesorsController(ProyectFinal1Context context)
        {
            _context = context;
        }

      
        [HttpGet]
        public List<Profesor> GetProfesor()
        {
            var listProfesors = _context.Profesors.ToList();

            return listProfesors;
        }

        [HttpPost]
        public void CrearProfesor(string Nombre, string Apellido, string Genero, string Telefono)
        {

            _context.Profesors.Add(new Profesor()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Genero = Genero,
                Telefono = Telefono
            });
            _context.SaveChanges();

        }
        [HttpPut]

        public void ActualizarProfesor(int ID, string Nombre, string Apellido, string Genero, string Telefono)
        {
            var actProfesor = _context.Profesors.ToList().Find(x => x.IdProfesor == ID);

            if (actProfesor != null)
            {
                actProfesor.Nombre = Nombre;
                actProfesor.Apellido = Apellido;
                actProfesor.Genero = Genero;
                actProfesor.Telefono = Telefono;

                _context.Entry(actProfesor).State = EntityState.Modified;
                _context.SaveChanges();

            }




        }
        [HttpDelete]
        public void BorraProfesor(int ID)
        {
            var borrarProfesors = _context.Profesors.ToList().Find(x => x.IdProfesor == ID);

            if (borrarProfesors != null)
            {
                _context.Profesors.Remove(borrarProfesors);
                _context.SaveChanges();

            }



        }
    }
}