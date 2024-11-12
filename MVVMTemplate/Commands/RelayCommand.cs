using System.Windows.Input;

namespace MVVMTemplate.Commands
{
    /// <summary>
    /// A command that allows for the execution of an action and optionally defines whether the command can execute.
    /// Implements the <see cref="ICommand"/> interface.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The action to execute when the command is invoked.</param>
        /// <param name="canExecute">A function that determines if the command can execute. Can be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="execute"/> parameter is null.</exception>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Occurs when the value of <see cref="CanExecute"/> changes.
        /// Used to notify the command manager when it should re-query whether the command can execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">An optional parameter for the command. This is not used in this implementation.</param>
        /// <returns>True if the command can execute; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Executes the command, invoking the <see cref="_execute"/> action.
        /// </summary>
        /// <param name="parameter">An optional parameter for the command. This is not used in this implementation.</param>
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
