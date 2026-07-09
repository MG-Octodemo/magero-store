# magero-store

## Overview
magero-store is a sample e-commerce application built using .NET Core MVC. The application simulates a shopping experience similar to popular e-commerce platforms, allowing users to browse products, add items to their cart, and complete purchases.

## Features
- **Home Page**: Displays featured products and navigation options.
- **Product Listing**: Users can view all available products and filter through them.
- **Product Details**: Detailed view of each product, including descriptions and images.
- **Shopping Cart**: Users can view items added to their cart and adjust quantities.
- **Checkout Process**: A streamlined process for users to finalize their purchases.

## Project Structure
```
magero-store
├── Controllers
│   ├── HomeController.cs
│   ├── ProductsController.cs
│   ├── CartController.cs
├── Models
│   ├── Product.cs
│   ├── CartItem.cs
│   └── ApplicationDbContext.cs
├── Views
│   ├── Home
│   │   └── Index.cshtml
│   ├── Products
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
│   ├── Cart
│   │   ├── Index.cshtml
│   │   ├── Checkout.cshtml
│   └── Shared
│       ├── _Layout.cshtml
│       └── _ViewImports.cshtml
├── wwwroot
│   ├── css
│   │   └── site.css
│   ├── js
│   │   └── site.js
│   └── lib
├── appsettings.json
├── Program.cs
├── Startup.cs
└── README.md
```

## Getting Started
1. **Clone the Repository**: 
   ```
   git clone <repository-url>
   cd magero-store
   ```

2. **Install Dependencies**: 
   Ensure you have the .NET Core SDK installed. Run the following command to restore dependencies:
   ```
   dotnet restore
   ```

3. **Run the Application**: 
   Start the application using:
   ```
   dotnet run
   ```
   Navigate to `http://localhost:5000` in your web browser to view the application.

## Figma Design Reference

This project includes a Figma MCP (Model Context Protocol) server configuration in `.vscode/mcp.json` that enables AI coding agents to access the Figma design data for this application.

- **Figma Design**: [My Demo Website](https://www.figma.com/design/XuvSv0eg5bQwy5vZJJJoDs/My-Demo-Website)

### Setting Up the Figma MCP Server

1. Generate a Figma personal access token from your [Figma account settings](https://help.figma.com/hc/en-us/articles/8085703771159-Manage-personal-access-tokens).

2. Set the `FIGMA_API_KEY` environment variable with your token:
   ```
   export FIGMA_API_KEY=your_figma_api_key_here
   ```

3. Verify that `.vscode/mcp.json` is present and references `${FIGMA_API_KEY}` in the `--figma-api-key` argument. The MCP server will be automatically started by VS Code when using GitHub Copilot or other MCP-compatible AI assistants.


4. Available MCP tools:
   - **get_figma_data**: Fetches comprehensive Figma file data including layout, content, visuals, and component information.
   - **download_figma_images**: Downloads SVG and PNG images used in the Figma file.

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
