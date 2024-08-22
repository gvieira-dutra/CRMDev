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
            var contact = _dbContext.Contacts
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

            return contact;
        }

        public ContactDetailVM Post(ContactCreateInputModel newContact)
        {
            var contact = new Contact(newContact.Name, newContact.Email, newContact.Phone, newContact.CellPhone, newContact.FieldOrIndustry, newContact.Position, newContact.Address, newContact.Note);

            _dbContext.Contacts
                .Add(contact);
            /*
                                    {
                                        "name": "Gleison Vieira",
                          "email": "gv@mail.com",
                          "phone": "(123) 456-7890",
                          "cellPhone": "n/a",
                          "fieldOrIndustry": {
                                            "fieldName": "sales"
                          },
                          "position": "Sales Manager",
                          "address": "399 Spadina Ave",
                          "note": {
                                            "content": "Friend's recommendation"
                          }
                                    }

             */
            var contactVM = _dbContext.Contacts
               .Where(c => c.Id == contact.Id)
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
