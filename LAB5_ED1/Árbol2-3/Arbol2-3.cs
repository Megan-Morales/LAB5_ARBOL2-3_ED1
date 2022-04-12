using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5_ED1.Árbol2_3
{
    public class Arbol2_3<T> where T : IComparable
    {
        readonly int orden_arbol = 3; //Esto se puede modificar según el tipo de árbol para el 2-3 su orden es de 3 ya que puede tener máximo 3 conexiones.
        Pagina<T> raiz;
        public Arbol2_3() //Contructor de mi árbol
        {
            this.raiz = null;
        }

        /*==============================================MÉTODOS FUNDAMENTALES==============================================*/
        //MÉTODOS DE INSERCIÓN.
        public void insertarEnArbol(T valor)
        {
            Nodo2_3<T> nodo = new Nodo2_3<T>(valor); 
            if (raiz == null)
            {
                raiz = new Pagina<T>(); //si mi árbol está vacio, creo una nueva página
                raiz.insertarEnPagina(nodo); //insertar el valor en la página
            }
            else
            {
                Nodo2_3<T> obj = insertar_En_Pagina(nodo, raiz); 
                if (obj != null)
                {
                    //si devuelve algo el metodo de insertar en página quiere decir que creo una nueva página, y se debe insertar en el árbol
                    raiz = new Pagina<T>();
                    raiz.insertarEnPagina(obj);
                    raiz.hoja = false;
                }
            }
        }

        private Nodo2_3<T> insertar_En_Pagina(Nodo2_3<T> nodoNuevo, Pagina<T> pagina) //Método para crear página, para desplazarme entre páginas
        {
            if (pagina.hoja)
            {
                //Esta parte es para insertarEnArbol el nodo en la página que sea hoja.
                pagina.insertarEnPagina(nodoNuevo);
                //Este es un if, básicamente es la parte que compara si se ha alcanzado el máximo de elementos en la hoja.
                //Aquí hacer un return
            }
            else //Si no es una hoja la página
            {
                //Entonces hay que recorrer el árbol por medio de sus páginas  y en cada página recorrer el nodo
                //correspondiente viendo si es mayor o menor el nodo de entrada           
                Nodo2_3<T> nodoActual = pagina.primero;
                do
                {
                    if (nodoNuevo.valor.CompareTo(nodoActual.valor) == 0) //Si tiene le mismo valor, ya no ingresa nada.
                    { 
                        return null;
                    }
                    else if (nodoNuevo.valor.CompareTo(nodoActual.valor) < 0)
                    { //si es menor se tiene que desplazar a la página hijoIzq del nodoActual recorrido.
                        Nodo2_3<T> obj = insertar_En_Pagina(nodoNuevo, nodoActual.hijoIzq);
                        return validar_Division(obj, pagina);
                    }
                    else if (nodoActual.siguiente == null)
                    {
                        Nodo2_3<T> obj = insertar_En_Pagina(nodoNuevo, nodoActual.hijoDer);
                        return validar_Division(obj, pagina);
                    }
                    nodoActual = nodoActual.siguiente;
                } while (nodoActual != null);
            }
            return null;
        }
   
        private Nodo2_3<T> validar_Division(Nodo2_3<T> obj, Pagina<T> pagina) // Método validar si no se debe dividir aún más los nodos.
        {
            if (obj is Nodo2_3<T>) 
            {
                pagina.insertarEnPagina(obj);
                if (pagina.contador == orden_arbol)
                {
                    return dividir(pagina);
                }
            }
            return null;
        }

        private Nodo2_3<T> dividir(Pagina<T> pagina) //Este método es el encargado de dividir la página recursivamente.
        {
            return null;
        }





    }
}
