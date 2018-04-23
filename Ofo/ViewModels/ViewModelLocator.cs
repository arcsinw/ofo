using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views; 
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
            var nav = SimpleIoc.Default.GetInstance<INavigationService>();
            

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            //SimpleIoc.Default.Register<IMasterDetailNavigationService>(() => nav);
            //SimpleIoc.Default.Register<NewsPageViewModel>();
            //SimpleIoc.Default.Register<WebViewPageViewModel>();
            //SimpleIoc.Default.Register<MasterDetailPageViewModel>();
            //SimpleIoc.Default.Register<MainPageViewModel>();
            //SimpleIoc.Default.Register<SearchPageViewModel>();
            //SimpleIoc.Default.Register<GamePageViewModel>();
        }

        #region ViewModels' instances 

        #endregion

        public static void Cleanup()
        {
            SimpleIoc.Default.Reset();
             
        }
    }
}
