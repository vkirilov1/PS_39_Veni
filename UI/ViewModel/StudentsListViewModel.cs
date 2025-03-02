using DataLayer.Database;
using DataLayer.Model;

namespace UI.ViewModel
{
    public class StudentsListViewModel
    {
        private readonly List<DatabaseUser> _studentsRecords;
        public StudentsListViewModel()
        {
            using (var dbContext = new DatabaseContext())
            {
                dbContext.Database.EnsureCreated();
                _studentsRecords = dbContext.Users.ToList();
            }
        }

        public List<DatabaseUser> StudentsRecords
        {
            get { return _studentsRecords; }
        }
    }
}
