Create Database StationeryCompany

use StationeryCompany

Create Table TypeProduct(
	ID int identity(1,1) Primary Key NOT NULL,
	Type nvarchar(max) NOT NULL
);

Create Table Products(
	ID int identity(1,1) Primary key NOT NULL,
	Name nvarchar(max) NOT NULL,
	TypeProductID int Foreign Key References TypeProduct(ID) NOT NULL,
	Quantity int NOT NULL,
	CostPrice Decimal(10,2) NOT NULL
);

Create Table SalesManagers(
	ID int identity(1,1) Primary Key NOT NULL,
	Name nvarchar(max)
);

Create Table Customers(
	ID int identity(1,1) Primary Key NOT NULL,
	Name nvarchar(max)
);

Create Table Sales(
	ID int identity(1,1) Primary Key NOT NULL,
	ProductID int NOT NULL Foreign Key References Products(ID),
	ManagerID int NOT NULL Foreign Key References SalesManagers(ID),
	CustomerID int NOT NULL Foreign Key References Customers(ID),
	QuantitySold int NOT NULL,
	UnitPrice Decimal(10,2) NOT NULL,
	SaleDate Date NOT NULL
);


INSERT INTO TypeProduct (Type)
VALUES ('Письменные'),('Бумажные'),('Клей'), ('Канцелярские');

INSERT INTO Products (Name, TypeProductID, Quantity, CostPrice)
VALUES 
    ('Ручка гелевая', 1, 100, 1.50),
    ('Блокнот', 2, 50, 2.00),
    ('Карандаш HB', 1, 80, 0.50),
    ('Клейкая лента', 3, 30, 1.20),
    ('Степлер', 4, 20, 3.50);


INSERT INTO SalesManagers (Name)
VALUES 
    ('Иванов Иван Иванович'),
    ('Петров Петр Петрович'),
    ('Сидоров Сидор Сидорович'),
    ('Козлов Константин Константинович'),
    ('Смирнов Сергей Сергеевич');


INSERT INTO Customers (Name)
VALUES 
    ('ООО "Ромашка"'),
    ('ИП Иванов'),
    ('ОАО "Солнце"'),
    ('ИП Петров'),
    ('ЗАО "Луна"');


INSERT INTO Sales (ProductID, ManagerID, CustomerID, QuantitySold, UnitPrice, SaleDate)
VALUES 
    (1, 1, 2, 10, 2.00, '2024-02-01'),
    (2, 2, 1, 5, 3.00, '2024-02-03'),
    (3, 3, 3, 20, 0.75, '2024-02-05'),
    (4, 4, 4, 8, 1.50, '2024-02-08'),
    (5, 5, 5, 3, 4.00, '2024-02-10');


Go
Create Procedure GetAllProducts
As
Begin
    Select Name, TypeProduct.Type, Quantity, CostPrice 
	From Products JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID;
End;

Exec GetAllProducts;





Go
Create Procedure GetAllTypeProducts
As
Begin
    Select Type
	From TypeProduct
End;

Exec GetAllTypeProducts;





Go
Create Function GetAllManager()
Returns Table
As
Return
(
    Select Name
    From SalesManagers
);

SELECT * FROM GetAllManager();




Go
Create Procedure GetProductsByMaxQuantity
As
Begin
    SELECT Name, Type, Quantity
    FROM Products JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
    WHERE Quantity = (SELECT MAX(Quantity) FROM Products);
End;

Exec GetProductsByMaxQuantity;


Go
Create Procedure GetProductsByMinQuantity
As
Begin
    Select Name, Type, Quantity
    From Products JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
    Where Quantity = (Select MIN(Quantity) From Products);
End;

Exec GetProductsByMinQuantity;



Go
Create Procedure GetProductsByMinCostPrice
As
Begin
    Select Name, Type, CostPrice
    From Products JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
    Where CostPrice = (Select MIN(CostPrice) From Products);
End;

Exec GetProductsByMinCostPrice;


Go
Create Procedure GetProductsByMaxCostPrice
As
Begin
    Select Name, Type, CostPrice
    From Products JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
    Where CostPrice = (Select Max(CostPrice) From Products);
End;

Exec GetProductsByMaxCostPrice;



Go
Create Procedure GetTypeProduct
@ProductType nvarchar(max)
As
Begin
    Select Name, Type, Quantity, CostPrice
	From Products JOIN TypeProduct On Products.TypeProductID = TypeProduct.ID
	Where Type = @ProductType
End;

Exec GetTypeProduct @ProductType = 'Письменные';




Go
Create Procedure GetManagerSales
@Name nvarchar(max)
As
Begin
    Select Products.Name, TypeProduct.Type, Sales.QuantitySold, Sales.UnitPrice, SalesManagers.Name
	From Sales JOIN Products ON Sales.ProductID = Products.ID JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID JOIN SalesManagers ON Sales.ManagerID = SalesManagers.ID
	Where SalesManagers.Name = @Name
