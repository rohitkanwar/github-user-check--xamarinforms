using GithubUserCheck.Constants;
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

        public void PerformSearch()
        {
            Debug.WriteLine("PerformSearch invoked. Username entered is: {0}", Username);



        }

        // Properties:

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;

                // Rohit: Commanding is not working; CanExecute is checked only once.
                //SearchCommand. ChangeCanExecute();
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




        /// TODO: Delete Commands section if not being used.
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
        //    // TODO: Check real constraints for a valid github username, and implement those
        //    if (!string.IsNullOrWhiteSpace(Username))
        //    {
        //        isValidInput = true;
        //    }
        //    return isValidInput;
        //}
    }
}
