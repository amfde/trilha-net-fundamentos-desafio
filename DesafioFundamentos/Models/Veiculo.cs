namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public DateTime Entrada { get; private set; }
        public DateTime Saida { get; private set; }

        public Veiculo(string placa, string modelo, string marca, DateTime entrada)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Entrada = entrada;
        }

        public void HoraSaida(DateTime saida)
        {
            this.Saida = saida;
        }

        public TimeSpan TempoPermanencia() => Saida - Entrada;

    }
}