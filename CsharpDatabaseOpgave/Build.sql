IF NOT EXISTS(SELECT *
FROM sys.databases
WHERE name = 'Cinema')
BEGIN
    CREATE DATABASE Cinema
END

GO

USE Cinema

GO

IF NOT EXISTS(SELECT *
FROM sysobjects
WHERE name='Customer')
BEGIN
    CREATE TABLE Customer
    (
        CustomerID int,
        FirstName varchar(255),
		LastName varchar(255),
        Phone varchar(255),
		Email varchar(255),
        CustomerType int
    )
END

IF NOT EXISTS(SELECT *
FROM sysobjects
WHERE name='Booking')
BEGIN
    CREATE TABLE Booking
    (
        CustomerID int,
		Movie varchar(255),
		PlayDate date,
		PlayTime time,
		SeatCount int,
		BookingType int
    )
END