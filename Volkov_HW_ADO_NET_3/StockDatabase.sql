Create Database Stock

use Stock

Create Table TypeProduct(
	ID int identity(1,1) Primary Key NOT NULL,
	Type nvarchar(max) NOT NULL
)

Create Table Product(
	ID int identity(1,1) Primary Key NOT NULL,
	Name nvarchar(max) NOT NULL,
	TypeID int NOT NULL Foreign Key References TypeProduct(ID)
)

Create Table Provider(
	ID int identity(1,1) Primary Key NOT NULL,
	Name nvarchar(max) NOT NULL,
	Country nvarchar(max) NOT NULL
)

Create Table Stock(
	ID int identity(1,1) Primary Key NOT NULL,
	ProductID int NOT NULL Foreign Key References Product(ID),
	ProviderID int NOT NULL Foreign Key References Provider(ID),
	Count int NOT NULL,
	CostPrice Decimal(18,2) NOT NULL,
	DateOfDelivery date NOT NULL
)


Insert Into TypeProduct(Type) Values ('Продукты'),('Фрукты'),('Овощи')

Insert Into Product(Name, TypeID) Values ('Молоко', 1),('Хлеб', 1),('Яблоки', 2),('Бананы', 2),('Огурцы', 3)

Insert Into Provider (Name, Country) Values ('Green Valley', 'Италия'),('Frutas del Sol', 'Испания'),('Fresh Fields', 'Нидерланды')

Insert Into dbo.Stock (ProductID, ProviderID, Count, CostPrice, DateOfDelivery) Values (1, 1, 100, 50, '2024-02-09'),(2, 1, 50, 30, '2024-02-08'),(3, 2, 100, 70, '2024-02-07'),(4, 2, 50, 60, '2024-02-06'),(5, 3, 100, 40, '2024-02-05')
