using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parse;

namespace BigBreakers
{
	public class RacketChoiceViewModel:ViewModelBase
	{
		public RacketChoiceViewModel()
		{
			
		}

		public async Task<IEnumerable<BrandModel>> getBrands()
		{
			var query = new ParseQuery<BrandModel>();
			query.OrderBy("name");
			return await query.FindAsync().ConfigureAwait(false);
		}

		public async Task<IEnumerable<RacketModel>> getRacketsForBrand(BrandModel brand)
		{
			var query = from racket in new ParseQuery<RacketModel>() where racket.brand == brand select racket;
			var rackets = await query.FindAsync().ConfigureAwait(false); ;
			return rackets;
		}
	}
}
