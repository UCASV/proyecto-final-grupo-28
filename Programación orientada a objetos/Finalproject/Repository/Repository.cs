using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalproject.Repository
{
    public interface Repository<T>
    {
        void create(T item);

    }
}
