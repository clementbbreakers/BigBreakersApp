/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BigBreakers"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace BigBreakers.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
	{
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			////if (ViewModelBase.IsInDesignModeStatic)
			////{
			////    // Create design time view services and models
			////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
			////}
			////else
			////{
			////    // Create run time view services and models
			////    SimpleIoc.Default.Register<IDataService, DataService>();
			////}
			/// 
			//var navigationService = this.CreateNavigationService();

			//Services
			SimpleIoc.Default.Register<LocationService>();
			SimpleIoc.Default.Register<GooglePlaceService>();
			//ViewModel
			SimpleIoc.Default.Register<LoginViewModel>();
			SimpleIoc.Default.Register<SignupViewModel>();
			SimpleIoc.Default.Register<PhoneValidationViewModel>();
			SimpleIoc.Default.Register<MapViewModel>();
			SimpleIoc.Default.Register<PrivateProfilePlayerViewModel>();
			SimpleIoc.Default.Register<RacketChoiceViewModel>();
			SimpleIoc.Default.Register<RacketOrderChoiceViewModel>();
        }

		public LoginViewModel Login
		{
			get { return ServiceLocator.Current.GetInstance<LoginViewModel>();}
		}
		public SignupViewModel Signup
		{
			get { return ServiceLocator.Current.GetInstance<SignupViewModel>(); }
		}
		public PhoneValidationViewModel phoneValidation
		{
			get { return ServiceLocator.Current.GetInstance<PhoneValidationViewModel>(); }
		}
		public MapViewModel Map
		{
			get { return ServiceLocator.Current.GetInstance<MapViewModel>(); }
		}
		public PrivateProfilePlayerViewModel ProfilePlayer
		{
			get { return ServiceLocator.Current.GetInstance<PrivateProfilePlayerViewModel>(); }
		}
		public RacketChoiceViewModel RacketChoice
		{
			get { return ServiceLocator.Current.GetInstance<RacketChoiceViewModel>(); }
		}
		public RacketOrderChoiceViewModel RacketOrder
		{
			get { return ServiceLocator.Current.GetInstance<RacketOrderChoiceViewModel>(); }
		}
		//public MainViewModel Main
		//{
		//    get
		//    {
		//        return ServiceLocator.Current.GetInstance<MainViewModel>();
		//    }
		//}

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}