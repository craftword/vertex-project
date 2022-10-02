using System;
using Microsoft.EntityFrameworkCore;
using VertexCore.Models;
using VertexInfrastrature;

namespace VertexTest
{
    public abstract class InMemoryTestBase
    {
        protected AppDbContext DbContext { get; private set; }

        protected InMemoryTestBase()
        {
            Init();
        }

        protected abstract void Reset();

        private void Init()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("AppDbContext")
                .Options;

            DbContext = new AppDbContext(options);

            Populate();
            DbContext.SaveChanges();

            Reset();
        }

        private void Populate()
        {
            DbContext.Database.EnsureDeleted();

            PopulateApplicationUserData();
        }

        private void PopulateApplicationUserData()
        {
            DbContext.Set<User>().AddRange(Helper.GetAllUsers());
            
        }
    }
}
