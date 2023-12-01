using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var generatedUsername = words[0].ToLower() + new Random().Next(1000, 9999).ToString();

            var user = entities.users.Where(u => u.username == generatedUsername).FirstOrDefault();
            if (user != null)
            {
                GetUsername(fullName, entities);
            }
            
            return generatedUsername;
        }
    }
}
