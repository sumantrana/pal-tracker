
using Microsoft.AspNetCore.Mvc;

namespace PalTracker{

    [Route("/time-entries")]
    [ValidateModel]
    public class TimeEntryController : ControllerBase {

        ITimeEntryRepository _repository;

        public TimeEntryController ( ITimeEntryRepository repository ){
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")] 
        public IActionResult Read(long id){
            
            if ( _repository.Contains(id) == false ){
                return new NotFoundResult();
            }

            return new OkObjectResult(_repository.Find(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry){
            
            TimeEntry createdEntry = _repository.Create(timeEntry);
            return new CreatedAtRouteResult("GetTimeEntry", new { id = createdEntry.Id }, createdEntry);

        }

        [HttpGet]
        public IActionResult List(){
            return new OkObjectResult(_repository.List());
        }        

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]TimeEntry timeEntry){
            if ( _repository.Contains(id) == false ){
                return new NotFoundResult();
            }

            TimeEntry updatedEntry = _repository.Update(id, timeEntry);
            
            return new OkObjectResult(updatedEntry);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            
            if ( _repository.Contains(id) == false ){
                return new NotFoundResult();
            }

            _repository.Delete(id);

            return new NoContentResult();
        }        

    }

}