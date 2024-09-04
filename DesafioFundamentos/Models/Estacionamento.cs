using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (pode ser o modelo padrão ou do Mercosul):");
            
            //Implementei um sistema de verificação de placas padrões e da Mercosul

            string placa = Console.ReadLine();

            var VerifPadrao = new Regex("[A-Z]{3}[0-9]{4}");
            var VerifMercosul = new Regex("[A-Z]{3}[0-9]{1}[A-Z]{3}[0-9]{1}");

            if (VerifPadrao.IsMatch(placa)||VerifMercosul.IsMatch(placa)){
                veiculos.Add(placa);
                Console.WriteLine("Placa verificada e registrada, veículo estacionado com sucesso!");
            }
            else{
                Console.WriteLine("Placa não identificada, registro não concluído!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                //Implementado a remoção de placas   

                decimal horas = Convert.ToDecimal(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Implementado a listagem de veículos da lista
                foreach (String item in veiculos){
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
