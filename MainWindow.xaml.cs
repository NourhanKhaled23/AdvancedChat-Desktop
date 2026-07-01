using System.Windows;
using AdvancedChat.Desktop.Views;

namespace AdvancedChat.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new LoginView());
    }
}