using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweaterProductionOrders.Data;
using SweaterProductionOrders.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterProductionOrders.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var orders = _context.ProductionOrders.ToList();
            return View(orders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.ProductionOrders
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }



        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.ProductionOrders.Find(id);
            if (order == null) return NotFound();

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductionOrders == null)
            {
                return NotFound();
            }

            var order = await _context.ProductionOrders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }



        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int OrderID)
        {
            Console.WriteLine($"[DEBUG] Received ID for deletion: {OrderID}");

            if (OrderID <= 0)
            {
                Console.WriteLine("[DEBUG] Invalid ID received.");
                return RedirectToAction(nameof(Index));
            }

            var order = await _context.ProductionOrders.FindAsync(OrderID);
            if (order != null)
            {
                _context.ProductionOrders.Remove(order);
                await _context.SaveChangesAsync();
                Console.WriteLine($"[DEBUG] Order with ID {OrderID} deleted.");
            }
            else
            {
                Console.WriteLine($"[DEBUG] Order with ID {OrderID} not found for deletion.");
            }

            return RedirectToAction(nameof(Index));
        }



    }
}
