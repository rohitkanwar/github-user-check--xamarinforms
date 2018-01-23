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
    public class ResultsPageModel : FreshMvvm.FreshBasePageModel
    {
        public override void Init(object initData)
        {
            // Provide the View with a reference to this ViewModel:
            ((ResultsPage)CurrentPage).pageModel = this;

            // TODO: Set properties in ViewIsAppearing:

            PageTitle = string.Format("User {0}", Data.currentUser.Login);
            ((ResultsPage)CurrentPage).Title = PageTitle;


            // Set the various properties:
            JoiningDateDescription = string.Format(AppStrings.Results.JoiningDateDescriptionTemplate, "TODO");
            int numRepos = Data.currentUserRepos.Count;
            if (numRepos == 0)
            {
                NumReposDescription = AppStrings.Results.NoReposDescription;
            }
            else if (numRepos == 1)
            {
                NumReposDescription = AppStrings.Results.SolitaryRepoDescription;
            }
            else
            {
                NumReposDescription = string.Format(AppStrings.Results.NumReposDescriptionTemplate, numRepos);
            }

            UserRepos = Data.currentUserRepos;
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

        private string _joiningDateDescription;
        public string JoiningDateDescription
        {
            get { return _joiningDateDescription; }
            set
            {
                _joiningDateDescription = value;
                RaisePropertyChanged("JoiningDateDescription");
            }
        }

        private string _numReposDescription;
        public string NumReposDescription
        {
            get { return _numReposDescription; }
            set
            {
                _numReposDescription = value;
                RaisePropertyChanged("NumReposDescription");
            }
        }


        private List<Repo> _userRepos;
        public List<Repo> UserRepos
        {
            get { return _userRepos; }
            set
            {
                _userRepos = value;
                RaisePropertyChanged("UserRepos");
            }
        }

        private Repo _selectedRepo;
        public Repo SelectedRepo
        {
            get { return _selectedRepo; }
            set
            {
                _selectedRepo = value;
                RaisePropertyChanged("SelectedRepo");

                Debug.WriteLine("Selected repo: Name={0}, HtmlUrl={1}", _selectedRepo.Name, _selectedRepo.HtmlUrl);

                HandleRepoSelection();
            }
        }

        private async void HandleRepoSelection()
        {
            await CoreMethods.PushPageModel<RepoPageModel>(SelectedRepo.Id, false, true);
        }






    }
}
