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