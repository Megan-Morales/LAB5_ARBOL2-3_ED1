namespace Lab03_ED_2022.Estructura_de_Datos.Cola
{
    public class Nodo<T>
    {

        public T valor;
        public Nodo<T> siguiente;
        public Nodo<T> anterior;

        //Constructor por defecto en una lista enlazada
        public Nodo(T object1)
        {
            this.valor = object1;
        }
        //Elementos y constructor necesario para trabajar con ColumnMajor
        private int posicion;

        public Nodo(T object1, int posicion)
        {
            this.valor = object1;
            this.posicion = posicion;
        }

        public int getPosicion()
        {
            return posicion;
        }

        public void setPosicion(int posicion)
        {
            this.posicion = posicion;
        }

        public T getValor()
        {
            return valor;
        }

        public void setValor(T valor)
        {
            this.valor = valor;
        }

    }
}
