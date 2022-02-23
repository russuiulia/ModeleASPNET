#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModeleASPNET.Models;

namespace ModeleASPNET.Data
{
    public class ModeleASPNETContext : DbContext
    {
        public ModeleASPNETContext (DbContextOptions<ModeleASPNETContext> options)
            : base(options)
        {
        }

        public DbSet<ModeleASPNET.Models.Librarie> Librarie { get; set; }
    }
}
