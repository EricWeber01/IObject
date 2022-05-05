using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObject
{
    interface iRepository
    {
        void Add(string n, int p, int c);
        void Show();
    }
    class PriceComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Good && y is Good)
            {
                if ((x as Good).Price > (y as Good).Price)
                    return 1;
                else if ((x as Good).Price == (y as Good).Price)
                    return 0;
                else if ((x as Good).Price < (y as Good).Price)
                    return -1;
            }
            throw new NotImplementedException();
        }
    }
    class Good : IComparable, ICloneable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Good(string n, int p, int c)
        {
            Name = n;
            Price = p;
            Count = c;
        }
        public override string ToString()
        {

            return $"{Name} | {Price}$ | {Count}";
        }
        public int CompareTo(object obj)
        {
            if (obj is Good)
                return Price.CompareTo((obj as Good).Price);
            throw new NotImplementedException();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    class Repository : iRepository, IEnumerable, ICloneable
    {
        public Good[] g = new Good[0];
        public void Add(string n, int p, int c)
        {
            Array.Resize(ref g, g.Length + 1);
            g[g.Length - 1] = new Good(n, p, c);

        }
        public object Clone()
        {
            Repository temp = new Repository();
            temp.g = new Good[this.g.Length];
            for (int i = 0; i < temp.g.Length; i++)
            {
                temp.g[i] = this.g[i].Clone() as Good;
            }

            return temp;
        }
        public void Sort(IComparer comparer)
        {
            Array.Sort(g, comparer);
        }
        public IEnumerator GetEnumerator()
        {
            return g.GetEnumerator();
        }
        public void Show()
        {
            /*for (int i = 0; i < g.Length; i++)
            {

                g[i].Show();

            }*/
        }
    }
}