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
/* Rooms_ID int,
FOREIGN KEY (Rooms_ID) REFERENCES Rooms(ID) */
);