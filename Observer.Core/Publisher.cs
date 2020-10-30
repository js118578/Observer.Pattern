using System.Collections.Generic;
using System.Threading.Tasks;
using Observer.Models;

namespace Observer.Core
{
    public class Publisher : IPublisher
    {
        //This is a bad example for tightly coupling classes but just for the sake of examples.
        private List<IListener> Listeners { get; set; } = new List<IListener>
        {
            new Data.Subscriber.File.Repository(),
            new Data.Subscriber.MySql.Repository(),
            new Data.Subscriber.Sql.Repository(),
            new Data.Subscriber.Logging.Repository(),
        };
        public async Task<bool> Add(Event e)
        {
            Listeners.ForEach(async listener =>
            {
                await listener.Add(e);
            });

            return true;
        }
        public async Task<Event> Update(Event e)
        {
            Listeners.ForEach(async listener =>
            {
                await listener.Update(e);
            });

            return e;
        }
        public async Task<bool> Delete(Event e)
        {
            Listeners.ForEach(async listener =>
            {
                await listener.Delete(e);
            });

            return true;
        }
    }
}
