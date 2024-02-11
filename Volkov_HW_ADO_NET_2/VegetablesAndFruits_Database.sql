Create Database VegetablesAndFruits

use VegetablesAndFruits

Create Table VegetablesAndFruits(
	name nvarchar(max) NOT NULL,
	type nvarchar(max) NOT NULL,
	color nvarchar(20) NOT NULL,
	calories int NOT NULL
)

Insert Into dbo.VegetablesAndFruits(name,type,color,calories) Values ('Яблоко','Фрукт','Зеленый',47),('Банан','Фрукт','Желтый',89),('Морковь','Овощь','Оранжевый',41),('Помидор','Овощ','Красный',41),('Огурец','Овощ','Зеленый',15)