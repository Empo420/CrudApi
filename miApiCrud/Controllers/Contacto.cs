using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miApiCrud.Controllers
{
    public class Contacto
    {
        public int id { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String Correo { get; set; }

        public String Telefono { get; set; }
    }
}
