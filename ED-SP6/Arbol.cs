using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_SP6
{
    internal class Arbol
    {
        public Nodo Raiz { get; set; }

        public Arbol()
        {
            Raiz = null;
        }

        public void Crear(Nodo nuevo)
        {
            if(Raiz == null)
            {
                Raiz = nuevo;
            }
            else
            {
                Insertar(nuevo);
            }
        }

        public void Insertar(Nodo nuevo)
        {
            if (Raiz != null)
            {
                Nodo aux = Raiz;
                Nodo ant = null;
                while (aux != null)
                {
                    ant = aux;
                    if(nuevo.NumeroCuenta < aux.NumeroCuenta)
                    {
                        aux = aux.Izquierdo;
                    }
                    else
                    {
                        if(nuevo.NumeroCuenta > aux.NumeroCuenta)
                        {
                            aux = aux.Derecho;
                        }
                        else // no se aceptan duplicados
                        {
                            break;
                        }

                    }
                }
                if(nuevo.NumeroCuenta < ant.NumeroCuenta)
                {
                    ant.Izquierdo = nuevo;
                }
                if(nuevo.NumeroCuenta > ant.NumeroCuenta)
                {
                    ant.Derecho = nuevo;
                }
            }
            else
            {
                Crear(nuevo);
            }
        }

        public Nodo Buscar(int NumeroCuenta)
        {
            Nodo nodo = Raiz;
            while(nodo != null && nodo.NumeroCuenta != NumeroCuenta)
            {
                if(NumeroCuenta < nodo.NumeroCuenta)
                {
                    nodo = nodo.Izquierdo;
                }
                else
                {
                    nodo = nodo.Derecho;
                }
            }
            return nodo;
        }

        public Nodo BuscarRecursivo(int NumeroCuenta, Nodo raiz)
        {
            Nodo nodo = raiz;
            if(nodo == null)
            {
                return null;
            }
            if (NumeroCuenta == nodo.NumeroCuenta)
            {
                return nodo;
            }
            if(NumeroCuenta < nodo.NumeroCuenta)
            {
                return BuscarRecursivo(NumeroCuenta, nodo.Izquierdo);
            }
            if(NumeroCuenta > nodo.NumeroCuenta)
            {
                return BuscarRecursivo(NumeroCuenta, nodo.Derecho);
            }

            return nodo;
        }

        public List<Nodo> Listar(Nodo raiz)
        {
            List<Nodo> nodos = new List<Nodo>();

            ListarRecursivo(raiz, nodos);

            return nodos;
            
        }

        private void ListarRecursivo(Nodo raiz, List<Nodo> nodos)
        {
            if (raiz.Izquierdo != null)
            {
                ListarRecursivo(raiz.Izquierdo, nodos);
            }
            
            nodos.Add(raiz); // mostrar

            if(raiz.Derecho != null)
            {
                ListarRecursivo(raiz.Derecho, nodos);
            }
        }


        // Determinar el Nivel del árbol binario
        public int Nivel(Nodo nodo)
        {
            int i = 0;
            int d = 0;

            if (nodo.Izquierdo != null)
            {
                i = Nivel(nodo.Izquierdo);
            }
            if (nodo.Derecho != null)
            {
                d = Nivel(nodo.Derecho);
            }
            if (i >= d)
            {
                return i + 1;
            }
            else
            {
                return d + 1;
            }
        }

        public void Equilibrar()
        {
            List<Nodo> lista = Listar(Raiz);
            int Cantidad = lista.Count;
            Nodo[] nodos = new Nodo[Cantidad];
            int i = 0;  
            foreach (Nodo n in lista)
            {
                nodos[i] = n;
                i++;
            }
            Raiz = null;
            EquilibrarRecursivo(nodos, 0, Cantidad-1);
            Raiz= nodos[Cantidad/2];
        }

        private void EquilibrarRecursivo(Nodo[] nodos, int ini, int fin)
        {
            if(ini <= fin)
            {
                int m = (ini + fin) / 2;
                Nodo nodo = nodos[m];
                nodo.Izquierdo = null;
                nodo.Derecho = null;    
                Insertar(nodo);
                EquilibrarRecursivo(nodos, ini, m - 1);
                EquilibrarRecursivo(nodos, m + 1, fin);
            }
        }
    }
}
