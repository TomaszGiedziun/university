using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrzychodniaLekarska
{
    public interface IDBEntity
    {
        [Key]
        int ID { get; set; }
        bool IsDeleted { get; set; }
    }
}