using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5_ED1.Árbol2_3
{
    public class Nodo2_3 <T> where T : IComparable<T>
    {
        T valor; //->Valor/ clave 
        //Apuntadores
        Nodo2_3<T> anterior, siguiente;
        Pagina<T> hijoIzq, hijoDer;

        public Nodo2_3(T valor) //contructor de mi clase 
        {
            this.valor = valor;
            this.anterior = this.siguiente = null;
            this.hijoIzq = this.hijoDer = null;
        }
    }
}
