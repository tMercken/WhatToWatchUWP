using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WhatToWatchEnvDev.Model;
using Windows.UI.Xaml;

namespace WhatToWatchEnvDev.Data
{
    class AzureApiAccess
    {
        private HttpClient client;
        private String apiUrl = "http://whattowatchapi.azurewebsites.net/";
        private String GetUserFromLogin;
        private String GetFavorisFromUser;
        private App currentApp = Application.Current as App;

        public AzureApiAccess ()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<User>> GetAllUsers()
        {
           
            HttpResponseMessage response = await client.GetAsync("api/users");
            List<User> users = new List<User>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return users;
        }

        public async Task<Boolean> FindUser(String newEmail, String newPassword)
        {
            List<User> users = await GetAllUsers();

            if (users.Any())
            {
                foreach (User item in users)
                {
                    if (item.email.Equals(newEmail) && item.password.Equals(newPassword))
                    {
                        //currentApp.GlobalInstance.userId = item.userid;
                        Windows.Storage.ApplicationDataContainer localSetting = Windows.Storage.ApplicationData.Current.LocalSettings;
                        //localSetting.Values["userid"] = item.userid;
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> RemoveFavorite(int idFav)
        {

            HttpResponseMessage response = await client.DeleteAsync("api/favoris/" + idFav);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Favori>> GetAllFavoris()
        {

            HttpResponseMessage response = await client.GetAsync("api/users");
            List<Favori> favoris = new List<Favori>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                favoris = JsonConvert.DeserializeObject<List<Favori>>(json);
            }
            return favoris;
        }

        public async Task<bool> AddToFavorite(Movie movieFav)
        {
            // witch one is added, fav or newFavorite
            // don't forget to check if the new fav isn't alreagy in the DB
            Favori fav = new Favori(movieFav.id, currentApp.GlobalInstance.GlobalUser.email);
            string json = JsonConvert.SerializeObject(fav);
            List<Favori> favoris = await GetAllFavoris();
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/favoris", content);

            if ((response.IsSuccessStatusCode) || (response.StatusCode.ToString().Equals("Conflict")))
            {
                Favori newFavori = new Favori(movieFav.id, currentApp.GlobalInstance.GlobalUser.email);
                string jsonFav = JsonConvert.SerializeObject(newFavori);
                HttpContent contentFavoris = new StringContent(jsonFav, Encoding.UTF8, "application/json");
                HttpResponseMessage responseFav = await client.PostAsync("api/userfavorites", contentFavoris);

                if (responseFav.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<Boolean> createUser(String newEmail, String newPassword)
        {
            User userToCreate = new User();
            List<User> users = await GetAllUsers();
            
            foreach (User item in users)
            {
                if (item.email.Equals(newEmail))
                {
                    return false;
                }
            }

            userToCreate.email = newEmail;
            userToCreate.password = newPassword;
            userToCreate.ListFavoris = new List<Favori>();
            string json = JsonConvert.SerializeObject(userToCreate);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response2 = await client.PostAsync("api/users", content);
            return true;
        }

    }
}


