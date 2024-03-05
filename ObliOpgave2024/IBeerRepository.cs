using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObliOpgave2024
{
    public interface IBeerRepository
    {
        Beer Add(Beer beer);
        IEnumerable<Beer> Get(int? Id = null, string? Name = null, int? Abv = null, string OrderBy = null);
        Beer? GetById(int id);
        Beer? Remove(int id);
        Beer? Update(int id, Beer beer);
    }
}
