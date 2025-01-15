Flower Shop by Denis Nedelcu 🌸
This repository is an e-commerce web application built using the ASP.NET MVC framework with Visual Studio 2022 and .NET 8.0. The application offers a seamless and enjoyable experience for users to explore and purchase various floral decorations, including soap flowers, natural flowers, and more.

The application provides different functionalities based on the user's role:
**Unauthorized Users**
- Limited access to pages.
- Can only view the Home and Login/Register pages.
**Normal Users**
- Access to all pages except Orders and Stores.
- Cannot delete or modify entities such as products or posts.
**Administrators**
- Full access to all pages, including Orders and Stores.
- Ability to create, edit, and delete any entities without restrictions.

Available Pages
- **Register:** Allows new users to create an account by providing an email and password (with pre-defined restrictions).
- **Login:** Users can log in to access additional pages based on their role.
- **Profile Page:** Users can view and edit personal information, change their email/password, and download their data as a file.
- **Home:** A welcoming landing page with a link to the available products.
- **Products:** Displays all products available for order. Administrators can add, edit, or delete products.
- **Orders:** Available only to administrators. Displays all user orders with detailed information.
- **Gallery:** Showcases images of available products. Any user can upload photos, but only administrators can modify them.
- **Stores:** Exclusive to administrators. Displays company stores, where administrators can assign products to specific locations.
- **Articles:** A space for all users to post articles about the site, feedback, news, and more. Only administrators can modify or delete posts.
- **About Us:** Provides a brief description of the company and its services.

Technologies Used
- **Framework:** ASP.NET MVC
- **IDE:** Visual Studio 2022
- **Language:** C#
- **Version:** .NET 8.0
