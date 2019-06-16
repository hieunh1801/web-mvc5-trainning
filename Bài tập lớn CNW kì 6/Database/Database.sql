CREATE DATABASE ShoesShop
GO

USE ShoesShop
GO

CREATE TABLE Category
(
  idCategory INT NOT NULL IDENTITY(1,1),
  name NVARCHAR(50),
  urlImage NTEXT,

  PRIMARY KEY(idCategory)
);

CREATE TABLE Vendor
(
  idVendor INT NOT NULL IDENTITY(1,1),
  name NVARCHAR(50),
  address NVARCHAR(200),
  phoneNumber NVARCHAR(15)

    PRIMARY KEY(idVendor)

);

CREATE TABLE Color
(
  idColor INT NOT NULL IDENTITY (1,1),
  color NVARCHAR(200)

    PRIMARY KEY(idColor)

);

CREATE TABLE Size
(
  idSize INT NOT NULL IDENTITY (1,1),
  size INT,

  PRIMARY KEY(idSize)
);

CREATE TABLE Account
(
  idAccount INT NOT NULL IDENTITY (1,1),
  userName NVARCHAR(50),
  password NVARCHAR(50),
  role NVARCHAR(20),

  PRIMARY KEY(idAccount)
)

CREATE TABLE Customer
(
  idCustomer INT NOT NULL IDENTITY (1,1),
  idAccount INT,
  gender NVARCHAR(50),
  address NVARCHAR(200),
  phoneNumber NVARCHAR(15),

  PRIMARY KEY(idCustomer),
  FOREIGN KEY(idAccount) REFERENCES Account(idAccount)
);
CREATE TABLE Shoes
(
  idShoes INT NOT NULL IDENTITY (1,1),
  name NVARCHAR(50),
  description NTEXT,
  defaultUrlImage NTEXT,
  idCategory INT,
  idVendor INT,
  price FLOAT,

  PRIMARY KEY(idShoes),
  FOREIGN KEY(idCategory) REFERENCES Category(idCategory),
  FOREIGN KEY(idVendor) REFERENCES Vendor(idVendor),
)
CREATE TABLE ShoesDetail
(
  idShoesDetail INT NOT NULL IDENTITY(1,1),
  idColor INT,
  idShoes INT,
  idSize INT,
  quantity INT,
  urlImage NTEXT,

  PRIMARY KEY(idShoesDetail),
  FOREIGN KEY(idColor) REFERENCES Color(idColor),
  FOREIGN KEY(idShoes) REFERENCES Shoes(idShoes),
  FOREIGN KEY(idSize) REFERENCES Size(idSize),
)
CREATE TABLE Cart
(
  idCart INT NOT NULL IDENTITY (1,1),
  idCustomer INT,
  idShoesDetail INT,
  quantity INT,

  PRIMARY KEY(idCart),
  FOREIGN KEY(idCustomer) REFERENCES Customer(idCustomer),
  FOREIGN KEY(idShoesDetail) REFERENCES ShoesDetail(idShoesDetail),
);
GO

--------------------------------STORE PROCEDURE--------------------------
CREATE PROCEDURE SP_Category_Insert
  @name NVARCHAR(50),
  @urlImage NTEXT
AS
BEGIN
  INSERT INTO Category(name, urlImage)
  VALUES(@name, @urlImage)
END
GO

CREATE PROCEDURE SP_Vendor_Insert
  @name NVARCHAR(50),
  @address NVARCHAR(200),
  @phoneNumber NVARCHAR(15)
AS
BEGIN
  INSERT INTO Vendor(name, address, phoneNumber)
  VALUES(@name, @address, @phoneNumber)
END
GO

CREATE PROCEDURE SP_Color_Insert
  @color NVARCHAR(200)
AS
BEGIN
  INSERT INTO Color(color)
  VALUES(@color)
END
GO

CREATE PROCEDURE SP_Size_Insert
  @size INT
AS
BEGIN
  INSERT INTO Size(size)
  VALUES(@size)
END
GO

CREATE PROCEDURE SP_Account_Insert
  @userName NVARCHAR(50),
  @password NVARCHAR(50),
  @role INT
AS
BEGIN
  INSERT INTO Account(userName, password, role)
  VALUES(@userName, @password, @role)
END
GO

CREATE PROCEDURE SP_Customer_Insert
  @idAccount INT,
  @gender NVARCHAR(50),
  @address NVARCHAR(200),
  @phoneNumber NVARCHAR(15)
AS
BEGIN
  INSERT INTO Customer(idAccount, gender, address, phoneNumber)
  VALUES(@idAccount, @gender, @address, @phoneNumber)
END
GO

CREATE PROCEDURE SP_Shoes_Insert
  @name NVARCHAR(50),
  @description NTEXT,
  @defaultUrlImage NTEXT,
  @idCategory INT,
  @idVendor INT,
  @price FLOAT
AS
BEGIN
  INSERT INTO Shoes(name, description, defaultUrlImage, idCategory, idVendor, price)
  VALUES(@name,@description, @defaultUrlImage, @idCategory, @idVendor, @price)
END
GO

CREATE PROCEDURE SP_ShoesDetail_Insert
  @idShoes INT,
  @idColor INT,
  @idSize INT,
  @quantity INT,
  @urlImage NTEXT
AS
BEGIN
  INSERT INTO ShoesDetail(idColor, idShoes, idSize, quantity, urlImage)
  VALUES(@idColor, @idShoes, @idSize, @quantity, @urlImage)
END
GO

CREATE PROCEDURE SP_Cart_Insert
  @idCustomer INT,
  @idShoesDetail INT,
  @quantity INT
AS
BEGIN
  INSERT INTO Cart(idCustomer, idShoesDetail, quantity)
  VALUES(@idCustomer, @idShoesDetail, @quantity)
END
GO
