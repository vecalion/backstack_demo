using System;
using Cirrious.MvvmCross.ViewModels;

namespace backstack
{
	public class DeepViewModel : MvxViewModel
	{
		public void Init(string message)
		{
			Message = message;
		}

		private string _message;
		public string Message
		{ 
			get { return _message; }
			set { _message = value; RaisePropertyChanged(() => Message); }
		}
	}
}