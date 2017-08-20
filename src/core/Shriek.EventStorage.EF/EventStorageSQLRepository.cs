﻿using Shriek.EventSourcing.Sql.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using Shriek.Events;
using System.Linq;

namespace Shriek.EventSourcing
{
    public class EventStorageSQLRepository : IEventStorageRepository
    {
        private EventStorageSQLContext context;

        public EventStorageSQLRepository(EventStorageSQLContext context)
        {
            this.context = context;
        }

        public IEnumerable<StoredEvent> All(Guid aggregateId)
        {
            return context.StoredEvent.Where(e => e.AggregateId == aggregateId).AsEnumerable();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Store(StoredEvent theEvent)
        {
            context.StoredEvent.Add(theEvent);
            context.SaveChanges();
        }
    }
}