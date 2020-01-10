using System;
using System.Collections.Generic;

namespace pryDemoCrudWebApi.Models
{
    public partial class Tbcliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
    }
}
