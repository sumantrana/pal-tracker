
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PalTracker {

    public class OperationCounter<T> : IOperationCounter<T>
    {

        private readonly IDictionary<TrackedOperation, int> _count;

        public IDictionary<TrackedOperation, int> GetCounts => _count.ToImmutableDictionary();

        public OperationCounter(){
            _count = new Dictionary<TrackedOperation, int>();

            foreach (var action in Enum.GetValues(typeof(TrackedOperation)))
            {
                _count.Add((TrackedOperation) action, 0);
            }            
        }

        public string Name => $"{typeof(T).Name}Operations";

        public void Increment(TrackedOperation operation)
        {
            _count[operation] = ++_count[operation];
        }
    }
}