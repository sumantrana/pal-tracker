

using System.Collections.Generic;
using System.Linq;

namespace PalTracker{

    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {

        private readonly IDictionary<long, TimeEntry> _timeEntryDict = new Dictionary<long, TimeEntry>();

        public bool Contains(long id)
        {
            return _timeEntryDict.ContainsKey(id);
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            
            long counter = _timeEntryDict.Count + 1;
            timeEntry.Id = counter;
            _timeEntryDict.TryAdd(counter, timeEntry);
            return timeEntry;
        }

        public void Delete(long id)
        {
            _timeEntryDict.Remove(id);
        }

        public TimeEntry Find(long id)
        {
            return _timeEntryDict[id];
        }

        public IEnumerable<TimeEntry> List()
        {
            List<TimeEntry> timeEntryList = new List<TimeEntry>(_timeEntryDict.Values);
            return timeEntryList;
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            timeEntry.Id = id;
            _timeEntryDict[id] = timeEntry;
            return timeEntry;
        }

    }


}