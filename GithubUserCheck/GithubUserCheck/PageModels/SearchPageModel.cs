using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck
{
    public class SearchPageModel : FreshMvvm.FreshBasePageModel
    {
        public override void Init(object initData)
        {
            Debug.WriteLine("SearchPageModel: Init called.");

            WelcomeText = "Sleeping. Zzzzz ....";
        }

        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            Debug.WriteLine("SearchPageModel: ViewIsAppearing.");

            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, System.EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        private string _welcomeText;
        public string WelcomeText
        {
            get { return _welcomeText; }
            set
            {
                _welcomeText = value;
                RaisePropertyChanged("WelcomeText");
            }
        }
    }
}
