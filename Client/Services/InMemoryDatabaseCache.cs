using System.Net.Http.Json;
using BlazorApp1.Static;
using Shared.Models;

namespace BlazorApp1.Services;

internal sealed class InMemoryDatabaseCache
{
    private readonly HttpClient _httpClient;
    public InMemoryDatabaseCache(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private List<Category> _categories = null;

    internal List<Category> Categories
    {
        get
        {
            return _categories;
        }
        set
        {
            _categories = value;
            NotifyCategoriesDataChanged();
        }
    }

    private bool _gettingCategoriesFromDatabaseAndCache = false;
    internal async Task GetCategoriesFromDatabaseAndCache()
    {
        if (_gettingCategoriesFromDatabaseAndCache == false)
        {
            _gettingCategoriesFromDatabaseAndCache = true;
            _categories = await _httpClient.GetFromJsonAsync<List<Category>>(APIEndpoint.s_categories);
            _gettingCategoriesFromDatabaseAndCache = false;
        }
    }

    internal event Action OnCategoriesDataChanged;
    private void NotifyCategoriesDataChanged() => OnCategoriesDataChanged?.Invoke();
}