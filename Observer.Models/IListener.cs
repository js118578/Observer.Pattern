using System.Threading.Tasks;

namespace Observer.Models
{
    public interface IListener
    {
        Task<bool> Add(Event e);
        Task<Event> Update(Event e);
        Task<bool> Delete(Event e);
    }
}
