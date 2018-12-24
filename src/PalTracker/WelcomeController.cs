using Microsoft.AspNetCore.Mvc;

namespace PalTracker {

    [Route("/")]
    [ValidateModel]
    public class WelcomeController : ControllerBase
    {
        
        private readonly WelcomeMessage _message;

        public WelcomeController( WelcomeMessage message){
            _message = message;
        }

        [HttpGet]
        public string SayHello() => _message.Message;

        [HttpPost]
        public IActionResult postMessage( [FromBody] WelcomeMessage message ){
            return new OkObjectResult(message.Message);
        }

    }
}