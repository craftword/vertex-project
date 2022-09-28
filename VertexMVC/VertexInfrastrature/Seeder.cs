using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VertexCore.Models;

namespace VertexInfrastrature
{
    public class Seeder
    {
        public static async Task SeedData(AppDbContext dbContext)
        {
            var baseDir = Directory.GetCurrentDirectory();

            var res = await dbContext.Database.EnsureCreatedAsync();

            if (!dbContext.Users.Any())
            {
                var path = File.ReadAllText(FilePath(baseDir, "data.json"));

                var users = JsonConvert.DeserializeObject<List<User>>(path);

                await dbContext.AddRangeAsync(users);
                
            }


            await dbContext.SaveChangesAsync();
        }

        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
