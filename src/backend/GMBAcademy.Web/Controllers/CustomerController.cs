using System;
using System.Threading.Tasks;
using GMBAcademy.DataAccess.Repositories;
using GMBAcademy.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GMBAcademy.Web.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly IDbRepository _dbRepository;

        public CustomerController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [HttpGet("{customerId}")]
        public ActionResult<Customer> Get(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                BadRequest("Customer id was empty");
            }

            var customer = _dbRepository.Query<Customer>();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (customer == null)
            {
                BadRequest("Customer was null");
            }

            await _dbRepository.Create(customer);

            return Ok("Customer was created");
        }
    }
}