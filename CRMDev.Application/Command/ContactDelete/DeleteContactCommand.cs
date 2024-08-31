using MediatR;

namespace CRMDev.Application.Command.ContactDelete
{
    public class DeleteContactCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
