#nullable disable
using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Define as datas usando .Value para evitar o erro de conversão
        dtp_checkin.Date = DateTime.Today;
        dtp_checkout.Date = DateTime.Today.AddDays(1);
    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        try
        {
            string nomeHospede = string.IsNullOrWhiteSpace(txt_hospede.Text) ? "Não Informado" : txt_hospede.Text;

            // RESOLVIDO: Usando .Value para converter DateTime? em DateTime com segurança
            DateTime checkin = dtp_checkin.Date ?? DateTime.Today;
            DateTime checkout = dtp_checkout.Date ?? DateTime.Today.AddDays(1);

            if (checkout <= checkin)
            {
                // RESOLVIDO: Ajustado para o formato correto aceito pelo MAUI
                await DisplayAlert("Erro nas Datas", "A data de Check-out deve ser posterior à data de Check-in.", "Entendi");
                return;
            }

            int totalDias = (checkout - checkin).Days;

            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert("Atenção", "Por favor, selecione um tipo de quarto antes de calcular.", "Fechar");
                return;
            }

            string quartoSelecionado = pck_quarto.SelectedItem.ToString();
            double valorDiariaQuarto = 0;

            switch (quartoSelecionado)
            {
                case "Econômico":
                    valorDiariaQuarto = 150.00;
                    break;
                case "Luxo":
                    valorDiariaQuarto = 350.00;
                    break;
                case "Presidencial":
                    valorDiariaQuarto = 750.00;
                    break;
            }

            int adultos = (int)stp_adultos.Value;
            int criancas = (int)stp_criancas.Value;
            int totalHospedes = adultos + criancas;

            double custoQuartoTotal = valorDiariaQuarto * totalDias;
            double custoCafeTotal = 0;

            if (sw_cafe.IsToggled)
            {
                custoCafeTotal = 45.00 * totalHospedes * totalDias;
            }

            double valorTotalGeral = custoQuartoTotal + custoCafeTotal;

            string mensagemPopUp =
                $"Hóspede: {nomeHospede}\n" +
                $"Período: {totalDias} diária(s)\n" +
                $"Acomodação: Quarto {quartoSelecionado} (R$ {valorDiariaQuarto:F2}/dia)\n" +
                $"Total de Pessoas: {totalHospedes} ({adultos} Adt / {criancas} Cç)\n" +
                $"----------------------------------------\n" +
                $"Custo das Diárias: R$ {custoQuartoTotal:F2}\n" +
                $"Custo Adicional Café: R$ {custoCafeTotal:F2}\n" +
                $"----------------------------------------\n" +
                $"VALOR TOTAL: R$ {valorTotalGeral:F2}";

            // RESOLVIDO: Chamada limpa e assíncrona do Pop-up
            await DisplayAlert("✨ DETALHES DA RESERVA ✨", mensagemPopUp, "Confirmar e Fechar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu uma falha no cálculo: {ex.Message}", "Ok");
        }
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SobrePage));
    }
}