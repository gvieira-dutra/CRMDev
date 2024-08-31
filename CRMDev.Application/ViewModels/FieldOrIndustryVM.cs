namespace CRMDev.Application.ViewModels
{
    public class FieldOrIndustryVM
    {
        public FieldOrIndustryVM(string fieldName, string description)
        {
            FieldName = fieldName;
            Description = description;
        }

        public string FieldName { get; set; }
        public string Description { get; set; }
    }
}
