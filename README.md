Here's a customized version of the readme tailored to your current project:

# AgriEnergy Application Readme

Welcome to the AgriEnergy Web Application! This readme provides comprehensive instructions on how to compile, run, and make the most of this web application developed using C#, ASP.NET, and SQL.

## System Requirements

Before diving into the AgriEnergy Application, ensure that your system meets the following requirements:

- Operating System: Windows (The application is designed specifically for Windows).
- Development Environment: Visual Studio 2022.

## Dependencies

The AgriEnergy Application has the following dependencies:
- ASP.NET Web Application (V4.8)
- SQL Server

## Getting Started

Let's get started with the AgriEnergy Application:

### 1. Open the Solution

Begin by opening the AgriEnergy Web Application solution in Visual Studio. This is your entry point into the software's source code and design.

### 2. Build the Solution

To get the application up and running, you need to build the solution. In Visual Studio, simply click on "Build" in the menu or use the keyboard shortcut `Ctrl+Shift+B`. This step compiles the application and prepares it for execution.

### 3. Database Setup

The AgriEnergy Application stores data in a SQL Server database hosted on Azure. You do not need to set up the database as it is already configured and running in Azure. The connection string is included in the application settings.

If you encounter any issues when trying to run the program, please rebuild the project and try cleaning it too. The application has been tested, and these steps should resolve common setup issues.

### 4. Run the Application

Now, it's time to experience the AgriEnergy Application firsthand. Run the application by clicking "Start" or using the keyboard shortcut `F5`. You will see the application's main window appear, ready for your input.

### User Roles and Permissions

- **Farmer**:
  - Can view and manage their own products.
  - Access the dashboard to see products they have added.
  
- **Employee**:
  - Can view and manage all products.
  - Access additional administrative functionalities.

## User Data

For testing purposes, the following user data can be used to log in to the application:

| Role     | Username | Password  |
|----------|----------|-----------|
| Employee | merw_    | Merywn1_  |
| Farmer   | alice_w  | password123! |
| Employee | bob_b    | password456! |
| Farmer   | piet_    | Fami12_   |
| Farmer   | mark_    | Fami12_   |

Please note that the passwords are case sensitive.

## Using the AgriEnergy Application

The AgriEnergy Application empowers farmers and employees to efficiently manage and track agricultural products. Here are the core features and how to use them:

### Registration and Login

1. The application will always start on the login page.
2. You must create an account first by selecting either Farmer or Employee during registration.
3. Once you have added your details, the application will verify your entered information.

### Adding Products

1. Navigate to the "Products" section.
2. Click on "Add Product" to populate the application with new products.
3. Input the product details, including name, category, production date, description, and farmer ID.
4. Click "Submit" to add the product to the database.

### Viewing and Managing Products

- Farmers can view and manage only the products they have added.
- Employees can view and manage all products in the system.

### Sign Out

- This application allows you to sign out of your profile and lets other users sign in.

### Exiting the Application

To conclude your AgriEnergy Application session, simply close the browser window. This will log you out and close the application.

## Data Persistence

The AgriEnergy Application stores data in a SQL Server database, ensuring your data is retained even after you close the application. Your product information is persisted between sessions.

## Code Structure

The application adheres to internationally recognized coding standards. Extensive comments within the source code explain variable names, methods, and the logic behind the programming code. LINQ is leveraged to efficiently manipulate data.

## Support and Issues

Error Handling: The application includes comprehensive error handling to ensure a smooth user experience. If you encounter any errors or invalid inputs during the process, appropriate error messages will be displayed, guiding you on how to rectify the issue.

Should you encounter any issues, have questions, or require assistance while using the AgriEnergy Application, please do not hesitate to reach out. Our support team is here to help and provide guidance.

We trust that the AgriEnergy Web Application will prove to be a valuable tool in helping you effectively manage agricultural products. Enjoy using the application!