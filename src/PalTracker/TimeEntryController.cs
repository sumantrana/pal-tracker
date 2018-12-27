
using Microsoft.AspNetCore.Mvc;

namespace PalTracker{

    [Route("/time-entries")]
    [ValidateModel]
    public class TimeEntryController : ControllerBase {

        ITimeEntryRepository _repository;
        IOperationCounter<TimeEntry> _counter;

        public TimeEntryController ( ITimeEntryRepository repository,  IOperationCounter<TimeEntry> counter){
            _repository = repository;
            _counter = counter;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")] 
        public IActionResult Read(long id){

            _counter.Increment ( TrackedOperation.Read );            
            
            if ( _repository.Contains(id) == false ){
                return new NotFoundResult();
            }

            return new OkObjectResult(_repository.Find(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry){
            
            TimeEntry createdEntry = _repository.Create(timeEntry);
            _counter.Increment ( TrackedOperation.Create );
            return new CreatedAtRouteResult("GetTimeEntry", new { id = createdEntry.Id }, createdEntry);

        }

        [HttpGet]
        public IActionResult List(){
            _counter.Increment ( TrackedOperation.List );
            return new OkObjectResult(_repository.List());
        }        

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]TimeEntry timeEntry){
            
            _counter.Increment ( TrackedOperation.Update );

            if ( _repository.Contains(id) == false ){
                return new NotFoundResult();
            }

            TimeEntry updatedEntry = _repository.Update(id, timeEntry);
            
            return new OkObjectResult(updatedEntry);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            
            _counter.Increment ( TrackedOperation.Delete );

            if ( _repository.Contains(id) == false ){
                return new NotFoundResult();
            }

            _repository.Delete(id);
            

            return new NoContentResult();
        }        

    }

}