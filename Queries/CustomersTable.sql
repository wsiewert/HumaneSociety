Create Table Customers (
ID int identity (1, 1) Primary Key,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
Age int NOT NULL,
ActivityLevel int CHECK(ActivityLevel>0 AND ActivityLevel<10) NOT NULL,
MartialStatus bit NOT NULL,
Occupation bit NOT NULL
);