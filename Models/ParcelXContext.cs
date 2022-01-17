using System;
using Microsoft.EntityFrameworkCore;

namespace ParcelX.Models
{
    public class ParcelXContext : DbContext
    {
        public ParcelXContext(DbContextOptions<ParcelXContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ParcelXCusModel> Px_Customers { get; set; }
        public virtual DbSet<ParcelXParModel> Px_Partners { get; set; }


    }
}
