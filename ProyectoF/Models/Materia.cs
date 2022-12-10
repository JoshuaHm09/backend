using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoF.Models
{
    public partial class Materia
    {
        public Materia()
        {
            MateriasEstudiantes = new HashSet<MateriasEstudiante>();
            MateriasProfesoreIdMateriasNavigations = new HashSet<MateriasProfesore>();
            MateriasProfesoreMateriaIdMateriaNavigations = new HashSet<MateriasProfesore>();
        }

        public int IdMateria { get; set; }
        public string Titulo { get; set; }
        public string Seccion { get; set; }
        public string Horario { get; set; }
        public string Aula { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<MateriasEstudiante> MateriasEstudiantes { get; set; }
        public virtual ICollection<MateriasProfesore> MateriasProfesoreIdMateriasNavigations { get; set; }
        public virtual ICollection<MateriasProfesore> MateriasProfesoreMateriaIdMateriaNavigations { get; set; }
    }
}
