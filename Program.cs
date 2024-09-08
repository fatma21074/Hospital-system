// See https://aka.ms/new-console-template for more information
using Hospital_system.Data;
using Hospital_system.Models;

var dbContext = new ApplicationDbContext();
dbContext.Database.EnsureCreated();

Console.WriteLine();
var patient = new Patient[]
{
    new Patient{FirstName = "Alex",
    LastName = "Sam",
    DataofBirth = DateTime.Now,
    Phone = "01234456",
    Address = "Los Anglose",
    Email="sam@gmail.com",
    Gender="Male"},


     new Patient{FirstName = "Elena",
    LastName = "Mark",
    DataofBirth = DateTime.Now,
    Phone = "01234456",
    Address = "UK",
     Email="mark@gmail.com",
    Gender="Male" }

};
dbContext.Patients.AddRange(patient);
dbContext.SaveChanges();

foreach (var p in patient)
{
    Console.WriteLine($"Patient: {p.FirstName} {p.LastName}, DOB: {p.DataofBirth}, Phone: {p.Phone}, Address: {p.Address}, Email: {p.Email}, Gender: {p.Gender}");
}

var departments = new Department[]
        {
            new Department { Name = "Cardiology", Description = "Heart related treatments" },
            new Department { Name = "Neurology", Description = "Brain and nervous system treatments" }
        };

dbContext.Departments.AddRange(departments);
dbContext.SaveChanges();
Console.WriteLine("================================================================");

foreach (var p in departments)
{
    Console.WriteLine($"Department:{p.Name} , Descrition:{p.Description}");
}
var doctors = new Doctor[]
      {
            new Doctor { FirstName = "John", LastName = "Doe", Specialization = "Cardiologist", YearsOfExperience = 10, Department = departments[0] ,Email="John@gmail.com" ,Phone="01123456789",DoctorName=" "},
            new Doctor { FirstName = "Jane", LastName = "Smith", Specialization = "Neurologist", YearsOfExperience = 8, Department = departments[1],Email="Jane@gmail.com",Phone="01123456789" ,DoctorName=" "}
      };
dbContext.Doctors.AddRange(doctors);
dbContext.SaveChanges();
Console.WriteLine("================================================================");

foreach (var p in doctors)
{
    Console.WriteLine($"Doctor: {p.FirstName} {p.LastName}, Specialization: {p.Specialization}, Phone: {p.Phone}, YearsOfExperience: {p.YearsOfExperience}, Email: {p.Email}, Department: {p.Department}");
}



