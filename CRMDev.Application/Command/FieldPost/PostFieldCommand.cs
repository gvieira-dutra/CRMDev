using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.FieldPost
{
    public class PostFieldCommand : IRequest<FieldOrIndustryVM>
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
    }
}
