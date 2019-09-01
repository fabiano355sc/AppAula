using AppAula.Models;
using AppAula.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAula.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = ViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", 
                async msg =>
                {
                    var confirmar = await DisplayAlert("Salvar Agendamento",
                        "Deseja mesmo enviar o agendamento?",
                        "Sim", "Não");

                    if (confirmar)
                    {
                        this.ViewModel.SalvarAgendamento();
                        /*
                        string mensagem = string.Format("Veiculo: {0} Nome: {1} Fone: {2} E-mail: {3} Data: {4} Hora: {5}",
                            ViewModel.Agendamento.Veiculo.Nome,
                            ViewModel.Agendamento.Nome,
                            ViewModel.Agendamento.Fone,
                            ViewModel.Agendamento.Email,
                            ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                            ViewModel.Agendamento.HoraAgendamento);

                        await DisplayAlert("Agendamento", mensagem, "Ok");
                        */
                    }
                });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
                msg =>
                {
                    DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "Ok");
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
                msg =>
                {
                    DisplayAlert("Agendamento", "Falhou no agendamento!", "Ok");
                });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}