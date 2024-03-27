using Domain.Models;
using Infrastructure.Services;

var service=new StudentService(); 

var student1=new Student()
{
    FirstName="Alisho",
    LastName="Sholanagrov",
    Age=24,
    Course=".Net"
};  
service.AddStudent(student1);
//Console.WriteLine(service.GetStudents()); 
var teacherServica = new TeacherService();
var teacher1 = new Teacher()
{
FirstName="Dilovar",
LastName="Dilyobov",
Age=74,
Salary=2500,
Position="Director"
}; 
teacherServica.AddTeacher(teacher1); 

var carService=new CarService();
var car1 = new Car()
{
    CarName="Toyota",
    Model="LC 200",
    EngineCapacity=4,
    HorsePower=325,
    PublishedYear=2017

}; 
carService.AddCar(car1);