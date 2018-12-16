using Microsoft.AspNetCore.Mvc;

namespace PalTracker{

    [Route("env")]
    public class EnvController : ControllerBase{

        private readonly CloudFoundryInfo _info;


        public EnvController( CloudFoundryInfo info){
            _info = info;
        }

        [HttpGet]
        public CloudFoundryInfo Get() => _info;

    }
}