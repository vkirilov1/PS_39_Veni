using System.Windows.Input;

namespace UI.ViewModel
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T?> _execute;
        private readonly Predicate<T?>? _canExecute;
        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<T?> execute, Predicate<T?>? canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute((T?)parameter);

        public void Execute(object? parameter) => _execute((T?)parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
