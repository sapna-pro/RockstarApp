using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SongsListContext : DbContext
    {
        public SongsListContext (DbContextOptions<SongsListContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.SongsList> SongsList { get; set; }
    }
}
