#nullable disable
using Microsoft.Maui.Controls;

namespace MauiAppHotel;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registra a rota da página Sobre de forma explícita no Shell
        Routing.RegisterRoute(nameof(SobrePage), typeof(SobrePage));
    }
}