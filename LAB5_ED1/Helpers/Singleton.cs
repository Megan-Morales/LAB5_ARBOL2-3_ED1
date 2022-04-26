using LAB5_ED1.Models;
using Arboles_multiamino;
using LAB5_ED1.Árbol2_3;

namespace LAB5_ED1.Helpers
{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public Arbol2_3<CarModel> carList = new Arbol2_3<CarModel>
        {

        };
    }
}
