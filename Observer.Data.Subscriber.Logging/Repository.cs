using System;
using System.Threading.Tasks;
using Observer.Models;

namespace Observer.Data.Subscriber.Logging
{
    public class Repository : IListener
    {
        public Task<bool> Add(Event e)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Event e)
        {
            throw new NotImplementedException();
        }

        public Task<Event> Update(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
