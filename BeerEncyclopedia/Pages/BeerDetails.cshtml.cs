using BeerEncyclopedia.Model;
using BeerEncyclopedia.UtilityFunctions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeerEncyclopedia.Pages
{
    public class BeerDetailsModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly BeerModelFunctions _utilityFunctions;


        [BindProperty]
        public BeerModel AlcoholModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public BeerDetailsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _utilityFunctions = new BeerModelFunctions();
        }


        public void OnGet()
        {
            AlcoholModel = new BeerModel();
            if (Id > 0)
            {
                var alcohol = _utilityFunctions.JsonToBeerModelList($"https://api.punkapi.com/v2/beers/{Id}");
                while (!alcohol.IsCompleted)
                {

                }
                AlcoholModel.Alcohol = alcohol.Result.First();
            }
        }

    }
}
