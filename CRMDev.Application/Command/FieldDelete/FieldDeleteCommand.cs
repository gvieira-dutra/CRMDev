using MediatR;

namespace CRMDev.Application.Command.FieldDelete
{
    public class FieldDeleteCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
