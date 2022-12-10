using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoF.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            MateriasEstudiantes = new HashSet<MateriasEstudiante>();
        }

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<MateriasEstudiante> MateriasEstudiantes { get; set; }
    }
}
