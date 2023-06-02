using Microsoft.EntityFrameworkCore;
using PDC03_MODULE07.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PDC03_MODULE07.ViewModel
{
    public class EmployeeViewModel
    {
        //CALL DATABASE

        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        // INSERT RECORDS

        public int InsertEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        // RETRIEVE RECORDS

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Employee.ToListAsync();
            return res;

        }

        // DELETE RECORDS

        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        // UPDATE RECORDS

        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employee.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}
