using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Media;
using Examen2Ev.Models;

namespace Examen2Ev.Services;

public class ApiService
{
    private HttpClient _client;
    private JsonSerializerOptions _options;
    private string _baseUrl = "http://192.168.16.117:7777";

    public ApiService()
    {
        _client = new HttpClient();
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<List<Artist>> GetArtists()
    {
        var artists = new List<Artist>();

        Uri uri = new Uri(_baseUrl + "/artists");

        try
        {
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                artists = JsonSerializer.Deserialize<List<Artist>>(content, _options);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return artists;
    }

    public async Task<List<Painting>> GetPaintings(int artistId)
    {
        var paintings = new List<Painting>();

        Uri uri = new Uri(_baseUrl + $"/artists/{artistId}");

        try
        {
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                paintings = JsonSerializer.Deserialize<ArtistDetail>(content, _options).Images;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        foreach (var p in paintings)
        {
            p.Genre = await GetGenreName(p.GenreId);
        }

        return paintings;
    }

    private async Task<string> GetGenreName(int genreId)
    {
        string genreName = "";

        Uri uri = new Uri(_baseUrl + $"/genres/{genreId}");

        try
        {
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                genreName = JsonSerializer.Deserialize<Genre>(content, _options).Name;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return genreName;
    }
}