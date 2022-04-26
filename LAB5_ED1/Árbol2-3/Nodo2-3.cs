using System;

namespace LAB5_ED1.Árbol2_3
{
    public class Nodo2_3<T> where T : IComparable
    {
        public T valor; //->Valor/ clave 
        //Apuntadores
        public Nodo2_3<T> anterior, siguiente;
        public Pagina<T> hijoIzq, hijoDer;

        public Nodo2_3(T valor) //contructor de mi clase 
        {
            this.valor = valor;
            this.anterior = this.siguiente = null;
            this.hijoIzq = this.hijoDer = null;
        }

        public Nodo2_3(T valor, Pagina<T> izquierda, Pagina<T> derecha) //Segundo constructor, aplicar sobre carga de constructores 
        {
            this.valor = valor;
            this.anterior = this.siguiente = null;
            this.hijoIzq = izquierda;
            this.hijoDer = derecha;
        }
    }
}
