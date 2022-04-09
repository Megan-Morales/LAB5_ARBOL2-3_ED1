using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LAB5_ED1.Árbol2_3
{
    public class Pagina<T> where T : IComparable<T>   //mi pagina sería el nodo que encapsula a mis otros nodos
    {
        public Boolean hoja;//identificar si es una hoja
        public int contador;//identificar la cantidad de elementos que tiene la pagina
        Nodo2_3<T> primero;

        public Pagina() //Constructor 
        {
            this.primero = null;
            this.hoja = true;
            this.contador = 0;
        }

        //Método de inserción en página
        public void insertarEnPagina(Nodo2_3<T> nuevo)
        {

        }
    }
}
