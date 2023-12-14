using System;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace CryptologyExam.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IDestructible, IPageLifecycleAware
    {
        protected INavigationService NavigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        // INavigationAware
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        // INavigationAware
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        // IDestructible
        public virtual void Destroy()
        {

        }

        public void OnAppearing()
        {
        }

        public void OnDisappearing()
        {
        }
    }
}

