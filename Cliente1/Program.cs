using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Cliente1.ServicoEstoque;

namespace Cliente1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            // Test the operations in the service
            Console.WriteLine("Cliente 1");
            Console.WriteLine();
            Console.WriteLine("Teste 1: Adicionar um produto");
            Produto produto = new Produto() {
                NumeroProduto = "11000",
                NomeProduto = "Produto 11",
                DescricaoProduto = "Este é o produto 11",
                EstoqueProduto = 110
            };
            bool sucesso = proxy.IncluirProduto(produto);
            if (sucesso) {
                Console.WriteLine("Produto incluído com sucesso!");
            } else {
                Console.WriteLine("Erro na inclusão do produto!");
            }
            Console.WriteLine();

            Console.WriteLine("Teste 2: Remover produto 10");
            sucesso = proxy.RemoverProduto("10000");
            if (sucesso) {
                Console.WriteLine("Produto removido com sucesso!");
            } else {
                Console.WriteLine("Erro na remoção do produto!");
            }
            Console.WriteLine();

            Console.WriteLine("Teste 3: Listar todos produtos");
            List<Produto> produtos = proxy.ListarProdutos().ToList();
            foreach (Produto p in produtos) {
                Console.WriteLine("Número do produto: {0}", p.NumeroProduto);
                Console.WriteLine("Nome do produto: {0}", p.NomeProduto);
                Console.WriteLine("Descrição do produto: {0}", p.DescricaoProduto);
                Console.WriteLine("Estoque de produto: {0}", p.EstoqueProduto);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Teste 4: Ver informações do produto 2");
            produto = proxy.VerProduto("2000");
            Console.WriteLine("Número do produto: {0}", produto.NumeroProduto);
            Console.WriteLine("Nome do produto: {0}", produto.NomeProduto);
            Console.WriteLine("Descrição do produto: {0}", produto.DescricaoProduto);
            Console.WriteLine("Estoque de produto: {0}", produto.EstoqueProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 5: Adicionar estoque para produto 2");
            sucesso = proxy.AdicionarEstoque("2000", 10);
            if (sucesso) {
                Console.WriteLine("Estoque adicionado com sucesso!");
            } else {
                Console.WriteLine("Erro na adição do estoque de produto!");
            }
            Console.WriteLine();

            Console.WriteLine("Teste 6: Verificar estoque do produto 2");
            int estoque = proxy.ConsultarEstoque("2000");
            Console.WriteLine("Estoque do produto 2: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Teste 7: Verificar estoque do produto 1");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Teste 8: Remover estoque para produto 1");
            sucesso = proxy.RemoverEstoque("1000", 20);
            if (sucesso) {
                Console.WriteLine("Estoque removido com sucesso!");
            } else {
                Console.WriteLine("Erro na remoção do estoque de produto!");
            }
            Console.WriteLine();

            Console.WriteLine("Teste 9: Verificar estoque do produto 1 novamente");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Teste 10: Ver informações do produto 1");
            produto = proxy.VerProduto("1000");
            Console.WriteLine("Número do produto: {0}", produto.NumeroProduto);
            Console.WriteLine("Nome do produto: {0}", produto.NomeProduto);
            Console.WriteLine("Descrição do produto: {0}", produto.DescricaoProduto);
            Console.WriteLine("Estoque de produto: {0}", produto.EstoqueProduto);
            Console.WriteLine();

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
