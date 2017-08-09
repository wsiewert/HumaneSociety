Create Table Animals (
ID int identity (1, 1) Primary Key,
Name varchar(255) NOT NULL,
Age int NOT NUll,
Species varchar(255) NOT NULL,
Breed varchar(255) NOT NULL,
Room int,
AdoptionStatus bit,
VaccinationStatus bit,
FedStatus bit,
FoodType varchar(255),
FoodQuantity int,
ActivityLevel int CHECK(ActivityLevel>0 AND ActivityLevel<10),
Rooms_ID int,
FOREIGN KEY (Rooms_ID) REFERENCES Rooms(ID)
);