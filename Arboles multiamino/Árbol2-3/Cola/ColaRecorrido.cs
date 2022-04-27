using Lab03_ED_2022.Estructura_de_Datos.Cola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03_ED_2022.Estructura_de_Datos
{
    public class ColaRecorrido<T>
    {
        private Nodo<T> cabeza = null;
        private Nodo<T> cola = null;
        private int longitud = 0;

        //-------------------------------Metodos Fundamentales de mi lista------------------------------------
        //Métodos de encapsulamiento que me serviran para mostrar los datos.
        public Nodo<T> getCabezaLista()
        {
            return this.cabeza;
        }

        public Nodo<T> getColaLista()
        {
            return this.cola;
        }

        public int getlength()
        {
            return longitud;
        }

        //--------------------------------------Método de inserción de datos--------------------------------
        public void insertElement_AtEnding(T valor)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(valor);
            if (cabeza == null)
            {
                cabeza = nodoNuevo;
                cola = nodoNuevo;
            }
            else
            {
                cola.siguiente = nodoNuevo;
                nodoNuevo.anterior = cola;
                cola = nodoNuevo;
            }
            longitud++;
        }

        //-----------------------------------------------------Método de búsqueda-------------------------------------

        public Nodo<T> getNodo(int position)
        {
            Nodo<T> nodoActual = cabeza;
            int i = 0;
            while (i != position)
            {
                i++;
                if (i >= longitud)
                {
                    return null;
                }
                nodoActual = nodoActual.siguiente;
            }
            return nodoActual;
        }
        //------------------------------------------------------Método de eliminación------------------------------
        public void deleteElement_AtBeggining()
        {
            if (longitud == 1)
            {
                cabeza = null;
                cola = null;
                longitud = 0;
            }
            else
            {
                cabeza = cabeza.siguiente;
                cabeza.anterior = null;
                longitud--;
            }
        }
        public Nodo<T> extractElement_AtBeggining()
        {
            Nodo<T> nodoExtraer = getNodo(0);
            deleteElement_AtBeggining();
            return nodoExtraer;
        }

    }
}
