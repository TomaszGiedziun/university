using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaLekarska.Models;

namespace PrzychodniaLekarska
{
    public interface IPacjentService
    {
        void AddPacjent(PacjentModel pacjent);
        List<PacjentModel> GetAllPacjent();
        void EditPacjent(PacjentModel pacjent);
        void DeletePacjentById(int pacjentId);
        void DeletePacjent(PacjentModel pacjent);
        PacjentModel GetPacjentById(int pacjentId);
    }
}
