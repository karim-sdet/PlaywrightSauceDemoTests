# PlaywrightSauceDemoTests

Playwright UI tests in C#/.NET 8 for the public [SauceDemo](https://www.saucedemo.com/) web app.

## Tech Stack

- C# / .NET 8
- Playwright for .NET
- NUnit

## Scenarios Covered

- Valid login: `standard_user` → navigates to the products page.
- Invalid login: shows an error message for wrong credentials.
- Add to cart: adds an item and verifies the cart badge shows `1`.

## Project Structure

- `SauceDemoPlaywrightTests` test class with async NUnit tests.
- `SetUp` / `TearDown` use Playwright `IBrowser` and `IPage` to manage browser lifecycle.
- Tests use Playwright locators + `Expect` assertions for verification.

## How to Run

1. Install .NET 8 SDK.
2. Clone the repo:
   ```bash
   git clone https://github.com/karim-sdet/PlaywrightSauceDemoTests.git
   cd PlaywrightSauceDemoTests
