using System;
using System.Collections.Generic;
using System.Text;

namespace GestorStart.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
        public string Imagen { get; set; }
    }
}
