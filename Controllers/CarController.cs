using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MiniOtomoto.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace MiniOtomoto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        
        private readonly ILogger<CarController> _logger;
        private readonly IConfiguration _configuration;

        public CarController(ILogger<CarController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public List<Car> cars_list = new List<Car>();
 
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            using var con = new MySqlConnection(_configuration.GetConnectionString("CarAppCon"));
            con.Open();

            string query = @"SELECT brand_name, model_name, id_offer, mileage, production_year, fuel, power
                             FROM((cars.adds
                             inner JOIN cars.brands ON adds.id_brand = brands.id_brand)
                             inner JOIN cars.models ON adds.id_model = models.id_model);";
            using var cmd = new MySqlCommand(query, con);
            //cmd.prepare
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                {
                    cars_list.Add(new Car
                    {
                        brand = reader.GetString(0),
                        model = reader.GetString(1),
                        id_offer = reader.GetInt64(2),
                        mileage = reader.GetString(3),
                        prodyear = reader.GetInt32(4),
                        fuel = reader.GetString(5),
                        power = reader.GetString(6)
                    });
                }
            return cars_list.ToArray();
        }

        [HttpGet("{id}")]
        public IEnumerable<Car> Get(long id)
        {
            using var con = new MySqlConnection(_configuration.GetConnectionString("CarAppCon"));
            con.Open();
            string query = @"SELECT brand_name, model_name, id_offer, mileage, production_year, fuel, power
                             FROM((cars.adds
                             inner JOIN cars.brands ON adds.id_brand = brands.id_brand)
                             inner JOIN cars.models ON adds.id_model = models.id_model)
                             where adds.id_offer=" + id + ";";
            using var cmd = new MySqlCommand(query, con);
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cars_list.Add(new Car
                {

                    brand = reader.GetString(0),
                    model = reader.GetString(1),
                    id_offer = reader.GetInt64(2),
                    mileage = reader.GetString(3),
                    prodyear = reader.GetInt32(4),
                    fuel = reader.GetString(5),
                    power = reader.GetString(6),
                    // this line under is to specify  @"D:\Projects\MiniOtomoto\MiniOtomoto\ClientApp\src\assets\Photos\" + reader.GetInt64(2) + @"\"
                    
                    image_amount = Directory.GetFiles(string.Format(@"D:\Projects\MiniOtomoto\MiniOtomoto\ClientApp\src\assets\Photos\{0}\", id), "*", SearchOption.TopDirectoryOnly).Length
            }); 
           }
            return cars_list.ToArray();
        }
        [Authorize]
        [HttpPut]
        public JsonResult Put(Car _Car)
        {
            using var con = new MySqlConnection(_configuration.GetConnectionString("CarAppCon"));
            con.Open();
            string query = @"Update cars.adds 
                             inner JOIN cars.brands ON '" + _Car.brand + @"' = brands.brand_name
                             inner JOIN cars.models ON '" + _Car.model + @"' = models.model_name
                             Set
                             adds.id_brand =  brands.id_brand,
                             adds.id_model = models.id_model,
                             production_year = " + _Car.prodyear + @",
                             mileage = '" + _Car.mileage + @"',
                             fuel = '" + _Car.fuel + @"',
                             power = '" + _Car.power + @"'
                             Where adds.id_offer = " + _Car.id_offer + ";";
            using var cmd = new MySqlCommand(query, con);
            using MySqlDataReader reader = cmd.ExecuteReader();
            return new JsonResult("Updated Successfully");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            using var con = new MySqlConnection(_configuration.GetConnectionString("CarAppCon"));
            con.Open();
            string query = @"Delete from cars.adds where id_offer = " + id;
            using var cmd = new MySqlCommand(query, con);
            using MySqlDataReader reader = cmd.ExecuteReader();
            return new JsonResult("Delete Successfully");
        }
    }
}
