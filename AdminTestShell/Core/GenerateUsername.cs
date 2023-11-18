using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTestShell.Core
{
    public class GenerateUsername
    {
        public static string GetUsername(string fullName, Database.TestMasterdDBEntities entities)
        {
            var words = fullName.Split(' ');

            var GeneratedUsername = words[0].ToLower() + new Random().Next(1000, 9999).ToString();

            var users = entities.users.ToList();
            foreach (var user in users)
            {
                if (user.username == GeneratedUsername)
                {
                    GetUsername(fullName, entities);
                }

            }
            return GeneratedUsername;
        }
    }
}
