using DataLayer.Database;
using System.Windows.Controls;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();

            using (var dbContext = new DatabaseContext())
            {
                dbContext.Database.EnsureCreated();
                var records = dbContext.Users.ToList();
                students.DataContext = records;
            }
        }
    }
}
