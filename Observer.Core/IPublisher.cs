using Observer.Models;
using System.Threading.Tasks;

namespace Observer.Core
{
    public interface IPublisher
    {
        Task<bool> Add(Event e);
        Task<bool> Delete(Event e);
        Task<Event> Update(Event e);
    }
}