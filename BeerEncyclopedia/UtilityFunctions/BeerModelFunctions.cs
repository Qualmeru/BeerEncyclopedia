using BeerEncyclopedia.Model;
using Nancy.Json;

namespace BeerEncyclopedia.UtilityFunctions
{
    public class BeerModelFunctions
    {
        public async Task<List<Beer>> JsonToBeerModelList(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<Beer>>(content);
        }

        public async Task<List<Beer>> FetchBeerList(int pageNumber, string searchTerm)
        {
            return await JsonToBeerModelList($"https://api.punkapi.com/v2/beers?page={pageNumber}&per_page=10&beer_name={searchTerm}");
        }

        public async Task SearchBeer(int pageNumber, string searchTerm, BeerModel beerModel)
        {
            beerModel.BeerList = await FetchBeerList(pageNumber, searchTerm);

            if (beerModel.BeerList.Count > 0)
            {
                beerModel.Pages = new List<int>();
                //render previus page number so you can go back but start at 0 when page is 1
                int pageNum = pageNumber == 1 ? 0 : pageNumber > 1 ? pageNumber - 2 : pageNumber;
                for (int i = 0; i < 5; i++)
                {
                    pageNum++;
                    //check if page has items if so render page number
                    List<Beer> BeerListMaxPage = await FetchBeerList(pageNum, searchTerm);
                    if (BeerListMaxPage.Count > 0)
                        beerModel.Pages.Add(pageNum);
                }
            }
            if (!string.IsNullOrEmpty(searchTerm) && beerModel.BeerList?.Count <= 0)
            {
                beerModel.NoResults = true;
            }
        }

    }
}
