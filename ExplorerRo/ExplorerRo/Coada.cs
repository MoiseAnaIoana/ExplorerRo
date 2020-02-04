using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerRo
{
    public class Nod
    {
        public int i, j, val;
        public Nod(int i, int j, int val)
        {
            this.i = i;
            this.j = j;
            this.val = val;
        }
    }

    public class Coada
    {
        public int dim;
        public Nod[] values;
        public Coada()
        {
            dim = 0;
            values = new Nod[dim];
        }

        public void Push(Nod n)
        {
            dim++;
            Nod[] aux = new Nod[dim];
            aux[0] = n;
            for (int i = 1; i < dim; i++)
                aux[i] = values[i - 1];
            values = aux;
        }

        public Nod Pop()
        {
            dim--;
            Nod[] aux = new Nod[dim];
            for (int i = 0; i < dim; i++)
                aux[i] = values[i];
            Nod a = values[dim];
            values = aux;
            return a;
        }

    }
}
