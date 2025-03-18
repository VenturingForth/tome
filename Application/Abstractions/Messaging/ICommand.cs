namespace Application.Abstractions.Messaging;

// Interface representing a command that does not have a return value
public interface ICommand : IBaseCommand
{
    
}

// Interface representing a command that has a return value
public interface ICommand<TResponse> : IBaseCommand
{
    
}

// An interface that can give a generic way of implementing the above two interfaces
public interface IBaseCommand
{
    
}