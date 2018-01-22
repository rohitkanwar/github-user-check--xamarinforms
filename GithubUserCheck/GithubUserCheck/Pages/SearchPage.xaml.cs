using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using GithubUserCheck.Constants;

namespace GithubUserCheck
{
    public partial class SearchPage : ContentPage
    {

        // A reference to the ViewModel:
        public SearchPageModel pageModel;

        public SearchPage()
        {
            InitializeComponent();

            // Set those UI strings that do not change (and therefore, do not require data binding):
            //WelcomeMsgLabel.Text = AppStrings.Search.WelcomeText;
            UsernamePromptLabel.Text = AppStrings.Search.UsernamePromptText;
            UsernameEntry.Placeholder = AppStrings.Search.UsernamePlaceholderText;
            SearchButton.Text = AppStrings.Search.SearchButtonText;

            SearchButton.Clicked += SearchButton_Clicked;
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            // Do not process event; just pass it to ViewModel.
            if (pageModel != null)
            {
                pageModel.TryPerformSearch();
            }
        }
    }
}
