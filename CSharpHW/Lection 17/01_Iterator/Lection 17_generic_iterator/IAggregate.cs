using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_17_generic_iterator
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}
