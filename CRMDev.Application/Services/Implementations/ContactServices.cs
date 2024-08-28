using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;

namespace CRMDev.Application.Services.Implementations
{
    public class ContactServices : IContactServices
    {
        private readonly CRMDevDbContext _dbContext;

        public ContactServices(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var contact = _dbContext.Contacts
                .FirstOrDefault(a => a.Id == id);

            contact?.DeleteContact();

            SaveChanges();
        }

        public List<ContactVM> GetAll(string query)
        {
            var contacts = _dbContext.Contacts
                .Where(c => c.IsActive == true)
                .Select(c => new ContactVM(c.Name, c.Email, c.Phone, c.FieldOrIndustry.FieldName, c.Position))
                .ToList();

            return contacts;
        }

        public ContactDetailVM GetOne(int id)
        {
            return CreateContactDetailVM(id);
        }

        public ContactDetailVM Post(ContactCreateInputModel newContact)
        {
            var field = _dbContext.FieldOrIndustries.FirstOrDefault(f => f.Id == newContact.FieldOrIndustryId);

            var contact = new Contact(newContact.Name, newContact.Email, newContact.Phone, newContact.CellPhone, field, newContact.Position, newContact.Address);

            _dbContext.Contacts
                .Add(contact);
 
            SaveChanges();

            return CreateContactDetailVM(contact.Id);
        }

        public ContactDetailVM Put(int id, ContactEditInputModel contactEditInputModel)
        {
            var contactNewInfo = new Contact(
                contactEditInputModel.Name,
                contactEditInputModel.Email,
                contactEditInputModel.Phone,
                contactEditInputModel.CellPhone,
                contactEditInputModel.FieldOrIndustry,
                contactEditInputModel.Position,
                contactEditInputModel.Address
            );

            var contactToBeEdited = _dbContext.Contacts
                .FirstOrDefault(c => c.Id == id);

            contactToBeEdited?.EditContact(contactNewInfo);

            SaveChanges();

            return CreateContactDetailVM(contactToBeEdited.Id);
        }


        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private ContactDetailVM CreateContactDetailVM(int id)
        {
            var contactVM = _dbContext.Contacts
               .Where(c => c.Id == id)
               .Select(c => new ContactDetailVM(
                   c.Name,
                   c.Email,
                   c.Phone,
                   c.CellPhone,
                   c.FieldOrIndustry.FieldName,
                   c.Position,
                   c.Address,
                   c.IsActive.ToString(),
                   c.Notes)
               )
               .FirstOrDefault();

            return contactVM;
        }
    }
}
