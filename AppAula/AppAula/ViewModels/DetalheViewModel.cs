using AppAula.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppAula.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
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

        public void OnPropertyChanged([CallerMemberName]string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
        }
    }
}
