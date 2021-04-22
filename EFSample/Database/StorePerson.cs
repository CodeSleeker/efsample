using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    public class StorePerson : IPerson
    {
        protected DataDBContext dBContext;
        public StorePerson(DataDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task AddPerson(Person person)
        {
            dBContext.PersonData.Add(person);
            await dBContext.SaveChangesAsync();
        }

        public async Task EnsurePersonStore()
        {
            await dBContext.Database.EnsureCreatedAsync();
        }

        public Task<List<Person>> GetPersons()
        {
            return Task.FromResult(dBContext.PersonData.ToList());
        }

        public async Task<bool> HasData()
        {
            return dBContext.PersonData.Count() > 0;
        }

        public async Task RemovePerson(Person person)
        {
            dBContext.PersonData.Remove(person);
            await dBContext.SaveChangesAsync();
        }

        public async Task SavePerson(Person person)
        {
            dBContext.PersonData.RemoveRange(dBContext.PersonData);
            dBContext.PersonData.Add(person);
            await dBContext.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person person)
        {
            dBContext.PersonData.Update(person);
            await dBContext.SaveChangesAsync();
        }
    }
}
