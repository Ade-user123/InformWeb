using InformWeb.Repository.Entities;
using InformWeb.Repository.Interface;
using InformWeb.Service.Interface;
using System;
using System.Collections.Generic;


namespace InformWeb.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(Contact entity)
        {
            _contactRepository.Add(entity);
            // commit the to database
            _unitOfWork.commit();
        }

        public void Delete(Guid Id)
        {
            _contactRepository.Delete(Id);
            // commit the to database
            _unitOfWork.commit();
        }

        public Contact GetById(Guid Id)
        {
            return _contactRepository.GetById(Id).GetAwaiter().GetResult();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll().GetAwaiter().GetResult();
        }

        public void Update(Contact entity)
        {
            _contactRepository.Update(entity);
            // commit the to database
            _unitOfWork.commit();
        }
    }
}
