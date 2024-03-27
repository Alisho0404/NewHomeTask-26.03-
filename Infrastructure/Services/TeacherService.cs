using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly DapperContext _context;
        public TeacherService()
        {
            _context = new DapperContext();
        }
        public string AddTeacher(Teacher teacher)
        {
            var sql = $"insert into teachers(first_name,last_name,age,salary,position)" +
                $"values('{teacher.FirstName}','{teacher.LastName}',{teacher.Age} ,{teacher.Salary} ,'{teacher.Position}')";
            var insert=_context.Connection().Execute(sql);
            if (insert>0)
            {
                return "Teacher succesfully added to db";
            }
            return "Error in adding teacher to db";
        }

        public bool DeleteTeacher(int id)
        {
            var sql = $"delete from teachers where id={id}";
            var delete= _context.Connection().Execute(sql);
            if (delete>0)
            {
                return true;
            } 
            return false;
        }

        public Teacher GetTeacherById(int id)
        {
            var sql = "select * from teachers where id=@id"; 
            var result=_context.Connection().QueryFirstOrDefault<Teacher>(sql);
            return result;

        }

        public List<Teacher> Teachers()
        {
            var sql = "select * from teachers";
            var result = _context.Connection().Query<Teacher>(sql).ToList();
            return result;
        }

        public string UpdateTeacher(Teacher teacher)
        {
            var sql = $"update teachers set firstname='{teacher.FirstName}',lastname='{teacher.LastName}',age={teacher.Age}," +
                $"salary={teacher.Salary} ,position='{teacher.Position}'"; 
            var result= _context.Connection().Execute(sql);
            if (result>0)
            {
                return "Teacher succesfully updated";
            }
            return "Error in updating teacher";
        }
    }
}
