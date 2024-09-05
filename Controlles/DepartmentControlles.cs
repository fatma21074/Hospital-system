using Hospital_system.Data;
using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Controlles
{
    public class DepartmentControlles
    {
        public class DepartmentService
        {
            private readonly ApplicationDbContext _context;

            public DepartmentService(ApplicationDbContext context)
            {
                _context = context;
            }

            // Create
            public void AddDepartment(Department department)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }

            // Read
            public Department GetDepartmentById(int id)
            {
                return _context.Departments
                    .Include(d => d.Doctors)
                    .SingleOrDefault(d => d.ID == id);
            }

            // Update
            public void UpdateDepartment(Department department)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
            }

            // Delete
            public void DeleteDepartment(int id)
            {
                var department = _context.Departments.Find(id);
                if (department != null)
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
                }
            }
        }

    }
}
