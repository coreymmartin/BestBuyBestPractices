using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {

        private readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateDepartment(string Name)
        {
            _conn.Execute("INSERT INTO departmens Name VALUES(@Name);", 
            new { Name = Name });
        }

        public void UpdateDepartment(int id, string newName)
        {
            _conn.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", 
            new {newName = newName, id = id});
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }
    }
}
