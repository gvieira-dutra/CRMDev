using CRMDev.Application.InputModels;
using CRMDev.Core.Entities;

namespace CRMDev.Application.Services.Interfaces
{
    public interface IFieldServices
    {
        List<FieldOrIndustry> GetAll(string query);
        FieldOrIndustry GetOne(int id);
        FieldOrIndustry Post(FieldInputModel newField);
        FieldOrIndustry Put(int id, FieldInputModel newFieldInfo);
        void Delete(int id);
        
    }
}
