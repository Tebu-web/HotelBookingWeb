using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Models;

namespace HotelBookingWeb.Data
{
    public class HotelBookingWebContext : DbContext
    {
        public HotelBookingWebContext (DbContextOptions<HotelBookingWebContext> options)
            : base(options)
        {
        }

        public DbSet<HotelBookingWeb.Models.Camera> Camera { get; set; } = default!;

        public DbSet<HotelBookingWeb.Models.Client>? Client { get; set; }

        public DbSet<HotelBookingWeb.Models.Rezervare>? Rezervare { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CameraFacilitate>()
                .HasKey(cf => new { cf.CameraId, cf.FacilitateId });

            modelBuilder.Entity<CameraFacilitate>()
                .HasOne(cf => cf.Camera)
                .WithMany(c => c.CameraFacilitati)
                .HasForeignKey(cf => cf.CameraId);

            modelBuilder.Entity<CameraFacilitate>()
                .HasOne(cf => cf.Facilitate)
                .WithMany(f => f.CameraFacilitati)
                .HasForeignKey(cf => cf.FacilitateId);
            modelBuilder.Entity<Recenzie>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Recenzii) 
                .HasForeignKey(r => r.ClientId);
        }
        public DbSet<HotelBookingWeb.Models.CameraFacilitate>? CameraFacilitate { get; set; }
        public DbSet<HotelBookingWeb.Models.Facilitate>? Facilitate { get; set; }
        public DbSet<Recenzie>? Recenzie { get; set; }

    }
}
