using GithubUserCheck.Constants;
using GithubUserCheck.DataLayer;
using GithubUserCheck.PageModels;
using GithubUserCheck.ServiceAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GithubUserCheck
{
    public class SearchPageModel : FreshMvvm.FreshBasePageModel
    {
        private NetworkManager networkManager;

        public override void Init(object initData)
        {
            // Provide the View with a reference to this ViewModel:
            ((SearchPage)CurrentPage).pageModel = this;

            CanPerformSearch = false;
        }

        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, System.EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        public void TryPerformSearch()
        {
            if (NetworkInfo.IsConnected())
            {
                PerformSearch();
            }
            else
            {
                Debug.WriteLine("TryPerformSearch : Not connected.");

                // Inform the user that connection is not there.
                ((SearchPage)CurrentPage).DisplayAlert("Not Connected", "Please enable WiFi or mobile data, and try again.", "OK");
            }
        }

        private async void PerformSearch()
        {
            IsNetworkOpInProgress = true;
            bool dataRetrieved = await Task.Run<bool>(() => NetworkManager.Instance.GetUserAndReposData(Username));
            IsNetworkOpInProgress = false;

            if (dataRetrieved)
            {
                Debug.WriteLine("Successfully got github user and repos data. Login = {0}, CreatedAt = {1}, Repos.Count = {2}", Data.currentUser.Login, Data.currentUser.CreatedAt, Data.currentUserRepos.Count);
                
                // Go to the results page:
                await CoreMethods.PushPageModel<ResultsPageModel>(true);
            }
            else
            {
                Debug.WriteLine("Failed to get user and repos data.");

                // Inform the user of the error:
                await CoreMethods.DisplayAlert("Error", "Sorry, there was a problem. Please try again later.", "OK");
            }
        }

        // Properties:

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;

                // Rohit: Commanding is not working; the CanExecute delegate is evaluated only once, 
                // even though we call ChangeCanExecute here:
                //SearchCommand.ChangeCanExecute();
                SetCanPerformSearch();
            }
        }

        // Can the user search at this time?
        private bool _canPerformSearch;
        public bool CanPerformSearch
        {
            get { return _canPerformSearch; }
            set
            {
                _canPerformSearch = value;
                RaisePropertyChanged("CanPerformSearch");
            }
        }

        private void SetCanPerformSearch()
        {
            // TODO: Find out real constraints for github usernames, and implement those, if possible.
            if (string.IsNullOrWhiteSpace(Username))
            {
                CanPerformSearch = false;
            }
            else
            {
                CanPerformSearch = true;
            }
        }

        private bool _isNetworkOpInProgress;
        public bool IsNetworkOpInProgress
        {
            get { return _isNetworkOpInProgress; }
            set
            {
                _isNetworkOpInProgress = value;
                RaisePropertyChanged("IsNetworkOpInProgress");
            }
        }



        // Rohit: Commanding is not working; the CanExecute delegate is invoked only once.
        // Commands

        //public Command SearchCommand
        //{
        //    get
        //    {
        //        return new Command(() => SearchForGithubUser(), () => CanSearchForGithubUser());
        //    }
        //}

        //private void SearchForGithubUser()
        //{
        //    Debug.WriteLine("method SearchForGithubUser invoked.");
        //}

        //private bool CanSearchForGithubUser()
        //{
        //    Debug.WriteLine("method CanSearchForGithubUser invoked.");
        //    bool isValidInput = false;
        //
        //    if (!string.IsNullOrWhiteSpace(Username))
        //    {
        //        isValidInput = true;
        //    }
        //    return isValidInput;
        //}
    }
}
