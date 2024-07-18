# Pharmacy IMS (Inventory Management System) MVC

## Description

### EN:

.NET MVC Inventory Management System for a pharmacy. The user can register and login, update their profile info and manage products. User can also sell products and generate transactions.
Each product has a unit price and a sale price (estimated on the tax rate associated); additionally, the products quantity in storage will be updated after a transaction.

### ES:

Sistema de gestión de inventario MVC para farmacia desarrollado en .NET. El usuario puede registrarse e iniciar sesión, actualizar la información de su perfil y administrar productos. El usuario también puede vender productos y generar transacciones.
Cada producto tiene un precio unitario y un precio de venta (estimado en función de la tasa impositiva asociada); además, la cantidad de productos almacenados se actualizará después de una transacción.

## Features

### EN:

- Monolithic software architecture
- Repository design pattern for data access
- Session-based Authentication with Identity Framework, and role-based actions.
- CRUD operations for business related entities
- Search functionality for products
- Single-page operations for selling products using jQuery
- Responsive design for most of the Views, using Bootstrap

### ES:

- Arquitectura de software monolítica
- Patrón de diseño Repository para acceso a datos.
- Autenticación basada en sesiones con Identity Framework y acciones basadas en roles.
- Operaciones CRUD para entidades relacionadas con el Negocio
- Funcionalidad de búsqueda de productos.
- Operaciones de single-page para venta de productos con jQuery
- Diseño responsivo para la mayoría de las Vistas, usando Bootstrap

## Requirements

- .NET SDK 8.0+
- SQLite

## Class Diagram

![uml-diagram-mvc-pharma](https://github.com/user-attachments/assets/00cad9e8-3f27-4aa4-826b-c8aa91250f0b)

## Screenshots

### Main (principal)

![03-main](https://github.com/user-attachments/assets/b24aa704-66d9-425a-b9ff-5f7d159c5739)

### Products (productos)

![11-products](https://github.com/user-attachments/assets/3d1c80ea-af96-41e7-b3e5-c07f45284748)

### Sale of items (venta de productos)

![13-sell](https://github.com/user-attachments/assets/622fcdc8-528b-442e-afb6-2491fc262f8d)

### Transactions (transacciones)

![14-transactions](https://github.com/user-attachments/assets/f583b51c-5509-45da-b4b2-451efc6dd50f)

### Transactions per month (Transacciones por mes)

![15-dashboard](https://github.com/user-attachments/assets/8780ca96-ef18-4754-b68d-335266c061a3)

Others screenshots are available in the directory '/Resources'

## Installation

### Steps:

1. Clone from github, using this command:<br>
   `git clone https://github.com/cris-jac/sql-dotnet-pharmacy-ims-mvc.git`

2. Navigate to the repository folder:<br>
   `cd sql-dotnet-pharmacy-ims-mvc`

3. Build the app:<br>
   `dotnet build`

- Optional: If entity framework is not installed:<br>
  `dotnet tool install --global dotnet-ef`

4. Run the app:<br>
   `dotnet run`

### Pasos:

1. Clonar el repositorio de github, usando este comando:<br>
   `git clone https://github.com/cris-jac/sql-dotnet-pharmacy-ims-mvc.git`

2. Navegar al directorio:<br>
   `cd sql-dotnet-pharmacy-ims-mvc`

3. Levantar app:<br>
   `dotnet build`

- Opcional: Si Entity Framework no esta instalado:<br>
  `dotnet tool install --global dotnet-ef`

4. Correr la app:<br>
   `dotnet run`

## Port

The default local port:<br>
http://localhost:5171/
