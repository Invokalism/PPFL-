using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListReport1._3.Models;

namespace ListReport1._3.Data
{
    public class ShippingDetailsContext : DbContext
    {
        public ShippingDetailsContext (DbContextOptions<ShippingDetailsContext> options)
            : base(options)
        {
        }

        public DbSet<ListReport1._3.Models.ShippingDetails> ShippingDetails { get; set; } = default!;
        public DbSet<Trade> Trades { get; set; }
    }
}
