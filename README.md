# AdvancedChat Desktop 💬

A modern, professional Windows Desktop application for **AdvancedChat**, built with **.NET 8 WPF** and beautifully styled using **Material Design**.

This client connects seamlessly to the `AdvancedChat.Web` ASP.NET Core API via **SignalR** to provide real-time messaging, secure JWT authentication, and a smooth user experience.

---

## 🎨 Features
- **Material Design UI**: Clean layouts, smooth interactions, floating labels, drop shadows, and modern typography (MaterialDesignThemes).
- **Secure Authentication**: Uses the `.NET 8 Identity API` endpoints to authenticate users and fetch JWT Bearer tokens securely—no browser cookies required!
- **Real-Time Communication**: Built-in SignalR client implementation allowing instant sending and receiving of messages in custom chat rooms.
- **Robust Architecture**: Separation of concerns with custom WPF Views for Navigation, Login, and Chat logic.

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- The [AdvancedChat.Web](https://github.com/NourhanKhaled23/AdvancedChat-Web) backend must be running.

### 1. Start the Backend API
Navigate to your `AdvancedChat.Web` project and run:
```bash
dotnet run
```
Ensure the API is listening on `https://localhost:7042` (default configured port).

### 2. Run the Desktop Client
Navigate to this repository folder (`AdvancedChat.Desktop`) and run:
```bash
dotnet run
```
The application will launch. 

### 3. Usage
- **Login**: Enter the credentials of a user registered on the Web Backend.
- **Join Room**: Enter a Room ID (e.g., `1`) in the top bar to connect and load messages.
- **Chat**: Type your messages in the modern text box and hit "SEND" or `Enter`.

## 🛠️ Tech Stack
- **Framework**: .NET 8.0 WPF (Windows Presentation Foundation)
- **UI Library**: `MaterialDesignThemes` v5+
- **Real-Time Engine**: `Microsoft.AspNetCore.SignalR.Client`
- **HTTP Client**: `Microsoft.Extensions.Http`

## 🤝 Contributing
Feel free to submit pull requests, open issues, and request new features!
