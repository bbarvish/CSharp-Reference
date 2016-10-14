using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces.Infrastructure
{
    public interface ICsvReader
    {
        IEnumerable<Person> ImportPersons();
    }
}
