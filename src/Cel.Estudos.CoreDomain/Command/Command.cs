using MediatR;

namespace Cel.Estudos.CoreDomain.Command
{
    public class Command<T> : ICommand, IRequest<T>
    {
        public Guid CorrelationId { get; set; }

        public Command()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}
