using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon Created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Coupon Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Discount Coupon Updated");
        }
    }
}
