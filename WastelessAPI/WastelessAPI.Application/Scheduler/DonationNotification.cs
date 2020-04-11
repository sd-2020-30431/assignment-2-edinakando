using Coravel.Invocable;
using System.Threading.Tasks;
using WastelessAPI.Application.Observer;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Scheduler
{
    public class DonationNotification : IInvocable
    {
        private UserRepository _userRepository;
        private GroceriesRepository _groceriesRepository;

        public DonationNotification(UserRepository userRepository, GroceriesRepository groceriesRepository)
        {
            _userRepository = userRepository;
            _groceriesRepository = groceriesRepository;
        }

        public Task Invoke()
        {
            var pushNotification = new PushNotificationObserver();
            var itemExpiration = new ItemExpiration(_userRepository, _groceriesRepository);

            itemExpiration.Register(pushNotification);
            itemExpiration.CheckExpirationDates();

            return Task.CompletedTask;
        }
    }
}
