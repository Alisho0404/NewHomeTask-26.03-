using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal interface ITeacherService
    {
        List<Teacher> Teachers();
        Teacher GetTeacherById(int id);
        string AddTeacher(Teacher teacher);
        string UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(int id);
    }
}
