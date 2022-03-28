using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NguyenVanCuong2022560;

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<NguyenTuanAnh2022201.PersonNTA2022201> PersonNTA2022201 { get; set; }

        public DbSet<NguyenTuanAnh2022201.NTA0201> NTA0201 { get; set; }
    }