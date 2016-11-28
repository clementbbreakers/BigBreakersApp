using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Parse;

namespace BigBreakers
{
	public class RacketOrderChoiceViewModel:ViewModelBase
	{
		public ObservableCollection<RacketModel> Rackets { get; set; }
		public RacketOrderChoiceViewModel()
		{
			Rackets = new ObservableCollection<RacketModel>();	
		}

		public async Task getRacketsDetail()
		{
			Rackets.Clear();
			foreach(var racket in (ParseUser.CurrentUser as UserModel).publicData.Get<IList<RacketModel>>("rackets"))
			{
				await racket.FetchIfNeededAsync().ConfigureAwait(false);
				await racket.brand.FetchIfNeededAsync();
				Rackets.Add(racket);
			}
		}
	}
}
