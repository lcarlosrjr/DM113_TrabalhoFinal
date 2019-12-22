using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Security;

namespace EstoqueProduto {

    // Service contract describing the operations provided by the WCF service
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque {
        [OperationContract]
        List<Produto> ListarProdutos();
        [OperationContract]
        bool IncluirProduto(Produto produto);
        [OperationContract]
        bool RemoverProduto(string numeroProduto);
        [OperationContract]
        int ConsultarEstoque(string numeroProduto);
        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);
        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);
        [OperationContract]
        Produto VerProduto(string numeroProduto);
    }


    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IServicoEstoqueV2 {
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        bool AdicionarEstoque(string numeroProduto, int quantidade);
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        bool RemoverEstoque(string numeroProduto, int quantidade);
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        int ConsultarEstoque(string numeroProduto);
    }



    // Data contract describing the details of a product passed to client applications
    [DataContract]
    public class Produto {
        [DataMember(Order = 0)]
        public string NumeroProduto;
        [DataMember(Order = 1)]
        public string NomeProduto;
        [DataMember(Order = 2)]
        public string DescricaoProduto;
        [DataMember(Order = 3)]
        public int EstoqueProduto;
    }
}

