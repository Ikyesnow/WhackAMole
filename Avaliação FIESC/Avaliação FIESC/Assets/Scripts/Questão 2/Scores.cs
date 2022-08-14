using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;


public class Scores
{
    public string Nome { get; set; }
    public int Ponto { get; set; }

}

public class ScoresClient
{
    private string _getHighscoreUrl;
    private string _getPlayerHighscoreUrl;
    private string _postHighscoreUrl;
    public ScoresClient()
    {
        _getHighscoreUrl = "http://localhost:3000/highscore";
        _getPlayerHighscoreUrl = "http://localhost:3000/highscore/{nome}";
        _postHighscoreUrl = "http://localhost:3000/novoHighscore/";

#if UNITY_EDITOR
        _getHighscoreUrl = "http://localhost:3000/highscore";
        _getPlayerHighscoreUrl = "http://localhost:3000/highscore/{nome}";
        _postHighscoreUrl = "http://localhost:3000/novoHighscore/";
#endif
    }
    public List<Scores> GetHighScores()
    {
        var message = new HttpRequestMessage(HttpMethod.Get, _getHighscoreUrl);
        var result = SendRequest<List<Scores>>(message);

        return result;
    }

    public List<Scores> GetPlayerScore(string nome)
    {
        var message = new HttpRequestMessage(HttpMethod.Get, _getPlayerHighscoreUrl.Replace("{nome}", nome));
        var result = SendRequest<List<Scores>>(message);

        return result;

    }
    public List<Scores> PostPlayerScore(string nome, int ponto)
    {
        var score = new Scores
        {
            Nome = nome,
            Ponto = ponto
        };

        var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var json = JsonConvert.SerializeObject(score, jsonSettings);
        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var message = new HttpRequestMessage(HttpMethod.Post, _postHighscoreUrl);
        message.Content = httpContent;

        var result = SendRequest<List<Scores>>(message);

        return result;
    }

    private T SendRequest<T>(HttpRequestMessage message)
    {
        using (var httpClient = new HttpClient())
        {
            var result = httpClient.SendAsync(message).Result;

            var content = result.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<T>(content);

            return obj;

        }
    }
}
