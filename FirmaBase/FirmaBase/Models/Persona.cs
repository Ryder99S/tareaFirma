using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace FirmaBase.Models
{
    public class Persona
    {
        internal Stream image;

        [PrimaryKey, AutoIncrement]
        public int Idpersona { get; set; }

        [MaxLength(10000000)]
        public String imagen { get; set; }

        [MaxLength(50)]
        public String nombre { get; set; }
        [MaxLength(50)]
        public String descripcion { get; set; }
    }
}
