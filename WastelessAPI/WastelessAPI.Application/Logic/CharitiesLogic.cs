using System;
using System.Collections.Generic;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Logic
{
    public class CharitiesLogic
    {
        private readonly CharitiesRepository _charitiesRepository;
        private readonly GroceriesRepository _groceriesRepository;

        public CharitiesLogic(CharitiesRepository charitiesRepository, GroceriesRepository groceriesRepository)
        {
            _charitiesRepository = charitiesRepository;
            _groceriesRepository = groceriesRepository;
        }

        public IList<Charity> GetCharities()
        {
            return _charitiesRepository.GetAll();
        }

        public void Donate(Donation donation)
        {
            _charitiesRepository.Donate(donation);
            _groceriesRepository.Consume(donation.ItemId);
        }
    }
}
