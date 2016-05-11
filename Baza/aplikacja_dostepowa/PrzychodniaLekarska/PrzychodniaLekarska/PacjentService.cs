using PrzychodniaLekarska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaLekarska
{
    public class PacjentService: IPacjentService
    {
        public void AddPacjent(PacjentModel pacjent)
        {
            IRepository<PacjentModel> pacjentRepository = new Repository<PacjentModel>();
            pacjentRepository.Add(pacjent);
        }

        public List<PacjentModel> GetAllPacjent()
        {
            IRepository<PacjentModel> pacjentRepository = new Repository<PacjentModel>();
            List<PacjentModel> pacjents = pacjentRepository.FindAll().ToList();

            return pacjents;
        }

        public void EditPacjent(PacjentModel pacjent)
        {
            IRepository<PacjentModel> pacjentRepository = new Repository<PacjentModel>();
            pacjentRepository.Update(pacjent);
        }

        public void DeletePacjentById(int pacjentId)
        {
            IRepository<PacjentModel> pacjentRepository = new Repository<PacjentModel>();
            PacjentModel pacjent = pacjentRepository.FindById(pacjentId);
            pacjentRepository.Delete(pacjent);
        }

        public PacjentModel GetPacjentById(int pacjentId)
        {
            IRepository<PacjentModel> pacjentRepository = new Repository<PacjentModel>();
            PacjentModel pacjent = pacjentRepository.FindById(pacjentId);
            
            return pacjent;
        }

        public void DeletePacjent(PacjentModel pacjent)
        {
            IRepository<PacjentModel> pacjentRepository = new Repository<PacjentModel>();
            pacjentRepository.Delete(pacjent);
        }

    }
}