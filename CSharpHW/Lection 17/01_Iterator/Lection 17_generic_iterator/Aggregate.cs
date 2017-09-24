using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_17_generic_iterator
{
    public class Aggregate<Type>: IAggregate<Type>
    {
        private readonly List<Type> _items = new List<Type>();

        public IIterator<Type> CreateIterator()
        {
            return new Iterator<Type>(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public Type this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }

        
    }
}
