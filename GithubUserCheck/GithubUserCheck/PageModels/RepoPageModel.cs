using GithubUserCheck.Constants;
using GithubUserCheck.DataLayer;
using GithubUserCheck.Pages;
using GithubUserCheck.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.PageModels
{
    public class RepoPageModel : FreshMvvm.FreshBasePageModel
    {
        // The id of the selected repo:
        private int selectedRepoId;

        // The selected repo:
        private Repo selectedRepo;

        // An invalid repo id:
        private const int InvalidRepoId = -1;

        public override void Init(object initData)
        {
            // Provide the View with a reference to this ViewModel:
            ((RepoPage)CurrentPage).pageModel = this;

            // TODO: Accept repo id as parameter
            if ((initData != null) && (initData is long))
            {
                selectedRepoId = (int)initData;
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
                ((ResultsPage)CurrentPage).Title = PageTitle;

                Name = selectedRepo.Name;
                HtmlUrl = selectedRepo.HtmlUrl;
            }
            else
            {
                CoreMethods.DisplayAlert("Error", "Sorry, unable to display this repo.", "Dismiss");

                // Set a generic title:
                PageTitle = AppStrings.RepoDetails.UnknownRepo;
                ((ResultsPage)CurrentPage).Title = PageTitle;
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

    }
}
