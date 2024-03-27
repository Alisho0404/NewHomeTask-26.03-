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
    public class CarService : ICarService
    {
        private readonly DapperContext _context;
        public CarService()
        {
            _context = new DapperContext();
        }
        public string AddCar(Car car)
        {
            var sql = $"insert into cars(car_name,model,engine_capacity,horse_power,published_year)" +
                $"values('{car.CarName}','{car.Model}',{car.EngineCapacity},{car.HorsePower} ,{car.PublishedYear})"; 

            var insert = _context.Connection().Execute(sql) ;
            if (insert > 0)
            {
                return "Car succesfully added to db";
            }
            return "Error in adding car to db";
        }

        public bool DeleteCar(int id)
        {
            var sql = $"delete from cars where id={id}";
            var delete = _context.Connection().Execute(sql);
            if (delete > 0)
            {
                return true;
            }
            return false;
        }

        public List<Car> GetCar()
        {
            var sql = "select * from cars";
            var result = _context.Connection().Query<Car>(sql).ToList();
            return result;
        }

        public string UpdateCar(Car car)
        {
            var sql = $"update cars set car_name='{car.CarName}',model='{car.Model}',engine_capacity={car.EngineCapacity}," +
                $"horse_power={car.HorsePower} ,published_year={car.PublishedYear}";
            var result = _context.Connection().Execute(sql);
            if (result > 0)
            {
                return "Car succesfully updated";
            }
            return "Error in updating car";
        }
    }
}
