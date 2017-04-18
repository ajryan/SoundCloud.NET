using System;
using System.Collections.Generic;
using System.Linq;
using SoundCloud.NET;

namespace Test
{
class Program
    {
        //Enter app credentials from here http://soundcloud.com/you/apps
        private const string ClientId = "";
        private const string ClientSecret = "";
        //enter username and password a soundcloud user, e.g. your own credentials
        private const string Username = "";
        private const string Password = "";

        static void Main(string[] args)
        {
            //fill credentials
            SoundCloudCredentials credentials = new SoundCloudCredentials(ClientId, ClientSecret, Username, Password);
            //create client
            SoundCloudClient client = new SoundCloudClient(credentials);
            //login to soundcloud
            SoundCloudAccessToken token = client.Authenticate().Result;

            //fetch some data
            if (client.IsAuthenticated)
            {
                //Fetch current user info
                var mySelf = User.Me();
                //search for tracks
                string searchFor = "warren zevon";
                //execute search
                List<Track> searchResults = Track.Search(searchFor, null, Filter.All, "", "", null, null, null, null, DateTime.MinValue, DateTime.Now, null, null, null).Result;
                //iterate in tracks and fetch details again
                foreach (int trackId in searchResults.Select(track => track.Id))
                {
                    Track track = Track.GetTrack(trackId).Result;
                    Console.WriteLine(track.Title);
                    //here you can play a track or do something else ;)
                }
            }
            //wait for user input
            Console.ReadLine();
        }
    }
}
