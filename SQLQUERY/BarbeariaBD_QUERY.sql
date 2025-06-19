use BarbeariaDB;


create table Barber(
	Id int primary key identity(1,1),
	[Name] varchar(100) NOT NULL,
	Phone varchar(11) NOT NULL,
	StartTimeWork time NOT NULL,
	EndTimeWord time NOT NULL
);

create table Client(
	Id int primary key identity(1,1),
	[Name] varchar(100) NOT NULL,
	Phone varchar(11) NOT NULL,
);

create table Service(
	Id int primary key identity(1,1),
	[Name] varchar(100) NOT NULL,
	Price decimal(10,2) NOT NULL,
);

ALTER TABLE Service
ADD Duration time;

create table Appointments(
	Id int primary key identity(1,1),
	IdClient int NOT NULL,
	IdBarber int NOT NULL,
	IdService int NOT NULL,
	StartTimeWork time NOT NULL,
	EndTimeWork time NOT NULL,
	[Status] int NOT NULL,

	CONSTRAINT FK_Client FOREIGN KEY (IdClient) REFERENCES Client(Id),
	CONSTRAINT FK_Barber FOREIGN KEY (IdBarber) REFERENCES Barber(Id),
	CONSTRAINT FK_Service FOREIGN KEY(IdService) REFERENCES Service(id)
);
