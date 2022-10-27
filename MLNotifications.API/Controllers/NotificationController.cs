using Microsoft.AspNetCore.Mvc;
using MLNotifications.Application.Commands;
using MLNotifications.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLNotifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _notificationService.GetById(id);

            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var response = await _notificationService.GetAll();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNotificationCommand command)
        {
            var response = await _notificationService.Add(command);

            if (response.Invalid)
                return BadRequest(response.Notifications);

            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateNotificationCommand command)
        {
            var response = await _notificationService.Update(command);

            if (response.Invalid)
                return BadRequest(response.Notifications);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _notificationService.Delete(id);
            if (response.Invalid)
                return BadRequest(response.Notifications);

            return Ok();
        }
    }
}
