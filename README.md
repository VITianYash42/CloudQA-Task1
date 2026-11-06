# CloudQA Task 1: Resilient UI Automation

This project automates the CloudQA practice form using C# and Selenium WebDriver. 

## Approach & Resilience

Standard locators (`id`, `name`, `class`) fail when the DOM mutates. This script uses **Selenium 4 Relative Locators** (`RelativeBy`). It searches for the semantic, human-readable text labels on the page (e.g., "First Name", "State") and interacts with the input elements physically nearest to them. This mimics how a human finds a field and ensures the script survives HTML structure, attribute, and ordering changes.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- Google Chrome browser

## How to Run

1. Clone this repository.
2. Open a terminal in the project directory.
3. Run the following command:
   ```bash
   dotnet run
   ```
4. To test against a modified URL, pass it as an argument:
   ```bash
   dotnet run "https://your-modified-url.com"
   ```