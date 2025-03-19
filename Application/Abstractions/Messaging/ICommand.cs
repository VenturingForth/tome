using MediatR;
using SharedKernel;

namespace Application.Abstractions.Messaging;

// Interface representing a command that does not have a return value
public interface ICommand : IRequest<Result>
{
     
}

// Interface representing a command that has a return value
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}