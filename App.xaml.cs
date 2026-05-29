#nullable disable
using Microsoft.Maui.Controls;

namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Inicialização padrão e limpa usando o Shell do projeto
        MainPage = new AppShell();
    }
}