using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5_ED1.Árbol2_3
{
    public class Arbol2_3<T> where T : IComparable<T>
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
                raiz.insertarEnPagina(nodo);
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
                /*Esta parte es para insertarEnArbol el nodo en la página que sea hoja.*/
                pagina.insertarEnPagina(nodoNuevo);
                /*Este es un if-else básicamente es la parte que compara si se ha alcanzado el máximo de elementos en la hoja.*/
               
            }
            return null;
        }
    }
}
