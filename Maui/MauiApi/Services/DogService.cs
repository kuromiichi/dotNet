using MauiApi.Models;
using System.Text.Json;
using static MauiApi.Models.Dog;

namespace MauiApi.Services;

public class DogService
{
    private HttpClient _client;
    private JsonSerializerOptions _jsonOptions;

    private string _baseUrl = "https://api.thedogapi.com/v1";
    private int limit = Preferences.Default.Get("DogNumber", 5);
    private string apiKey = Preferences.Default.Get("ApiKey", string.Empty);

    public List<Dog> Dogs { get; private set; }
    public List<Breed> Breeds { get; private set; }

    public DogService()
    {
        _client = new HttpClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<List<Dog>> GetDogs()
    {
        Dogs = new List<Dog>();

        var uri = new Uri(_baseUrl + "/images/search" +
                          "?has_breeds=1" +
                          $"&limit={limit}" +
                          $"&api_key={apiKey}");

        try
        {
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Dogs = JsonSerializer.Deserialize<List<Dog>>(content, _jsonOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Dogs;
    }

    public async Task<List<Breed>> GetBreeds()
    {
        Breeds = new List<Breed>();

        var uri = new Uri(_baseUrl + "/breeds");

        try
        {
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Breeds = JsonSerializer.Deserialize<List<Breed>>(content, _jsonOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Breeds;
    }

    public async Task<string> GetBreedImage(int breedId)
    {
        string image = string.Empty;

        var uri = new Uri(_baseUrl + $"/images/search?breed_id={breedId}&api_key={apiKey}");

        try
        {
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                image = JsonSerializer.Deserialize<List<Dog>>(content, _jsonOptions)[0].Url;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return image;
    }
}