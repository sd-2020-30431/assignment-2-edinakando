using System;
using WastelessAPI.Application.Shared;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Logic
{
    public class UserLogic
    {
        private readonly UserRepository _userRepository;

        public UserLogic(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User InsertNewUser(User user)
        {
            if (IsDuplicateUser(user))
            {
                return null;
            }

            user.Password = HashingSHA.GenerateSHA256String(user.Password);
            return _userRepository.AddUser(user);
        }

        Boolean IsDuplicateUser(User user)
        {
            return _userRepository.IsDuplicateUser(user);
        }

        public User GetValidUser(User user)
        {
            user.Password = HashingSHA.GenerateSHA256String(user.Password);
            return _userRepository.GetValidUser(user);
        }
    }
}