End;


Exec GetManagerSales @Name = 'Иванов Иван Иванович';






Go
Create Procedure GetCustomerBuyProduct
@Name nvarchar(max)
As
Begin
    Select Products.Name, TypeProduct.Type, Sales.QuantitySold, Sales.UnitPrice, Customers.Name
	From Sales JOIN Products ON Sales.ProductID = Products.ID JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID JOIN Customers ON Sales.ManagerID = Customers.ID
	Where Customers.Name = @Name
End;

Exec GetCustomerBuyProduct @Name = 'ИП Петров';






Go
Create Function GetDateLastSale()
Returns Table
As
Return
(
    Select TOP 1 Products.Name, TypeProduct.Type, Sales.SaleDate
    From Sales JOIN Products ON Sales.ProductID = Products.ID JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
	Order By Sales.SaleDate DESC
);

SELECT * FROM GetDateLastSale();


Go
Create Function GetAvgTypeQuantity()
Returns Table
As
Return
(
    Select Type, AVG(Quantity) As AverageQuantity
	From Products JOIN TypeProduct ON Products.ID = TypeProduct.ID
	Group By Type
);

SELECT * FROM GetAvgTypeQuantity();




-----------------------------------------------------------------TASK 2

Go
Create Procedure InsertStationeryProduct
    @ProductName nvarchar(max),
    @ProductType nvarchar(max),
    @Quantity int,
    @CostPrice decimal(10, 2)
As
Begin
    Set nocount on;
    Declare @ProductTypeID int;
    if NOT EXISTS (Select 1 
				   From TypeProduct 
				   Where Type = @ProductType)
    Begin
        Insert Into TypeProduct (Type)
        Values (@ProductType);
    End;
    Select @ProductTypeID = ID
    From TypeProduct
    Where Type = @ProductType;
    Insert Into Products (Name, TypeProductID, Quantity, CostPrice) Values (@ProductName, @ProductTypeID, @Quantity, @CostPrice);
End;

Exec InsertStationeryProduct @ProductName = 'Фломастер', @ProductType = 'Письменные', @Quantity = 100, @CostPrice = 5.99;



Go
Create Procedure InsertTypeProduct
    @ProductType nvarchar(max)
As
Begin
    Set nocount on;
    if NOT EXISTS (Select 1 From TypeProduct Where Type = @ProductType)
    Begin
        Insert Into TypeProduct (Type) Values (@ProductType);
    End;
End;

Exec InsertTypeProduct @ProductType = 'клейкое';




Go
Create Procedure InsertManager
    @ManagerName nvarchar(max)
As
Begin
    Set nocount on;
    Insert Into SalesManagers (Name) Values (@ManagerName);
End;

Exec InsertManager @ManagerName = 'Иван Иванович Иванов';



Go
Create Procedure InsertCustomers
	@Name nvarchar(max)
As
Begin
	Set nocount on;
	Insert Into Customers (Name) Values (@Name)
End;

Exec InsertCustomers @Name = 'ООО Иванович';





Go
Create Procedure UpdateStationeryProduct
    @ProductID int,
    @ProductName nvarchar(max),
    @ProductType nvarchar(max),
    @Quantity int,
    @CostPrice decimal(10, 2)
As
Begin
	Set nocount on;
    Update Products Set Name = @ProductName, Quantity = @Quantity, CostPrice = @CostPrice
    Where ID = @ProductID;
    if EXISTS (Select 1 From TypeProduct Where Type = @ProductType)
    Begin
        Update Products
        Set TypeProductID = (Select ID From TypeProduct Where Type = @ProductType)
        Where ID = @ProductID;
    End;
End;




Go
Create Procedure UpdateCustomer
    @CustomerID int,
    @NewCustomerName nvarchar(max)
As
Begin
    Set nocount on;
    Update Customers Set Name = @NewCustomerName Where ID = @CustomerID;
End;


EXEC UpdateCustomer @CustomerID = 6, @NewCustomerName = 'ООО Юфывфывццра';




Go
Create Procedure UpdateSalesManager
    @ManagerID int,
    @NewManagerName nvarchar(max)
As
Begin
    Set nocount on;
    Update SalesManagers
    Set Name = @NewManagerName
    Where ID = @ManagerID;
End;

Exec UpdateSalesManager @ManagerID = 6, @NewManagerName = 'аа аа аа';



Go
Create Procedure UpdateTypeProduct
    @TypeID int,
    @NewType nvarchar(max)
As
Begin
    Set nocount on;
    Update TypeProduct Set Type = @NewType
    Where ID = @TypeID;
End;

Exec UpdateTypeProduct @TypeID = 6, @NewType = 'fgdfgdf'




Go
Create Procedure DeleteProduct
    @ProductID int
As
Begin
    Set nocount on;
    Delete From Products
    Where ID = @ProductID;
End;


Exec DeleteProduct @ProductID = 5



