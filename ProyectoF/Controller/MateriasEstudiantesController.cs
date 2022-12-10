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
    public class MateriasEstudiantesController : ControllerBase
    {
        private readonly ProyectFinal1Context _context;

        public MateriasEstudiantesController(ProyectFinal1Context context)
        {
            _context = context;
        }
            [HttpGet]
            public List<MateriasEstudiante> GetMateriasEstudiante()
            {
                var listMateriasEstudiante = _context.MateriasEstudiantes.ToList();

                return listMateriasEstudiante;
            }
            [HttpPost]

            public void CrearMateriasEstudiante(int idEst, int idMat)
            {

                _context.MateriasEstudiantes.Add(new MateriasEstudiante() 
                {
                    IdEstudiante = idEst,
                    IdMaterias = idMat
                });
                _context.SaveChanges();

            }
        }
    }