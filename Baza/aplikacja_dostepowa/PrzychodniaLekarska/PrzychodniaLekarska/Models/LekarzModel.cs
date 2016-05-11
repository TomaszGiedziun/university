using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaLekarska.Models
{
    public class LekarzModel
    {
        public int ID { get; set; }
        public string MailAddress { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public int? SekretarkaId { get; set; }

        public bool Vacation { get; set; }
        public DateTime VacationStartTime { get; set; }
        public DateTime VacationEndTime { get; set; }

        public DateTime WorkStartTime { get; set; }
        public DateTime WorkEndTime { get; set; }
        
    }
}