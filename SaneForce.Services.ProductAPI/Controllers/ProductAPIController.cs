using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaneForce.Services.ProductAPI.Data;
using SaneForce.Services.ProductAPI.Models;
using SaneForce.Services.ProductAPI.Models.Dto;
using System.Collections;
using System.Collections.Generic;

namespace SaneForce.Services.ProductAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public ProductAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable < Product> objlist = _db.ProductMaster.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(objlist);
                _response.IsSuccess = true;
                _response.Message = "API Success";
                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message= ex.Message;
                return BadRequest(_response);
            }
            
        }

        [HttpPost]
        public IActionResult SaveProductOrder([FromBody] List<ProductOrderDto>
            orders)
        {
            if (orders.Any())
            {
                
                IEnumerable<OrderDetails> objlist = _mapper.Map< IEnumerable<OrderDetails>> (orders);
                _db.OrderDetailsMaster.AddRange(objlist);
                _db.SaveChanges();
            }
            else
            {
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            return Ok(_response);
        }

    }
}
