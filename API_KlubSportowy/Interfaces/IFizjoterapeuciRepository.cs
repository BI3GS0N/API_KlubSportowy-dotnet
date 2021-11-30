using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Interfaces
{
    public interface IFizjoterapeuciRepository
    {
        Fizjoterapeuci Get(int FizjoterapeuciId);
        IEnumerable<Fizjoterapeuci> GetAll();
        Fizjoterapeuci Post(Fizjoterapeuci newFizjoterapeuci);
        Fizjoterapeuci Put(Fizjoterapeuci updatedFizjoterapeuci);
        Fizjoterapeuci Delete(int FizjoterapeuciId);
    }
}
