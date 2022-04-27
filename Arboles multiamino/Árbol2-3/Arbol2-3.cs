using Lab03_ED_2022.Estructura_de_Datos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LAB5_ED1.Árbol2_3
{
    public class Arbol2_3<T> : IEnumerable, IEnumerable<T> where T : IComparable
    {
        

        readonly int orden_arbol = 3; //Esto se puede modificar según el tipo de árbol para el 2-3 su orden es de 3 ya que puede tener máximo 3 conexiones.

        Pagina<T> raiz;
        public Arbol2_3() //Contructor de mi árbol
        {
            this.raiz = null;

        }

        /*==============================================MÉTODOS FUNDAMENTALES==============================================*/
        //MÉTODOS DE INSERCIÓN.
        public void InsertarEnArbol(T valor)
       {
            Nodo2_3<T> nodo = new Nodo2_3<T>(valor);
            if (raiz == null)
            {
                raiz = new Pagina<T>(); //si mi árbol está vacio, creo una nueva página
                raiz.InsertarEnPagina(nodo); //insertar el valor en la página
            }
            else
            {
                Nodo2_3<T> obj = Insertar_En_Pagina(nodo, raiz);
                if (obj != null)
                {
                    //si devuelve algo el metodo de insertar en página quiere decir que creo una nueva página, y se debe insertar en el árbol
                    raiz = new Pagina<T>();
                    raiz.InsertarEnPagina(obj);
                    raiz.hoja = false;
                }
            }
        }

        private Nodo2_3<T> Insertar_En_Pagina(Nodo2_3<T> nodoNuevo, Pagina<T> pagina) //Método para crear página, para desplazarme entre páginas
        {
            if (pagina.hoja)
            {
                //Esta parte es para insertarEnArbol el nodo en la página que sea hoja.
                pagina.InsertarEnPagina(nodoNuevo);
                //Este es un if, básicamente es la parte que compara si se ha alcanzado el máximo de elementos en la hoja.
                return (pagina.contador == orden_arbol) ? Dividir(pagina) : null;
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
                        Nodo2_3<T> obj = Insertar_En_Pagina(nodoNuevo, nodoActual.hijoIzq);
                        return Validar_Division(obj, pagina);
                    }
                    else if (nodoActual.siguiente == null)
                    {
                        Nodo2_3<T> obj = Insertar_En_Pagina(nodoNuevo, nodoActual.hijoDer);
                        return Validar_Division(obj, pagina);
                    }
                    nodoActual = nodoActual.siguiente;
                } while (nodoActual != null);
            }
            return null;
        }

        private Nodo2_3<T> Validar_Division(Nodo2_3<T> obj, Pagina<T> pagina) // Método validar si no se debe dividir aún más los nodos.
        {
            if (obj is Nodo2_3<T>)
            {
                pagina.InsertarEnPagina(obj);
                if (pagina.contador == orden_arbol)
                {
                    return Dividir(pagina);
                }
            }
            return null;
        }

        private Nodo2_3<T> Dividir(Pagina<T> pagina) //Este método es el encargado de dividir la página recursivamente.
        {
            T valorNodoDivisor = default(T);
            Nodo2_3<T> temp, nodoGenerado;
            Nodo2_3<T> nodoActual = pagina.primero;
            Pagina<T> rderecha = new Pagina<T>();
            Pagina<T> rizquierda = new Pagina<T>();

            int cont = 0;
            while (nodoActual != null)
            {
                cont++;
                //implementacion para dividir unicamente ramas de 3 nodos
                if (cont < 2)
                { // Para los nodos que se van a la izquierda.
                    temp = new Nodo2_3<T>(nodoActual.valor);
                    temp.hijoIzq = nodoActual.hijoIzq;
                    if (cont == 1)
                    {
                        temp.hijoDer = nodoActual.siguiente.hijoIzq;
                    }
                    else
                    {
                        temp.hijoDer = nodoActual.hijoDer; //este podría ser null
                    }
                    //si la pagina posee hijos quiere decir que no es una hoja
                    if (temp.hijoDer != null && temp.hijoIzq != null)
                    {
                        rizquierda.hoja = false;
                    }
                    rizquierda.InsertarEnPagina(temp);

                }
                else if (cont == 2)
                {
                    valorNodoDivisor = nodoActual.valor;
                }
                else
                { // Para los nodos que se van a la derecha.
                    temp = new Nodo2_3<T>(nodoActual.valor, nodoActual.hijoIzq, nodoActual.hijoDer);
                    //si la rama posee ramas deja de ser hoja
                    if (temp.hijoDer != null && temp.hijoIzq != null)
                    {
                        rderecha.hoja = false;
                    }
                    rderecha.InsertarEnPagina(temp);
                }
                nodoActual = nodoActual.siguiente;
            }
            nodoGenerado = new Nodo2_3<T>(valorNodoDivisor, rizquierda, rderecha);
            return nodoGenerado;
        }

        private void InOrder(Pagina<T> padre, ref ColaRecorrido<T> queue)
        {

            if (padre != null)
            {
                

            }
            return;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var queue = new ColaRecorrido<T>();
            InOrder(raiz, ref queue);

            while (!queue.ColaVacia())
            {
                yield return queue.DesEncolar();
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
