using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightSauceDemoTests
{
    [TestFixture]
    public class SauceDemoPlaywrightTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        // yeh har test se pehle chalega
        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false  // true karoge to browser hidden mode me chalega
                });

            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        // yeh har test ke baad chalega
        [TearDown]
        public async Task TearDown()
        {
            if (_context is not null)
                await _context.CloseAsync();

            if (_browser is not null)
                await _browser.CloseAsync();

            _playwright?.Dispose();
        }

        [Test]
        public async Task ValidLogin_ShouldNavigateToProductsPage()
        {
            // 1) Go to SauceDemo login page
            await _page.GotoAsync("https://www.saucedemo.com/");

            // 2) Fill username & password
            await _page.FillAsync("#user-name", "standard_user");
            await _page.FillAsync("#password", "secret_sauce");

            // 3) Click Login
            await _page.ClickAsync("#login-button");

            // 4) Assert: products page open ho
            await Expect(_page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        }
        [Test]
        public async Task InvalidLogin_ShouldShowErrorMessage()
        {
            // 1) Go to login page
            await _page.GotoAsync("https://www.saucedemo.com/");

            // 2) Wrong username / password
            await _page.FillAsync("#user-name", "locked_out_user");
            await _page.FillAsync("#password", "wrong_password");

            // 3) Click Login
            await _page.ClickAsync("#login-button");

            // 4) Assert: error message visible
            var error = _page.Locator("[data-test='error']");
            await Expect(error).ToBeVisibleAsync();
        }

        [Test]
        public async Task AddItemToCart_ShouldShowCartBadgeCount()
        {
            // Login first
            await _page.GotoAsync("https://www.saucedemo.com/");
            await _page.FillAsync("#user-name", "standard_user");
            await _page.FillAsync("#password", "secret_sauce");
            await _page.ClickAsync("#login-button");

            // On products page, add 1st item to cart
            await _page.ClickAsync("[data-test='add-to-cart-sauce-labs-backpack']");

            // Assert: cart badge shows "1"
            var cartBadge = _page.Locator(".shopping_cart_badge");
            await Expect(cartBadge).ToHaveTextAsync("1");
        }


    }
}
