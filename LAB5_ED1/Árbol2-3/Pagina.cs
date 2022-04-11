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
        public Nodo2_3<T> primero;

        public Pagina() //Constructor 
        {
            this.primero = null;
            this.hoja = true;
            this.contador = 0;
        }

        //Método de inserción en página
        public void insertarEnPagina(Nodo2_3<T> nuevo)
        {
            if (primero == null)//si la página está vacía
            {
                //primero en la lista
                primero = nuevo;
                contador++;
            }
            else //si la página no está vacía
            {
                //recorrer e insertarEnPagina
                Nodo2_3<T> aux = primero;
                while(aux != null) //recorrer los nodos dentro de la página hasta que sea el último
                {
                    if (aux.valor.CompareTo(nuevo.valor) == 0) //si el valor a insertar ya existe en el árbol
                    {
                        //agregar lo de throw exception
                        break;
                    }
                    else //sino existe el valor, insertar en el árbol
                    {
                        if (aux.valor.CompareTo(nuevo.valor) > 0) //se hacen las comparaciones para saber en que parte insertar
                        {
                            if (aux == primero) //insertar en página al inicio
                            {
                                aux.anterior = nuevo; //cabeza apunta al nuevo
                                nuevo.siguiente = aux; //nuevo apunta a cabeza
                                //ramas del nodo
                                aux.hijoIzq = nuevo.hijoDer;  //le paso los punteros derechos al aux
                                nuevo.hijoDer = null; //como es el primero en la página no tendrá hijo derecho
                                primero = nuevo; //pagina.primero apunta al nuevo
                                contador++;
                                break;
                            }
                            else //insertar en página al medio
                            {
                                nuevo.siguiente = aux; //nuevo apunta al aux
                                //ramas del nodo
                                aux.hijoIzq = nuevo.hijoDer;
                                nuevo.hijoDer = null;

                                nuevo.anterior = aux.anterior; //nuevo su anterior apunta a la cabeza 
                                aux.anterior.siguiente = nuevo;//modificar el puntero de mi anterior, o sea que mi cabeza apunte al nuevo
                                aux.anterior = nuevo; //ahora aux apunta al nuevo
                                contador++;
                                break;
                            }
                        } else if (aux.siguiente == null) //insertar en página al final
                        {
                            aux.siguiente = nuevo;
                            nuevo.anterior = aux;
                            aux.hijoDer = null;
                            contador++;
                            break;
                        }
                    }
                    aux = aux.siguiente; //Cambia de posición el nodo aux
                }
            }
        }
    }
}
