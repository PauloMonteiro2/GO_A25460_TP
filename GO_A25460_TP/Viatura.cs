using System;
using System.Collections.Generic;

namespace TP_a25460_GO
{
    // Classe para representar uma viatura
    public class Viatura
    {
        // Propriedades da viatura
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Estado { get; private set; }

        // Construtor para inicializar a viatura
        public Viatura(string matricula, string marca, string modelo, int ano, string estadoInicial = "Disponível")
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Estado = estadoInicial;
        }

        // Método para atualizar o estado da viatura
        public void AtualizarEstado(string novoEstado)
        {
            Estado = novoEstado;
            Console.WriteLine($"Estado da viatura {Matricula} atualizado para: {novoEstado}");
        }

        // Método para exibir as informações da viatura
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }

    // Classe para gerir a lista de viaturas
    public class GestaoViaturas
    {
        private List<Viatura> viaturas;

        public GestaoViaturas()
        {
            viaturas = new List<Viatura>();
        }

        // Função para adicionar uma viatura
        public void AdicionarViatura(Viatura viatura)
        {
            viaturas.Add(viatura);
            Console.WriteLine($"Viatura {viatura.Matricula} adicionada com sucesso.");
        }

        // Função para remover uma viatura usando a matrícula
        public bool RemoverViatura(string matricula)
        {
            Viatura viatura = viaturas.Find(v => v.Matricula == matricula);
            if (viatura != null)
            {
                viaturas.Remove(viatura);
                Console.WriteLine($"Viatura {matricula} removida com sucesso.");
                return true;
            }
            else
            {
                Console.WriteLine($"Viatura com matrícula {matricula} não encontrada.");
                return false;
            }
        }

        // Função para consultar uma viatura específica pela matrícula
        public void ConsultarViatura(string matricula)
        {
            Viatura viatura = viaturas.Find(v => v.Matricula == matricula);
            if (viatura != null)
            {
                Console.WriteLine("Informações da Viatura:");
                viatura.ExibirInformacoes();
            }
            else
            {
                Console.WriteLine($"Viatura com matrícula {matricula} não encontrada.");
            }
        }

        // Função para exibir todas as viaturas
        public void ExibirViaturas()
        {
            Console.WriteLine("Lista de Viaturas:");
            foreach (var viatura in viaturas)
            {
                viatura.ExibirInformacoes();
                Console.WriteLine("------------------------");
            }
        }
    }
}