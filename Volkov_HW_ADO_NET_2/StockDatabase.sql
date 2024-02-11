Create Database Stock

use Stock

Create Table Product(
	id int identity(1,1) Primary Key NOT NULL,
	Name nvarchar(max) NOT NULL,
	Type nvarchar(max) NOT NULL
)

Create Table Provider(
	ID int identity(1,1) Primary Key NOT NULL,
	Name nvarchar(max) NOT NULL,
	Country nvarchar(max) NOT NULL
)

Create Table Stock(
	ID int identity(1,1) Primary Key NOT NULL,
	ProductID int NOT NULL Foreign Key References Product(id),
	ProviderID int NOT NULL Foreign Key References Provider(ID),
	Count int NOT NULL,
	CostPrice Decimal(18,2) NOT NULL,
	DateOfDelivery date NOT NULL
)

Insert Into Product(Name, Type) Values ('Молоко', 'Продукты'),('Хлеб', 'Продукты'),('Яблоки', 'Фрукты'),('Бананы', 'Фрукты'),('Огурцы', 'Овощи')

Insert Into Provider (Name, Country) Values ('Green Valley', 'Италия'),('Frutas del Sol', 'Испания'),('Fresh Fields', 'Нидерланды')

Insert Into dbo.Stock (ProductID, ProviderID, Count, CostPrice, DateOfDelivery) Values (1, 1, 100, 50, '2024-02-09'),(2, 1, 50, 30, '2024-02-08'),(3, 2, 100, 70, '2024-02-07'),(4, 2, 50, 60, '2024-02-06'),(5, 3, 100, 40, '2024-02-05')