create database dbMiBodeguita
GO

use dbMiBodeguita
GO

create table Unidad(
	ID int primary key not null --1
	,	Codigo varchar(2)		-- UN
	,	Nombre varchar(20)		-- UNIDAD
)
GO

create table Producto(
	ID int primary key not null
	,	Nombre varchar(75)
	,	PCompra decimal(10,2) not null -- 1234567.1234
	,	PVenta decimal(10,2) not null
	,	Stock decimal(10,2) not null
	,	ID_Unidad int not null
)

ALTER TABLE Producto WITH CHECK ADD CONSTRAINT FK_Producto_Unidad
FOREIGN KEY(ID_Unidad) REFERENCES Unidad(ID)
GO

INSERT INTO Producto VALUES(1,'Harina',5.6,7.8,100,1)
INSERT INTO Producto VALUES(2,'Azucar',1.632,2.346,100,1)
INSERT INTO Producto VALUES(3,'Tomate',2.632,3.346,100,1)
INSERT INTO Producto VALUES(4,'Prueba',2.632,4.346,100,1)

DELETE Producto
WHERE PCompra>3
GO

SELECT 
	*
FROM Producto prod
inner join Unidad un on un.ID = prod.ID_Unidad


INSERT INTO Unidad(Nombre,ID) VALUES('UNIDAD',1)
INSERT INTO Unidad VALUES(2,'KG','KILOGRAMO')
INSERT INTO Unidad VALUES(3,'LT','LITRO')

UPDATE Unidad
set Nombre = 'KILOGRAMO'
WHERE ID = 2

SELECT *FROM Unidad


