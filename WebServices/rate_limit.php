<?php

  $url = "https://api.github.com/rate_limit";

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