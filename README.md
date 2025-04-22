# N4ZV0Z_HFT_2023241

## Overview
This project is a multi-layered application that includes backend, frontend, and testing components. It is designed to manage and interact with data related to employees, games, and publishers. The project is structured into several components, each serving a specific purpose.

## Project Structure

### Backend
- **N4ZV0Z_HFT_2023241.Endpoint**: Contains the API endpoints and SignalR hub for real-time communication.
- **N4ZV0Z_HFT_2023241.Logic**: Implements the business logic for the application.
- **N4ZV0Z_HFT_2023241.Models**: Defines the data models used across the application.
- **N4ZV0Z_HFT_2023241.Repository**: Handles data access and database interactions.

### Frontend
- **N4ZV0Z_HFT_2023241.Client**: A console-based client for interacting with the backend.
- **N4ZV0Z_HFT_2023241.JSClient**: A JavaScript-based web client with HTML, CSS, and JavaScript files.
- **N4ZV0Z_HFT_2023241.WpfClient**: A WPF-based desktop client for a richer user interface.

### Testing
- **N4ZV0Z_HFT_2023241.Test**: Contains unit tests to ensure the reliability of the application.

## How to Run

### Prerequisites
- .NET SDK installed on your system.
- A compatible IDE like Visual Studio.

### Steps
1. Open the solution file `N4ZV0Z_HFT_2023241.sln` in Visual Studio.
2. Build the solution to restore dependencies and compile the code.
3. Run the desired projects (e.g., Endpoint, Client, JSClient, or WpfClient) as the startup projects.

## Key Features
- **Employee Management**: CRUD operations for employees.
- **Game Management**: CRUD operations for games.
- **Publisher Management**: CRUD operations for publishers.
- **Real-Time Updates**: SignalR integration for real-time communication.

## Technologies Used
- **Backend**: ASP.NET Core, Entity Framework Core.
- **Frontend**: WPF, JavaScript, HTML, CSS.
- **Database**: SQL Server.
- **Testing**: xUnit.
