using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Sales.ApplicationWebLayer.Helpers
{
    public class BookCounterHub : Hub
    {
        public async Task UpdateRemainCopiesNumber(int bookId, int changeValue)
        {
            await Clients.All.SendAsync("UpdateRemainCopiesNumber", bookId, changeValue);
        }

    }
}