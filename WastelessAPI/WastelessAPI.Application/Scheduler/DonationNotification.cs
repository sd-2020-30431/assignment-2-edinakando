using Coravel.Invocable;
using System.Threading.Tasks;
using WastelessAPI.Application.Observer;
using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Scheduler
{
    public class DonationNotification : IInvocable
    {
        private UserRepository _userRepository;
        private IGroceriesRepository _groceriesRepository;

        public DonationNotification(UserRepository userRepository, IGroceriesRepository groceriesRepository)
        {
            _userRepository = userRepository;
            _groceriesRepository = groceriesRepository;
        }

        public Task Invoke()
        {
            var pushNotification = new PushNotificationObserver(_groceriesRepository);
            var itemExpiration = new ItemExpiration(_userRepository, _groceriesRepository);

            itemExpiration.Register(pushNotification);
            itemExpiration.CheckExpirationDates();

            return Task.CompletedTask;
        }
    }
}
