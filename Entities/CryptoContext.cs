using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CryptoContext : DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options) :base(options)
        {
                
        }
       // public DbSet<RateResponse> RateResponse { get; set; }
        public DbSet<Rate> Rates { get; set; }

    }
}
