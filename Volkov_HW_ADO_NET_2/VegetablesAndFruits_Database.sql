Create Database VegetablesAndFruits

use VegetablesAndFruits

Create Table VegetablesAndFruits(
	name nvarchar(max) NOT NULL,
	type nvarchar(max) NOT NULL,
	color nvarchar(20) NOT NULL,
	calories int NOT NULL
)

Insert Into dbo.VegetablesAndFruits(name,type,color,calories) Values ('������','�����','�������',47),('�����','�����','������',89),('�������','�����','���������',41),('�������','����','�������',41),('������','����','�������',15)