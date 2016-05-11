using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrzychodniaLekarska.Models;

namespace PrzychodniaLekarska
{
    public class SekretarkaService: ISekretarkaService
    {
        public void AddSekretarka(SekretarkaModel sekretarka)
        {
            IRepository<SekretarkaModel> sekretarkaRepository = new Repository<SekretarkaModel>();
            sekretarkaRepository.Add(sekretarka);
        }

        public List<SekretarkaModel> GetAllSekretarka()
        {
            IRepository<SekretarkaModel> sekretarkaRepository = new Repository<SekretarkaModel>();
            List<SekretarkaModel> sekretarkaList = sekretarkaRepository.FindAll().ToList();

            return sekretarkaList;
        }

        public void EditSekretarka(SekretarkaModel sekretarka)
        {
            IRepository<SekretarkaModel> sekretarkaRepository = new Repository<SekretarkaModel>();
            sekretarkaRepository.Update(sekretarka);
        }

        public void DeleteSekretarkaById(int sekretarkaId)
        {
            IRepository<SekretarkaModel> sekretarkaRepository = new Repository<SekretarkaModel>();
            SekretarkaModel sekretarka = sekretarkaRepository.FindById(sekretarkaId);
            sekretarkaRepository.Delete(sekretarka);
        }

        public SekretarkaModel GetSekretarkaById(int sekretarkaId)
        {
            IRepository<SekretarkaModel> pacjentRepository = new Repository<SekretarkaModel>();
            SekretarkaModel sekretarka = pacjentRepository.FindById(sekretarkaId);

            return sekretarka;
        }

        public void DeleteSekretarka(SekretarkaModel sekretarka)
        {
            IRepository<SekretarkaModel> pacjentRepository = new Repository<SekretarkaModel>();
            pacjentRepository.Delete(sekretarka);
        }
    }
}