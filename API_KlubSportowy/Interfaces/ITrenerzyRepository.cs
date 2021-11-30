using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Interfaces
{
    public interface ITrenerzyRepository
    {
        Trenerzy Get(int TrenerId);
        IEnumerable<Trenerzy> GetAll();
        Trenerzy Post(Trenerzy newTrener);
        Trenerzy Put(Trenerzy updatedTrener);
        Trenerzy Delete(int TrenerId);
    }
}
