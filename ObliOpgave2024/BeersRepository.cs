using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObliOpgave2024
{
    public class BeersRepository
    {
        private int _nextId = 6;
        private List<Beer> _beers = new()
        {
            new Beer {Id = 1, Name = "Carlsberg", Abv = 27.2 },
            new Beer {Id = 2, Name = "Tuborg", Abv = 30.7},
            new Beer {Id = 3, Name = "Grimbergen", Abv = 50.5},
            new Beer {Id = 4, Name = "Heineken", Abv = 12.0},
            new Beer {Id = 5, Name = "Salikatt", Abv = 8.9}
        };

        public IEnumerable<Beer> GetBeers(double? Abv = null, string? NameSort = null, string? OrderBy = null)
        {
            IEnumerable<Beer> result = new List<Beer>(_beers);
            //Filtering
            if(Abv != null)
            {
                result = result.Where(b => b.Abv > Abv);
            }

            if(NameSort != null)
            {
                result = result.Where(n => n.Name.StartsWith(NameSort));
            }
            // Ordering
            if (OrderBy != null)
            {
                OrderBy = OrderBy.ToLower();
                switch (OrderBy)
                {
                    case "Name":
                    case "Name ascending":
                        result = result.OrderBy(n => n.Name);
                        break;
                    case "title descending":
                        result = result.OrderByDescending(n => n.Name);
                        break;
                    case "Abv":
                    case "Abv ascending":
                        result = result.OrderBy(b => b.Abv);
                        break;
                    case "year descending":
                        result = result.OrderByDescending(b => b.Abv);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
        public Beer? GetById(int id)
        {
            return _beers.Find(beer => beer.Id == id);
        }

        public Beer Add(Beer beer)
        {
            beer.Validate();
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }

        public Beer? Remove(int id)
        {
            Beer? beer = GetById(id);
            if (beer == null)
            {
                return null;
            }
            _beers.Remove(beer);
            return beer;
        }

        public Beer? Update(int id, Beer beer)
        {
            beer.Validate();
            Beer? existingBeer = GetById(id);
            if (existingBeer == null)
            {
                return null;
            }
            existingBeer.Name = beer.Name;
            existingBeer.Abv = beer.Abv;
            return existingBeer;
        }
    }
}
