using System;
using System.Collections.Generic;
using System.Text;

namespace AppAula.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 40000 },
                new Veiculo { Nome = "Fiesta", Preco = 50000 },
                new Veiculo { Nome = "HB20 S", Preco = 25000 }
            };
        }

    }
}
