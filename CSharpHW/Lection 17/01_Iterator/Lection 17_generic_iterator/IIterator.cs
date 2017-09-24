using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_17_generic_iterator
{
    public interface IIterator<T>
    {
        T First();

        T Next();

        bool IsDone();

        T CurrentItem();
    }
}
