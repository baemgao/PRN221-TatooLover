Create database PRN221_TatooLover
Use PRN221_TatooLover

Create table Customer (
	CustomerID int Not null Primary key Identity(1,1),
	Code varchar(50) Not null,
	Email varchar(100) Not null,
	Password varchar(100) Not null,
	Name nvarchar(255) Not null,
	Address nvarchar(255) Not null,
	Phone varchar(20),
	Avatar varchar(255),
	Status int Not null
);

Create table Studio (
	StudioID int Not null Primary key Identity(1,1),
	Code varchar(50) Not null,
	Password varchar(255) Not null,
	Name nvarchar(100) Not null,
	Address nvarchar(255) Not null,
	Phone varchar(20),
	OpenHour Time Not null,
	CloseHour Time Not null,
	IsWeekendOff Bit Not null, --1: off | 0: no off
	Status int Not null
);

CREATE TABLE Service (
    ServiceID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    StudioID INT FOREIGN KEY REFERENCES Studio(StudioID),
    Code VARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Time INT NOT NULL,
    Price FLOAT NOT NULL,
    Status INT
);

Create table Artist (
	ArtistID int Not null Primary key Identity(1,1),
	StudioID int Not null FOREIGN KEY REFERENCES Studio(StudioID),
	Code VARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Email varchar(100) Not null,
	Password varchar(100) Not null,
	Phone varchar(20),
	Address nvarchar(255),
	Avatar varchar(255),
	Certificate varchar(255),
	Status int
);

Create table ArtistDetail (
	ArtistDetailID int  Not null Primary key Identity(1,1),
	ArtistID int Not null FOREIGN KEY REFERENCES Artist(ArtistID), 
	ServiceID int Not null FOREIGN KEY REFERENCES Service(ServiceID)
);

Create table Schedule (
	ScheduleID int  Not null Primary key Identity(1,1),
	ArtistID int Not null FOREIGN KEY REFERENCES Artist(ArtistID), 
	Date Datetime Not null,
	TimeFrom Time Not null,
	TimeTo Time Not null,
	Status int Not null
);

Create table Booking (
	BookingID int not null Primary key Identity(1,1),
	CustomerID int Not null FOREIGN KEY REFERENCES Customer(CustomerID), 
	ArtistID int Not null FOREIGN KEY REFERENCES Artist(ArtistID),
	Price Float Not null,
	BookingDate DateTime Not null,
	BookingTime Time Not null,
	Note nvarchar(255),
	Point int,
	ArtistFeedBack nvarchar(255),
	ServiceFeedBack nvarchar(255),
	Status int Not null
	
	--Booking status:
	-- 0: Pending (After booking, waiting to booking date time)
	-- 1: Check in (After customer come to studio)
	-- 2: done (finish service)
	-- 3: checkout (after pay bill, warranty time)
	-- 4: finish (out of warranty, finish booking)
);

Create table BookingDetail (
	BookingDetailID int not null Primary key Identity(1,1),
	BookingID int Not null FOREIGN KEY REFERENCES Booking(BookingID),
	ServiceID int Not null FOREIGN KEY REFERENCES Service(ServiceID),
	Description nvarchar(255),
	Status int Not null
);

Create table Bill (
	BillID int not null Primary key Identity(1,1),
	BookingID int Not null FOREIGN KEY REFERENCES Booking(BookingID),
	Note nvarchar(255),
	Status int Not null

	--Bill Status
	-- 0: Open
	-- 1: Close
	-- 2: Finish
);