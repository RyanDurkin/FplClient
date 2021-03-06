﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FplClient.Data;
using Newtonsoft.Json;

namespace FplClient.Clients
{
    public class FplEntryClient : IFplEntryClient
    {
        private readonly HttpClient _client;

        public FplEntryClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<FplBasicEntry> Get(int teamId)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var url = $"https://fantasy.premierleague.com/api/entry/{teamId}/";

            var json = await _client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<FplBasicEntry>(json);
        }

        public async Task<FplEntryPicks> GetPicks(int teamId, int gameweek)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var url = $"https://fantasy.premierleague.com/api/entry/{teamId}/event/{gameweek}/picks/";

            var json = await _client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<FplEntryPicks>(json);
        }
    }
}
