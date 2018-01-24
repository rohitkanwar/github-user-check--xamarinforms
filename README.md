# GitHub User Check - Xamarin.Forms
A sample Android app that can search for a user on GitHub, and display a list of their repositories. The app is made using [Xamarin.Forms](https://www.xamarin.com/forms), and the [FreshMVVM framework](https://github.com/rid00z/FreshMvvm).

## Functionality
#### Search screen
<img src="https://github.com/rohitkanwar/github-user-check--xamarinforms/blob/master/Screenshots/01-Search.png?raw=true" height="480"/>
This is the first screen of the app. Here, you enter the username of the GitHub user you want to check. The app pre-populates this field with the username for [Chris Wanstrath](https://github.com/defunkt), the co-founder and CEO of GitHub.

If the search (lookup) for the entered username succeeds, the app would take you to the **Results screen**.
#### Results screen
<img src="https://github.com/rohitkanwar/github-user-check--xamarinforms/blob/master/Screenshots/02-Results.png?raw=true" height="480"/>
This screen displays the user's avatar, and a short summary of their stats. Below this information, the app displays a list of the user's repositories. If you tapped any of the items (repositories) in this list, the app would take you to the GitHub webpage for the repo, using your phone's browser application:
<img src="https://github.com/rohitkanwar/github-user-check--xamarinforms/blob/master/Screenshots/04-RepoPageInBrowser.png?raw=true" height="480"/>

#### Internal Browser
The app also contains a screen with an embedded WebView. Instead of launching the external browser app, the app can use this screen to display a repo's webpage. At the moment, this functionality is commented-out, but can be easily enabled it.

If you have any feedback or suggestions, please let me know. :)

