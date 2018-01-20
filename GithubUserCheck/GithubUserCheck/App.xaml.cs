﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using FreshMvvm;
using GithubUserCheck;

namespace GithubUserCheck
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new GithubUserCheck.MainPage();

            var page = FreshPageModelResolver.ResolvePageModel<SearchPageModel>(null);
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
