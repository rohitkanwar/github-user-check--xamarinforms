using GithubUserCheck.Constants;
using GithubUserCheck.DataLayer;
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

                // TODO: Inform the user that connection is not there.
            }
        }

        private async void PerformSearch()
        {
            // TODO: Indicate network op in progress.

            bool dataRetrieved = await Task.Run<bool>(() => NetworkManager.Instance.GetUserAndReposData(Username));
            
            // TODO: Indicate network op complete.

            if (dataRetrieved)
            {
                Debug.WriteLine("Successfully got github user data. Id = {0}, CreatedAt = {1}", Data.currentUser.Id, Data.currentUser.CreatedAt);
            }
            else
            {
                Debug.WriteLine("Failed to get github user data.");
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
