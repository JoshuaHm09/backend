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
    public class MateriasController : ControllerBase
    {
        private readonly ProyectFinal1Context _context;

        public MateriasController(ProyectFinal1Context context)
        {
            _context = context;
        }

        ProyectFinal1Context context = new ProyectFinal1Context();

        [HttpGet]
        [Route("Materia")]
        public IEnumerable<Materia> Get()
        {

            using (var context = new ProyectFinal1Context())
            {
                return context.Materias.ToList();
            }
        }
        [HttpPost]
        public void CrearMaterias(string Titulo, string Seccion, string Horario, string Aula, string Descripcion)
        {

            _context.Materias.Add(new Materia()
            {
                Titulo = Titulo,
                Seccion = Seccion,
                Horario = Horario,
                Aula = Aula,
                Descripcion = Descripcion
            });
            _context.SaveChanges();

        }

    }
    }

