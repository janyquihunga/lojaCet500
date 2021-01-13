using lojaCet500.Dados;
using lojaCet500.Dados.Entidades;
using lojaCet500.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
using System.Threading.Tasks;

namespace lojaCet500.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IRepository repository;
        private IRepositiry repositiry;

        public ProdutosController(IRepositiry repositiry)
        {
            this.repositiry = repositiry;
        }

        // GET: Produtos
        public IActionResult Index()
        { 
            return View(this.repositiry.GetProduct());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = this.repositiry.GetProduct(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Preco,UrlDaIamgem,UltimaCompra,UltimaVenda,Disponivel,Stock")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                this.repositiry.AddProduto(produto);
                await repositiry.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = this.repositiry.GetProduct(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Preco,UrlDaIamgem,UltimaCompra,UltimaVenda,Disponivel,Stock")] Produto produto)
        {
      

            if (ModelState.IsValid)
            {
                try
                {
                    this.repositiry.UpdateProduto(produto);
                    await this.repositiry.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repositiry.ProdutoExiste(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = this.repositiry.GetProduct(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = this.repositiry.GetProduct(id);
            this.repositiry.RemoveProduto(produto);
            await this.repositiry.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
