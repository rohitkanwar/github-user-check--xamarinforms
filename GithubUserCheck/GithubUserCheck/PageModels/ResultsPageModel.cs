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
using Xamarin.Forms;

namespace GithubUserCheck.PageModels
{
    public class ResultsPageModel : FreshMvvm.FreshBasePageModel
    {
        public override void Init(object initData)
        {
            // Provide the View with a reference to this ViewModel:
            ((ResultsPage)CurrentPage).pageModel = this;
        }

        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            // Set the page title and various properties:

            PageTitle = string.Format("User {0}", Data.currentUser.Login);
            ((ResultsPage)CurrentPage).Title = PageTitle;

            User user = Data.currentUser;

            // Date when the user joined Github:
            //DateTime dateOfRegistration = DateTime.Parse(user.CreatedAt.ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind);
            //string dateOfRegistrationDescription = dateOfRegistration.ToString("dd MMMM yyyy");
            //JoiningDateDescription = string.Format(AppStrings.Results.JoiningDateDescriptionTemplate, dateOfRegistrationDescription);
            JoiningDateDescription = string.Format(AppStrings.Results.JoiningDateDescriptionTemplate, user.CreatedAt.ToString("dd MMMM yyyy"));

            // The number of public repos the user has:
            string numReposDescription = string.Empty;
            long numRepos = Data.currentUser.PublicRepos;
            if (numRepos == 0L)
            {
                numReposDescription = AppStrings.Results.NoReposDescription;
            }
            else if (numRepos == 1L)
            {
                numReposDescription = AppStrings.Results.SolitaryRepoDescription;
            }
            else
            {
                numReposDescription = string.Format(AppStrings.Results.NumReposDescriptionTemplate, numRepos);
            }

            // The number of public gists the user has:
            string numGistsDescription = string.Empty;
            long numGists = Data.currentUser.PublicGists;
            if (numGists == 0L)
            {
                numGistsDescription = AppStrings.Results.NoGistsDescription;
            }
            else if (numGists == 1L)
            {
                numGistsDescription = AppStrings.Results.SolitaryGistDescription;
            }
            else
            {
                numGistsDescription = string.Format(AppStrings.Results.NumGistsDescriptionTemplate, numGists);
            }

            //// Combine the two descriptions into one sentence:
            //NumReposAndGistsDescription = string.Format(AppStrings.Results.NumReposAndGistsTemplate, numReposDescription, numGistsDescription);

            NumReposAndGistsDescription = numReposDescription + ".";

            // Summarize the followers and following count:
            NumFollowersFollowingDescription = string.Format(AppStrings.Results.NumFollowersFollowingTemplate, user.Followers, user.Following);

            // The user's avatar:
            if (!string.IsNullOrWhiteSpace(user.AvatarUrl))
            {
                AvatarImageSource = ImageSource.FromUri(new Uri(Data.currentUser.AvatarUrl));
            }
            else
            {
                if (user.AvatarUrl == null)
                {
                    Debug.WriteLine("Cannot display avatar: user.AvatarUrl is null.");
                }
                else
                {
                    Debug.WriteLine("Cannot display avatar: user.AvatarUrl.Length = {0}, user.AvatarUrl = {1}", user.AvatarUrl.Length, user.AvatarUrl);
                }
            }

            // The list of the user's repos:
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

        private string _numReposAndGistsDescription;
        public string NumReposAndGistsDescription
        {
            get { return _numReposAndGistsDescription; }
            set
            {
                _numReposAndGistsDescription = value;
                RaisePropertyChanged("NumReposAndGistsDescription");
            }
        }

        private string _numFollowersFollowingDescription;
        public string NumFollowersFollowingDescription
        {
            get { return _numFollowersFollowingDescription; }
            set
            {
                _numFollowersFollowingDescription = value;
                RaisePropertyChanged("NumFollowersFollowingDescription");
            }
        }

        private ImageSource _avatarImageSource;
        public ImageSource AvatarImageSource
        {
            get { return _avatarImageSource; }
            set
            {
                _avatarImageSource = value;
                RaisePropertyChanged("AvatarImageSource");
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

                Debug.WriteLine("Selected repo: Id={0}", _selectedRepo.Id);

                HandleRepoSelection();
            }
        }

        private async void HandleRepoSelection()
        {
            // Use internal web browser:
            await CoreMethods.PushPageModel<RepoPageModel>(_selectedRepo.Id, false, true);

            // Use external web browser app:
            //await Task.Run(() =>
            //{
            //    Device.OpenUri(new Uri(SelectedRepo.HtmlUrl));
            //});

        }






    }
}
