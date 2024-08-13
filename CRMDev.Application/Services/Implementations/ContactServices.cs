using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Application.ViewModels;

namespace CRMDev.Application.Services.Implementations
{
    internal class ContactServices : IContactServices
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactVM> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public ContactDetailVM GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public ContactDetailVM Post(ContactCreateInputModel contactCreateInputModel)
        {
            throw new NotImplementedException();
        }

        public ContactDetailVM Put(ContactEditInputModel contactEditInputModel)
        {
            throw new NotImplementedException();
        }
    }
}
