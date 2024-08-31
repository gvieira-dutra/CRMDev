using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.FieldPut
{
    public class PutFieldCommand : IRequest<FieldOrIndustryVM>
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
    }
}
