using Microsoft.AspNetCore.Mvc;

namespace BeerEncyclopedia.Model
{
    public class BeerModel
    {
        public List<Beer> BeerList { get; set; }
        public Beer Alcohol { get; set; }
        public List<int> Pages { get; set; }
        public bool NoResults { get; set; }
    }
}
