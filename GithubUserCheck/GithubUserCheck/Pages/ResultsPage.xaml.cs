using GithubUserCheck.PageModels;
using GithubUserCheck.ResponseModels;
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
    public partial class ResultsPage : ContentPage
    {
        // A reference to the ViewModel:
        public ResultsPageModel pageModel;

        public ResultsPage()
        {
            InitializeComponent();

            ReposList.ItemTapped += ListItemTapped;
            ReposList.ItemSelected += ClearListItemSelection;
        }

        private void ListItemTapped(object sender, ItemTappedEventArgs e)
        {
            if ((e.Item != null) && (e.Item is Repo))
            {
                pageModel.SelectedRepo = (Repo)e.Item;
            }
        }

        private void ClearListItemSelection(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}