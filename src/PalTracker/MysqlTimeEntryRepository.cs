

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker {

    public class MySqlTimeEntryRepository : ITimeEntryRepository {

        TimeEntryContext Context;

        public MySqlTimeEntryRepository( TimeEntryContext context ){

            Context = context;
        }

        public bool Contains(long id)
        {
            return Context.TimeEntryRecords.AsNoTracking().Any( t => t.Id == id);
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var toCreateRecord = timeEntry.ToRecord();
            
            Context.Add(toCreateRecord);
            Context.SaveChanges();

            return Find(toCreateRecord.Id.Value);
        }

        public void Delete(long id)
        {
            Context.Remove( FindRecord(id) );
            Context.SaveChanges();
            
        }

        private TimeEntryRecord FindRecord( long id){
            return Context.TimeEntryRecords.AsNoTracking().Single( t => t.Id == id);
        }

        public TimeEntry Find(long id)
        {
            return FindRecord(id).ToEntity();
        }

        public IEnumerable<TimeEntry> List()
        {
            return Context.TimeEntryRecords.AsNoTracking().Select( t => t.ToEntity() ).ToList();
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            TimeEntryRecord theUpdatedRecord = timeEntry.ToRecord();
            theUpdatedRecord.Id = id;
            
            Context.Update(theUpdatedRecord);
            Context.SaveChanges();
            
            return Find(id);
        }
    }

}