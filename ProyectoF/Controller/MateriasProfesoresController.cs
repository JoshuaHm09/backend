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
    public class MateriasProfesoresController : ControllerBase
    {
        private readonly ProyectFinal1Context _context;

        public MateriasProfesoresController(ProyectFinal1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<MateriasProfesore> GetMateriasProfesor()
        {
            var listProfesors = _context.MateriasProfesores.ToList();

            return listProfesors;
        }

        [HttpPost]
        public void CrearMateriasProfesor(int idMat, int idProf)
        {

            _context.MateriasProfesores.Add(new MateriasProfesore()
            {
                IdMaterias = idMat,
                IdProfesor = idProf
            });
            _context.SaveChanges();

        }
    }
}
