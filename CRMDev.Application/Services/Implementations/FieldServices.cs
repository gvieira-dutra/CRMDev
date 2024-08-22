using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;

namespace CRMDev.Application.Services.Implementations
{
    public class FieldServices : IFieldServices
    {
        private readonly CRMDevDbContext _dbContext;

        public FieldServices(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {

            var toBeDeleted = _dbContext.FieldOrIndustries
                .FirstOrDefault(f => f.Id == id);
            
            _dbContext.FieldOrIndustries
                .Remove(toBeDeleted);
                
        }

        public List<FieldOrIndustry> GetAll(string query)
        {
            var fields = _dbContext.FieldOrIndustries
                .ToList() ;

            return fields;
        }

        public FieldOrIndustry GetOne(int id)
        {
            var field = _dbContext.FieldOrIndustries
                .FirstOrDefault(f => f.Id == id);

            return field;
        }

        public FieldOrIndustry Post(FieldInputModel newField)
        {
            var field = new FieldOrIndustry(
                newField.FieldName,
                newField.Description
            );

            _dbContext.FieldOrIndustries
                .Add(field);

            return (GetOne(0));
        }

        public FieldOrIndustry Put(int id, FieldInputModel newFieldInfo)
        {
            var fieldToBeEdited = _dbContext.FieldOrIndustries
                .FirstOrDefault(f => f.Id == id);

            var fieldNewInfo = new FieldOrIndustry
                (
                    newFieldInfo.FieldName,
                    newFieldInfo.Description
                );

            fieldToBeEdited?.EditField(fieldNewInfo);

            return fieldToBeEdited;
        }
    }
}
