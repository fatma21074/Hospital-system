// See https://aka.ms/new-console-template for more information
using Hospital_system.Data;
using Hospital_system.Models;

var dbContext = new ApplicationDbContext();
dbContext.Database.EnsureCreated();
if (dbContext.Patients.Any())
{
    return; // DB has been seeded
}
Console.WriteLine();
var patient = new Patient[]
{
    new Patient{FirstName = "Alex",
    LastName = "Sam",
    DataofBirth = DateTime.Now,
    Phone = "01234456",
    Address = "Los Anglose"},
     new Patient{FirstName = "Elena",
    LastName = "Mark",
    DataofBirth = DateTime.Now,
    Phone = "01234456",
    Address = "UK"}

};
dbContext.Patients.AddRange(patient);
dbContext.SaveChanges();



var departments = new Department[]
        {
            new Department { Name = "Cardiology", Description = "Heart related treatments" },
            new Department { Name = "Neurology", Description = "Brain and nervous system treatments" }
        };

dbContext.Departments.AddRange(departments);
dbContext.SaveChanges();



var doctors = new Doctor[]
      {
            new Doctor { FirstName = "John", LastName = "Doe", Specialization = "Cardiologist", YearsOfExperience = 10, Department = departments[0] },
            new Doctor { FirstName = "Jane", LastName = "Smith", Specialization = "Neurologist", YearsOfExperience = 8, Department = departments[1] }
      };
dbContext.Doctors.AddRange(doctors);
dbContext.SaveChanges();





