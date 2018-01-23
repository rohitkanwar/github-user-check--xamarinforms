<?php
// This PHP service in turn calls the GitHub API, and returns its result.

  // Find out the username passed, or assume a default one:
  if (isset($_GET['user']))
  {
    $user = $_GET['user'];
  }
  else
  {
    $user = 'octocat';
  }
  
  $url = "https://api.github.com/users/{$user}/repos";

  $curl = curl_init();
  
  // Authentication:
  curl_setopt($curl, CURLOPT_HTTPAUTH, CURLAUTH_BASIC);
  curl_setopt($curl, CURLOPT_USERPWD, "rohitkanwar:51bcd540c455d11e6f780b57c68bcb7ca5452511");
    
  curl_setopt($curl, CURLOPT_URL, $url);
  curl_setopt($curl, CURLOPT_USERAGENT, 'rohitkanwar');
  //curl_setopt($curl, CURLOPT_USERAGENT,'Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.13) Gecko/20080311 Firefox/2.0.0.13');
  curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);

  $result = curl_exec($curl);

  curl_close($curl);

  echo($result);
?> 
