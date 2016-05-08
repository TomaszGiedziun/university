using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaLekarska.Models
{
    public class SekretarkaModel : IDBEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public string MailAddress { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}