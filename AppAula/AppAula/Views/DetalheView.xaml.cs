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
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;
        public Veiculo _veiculo { get; set; }

        public string TextoFreioABS
        {
            get { return string.Format("Freio ABS R$ {0}", FREIO_ABS);}
        }
        public string TextoArCondicionado
        {
            get { return string.Format("Ar Condicionado R$ {0}", AR_CONDICIONADO); }
        }
        public string TextoMP3Player
        {
            get { return string.Format("MP3 Player R$ {0}", MP3_PLAYER); }
        }

        bool temFreio;
        public bool TemFreio {
            get { return temFreio; }
            set
            {
                temFreio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temAR;
        public bool TemAR
        {
            get { return temAR; }
            set
            {
                temAR = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temMP3;
        public bool TemMP3
        {
            get { return temMP3; }
            set
            {
                temMP3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public string ValorTotal
        {
            get
            {
                return string.Format("Valor Total: R$ {0}",
                    _veiculo.Preco
                    + (TemFreio ? FREIO_ABS : 0)
                    + (TemAR ? AR_CONDICIONADO : 0)
                    + (TemMP3 ? MP3_PLAYER : 0)
                    );
            }
        }
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this._veiculo = veiculo;
            this.BindingContext = this;
        }

        private void ButtonProximo_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AgendamentoView(this._veiculo));

        }
    }
}