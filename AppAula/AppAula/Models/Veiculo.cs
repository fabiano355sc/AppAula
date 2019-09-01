using System;
using System.Collections.Generic;
using System.Text;

namespace AppAula.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }
        public bool TemFreio { get; set; }
        public bool TemAR { get; set; }
        public bool TemMP3 { get; set; }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor Total: R$ {0}",
                    Preco
                    + (TemFreio ? FREIO_ABS : 0)
                    + (TemAR ? AR_CONDICIONADO : 0)
                    + (TemMP3 ? MP3_PLAYER : 0)
                    );
            }
        }
    }
}
