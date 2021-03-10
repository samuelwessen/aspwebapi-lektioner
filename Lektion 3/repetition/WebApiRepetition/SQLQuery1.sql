CREATE TABLE Customers (
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null
)

CREATE TABLE ServiceWorkers(
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null
)
GO

CREATE TABLE Issues (
	Id int not null identity(1,1) primary key,
	CustomerId int not null references Customers(Id),
	ServiceWorkerId int not null references ServiceWorkers(Id),
	IssueDate datetime not null,
	ResovleDate datetime null,
	IssueDescription nvarchar(max) not null,
	IssueStatus nvarchar(20) not null
)
