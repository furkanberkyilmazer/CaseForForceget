using CaseForForceget.EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseForForceget.DataAccessLayer.Context
{
    public class DbContextForceget : DbContext
    {
        public DbContextForceget(DbContextOptions options):base(options)
        {
        }

        public DbSet<Offer> Offers { get; set; }

       

    }
}
