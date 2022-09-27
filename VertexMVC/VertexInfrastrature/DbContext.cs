using System;
using Microsoft.EntityFrameworkCore;
using VertexCore.Models;

namespace VertexInfrastrature
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
