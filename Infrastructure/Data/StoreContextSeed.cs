using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Reflection;


namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if(!context.Users.Any())
                {
                    var userData = File.ReadAllText("../Infrastructure/Data/SeedData/users.json");

                    var users = JsonSerializer.Deserialize<List<User>>(userData);

                    foreach (var user in users)
                    {
                        context.Users.Add(user);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.Assignments.Any())
                {
                    var assignmentData = File.ReadAllText("../Infrastructure/Data/SeedData/assignments.json");

                    var assignments = JsonSerializer.Deserialize<List<Assignment>>(assignmentData);

                    foreach (var assignment in assignments)
                    {
                        context.Assignments.Add(assignment);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
               var logger = loggerFactory.CreateLogger<StoreContextSeed>();
               logger.LogError(ex.Message);
            }
        }
    }
}