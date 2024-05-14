using MediatR;

namespace BuildingBlocks.CQRS
{
    // no reponse necessary
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }

    // must have response
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }
}
