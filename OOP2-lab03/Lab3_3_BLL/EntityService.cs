using Lab3_3_DAL.DataProvider;
using Lab3_3_DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_3_BLL
{
    public class EntityService
    {
        private readonly IDataProvider _provider;

        public EntityService(IDataProvider provider)
        {
            _provider = provider;
        }

        public void SaveAccounts(List<Account> accounts, string path) =>
            _provider.Serialize(accounts, path);

        public List<Account> LoadAccounts(string path) =>
            _provider.Deserialize<List<Account>>(path);

        public void SaveStudents(List<Student> students, string path) =>
            _provider.Serialize(students, path);

        public List<Student> LoadStudents(string path) =>
            _provider.Deserialize<List<Student>>(path);

        public int CountDormStudents(List<Student> students) =>
            students.Count(s => s.Course == 5 && s.LivesInDorm);
    }
}
