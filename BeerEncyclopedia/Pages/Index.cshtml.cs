using BeerEncyclopedia.Model;
using BeerEncyclopedia.UtilityFunctions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeerEncyclopedia.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BeerModelFunctions _utilityFunctions;

        [BindProperty]
        public BeerModel BeerlModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int pageNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _utilityFunctions = new BeerModelFunctions();
            BeerlModel = new BeerModel();
        }

        public async Task<IActionResult> OnGet()
        {
            await _utilityFunctions.SearchBeer(pageNumber, SearchTerm, BeerlModel);
            return Page();
        }

        public async Task<IActionResult> OnPostSearch()
        {
            pageNumber = 1;
            await _utilityFunctions.SearchBeer(pageNumber, SearchTerm, BeerlModel);
            return Page();
        }
       
        
    }
}