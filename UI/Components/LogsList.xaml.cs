using System.Windows.Controls;
using UI.ViewModel;

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
            LogsViewModel LogsViewModel = new();
            DataContext = LogsViewModel;
        }
    }
}
