using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoF.Models
{
    public partial class MateriasProfesore
    {
        public int Id { get; set; }
        public int IdProfesor { get; set; }
        public int IdMaterias { get; set; }
        public int? MateriaIdMateria { get; set; }

        public virtual Materia IdMateriasNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
        public virtual Materia MateriaIdMateriaNavigation { get; set; }
    }
}
