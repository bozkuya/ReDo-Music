# Redo Music

## Project Description
Redo Music is an e-commerce platform offering a vast range of musical instruments to enthusiasts. Users can explore, compare, and purchase products listed under various brands and categories.

## Features of the Project

### Category Management
- Implemented a system that allows users to filter products by categories.

### Brand and Product Addition Enhancement
- Enhanced the detail of information users can provide when adding brands and products.

### Artist-Specific Product Features
- Features to search and add artist-related products were integrated, allowing users to find items associated with their favorite artists.


## Detailed Features Added

### Category Management
- Created the `Category` entity and added methods in `CategoryController` for CRUD operations.
- Developed views (`Add`, `Edit`, `Delete`, `Index`) for category management.
  
### Artist-Specific Product Features
- Introduced a new feature that allows users to search for products linked to specific artists and add artist-branded items to the platform.

### Brand and Product Addition Enhancement
- Added additional fields to `Brand` and `Product` entities and updated the `Add` views to allow users to input more detailed information.


## Challenges Encountered

### Category Management Integration
- Encountered some foreign key constraints when linking categories to products. Resolved by revising the database schema and configuring the related entities correctly.


# Contributors

## @altudev
## @ahozturk
