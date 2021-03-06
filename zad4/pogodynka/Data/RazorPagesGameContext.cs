using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class RazorPagesGameContext : DbContext
    {
        public RazorPagesGameContext (DbContextOptions<RazorPagesGameContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }

        public DbSet<Weather> Weather { get; set; }
    }
