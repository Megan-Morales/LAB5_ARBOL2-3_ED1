using Lab03_ED_2022.Estructura_de_Datos.Cola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03_ED_2022.Estructura_de_Datos
{
    public class ColaRecorrido<T>
    {
        NodoSimple<T> Cabeza = new NodoSimple<T>();
        NodoSimple<T> Cola = new NodoSimple<T>();
        NodoSimple<T> Retorno = new NodoSimple<T>();

        public void Encolar(T data)
        {
            NodoSimple<T> Nuevo = new NodoSimple<T>();
            Nuevo.Valor = data;

            if (Cabeza.Valor == null)
            {
                Cabeza = Nuevo;
                Cola = Nuevo;
            }
            else
            {
                Cola.Siguiente = Nuevo;
                Cola = Nuevo;
            }
        }

        public T DesEncolar()
        {
            if (Cabeza != null)
            {
                Retorno = Cabeza;
                Cabeza = Cabeza.Siguiente;
                if (Cabeza == null)
                {
                    Cola = null;
                }
            }
            return Retorno.Valor;
        }

        public bool ColaVacia()
        {
            return Cabeza == null;
        }
    }
}
