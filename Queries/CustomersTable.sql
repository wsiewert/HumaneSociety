Create Table Customers (
ID int identity (1, 1) Primary Key,
FirstName varchar(255),
LastName varchar(255),
ActivityLevel int CHECK(ActivityLevel>0 AND ActivityLevel<10),
MartialStatus bit,
Occupation bit
);