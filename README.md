# FarmFresh

## Project Scope and Usage Guide

### 1.FarmFresh (Asp.net MVC) (Front-End)
  - Search Bar function will work for all types of searching (Product Name(eg.Fish,cake), Product Type(eg.Fruit,Meat,Beverages), On Sale, Shop By Store).
  ![alt text](https://github.com/ArunAron/FarmFresh/blob/main/FarmFresh%20Screen/Search%20Fruit.png)
  
  - Categorize Product list can be reach by clickling on the shopping cart.
  ![alt text](https://github.com/ArunAron/FarmFresh/blob/main/FarmFresh%20Screen/shopping%20cartclick.png)
  ![alt text](https://github.com/ArunAron/FarmFresh/blob/main/FarmFresh%20Screen/Categorized%20Product%20List.png)
  
  - Product Detail can be view by clicking on the product photo.
  ![alt text](https://github.com/ArunAron/FarmFresh/blob/main/FarmFresh%20Screen/Product%20Detail.png)
  
  - AdminDashboard for managing product can be found under (YourHost)/Admin/ProductListAdmin where you can add new products, edit their details and type.
   ![alt text](https://github.com/ArunAron/FarmFresh/blob/main/FarmFresh%20Screen/Admin%20Product%20List.png)
   ![alt text](https://github.com/ArunAron/FarmFresh/blob/main/FarmFresh%20Screen/Admin%20Product%20List%20Update.png)
  - I had used Ajax funtions call for all kind of request(Search, Paging, TabChange).
 
### 2.DataAccess (Class Library)
  - I had used Entity Framework (Code First) with generic repository pattern for data access layer. 
  - All Pagination are server side only since I fetch only 8 rows and fetching consecutive only on clicking the next paging and u can check it in the codes too.
  - Instead of using API, I just used this DataAcess Layer within the Same Project and directly called from the controller.
  - The database backup file was also in the project file and u can find it as farmfresk.bak. 
