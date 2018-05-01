using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Ofo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofo.ViewModels
{
    public class ViewModelLocator 
    {
        #region Keys 
        private const string MainPageKey = "MainPage";
        private const string LoginFirstStepPageKey = "LoginFirstStepPage";
        private const string LoginSecondStepPageKey = "LoginSecondStepPage";
        #endregion

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

            }

            Configure();
        }

        private void Configure()
        {
            var nav = new NavigationService();
            nav.Configure(MainPageKey,typeof(MainPage));
            nav.Configure(LoginFirstStepPageKey, typeof(LoginFirstStepPage));
            nav.Configure(LoginSecondStepPageKey, typeof(LoginSecondStepPage));


            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<LoginFirstStepPageViewModel>();
            //SimpleIoc.Default.Register<WebViewPageViewModel>();
            //SimpleIoc.Default.Register<MasterDetailPageViewModel>();
            //SimpleIoc.Default.Register<MainPageViewModel>();
            //SimpleIoc.Default.Register<SearchPageViewModel>();
            //SimpleIoc.Default.Register<GamePageViewModel>();
        }

        #region ViewModels' instances 
        public LoginFirstStepPageViewModel LoginFirstPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginFirstStepPageViewModel>();
            }
        }
        #endregion

        public static void Cleanup()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<LoginFirstStepPageViewModel>();
        }
    }
}
