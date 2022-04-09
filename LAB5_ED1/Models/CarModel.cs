using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5_ED1.Models
{
    public class CarModel
    {
        [Required]
        public string Placa { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Propietario { get; set; }

        [Required]
        public string Coordenadas { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }


    }
}
