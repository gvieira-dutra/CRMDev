namespace CRMDev.Core.Entities
{
    public class FieldOrIndustry : BaseClass
    {
        public FieldOrIndustry(string fieldName)
        {
            FieldName = fieldName;
        }

        public string FieldName { get; private set; }
    }
}
