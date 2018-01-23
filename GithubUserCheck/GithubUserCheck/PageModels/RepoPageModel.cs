using GithubUserCheck.Constants;
using GithubUserCheck.DataLayer;
using GithubUserCheck.Pages;
using GithubUserCheck.ResponseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.PageModels
{
    public class RepoPageModel : FreshMvvm.FreshBasePageModel
    {
        // The id of the selected repo:
        private long selectedRepoId;

        // An invalid repo id:
        private const long InvalidRepoId = -1L;

        // The selected repo:
        private Repo selectedRepo;

        public override void Init(object initData)
        {
            // Provide the View with a reference to this ViewModel:
            ((RepoPage)CurrentPage).pageModel = this;

            // Accept repo id as parameter
            if ((initData != null) && (initData is long))
            {
                selectedRepoId = (long)initData;
            }
            else
            {
                selectedRepoId = InvalidRepoId;
            }

            FindSelectedRepo(selectedRepoId);
        }

        private void FindSelectedRepo(long repoId)
        {
            selectedRepo = null;
            foreach (var r in Data.currentUserRepos)
            {
                if (r.Id == repoId)
                {
                    selectedRepo = r;
                    break;
                }
            }
        }


        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            if (selectedRepo != null)
            {
                // Set title to repo name
                PageTitle = selectedRepo.FullName;
                ((RepoPage)CurrentPage).Title = PageTitle;

                Name = selectedRepo.Name;
                HtmlUrl = selectedRepo.HtmlUrl;
                IsWebViewNavigating = true;
            }
            else
            {
                CoreMethods.DisplayAlert("Error", "Sorry, unable to display this repo.", "Dismiss");

                // Set a generic title:
                PageTitle = AppStrings.RepoDetails.UnknownRepo;
                ((RepoPage)CurrentPage).Title = PageTitle;
            }
        }

        // Properties

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                RaisePropertyChanged("PageTitle");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _htmlUrl;
        public string HtmlUrl
        {
            get { return _htmlUrl; }
            set
            {
                _htmlUrl = value;
                RaisePropertyChanged("HtmlUrl");
            }
        }

        private bool _isWebViewNavigating;
        public bool IsWebViewNavigating
        {
            get { return _isWebViewNavigating; }
            set
            {
                _isWebViewNavigating = value;
                RaisePropertyChanged("IsWebViewNavigating");
            }
        }

        public void WebViewNavigationStarted()
        {
            Debug.WriteLine("RepoPage: WebViewNavigationStarted");

            IsWebViewNavigating = true;

            //PageTitle = "Please wait ...";
            //((RepoPage)CurrentPage).Title = PageTitle;
        }

        public void WebViewNavigationComplete()
        {
            Debug.WriteLine("RepoPage: WebViewNavigationComplete");

            IsWebViewNavigating = false;

            //PageTitle = selectedRepo.FullName;
            //((RepoPage)CurrentPage).Title = PageTitle;
        }
    }
}
