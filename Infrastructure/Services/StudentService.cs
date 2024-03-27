using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class StudentService:IStudentService
{
    private readonly DapperContext _context;
    public StudentService()
    {
        _context= new DapperContext();
    }
    public List<Student> GetStudents()
    {
        var sql = "select * from student";
        var result = _context.Connection().Query<Student>(sql).ToList();
        return result;
    }

    public Student GetStudentById(int id)
    {
        var sql = "select * from student where id=@id";
        var result = _context.Connection().QueryFirstOrDefault<Student>(sql);
        return result;
    }

    public string AddStudent(Student student)
    {
        var sql =  $"insert into student (firstname, lastname,age,course)" +
                   $"values ('{student.FirstName}','{student.LastName}', {student.Age},'{student.Course}')";
        var inserted =  _context.Connection().Execute(sql);
        if (inserted > 0) return "Successfully created new student";
         return "Error in creating new student";
        
    }

    public string UpdateStudent(Student student)
    {
          
          var sql=$"update student set firstname = '{student.FirstName}', "+
            $"lastname = '{student.LastName}',age= {student.Age},course = '{student.Course}'"+
            $"where id = {student.Id}";
        var inserted =  _context.Connection().Execute(sql);
        if (inserted > 0) return "Successfully updated  student"; 
        return "Error in updating  student";
    }

    public bool DeleteStudent(int id)
    {
        var sql = $"delete from student where id = {id}";
        var deleted =_context.Connection().Execute(sql);
        if (deleted > 0) return true;
         return false;
    }
}