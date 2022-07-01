using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();

        void CreateDepartment(string Name);
    }
}
