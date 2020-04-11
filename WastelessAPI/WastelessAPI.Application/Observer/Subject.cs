using System;
using System.Collections.Generic;
using WastelessAPI.Application.Models.Groceries;

namespace WastelessAPI.Application.Observer
{
    public abstract class Subject
    {
		private IList<IObserver> _observers = new List<IObserver>();

		public void Register(IObserver observer)
		{
			_observers.Add(observer);
		}

		public void Unregister(IObserver observer)
		{
			_observers.Remove(observer);
		}

		protected void Notify(Int32 userId, GroceryItem item)
		{
			foreach (var observer in _observers)
				observer.Update(userId, item);
		}
	}
}
