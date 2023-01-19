using InformWeb.Repository.Common;
using InformWeb.Repository.Entities;
using InformWeb.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformWeb.Repository.Implementation
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public async Task Add(Contact entity)
        {
            DbContext.Add(entity);
        }

        public async Task Delete(Guid Id)
        {
            var data = DbContext.Contacts.FirstOrDefault(s => s.Id == Id);
            DbContext.Remove(data);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return DbContext.Contacts;
        }

        public async Task<Contact> GetById(Guid Id)
        {
            return DbContext.Contacts.FirstOrDefault(s => s.Id == Id);
        }

        public async Task Update(Contact entity)
        {
            var contactData = DbContext.Contacts.FirstOrDefault(d => d.Id == entity.Id);
            if (contactData != null)
            {
                contactData.Email = entity.Email;
                contactData.FirstName = entity.FirstName;
                contactData.LastName = entity.LastName;
                contactData.PhoneNumber = entity.PhoneNumber;
            }
            DbContext.Contacts.Attach(contactData);
            DbContext.Entry(contactData).State = EntityState.Modified;
        }
    }
}
