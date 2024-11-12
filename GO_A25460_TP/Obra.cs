using System;

namespace TP_a25460_GO
{
    public class Obra
    {
        // Propriedades da obra
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Orcamento { get; private set; }
        public decimal CustosTotais { get; private set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Estado { get; private set; }

        // Construtor para inicializar a obra
        public Obra(string nome, string descricao, decimal orcamento, DateTime dataInicio)
        {
            Nome = nome;
            Descricao = descricao;
            Orcamento = orcamento;
            DataInicio = dataInicio;
            CustosTotais = 0;
            Estado = "Em andamento";
        }

        // Método para adicionar um custo à obra
        public void AdicionarCusto(decimal custo)
        {
            if (custo < 0)
            {
                Console.WriteLine("Custo inválido. Insira um valor positivo.");
                return;
            }

            CustosTotais += custo;
            Console.WriteLine($"Custo de {custo:C} adicionado. Custos totais agora: {CustosTotais:C}");
        }

        // Método para atualizar o estado da obra
        public void AtualizarEstado(string novoEstado)
        {
            Estado = novoEstado;
            Console.WriteLine($"Estado da obra atualizado para: {novoEstado}");
        }

        // Método para verificar o orçamento restante
        public decimal VerificarOrcamentoRestante()
        {
            decimal orcamentoRestante = Orcamento - CustosTotais;
            Console.WriteLine($"Orçamento restante: {orcamentoRestante:C}");
            return orcamentoRestante;
        }

        // Método para exibir todas as informações da obra
        public void ExibirInformacoes()
        {
            Console.WriteLine("Informações da Obra:");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Orçamento: {Orcamento:C}");
            Console.WriteLine($"Custos Totais: {CustosTotais:C}");
            Console.WriteLine($"Orçamento Restante: {VerificarOrcamentoRestante():C}");
            Console.WriteLine($"Data de Início: {DataInicio.ToShortDateString()}");
            Console.WriteLine($"Data de Conclusão: {(DataConclusao.HasValue ? DataConclusao.Value.ToShortDateString() : "Não definida")}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}