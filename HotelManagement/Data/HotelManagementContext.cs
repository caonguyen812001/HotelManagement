using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Models.HotelManagement;

namespace HotelManagement.Data
{
    public class HotelManagementContext : DbContext
    {
        public HotelManagementContext (DbContextOptions<HotelManagementContext> options)
            : base(options)
        {
        }

        public DbSet<HotelManagement.Models.HotelManagement.Hotel> Hotels { get; set; } = default!;
        public DbSet<HotelManagement.Models.HotelManagement.RoomType> RoomTypes { get; set; }
    }
}
