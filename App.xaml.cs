#nullable disable
using Microsoft.Maui.Controls;

namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Inicialização padrão segura
        MainPage = new AppShell();
    }
}