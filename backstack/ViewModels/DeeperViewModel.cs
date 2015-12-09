using System;
using Cirrious.MvvmCross.ViewModels;

namespace backstack
{
	public class DeeperViewModel : MvxViewModel
	{
		public void Init(int answer)
		{
			Answer = answer.ToString ();
		}

		private string _answer;
		public string Answer
		{ 
			get { return _answer; }
			set { _answer = value; RaisePropertyChanged(() => Answer); }
		}
	}
}

