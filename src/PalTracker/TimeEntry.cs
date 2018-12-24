using System;

namespace PalTracker{

    public class TimeEntry {

        public long? Id { get; set; }
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }

        public TimeEntry ( long id, long projectId, long userId, DateTime date, int hours ){

            Id = id;
            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        }

        public TimeEntry ( long projectId, long userId, DateTime date, int hours ){

            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        }

        public TimeEntry(){

        }

        public override bool Equals(object obj){
            
            var timeEntry = obj as TimeEntry;

            if ( timeEntry == null){
                return false;
            }

            return ( timeEntry.Id == Id) &&
                        timeEntry.Hours == Hours &&
                            timeEntry.ProjectId == ProjectId &&
                                timeEntry.Date == Date &&
                                    timeEntry.UserId == UserId;
        }

        public override int GetHashCode(){
            
            int temp = (int) (Id ^ (Id >> 32));

            return ( 32 * temp + 17);
        }

    }


}