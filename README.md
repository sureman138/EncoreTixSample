# EncoreTixSample

EncoreTixSample is an MVC web application designed to provide users with an intuitive interface for searching and exploring attractions and events using the Ticketmaster API.

![Image](https://github.com/user-attachments/assets/80a74c1e-eb62-48e9-ae57-3ff57590ed26)

## Technologies Used

- **.NET 8**: Built with modern version of .NET for optimal performance.
- **MVC**: Utilizes Razor Pages for a clean and modular UI.
- **Ticketmaster API**: Integrates with the Ticketmaster API to fetch attraction and event data.

## Installation

1. Clone the repository: [git clone https://github.com/your-repo/EncoreTix.git cd EncoreTix]
2. Install dependencies: dotnet restore
3. Configure the application:
  - Add `secrets.json` and update file or `appsettings.json` file with your Ticketmaster API credentials.
4. Run the application

## Project Structure

- **Controller**: Handles application logic (e.g., `HomeController`).
- **Views**: Razor Pages for the UI (e.g., `Index.cshtml`, `AttractionEvents.cshtml`).
- **Models**: Data models for attractions, events, and external links.
- **ViewModels**: View-specific data structures for passing data to the UI.
- **Services**: Contains the `TicketmasterApiClient` for API integration.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Acknowledgments

- [Ticketmaster API](https://developer.ticketmaster.com/) for providing attraction and event data.
