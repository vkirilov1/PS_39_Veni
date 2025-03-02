using DataLayer.Database;
using DataLayer.Model;
using System.Windows;
using System.Windows.Input;

namespace UI.ViewModel
{
    public class LogsViewModel : ObservableObject
    {
        private readonly List<DBLogEntry> _logsRecords;
        public ICommand ShowLogDetailsCommand { get; }

        private DBLogEntry? _selectedLog;

        public List<DBLogEntry> LogsRecords
        {
            get { return _logsRecords; }
        }

        public DBLogEntry? SelectedLog
        {
            get { return _selectedLog; }
            set
            {
                _selectedLog = value;
                RaisePropertyChangedEvent(nameof(SelectedLog));

                (ShowLogDetailsCommand as DelegateCommand<DBLogEntry>)?.RaiseCanExecuteChanged();
            }
        }

        public LogsViewModel()
        {
            using (var dbContext = new DatabaseContext())
            {
                dbContext.Database.EnsureCreated();
                _logsRecords = dbContext.Logs.ToList();
            }
            ShowLogDetailsCommand = new DelegateCommand<DBLogEntry>
            (
                ShowLogDetails,
                log => log != null
            );
        }

        private void ShowLogDetails(DBLogEntry? log)
        {
            if (log == null) return;

            String FormattedException = log.Exception ?? "N/A";

            string logDetails = $"LogLevel: {log.LogLevel}\n" +
                                $"Message: {log.Message}\n" +
                                $"Exception: {FormattedException}\n" +
                                $"Date: {log.Timestamp:yyyy-MM-dd HH:mm:ss}\n";

            MessageBox.Show(logDetails, "Log Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
