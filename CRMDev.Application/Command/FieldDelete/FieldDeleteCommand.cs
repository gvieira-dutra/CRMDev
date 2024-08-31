using MediatR;

namespace CRMDev.Application.Command.FieldDelete
{
    public class FieldDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
