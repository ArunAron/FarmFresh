# FarmFresh

## Project Scope and Usage Guide

### 1.FarmFresh (Asp.net MVC) (Front-End)
  - Search Bar function will work for all types of searching (Product Name(eg.Fish,cake), Product Type(eg.Fruit,Meat,Beverages), On Sale, Shop By Store).
  - Categorize Product list can be reach by clickling on the shopping cart.
  - AdminDashboard for managing product can be found under (YourHost)/Admin/ProductListAdmin.
  - I had used Ajax funtions call for all kind of request(Search, Paging, TabChange).
 
### 2.DataAccess (Class Library)
  - I had used Entity Framework (Code First) with generic repository pattern for data access layer. 
  - All Pagination are server side only since I fetch only 8 rows and fetching consecutive only on clicking the next paging and u can check it in the codes too.
  - Instead of using API, I just used this DataAcess Layer within the Same Project and directly called from the controller.
  - The database backup file was also in the project file and u can find it as farmfresk.bak. 
