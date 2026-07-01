using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace AdvancedChat.Desktop.Views;

public partial class LoginView : Page
{
    private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7042/") };

    public LoginView()
    {
        InitializeComponent();
    }

    private async void Login_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            ErrorText.Text = "Logging in...";
            var payload = new { email = EmailBox.Text, password = PasswordBox.Password };
            var response = await _httpClient.PostAsJsonAsync("login", payload);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenObj = JsonSerializer.Deserialize<JsonElement>(content);
                var token = tokenObj.GetProperty("accessToken").GetString();
                
                NavigationService.Navigate(new ChatView(token!));
            }
            else
            {
                ErrorText.Text = "Login failed. Check your credentials.";
            }
        }
        catch (Exception ex)
        {
            ErrorText.Text = $"Connection error: {ex.Message}";
        }
    }
}
