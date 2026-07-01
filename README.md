# AdvancedChat Desktop

A Windows Desktop client for AdvancedChat, built with .NET 8 WPF and Material Design. It connects to the `AdvancedChat.Web` ASP.NET Core API via SignalR for real-time messaging and secure JWT authentication.

## Features
- **Material Design UI**: Clean layouts and modern typography using MaterialDesignThemes.
- **Secure Authentication**: Uses .NET 8 Identity API endpoints for JWT Bearer token authentication.
- **Real-Time Communication**: SignalR client implementation for instant messaging in custom chat rooms.

## Getting Started

### Prerequisites
- .NET 8 SDK
- Running instance of the AdvancedChat.Web backend.

### Running the Application
1. Start the backend API (`AdvancedChat.Web`) and ensure it listens on `https://localhost:7042`.
2. Run the desktop client from the `AdvancedChat.Desktop` directory:
   ```bash
   dotnet run
   ```
3. Log in with an existing user, enter a Room ID (e.g., `1`), and start chatting.

## Tech Stack
- .NET 8.0 WPF
- MaterialDesignThemes
- Microsoft.AspNetCore.SignalR.Client
