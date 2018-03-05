using Autohandel.Domain.Data;
using Autohandel.web.Models.DatadisplayViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Controllers
{
    public class DataDisplayController : Controller
    {
        private readonly AutohandelContext _context;

        public DataDisplayController(AutohandelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DatadisplayViewModel()
            {
                voertuigCategorieen = await _context.VoertuigCategorieen.ToListAsync(),
                autoMerken = await _context.Merken.ToListAsync(),
                automodellen = await _context.Types.ToListAsync(),
                aanbodVoertuigen = await _context.Voertuigen.ToListAsync()
            };
           
            return View(viewModel);
        }
    }
}