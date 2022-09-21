using BeerEncyclopedia.Model;
using BeerEncyclopedia.UtilityFunctions;

namespace BeerTesting
{
    [TestClass]
    public class BeerTest
    {
        private readonly BeerModelFunctions beerModelFunctions;

        public BeerTest()
        {
            beerModelFunctions = new BeerModelFunctions();
        }

        [TestMethod]
        public async Task ExpectNoResults()
        {
            BeerModel beerModel = new BeerModel();
            await beerModelFunctions.SearchBeer(1, "öl", beerModel);
            Assert.IsNotNull(beerModel.BeerList);
            Assert.AreEqual(0, beerModel.BeerList.Count);
            Assert.IsTrue(beerModel.NoResults);
        }
        [TestMethod]
        public async Task ExpectOneReult()
        {
            BeerModel beerModel = new BeerModel();
            await beerModelFunctions.SearchBeer(1, ",.", beerModel);
            Assert.IsNotNull(beerModel.BeerList);
            Assert.AreEqual(1, beerModel.BeerList.Count);
            Assert.AreEqual(1, beerModel.Pages.Count);
        }
        [TestMethod]
        public async Task ExpectToStopPage8()
        {
            BeerModel beerModel = new BeerModel();
            await beerModelFunctions.SearchBeer(8, "ale", beerModel);
            Assert.IsNotNull(beerModel);
            // Previus and current page
            Assert.AreEqual(2, beerModel.Pages.Count);

            // When at page seven it stop pages after 8
            await beerModelFunctions.SearchBeer(7, "ale", beerModel);
            Assert.AreEqual(3, beerModel.Pages.Count);
        }
    }
}