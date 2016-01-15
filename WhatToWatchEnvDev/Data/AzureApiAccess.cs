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
            
            try
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
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> GetUser(String newEmail, String newPassword)
        {
            try
            {
                List<User> users = await GetAllUsers();
                if (users.Any())
                {
                    foreach (User item in users)
                    {
                        if (item.email.Equals(newEmail) && item.password.Equals(newPassword))
                        {
                            currentApp.GlobalInstance.GlobalUser = item;
                            currentApp.GlobalInstance.GlobalUser.ListFavoris = await GetAllFavoritesFromGlobalUser();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveFavorite(Movie movieFav)
        {
            try
            {
                int? idFav = -1;
                List<Favori> favoris = await GetAllFavoris();
                //find wich favori to delete in the api
                foreach (Favori item in favoris)
                {
                    if (item.idMovie == movieFav.id && item.emailUser == currentApp.GlobalInstance.GlobalUser.email)
                    {
                        idFav = item.id;
                    }
                }

                HttpResponseMessage response = await client.DeleteAsync("api/filmfavoris/" + idFav);
                if (response.IsSuccessStatusCode)
                {
                    //find wich favori to delete in the global user's list
                    foreach (Favori item in currentApp.GlobalInstance.GlobalUser.ListFavoris)
                    {
                        if (item.idMovie == movieFav.id)
                        {
                            currentApp.GlobalInstance.GlobalUser.ListFavoris.Remove(item);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<List<Favori>> GetAllFavoris()
        {

            HttpResponseMessage response = await client.GetAsync("api/filmfavoris");
            List<Favori> favoris = new List<Favori>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                favoris = JsonConvert.DeserializeObject<List<Favori>>(json);
            }
            return favoris;
        }

        public async Task<List<Favori>> GetAllFavoritesFromGlobalUser()
        {
            HttpResponseMessage response = await client.GetAsync("api/filmfavoris");
            List<Favori> favoris = new List<Favori>();
            List<Favori> userFavoris = new List<Favori>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                favoris = JsonConvert.DeserializeObject<List<Favori>>(json);

                foreach (Favori item in favoris)
                {
                    if (item.emailUser == currentApp.GlobalInstance.GlobalUser.email)
                    {
                        userFavoris.Add(item);
                    }
                }
            }

            return userFavoris;
        }

        public async Task<bool> AddToFavorite(Movie movieFav)
        {
            try
            {
                    // check if the new fav isn't alreagy in the DB
                foreach (Favori item in currentApp.GlobalInstance.GlobalUser.ListFavoris)
                {
                    if(movieFav.id == item.idMovie)
                    {
                        return false;
                    }
                }

                //add fav            
                Favori fav = new Favori(0, movieFav.id, currentApp.GlobalInstance.GlobalUser.email);
                fav.id = 0;
                currentApp.GlobalInstance.GlobalUser.ListFavoris.Add(fav);
                string json = JsonConvert.SerializeObject(fav);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/filmfavoris", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Boolean> createUser(String newEmail, String newPassword)
        {
            try
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
                currentApp.GlobalInstance.GlobalUser = userToCreate;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}


