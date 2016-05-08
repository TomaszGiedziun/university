using PrzychodniaLekarska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaLekarska
{
    interface ISekretarkaService
    {
        void AddSekretarka(SekretarkaModel sekretarka);
        List<SekretarkaModel> GetAllSekretarka();
        void EditSekretarka(SekretarkaModel sekretarka);
        void DeleteSekretarkaById(int sekretarkaId);
        void DeleteSekretarka(SekretarkaModel pacjent);
        SekretarkaModel GetSekretarkaById(int sekretarkaId);
    }
}
