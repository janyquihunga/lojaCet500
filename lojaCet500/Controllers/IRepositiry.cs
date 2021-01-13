using lojaCet500.Dados.Entidades;
using System.Threading.Tasks;

namespace lojaCet500.Controllers
{
    public interface IRepositiry
    {
        string GetProduct(int value);
        string GetProduct();
        void AddProduto(Produto produto);
        Task SaveChangesAsync();
        void UpdateProduto(Produto produto);
        bool ProdutoExiste(int id);
        void RemoveProduto(string produto);
    }
}