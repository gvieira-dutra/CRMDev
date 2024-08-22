using CRMDev.Application.ViewModels;
using CRMDev.Application.InputModels;

namespace CRMDev.Application.Services.Interfaces
{
    public interface IContactServices
    {
        List<ContactVM> GetAll(string query);
        ContactDetailVM GetOne(int id);
        ContactDetailVM Post(ContactCreateInputModel contactCreateInputModel);
        ContactDetailVM Put(int id, ContactEditInputModel contactEditInputModel);
        void Delete(int id);
    }
}
