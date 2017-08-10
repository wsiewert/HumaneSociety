Create Table Animals (
ID int identity (1, 1) Primary Key,
Name varchar(255) NOT NULL,
Age int NOT NUll,
Species varchar(255) NOT NULL,
Breed varchar(255) NOT NULL,
AdoptionStatus bit NOT NULL,
VaccinationStatus bit NOT NULL,
FoodType varchar(255) NOT NULL,
FoodQuantity int NOT NULL,
ActivityLevel int CHECK(ActivityLevel>0 AND ActivityLevel<10) NOT NULL,
FK_Rooms_ID int,
FK_Customers_ID int,
FOREIGN KEY (FK_Rooms_ID) REFERENCES dbo.Rooms(ID),
FOREIGN KEY (FK_Customers_ID) REFERENCES dbo.Customers(ID)
);

Select * FROM Animals