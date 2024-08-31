using MediatR;

namespace CRMDev.Application.Command.ContactDelete
{
    public class DeleteContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
