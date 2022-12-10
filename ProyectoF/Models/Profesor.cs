using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoF.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            MateriasProfesores = new HashSet<MateriasProfesore>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<MateriasProfesore> MateriasProfesores { get; set; }
    }
}
