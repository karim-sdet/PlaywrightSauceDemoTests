# PlaywrightSauceDemoTests

C# .NET 8 UI test automation project using Microsoft Playwright against the public SauceDemo web app.

## Tech Stack
- C# / .NET 8
- Playwright for .NET
- NUnit

## Scenarios Covered
- Valid login – navigates to products page
- Invalid login – shows error message
- Add to cart – adds an item and verifies cart badge = 1

## How to Run
- `dotnet restore`
- `dotnet test`

## Why I built this
I created this project to practise Playwright with C# as part of my SDET preparation and to complement my Selenium/POM and API testing projects.