Go
Create Procedure DeleteManager
	@ManagerID int
As
Begin
	Set nocount on;
	Delete From SalesManagers
	Where ID = @ManagerID;
End;

Exec DeleteManager @ManagerID = 6



Go
Create Procedure DeleteTypeProduct
	@TypeProductID int
As
Begin
	Set nocount on;
	Delete From TypeProduct
	Where ID = @TypeProductID
End;

Exec DeleteTypeProduct @TypeProductID = 6



Go
Create Procedure DeleteCustomers
	@CustomersID int
As
Begin
	Set nocount on;
	Delete From Customers
	Where ID = @CustomersID
End;

Exec DeleteCustomers @CustomersID = 6


Go
Create Procedure GetTopSalesManager
As
Begin
	Set nocount on;
    Select Top 1 SalesManagers.ID as ManagerID, SalesManagers.Name as ManagerName, SUM(Sales.QuantitySold) as TotalSales
    From Sales JOIN SalesManagers on Sales.ManagerID = SalesManagers.ID
    Group By SalesManagers.ID, SalesManagers.Name
    Order By TotalSales desc;
End;

Exec GetTopSalesManager;



Go
Create Procedure GetTopProfitSalesManager
As
Begin
	Set nocount on;
    Select Top 1 SalesManagers.ID as ManagerID, SalesManagers.Name as ManagerName, SUM(Sales.QuantitySold * Sales.UnitPrice - Products.CostPrice * Sales.QuantitySold) as TotalProfit
    From Sales JOIN SalesManagers ON Sales.ManagerID = SalesManagers.ID JOIN Products ON Sales.ProductID = Products.ID
    Group By SalesManagers.ID, SalesManagers.Name
    Order By TotalProfit DESC;
End;


Exec GetTopProfitSalesManager;




Go
Create Procedure GetTopProfitSalesManagerInRange
    @StartDate date,
    @EndDate date
As
Begin
	Set nocount on;
    Select Top 1 SalesManagers.ID as ManagerID, SalesManagers.Name as ManagerName, SUM(Sales.QuantitySold * Sales.UnitPrice - Products.CostPrice * Sales.QuantitySold) as TotalProfit
    From Sales JOIN SalesManagers ON Sales.ManagerID = SalesManagers.ID JOIN Products ON Sales.ProductID = Products.ID
    Where Sales.SaleDate BETWEEN @StartDate AND @EndDate
    Group By SalesManagers.ID, SalesManagers.Name
    Order By TotalProfit DESC;
End;




Go
Create Procedure GetTopSpendingCustomer
As
Begin
	Set nocount on;
    Select Top 1 Customers.ID AS CustomerID, Customers.Name AS CustomerName, SUM(Sales.QuantitySold * Sales.UnitPrice) AS TotalSpent
    From Sales JOIN Customers ON Sales.CustomerID = Customers.ID
    Group By Customers.ID, Customers.Name
    Order By TotalSpent DESC;
End;

Exec GetTopSpendingCustomer






Go
Create Procedure GetTopSalesTypeProduct
As
Begin
	Set nocount on;
    Select Top 1 TypeProduct.ID AS TypeProductID, TypeProduct.Type as TypeProductName, SUM(Sales.QuantitySold) as TotalSales
    From Sales JOIN Products ON Sales.ProductID = Products.ID JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
    Group By TypeProduct.ID, TypeProduct.Type
    Order By TotalSales DESC;
end;

Exec GetTopSalesTypeProduct




Go
Create Procedure GetTopProfitableTypeProduct
As
Begin
	Set nocount on;
    Select Top 1 TypeProduct.ID as TypeProductID, TypeProduct.Type AS TypeProductName, SUM((Sales.UnitPrice - Products.CostPrice) * Sales.QuantitySold) as TotalProfit
    From Sales JOIN Products ON Sales.ProductID = Products.ID JOIN TypeProduct ON Products.TypeProductID = TypeProduct.ID
    Group By TypeProduct.ID, TypeProduct.Type
    Order By TotalProfit DESC;
End;

Exec GetTopProfitableTypeProduct



Go
Create Procedure GetMostPopularStationeryProducts
As
Begin
	Set nocount on;
    Select Products.Name as ProductName, SUM(Sales.QuantitySold) as TotalQuantitySold
    From Sales JOIN Products ON Sales.ProductID = Products.ID
    Group By Products.Name
    Order By TotalQuantitySold DESC;
End;

Exec GetMostPopularStationeryProducts




Go
Create Procedure GetStationeryProductsNotSoldForDays
    @NumberOfDays int
As
Begin
	Set nocount on;
    Select Distinct Products.Name as ProductName
    From Products
    Where NOT EXISTS (
            Select 1
            From Sales
            Where Sales.ProductID = Products.ID AND Sales.SaleDate >= DateAdd(DAY, -@NumberOfDays, GETDATE())
        );
End;

Exec GetStationeryProductsNotSoldForDays @NumberOfDays = 10