use master 
go

if(exists(select * from sys.databases where name = 'csharpAPI'))
	drop database csharpAPI
go

create database csharpAPI
go

use csharpAPI
go

create table Product(
	ID int identity primary key,
	ItemName varchar(80) not null,
	Photo varbinary(MAX) null,
	DescriptionText varchar(400) not null
);
go

create table Store(
	ID int identity primary key,
	Loc varchar(200) not null
);
go

create table MenuItem(
	ID int identity primary key,
	ProductID int references Product(ID) not null,
	StoreID int references Store(ID) not null,
	Price decimal(5, 2) not null
);
go

create table ClientOrder(
	ID int identity primary key,
	OrderCode varchar(12) not null,
	StoreID int references Store(ID) not null,
	FinishMoment datetime null,
	DeliveryMoment datetime null
);
go

create table ClientOrderItem(
	ID int identity primary key,
	ClientOrderID int references ClientOrder(ID) not null,
	ProductID int references Product(ID) not null
);
go

insert Store values 
	('Mc Curitiba'), 
	('Mec Errejota'),
	('Mc SP')
