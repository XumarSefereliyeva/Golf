using Golf.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.DAL.Contexts
{
    public class AppDbContext:DbContext
    {
     

        public DbSet<GolfPr> golfs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        

    }
}
