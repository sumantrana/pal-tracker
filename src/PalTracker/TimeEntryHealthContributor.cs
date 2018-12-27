

using System.Linq;
using Steeltoe.Common.HealthChecks;
using static Steeltoe.Common.HealthChecks.HealthStatus;

namespace PalTracker {

    public class TimeEntryHealthContributor : IHealthContributor
    {
        public string Id => "timeEntry";

        private ITimeEntryRepository Repository;
        public const int MaxTimeEntries = 5;

        public TimeEntryHealthContributor ( ITimeEntryRepository repository ){
            Repository = repository;
        }

        public HealthCheckResult Health()
        {
            
            var count = Repository.List().Count();
            var status = count < MaxTimeEntries ? UP : DOWN;

            HealthCheckResult theResult = new HealthCheckResult { Status = status };

            theResult.Details.Add("count", count);
            theResult.Details.Add( "threshold", MaxTimeEntries );
            theResult.Details.Add( "status", status.ToString() );

            return theResult;
        }
    }
}