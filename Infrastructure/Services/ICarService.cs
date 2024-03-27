using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal interface ICarService
    {
        List<Car> GetCar();
        string AddCar(Car car);
        string UpdateCar(Car car);
        bool DeleteCar(int id);
    }
}
