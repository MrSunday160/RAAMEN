create table Role(

	ID int not null primary key identity(1, 1),
	Name varchar(50) not null

)

create table Users(

	ID int not null primary key identity(1, 1),
	roleID int not null,
	Username varchar(50) not null,
	Email varchar(50) not null,
	Gender varchar(50) not null,
	Password varchar(50) not null,

	foreign key(roleID) references Role(ID)

)

create table Header(

	ID int not null primary key identity(1, 1),
	customerID int not null,
	staffID int not null,
	Date date not null,

	foreign key(customerId) references Users(ID)

)

-- meat, ramen, detail
create table Meat(

	ID int not null primary key identity(1, 1),
	Name varchar(50) not null

)

create table RamenDetail(

	ID int not null primary key identity(1, 1),
	meatID int not null,
	Name varchar(50) not null,
	Broth varchar(50) not null,
	Price varchar(50) not null,

	foreign key(meatID) references Meat(ID)

)

create table Detail(

	headerID int not null,
	ramenID int not null,
	Quantity int not null

	primary key(headerID, ramenID)

	foreign key(headerID) references Header(ID),
	foreign key(ramenID) references RamenDetail(ID)

)