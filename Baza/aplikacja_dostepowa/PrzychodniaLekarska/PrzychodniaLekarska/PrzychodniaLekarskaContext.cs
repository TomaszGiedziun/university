using PrzychodniaLekarska.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrzychodniaLekarska
{
    public class PrzychodniaLekarskaContext : DbContext
    {
        public PrzychodniaLekarskaContext()
        {
            base.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<PrzychodniaLekarskaContext>(null);
        }

        public DbSet<PacjentModel> Pacjent { get; set; }
        public DbSet<SekretarkaModel> Sekretarka { get; set; }
        //public DbSet<FloorDTO> Floors { get; set; }
        //public DbSet<RoomDTO> Rooms { get; set; }
        //public DbSet<LogsDTO> Logs { get; set; }
        //public DbSet<OfficeDTO> Offices { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacjentModel>().ToTable("Pacjent");
            modelBuilder.Entity<SekretarkaModel>().ToTable("Sekretarka");
            //    modelBuilder.Entity<FloorDTO>().ToTable("Floors");
            //    modelBuilder.Entity<RoomDTO>().ToTable("Rooms");
            //    modelBuilder.Entity<LogsDTO>().ToTable("Logs");
            //    modelBuilder.Entity<OfficeDTO>().ToTable("Offices");

            //    modelBuilder.Entity<UserDTO>().HasOptional(x => x.Desk).WithMany().HasForeignKey(x => x.DeskId);
            //    modelBuilder.Entity<DeskDTO>().HasOptional(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}

