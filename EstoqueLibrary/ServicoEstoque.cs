using EstoqueProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EstoqueEntityModel;
using System.ServiceModel.Activation;


namespace EstoqueProduto {

    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2 {
        //Listar Produtos
        public List<Produto> ListarProdutos() {
            List<Produto> produtos = new List<Produto>();
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    List<ProdutoEstoque> produtoEstoques = (from produto in database.ProdutoEstoques
                                                            select produto).ToList();

                    foreach (ProdutoEstoque produtoEstoque in produtoEstoques) {
                        Produto produto = new Produto() {
                            NumeroProduto = produtoEstoque.NumeroProduto,
                            NomeProduto = produtoEstoque.NomeProduto,
                            DescricaoProduto = produtoEstoque.DescricaoProduto,
                            EstoqueProduto = produtoEstoque.EstoqueProduto
                        };
                        produtos.Add(produto);
                    }
                }
            } catch {
            }
            return produtos;
        }

        public bool IncluirProduto(Produto produto) {
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.NumeroProduto = produto.NumeroProduto;
                    produtoEstoque.NomeProduto = produto.NomeProduto;
                    produtoEstoque.DescricaoProduto = produto.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = produto.EstoqueProduto;

                    database.ProdutoEstoques.Add(produtoEstoque);
                    database.SaveChanges();
                }
            } catch {
                return false;
            }

            return true;
        }

        public bool RemoverProduto(string numeroProduto) {
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    database.ProdutoEstoques.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            } catch {
                return false;
            }

            return true;
        }

        public int ConsultarEstoque(string numeroProduto) {
            int estoqueProduto = -1;
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    estoqueProduto = produtoEstoque.EstoqueProduto;
                }
            } catch {
            }

            return estoqueProduto;
        }

        public bool AdicionarEstoque(string numeroProduto, int quantidade) {
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto + quantidade;
                    database.SaveChanges();
                }
            } catch {
                return false;
            }

            return true;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade) {
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto - quantidade;
                    database.SaveChanges();
                }
            } catch {
                return false;
            }

            return true;
        }

        public Produto VerProduto(string numeroProduto) {
            Produto produto = null;
            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    produto = new Produto() {
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        NomeProduto = produtoEstoque.NomeProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };
                }
            } catch {
            }

            return produto;
        }
    }
}
