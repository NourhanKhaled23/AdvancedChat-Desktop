using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;

namespace AdvancedChat.Desktop.Views;

public record ReceiveMessagePayload(int roomId, string userName, string text, DateTime sentAt);

public partial class ChatView : Page
{
    private readonly string _token;
    private HubConnection? _connection;
    private int _currentRoomId = 0;

    public ChatView(string token)
    {
        InitializeComponent();
        _token = token;
        _ = ConnectToSignalR();
    }

    private async Task ConnectToSignalR()
    {
        StatusText.Text = "Connecting...";
        try
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7042/chatHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult((string?)_token);
                })
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("SystemMessage", (message) =>
            {
                Dispatcher.Invoke(() => MessagesList.Items.Add($"[System] {message}"));
            });

            _connection.On<ReceiveMessagePayload>("ReceiveMessage", (payload) =>
            {
                Dispatcher.Invoke(() => 
                {
                    MessagesList.Items.Add($"[{payload.sentAt:HH:mm}] {payload.userName}: {payload.text}");
                    MessagesList.ScrollIntoView(MessagesList.Items[^1]);
                });
            });

            await _connection.StartAsync();
            StatusText.Text = "Connected";
            var greenBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightGreen);
            StatusText.Foreground = greenBrush;
            StatusIcon.Foreground = greenBrush;
        }
        catch (Exception ex)
        {
            StatusText.Text = $"Connection failed: {ex.Message}";
            var redBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            StatusText.Foreground = redBrush;
            StatusIcon.Foreground = redBrush;
        }
    }

    private async void Join_Click(object sender, RoutedEventArgs e)
    {
        if (_connection?.State == HubConnectionState.Connected && int.TryParse(RoomIdBox.Text, out var roomId))
        {
            try
            {
                await _connection.InvokeAsync("JoinRoom", roomId);
                _currentRoomId = roomId;
                MessagesList.Items.Add($"--- Joined Room {roomId} ---");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error joining room");
            }
        }
    }

    private async void Send_Click(object sender, RoutedEventArgs e)
    {
        await SendMessageAsync();
    }

    private async void MessageBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            await SendMessageAsync();
        }
    }

    private async Task SendMessageAsync()
    {
        if (_connection?.State == HubConnectionState.Connected && _currentRoomId > 0 && !string.IsNullOrWhiteSpace(this.MessageBox.Text))
        {
            try
            {
                await _connection.InvokeAsync("SendMessage", _currentRoomId, this.MessageBox.Text);
                this.MessageBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error sending message");
            }
        }
    }
}
