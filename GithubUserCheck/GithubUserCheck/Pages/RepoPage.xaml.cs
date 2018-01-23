using GithubUserCheck.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GithubUserCheck.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepoPage : ContentPage
    {
        // A reference to the ViewModel:
        public RepoPageModel pageModel;

        public RepoPage()
        {
            InitializeComponent();
        }

        public void DisplayWebPage(string url)
        {
            RepoWebView.Source = url;
        }

        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            pageModel.WebViewNavigationStarted();
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            pageModel.WebViewNavigationComplete();
        }
    }
}