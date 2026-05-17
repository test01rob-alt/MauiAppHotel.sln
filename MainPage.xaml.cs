#nullable disable
using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        // Alterado para DisplayAlert (nativo da Page) de forma assíncrona para eliminar o aviso de obsoleto
        await this.DisplayAlert("DADOS DO DESENVOLVEDOR",
            "Nome: Robson\nAno: 2026\nInstituição: ETEC Centro Paula Souza\nProjeto: App Hotel - Agenda 13",
            "Fechar");
    }
}