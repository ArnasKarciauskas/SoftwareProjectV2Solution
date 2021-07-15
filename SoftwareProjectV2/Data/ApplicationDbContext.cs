using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SoftwareProjectV2.Models;

namespace SoftwareProjectV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SoftwareProjectV2.Models.AddDetail> AddDetail { get; set; }
        public DbSet<SoftwareProjectV2.Models.AddEquipment> AddEquipment { get; set; }
        public DbSet<SoftwareProjectV2.Models.Inventory> Inventory { get; set; }
    }
}
