using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LAB5_ED1.Helpers;

namespace LAB5_ED1.Models
{
    public class CarModel : IComparable
    {

        [Required]
        [MaxLength(6)]
        [MinLength(1)]
        public int Placa { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Propietario { get; set; }

        [Required]
        public string Coordenadas { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }

        public static bool Guardar(CarModel model)
        {
            Singleton.Instance.carList.insertarEnArbol(model);
            return true;
        }

        public int CompareTo(object obj)
        {
            return this.Placa - ((CarModel)obj).Placa;
        }
 
    }
}
