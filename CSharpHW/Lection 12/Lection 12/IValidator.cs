using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_12
{
    interface IValidator
    {
        bool ValidateUser(IUser user);
    }
}
