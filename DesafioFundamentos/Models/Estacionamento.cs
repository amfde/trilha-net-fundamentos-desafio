namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal _precoInicial = 0;
        private readonly decimal _precoPorHora = 0;
        private readonly List<Veiculo> Veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this._precoInicial = precoInicial;
            this._precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTADO*
                        
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veículo para estacionar:");
            string modelo = Console.ReadLine();
            Console.WriteLine("Digite a marca do veículo para estacionar:");
            string marca = Console.ReadLine();
            DateTime entrada = DateTime.Now;
            
            Veiculo veiculo = new(placa, modelo, marca, entrada);
            
            Veiculos.Add(veiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTADO*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (Veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                
                var veiculo = Veiculos.Where(x => x.Placa.ToUpper() == placa.ToUpper()).FirstOrDefault();
            
                veiculo.HoraSaida(DateTime.Now);
                var permanencia = veiculo.TempoPermanencia();
                decimal valorTotal = _precoInicial + (_precoPorHora * permanencia.Hours);

                Console.WriteLine($"Veículo {veiculo.Marca.ToUpper()} {veiculo.Modelo.ToUpper()} placa: {veiculo.Placa.ToUpper()}");                
                Console.WriteLine($"Hora entrada:{veiculo.Entrada.ToString(@"hh\:mm")}");
                Console.WriteLine($"Hora saída:{veiculo.Saida.ToString(@"hh\:mm")}");
                Console.WriteLine($"Permanência:{(permanencia.ToString(@"hh\:mm"))}");
                Console.WriteLine($"Valor a pagar pela permanência: {valorTotal.ToString("C")}");

                //Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTADO*
                // int horas = int.Parse(Console.ReadLine());
                // decimal valorTotal = precoInicial + (precoPorHora * horas); 

                // // TODO: Remover a placa digitada da lista de veículos
                // // *IMPLEMENTADO* 
                Veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("C")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (Veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTADO*
                foreach (var veiculo in Veiculos)
                {
                    if(veiculo.Modelo != String.Empty && veiculo.Marca == String.Empty)
                    {
                        Console.WriteLine($"Veículo {veiculo.Modelo.ToUpper()} placa: {veiculo.Placa.ToUpper()}");
                    }
                    else if(veiculo.Modelo == String.Empty && veiculo.Marca != String.Empty)
                    {
                        Console.WriteLine($"Veículo {veiculo.Marca.ToUpper()} placa: {veiculo.Placa.ToUpper()}");
                    }
                    else if(veiculo.Modelo != String.Empty && veiculo.Marca != String.Empty)
                    {
                        Console.WriteLine($"Veículo {veiculo.Marca.ToUpper()} {veiculo.Modelo.ToUpper()} placa: {veiculo.Placa.ToUpper()}");
                    }
                    else
                    {
                        Console.WriteLine($"Veículo placa: {veiculo.Placa.ToUpper()}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
