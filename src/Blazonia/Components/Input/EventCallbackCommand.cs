using System.ComponentModel;
using System.Windows.Input;

namespace Blazonia.Components.Input;

/// <remarks>Experimental API, subject to change.</remarks>
[EditorBrowsable(EditorBrowsableState.Never)]
public class EventCallbackCommand : ICommand
{
    private readonly Action<object> _eventCallbackAction;

    public EventCallbackCommand(Action eventCallbackAction)
    {
        _eventCallbackAction = _ => eventCallbackAction();
    }

    public EventCallbackCommand(Action<object> eventCallbackAction)
    {
        _eventCallbackAction = eventCallbackAction;
    }

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
        _eventCallbackAction(parameter);
    }

    event EventHandler ICommand.CanExecuteChanged
    {
        add { }
        remove { }
    }
}
