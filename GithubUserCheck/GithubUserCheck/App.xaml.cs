using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using FreshMvvm;
using GithubUserCheck;
using GithubUserCheck.ServiceAccessLayer;

namespace GithubUserCheck
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<SearchPageModel>(null);
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
            // The app is starting.
        }

        protected override void OnSleep()
        {
            // The app is going to the background.

            NetworkInfo.DisposeResources();
        }

        protected override void OnResume()
        {
            // The app is resuming after being sent to the background.
        }
    }
}
