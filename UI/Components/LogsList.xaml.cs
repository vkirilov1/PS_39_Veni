using DataLayer.Database;
using DataLayer.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();

            using (var dbContext = new DatabaseContext())
            {
                dbContext.Database.EnsureCreated();
                var records = dbContext.Logs.ToList();
                logs.DataContext = records;
            }
        }
        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (logs.SelectedItem is DBLogEntry selectedLog)
            {
                string formattedException = selectedLog.Exception == null ? "N/A" : selectedLog.Exception;
                string logDetails = $"Date: {selectedLog.Timestamp:yyyy-MM-dd HH:mm:ss}\n" +
                                    $"LogLevel: {selectedLog.LogLevel}\n" +
                                    $"Message: {selectedLog.Message}\n" +
                                    $"Exception: {formattedException}";

                MessageBox.Show(logDetails, "Log Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
