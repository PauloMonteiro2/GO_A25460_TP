using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO_A25460_TP
{
    public class Funcionario
    {
        // Propriedades do funcionário
        public string Nome { get; set; }
        public string Cargo { get; private set; }
        public decimal Salario { get; private set; }
        public DateTime DataContratacao { get; private set; }

        // Construtor para inicializar o funcionário
        public Funcionario(string nome, string cargo, decimal salario, DateTime dataContratacao)
        {
            Nome = nome;
            Cargo = cargo;
            Salario = salario;
            DataContratacao = dataContratacao;
        }

        // Método para atualizar o cargo do funcionário
        public void AtualizarCargo(string novoCargo)
        {
            Cargo = novoCargo;
            Console.WriteLine($"Cargo do funcionário {Nome} atualizado para: {novoCargo}");
        }

        // Método para atualizar o salário do funcionário
        public void AtualizarSalario(decimal novoSalario)
        {
            if (novoSalario < 0)
            {
                Console.WriteLine("Salário inválido. Insira um valor positivo.");
                return;
            }

            Salario = novoSalario;
            Console.WriteLine($"Salário do funcionário {Nome} atualizado para: {novoSalario:C}");
        }

        // Método para exibir todas as informações do funcionário
        public void ExibirInformacoes()
        {
            Console.WriteLine("Informações do Funcionário:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário: {Salario:C}");
            Console.WriteLine($"Data de Contratação: {DataContratacao.ToShortDateString()}");
        }
    }
}
