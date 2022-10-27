using Microsoft.AspNetCore.Mvc;
using MLNotifications.Application.Commands;
using MLNotifications.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLNotifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        private readonly IUserNotificationService _userNotificationService;
        private readonly IPushNotificationService _pushNotificationService;

        public PushNotificationController(IUserNotificationService userNotificationService, IPushNotificationService pushNotificationService)
        {
            _userNotificationService = userNotificationService;
            _pushNotificationService = pushNotificationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _userNotificationService.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserNotificationCommand command)
        {
            var response = await _userNotificationService.Add(command);

            if (response.Invalid)
                return BadRequest(response.Notifications);

            var reponseSend= await _pushNotificationService.Send(response.Data);
            
            return Ok(reponseSend);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateUserNotificationCommand command)
        {
            var response = await _userNotificationService.Update(command);

            if (response.Invalid)
                return BadRequest(response.Notifications);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _userNotificationService.Delete(id);
            if (response.Invalid)
                return BadRequest(response.Notifications);

            return Ok();
        }


        [HttpPost("SendScheduled")]
        public async Task<IActionResult> SendScheduled()
        {
            try
            {
                await _pushNotificationService.SendScheduled();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
