using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMDev.Application.ViewModels
{
    public class OpportunityVM(int id, string title, string description, decimal estimative)
    {
        public int Id { get; private set; } = id;
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public decimal Estimative { get; private set; } = estimative;

    }
}
