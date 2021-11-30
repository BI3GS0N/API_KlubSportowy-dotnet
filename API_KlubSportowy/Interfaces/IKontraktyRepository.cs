using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Interfaces
{
    public interface IKontraktyRepository
    {
        Kontrakty Get(int KontraktyId);
        IEnumerable<Kontrakty> GetAll();
        Kontrakty Post(Kontrakty newKontrakty);
        Kontrakty Put(Kontrakty updatedKontrakty);
        Kontrakty Delete(int KontraktyId);
    }
}
