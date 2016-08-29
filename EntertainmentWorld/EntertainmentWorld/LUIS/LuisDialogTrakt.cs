using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EntertainmentWorld.Models;
using System.Linq;

namespace EntertainmentWorld
{

    [LuisModel("ef0f8c5d-7724-48be-9d62-016ba704232f", "")]
    [Serializable]

    public class LuisDialogTrakt : LuisDialog<object>
    {
        public LuisDialogTrakt()
        {
        }

        public LuisDialogTrakt(ILuisService service) : base(service)
        {
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            //if luis cannot find result
            string message = "Sorry invaild message ,Please try Again!";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
        //POPULAR MOVIES
        [LuisIntent("intent.Entertainmentworld1.movie.popular")]
        public async Task Popular(IDialogContext context, LuisResult result)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("https://api.trakt.tv") })

            {
                //clientid  from trakt
                client.DefaultRequestHeaders.Add("trakt-api-key", "be003f63462510f551328329339d8fcc4dc8fa32c792004ba498b57eb050dadc");
                client.DefaultRequestHeaders.Add("trakt-api-version", "2");
                using (var Message = client.GetAsync("movies/popular").Result)
                {
                    if (Message.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = Message.Content.ReadAsStringAsync().Result;
                        //replaying to the json message using the popular movie function
                        var responseJSON = JsonConvert.DeserializeObject<List<PopularMovies>>(responseString);
                    }

                    else
                    {
                        string message = $"Sorry invalid message, please try again: " + string.Join(", ", result.Intents.Select(i => i.Intent));
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);
                    }
                }
            }
        }
        //WATCHED MOVIES
        [LuisIntent("intent.Entertainmentworld1.movie.Watched")]
        public async Task Watched(IDialogContext context, LuisResult result)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("https://api.trakt.tv") })

            {
                //clientid  from trakt
                client.DefaultRequestHeaders.Add("trakt-api-key", "be003f63462510f551328329339d8fcc4dc8fa32c792004ba498b57eb050dadc");
                client.DefaultRequestHeaders.Add("trakt-api-version", "2");
                using (var Message = client.GetAsync("movies/watched").Result)
                {
                    if (Message.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = Message.Content.ReadAsStringAsync().Result;
                        //replaying to the json message using the popular movie function
                        var responseJSON = JsonConvert.DeserializeObject<List<WatchedMovies>>(responseString);
                    }

                    else
                    {
                        string message = $"Sorry invalid message, please try again: " + string.Join(", ", result.Intents.Select(i => i.Intent));
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);
                    }
                }
            }
        }
        //WATCHED SHOW
        [LuisIntent("intent.Entertainmentworld1.show.watched")]
        public async Task Collected(IDialogContext context, LuisResult result)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("https://api.trakt.tv") })

            {
                //clientid  from trakt
                client.DefaultRequestHeaders.Add("trakt-api-key", "be003f63462510f551328329339d8fcc4dc8fa32c792004ba498b57eb050dadc");
                client.DefaultRequestHeaders.Add("trakt-api-version", "2");
                using (var Message = client.GetAsync("shows/collected").Result)
                {
                    if (Message.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = Message.Content.ReadAsStringAsync().Result;
                        //replaying to the json message using the popular movie function
                        var responseJSON = JsonConvert.DeserializeObject<List<Watchedshows>>(responseString);
                    }

                    else
                    {
                        string message = $"Sorry invalid message, please try again: " + string.Join(", ", result.Intents.Select(i => i.Intent));
                        await context.PostAsync(message);
                        context.Wait(MessageReceived);
                    }
                }
            }
        }
    }
}
