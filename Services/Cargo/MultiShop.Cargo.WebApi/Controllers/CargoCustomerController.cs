using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CreateCargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoCustomerList(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                SurName = createCargoCustomerDto.SurName
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Cargo Customer Added");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Cargo Customer Removed");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                SurName = updateCargoCustomerDto.SurName
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Cargo Customer Updated");
        }
    }
}
