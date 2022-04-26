using LAB5_ED1.Helpers;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

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
        public int Latitud { get; set; }
        [Required]
        public int Longitud { get; set; }

        public static bool Guardar(CarModel model)
        {
            Singleton.Instance.carList.InsertarEnArbol(model);
            return true;
        }

        public int CompareTo(object obj)
        {
            return this.Placa - ((CarModel)obj).Placa;
        }


        
    }
    //update 
}
