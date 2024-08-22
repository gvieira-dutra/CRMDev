﻿namespace CRMDev.Core.Entities
{
    public class FieldOrIndustry : BaseClass
    {
        public FieldOrIndustry(string fieldName, string descrip)
        {
            FieldName = fieldName;
            Description = descrip;
        }

        public string FieldName { get; private set; }
        public string Description { get; private set; }

        public void EditField(FieldOrIndustry newInfo)
        {
            FieldName = string.IsNullOrEmpty(newInfo.FieldName ) ? FieldName : newInfo.FieldName;

            Description = string.IsNullOrEmpty(newInfo.Description) ? Description : newInfo.Description;
        }
    }
}
