using AppAula.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppAula.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS
        {
            get { return string.Format("Freio ABS R$ {0}", Veiculo.FREIO_ABS); }
        }
        public string TextoArCondicionado
        {
            get { return string.Format("Ar Condicionado R$ {0}", Veiculo.AR_CONDICIONADO); }
        }
        public string TextoMP3Player
        {
            get { return string.Format("MP3 Player R$ {0}", Veiculo.MP3_PLAYER); }
        }
        public bool TemFreio
        {
            get { return Veiculo.TemFreio; }
            set
            {
                Veiculo.TemFreio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemAR
        {
            get { return Veiculo.TemAR; }
            set
            {
                Veiculo.TemAR = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemMP3
        {
            get { return Veiculo.TemMP3; }
            set
            {
                Veiculo.TemMP3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoComand = new Command(()=> {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }

        public ICommand ProximoComand { get; set; }
    }
}
