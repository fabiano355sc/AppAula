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
        public Veiculo _veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento {
            get { return dataAgendamento; }
            set { dataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento { get; set; }
        
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this._veiculo = veiculo;
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string mensagem = string.Format("Nome: {0} Fone: {1} E-mail: {2} Data: {3} Hora: {4}",
                Nome, Fone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento);

            DisplayAlert("Agendamento", mensagem, "Ok");
        }
    }
}