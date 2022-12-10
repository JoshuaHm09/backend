using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoF.Models
{
    public partial class MateriasEstudiante
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        public int IdMaterias { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Materia IdMateriasNavigation { get; set; }
    }
}
