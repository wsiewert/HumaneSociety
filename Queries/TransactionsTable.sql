Create Table Transactions (
ID int identity (1,1) Primary Key,
Amount decimal,
FK_CustomerID int,
FK_AnimalID int,
FOREIGN KEY (FK_CustomerID) REFERENCES dbo.Animals(ID),
FOREIGN KEY (FK_AnimalID) REFERENCES dbo.Customers(ID)
);