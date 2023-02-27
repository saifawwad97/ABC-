-------------- Customer Table  ------------------
CREATE TABLE Customer (
 CustomerID varchar(10) PRIMARY KEY,
 CustomerName varchar(50),
 Addresses varchar(100),
 City varchar(50),
 Province varchar(50),
 PostalCode varchar(7)
);


------------- Sale Table -----------------------------

CREATE TABLE Sale (
 SaleNumber Varchar(50) PRIMARY KEY CHECK (SaleNumber > 1 and SaleNumber < 100000 ),
 SaleDate varchar(50),
 SalePerson varchar(10),
 CustomerID varchar(10) FOREIGN KEY REFERENCES Customer(CustomerID),
 SubTotal int ,
 GST int,
 SaleTotal varchar(50)
);



-------------- Item Table-------------------- 

CREATE TABLE Item (
 ItemCode varchar(10) PRIMARY KEY,
 [Description] varchar(20),
 UnitPrice int,
 Quantity int
);

insert into Item values('S12345','NewItem',1,4)


drop table Item

drop table saleitem
----------------- Sale Item -------------

CREATE TABLE SaleItem (

 SaleNumber Varchar(50)  FOREIGN KEY REFERENCES Sale(SaleNumber) CHECK (SaleNumber > 1 and
SaleNumber < 100000 ),

 ItemCode varchar(10) FOREIGN KEY REFERENCES Item(ItemCode ),


 quantity int,
 ItemTotal Varchar(50)
);



----------------------------------------------------Procedure Section -------------------------------------------------------------------------


---------------------------------------------------AddItem Procedure ------------------------------------------------------------------
Create Procedure AddSale (
                             @SaleNumber varchar(50) = null,
							 @SaleDate varchar(5) = null,
							 @SalePerson varchar(10)= null,
							 @CustomerID varchar(10) =null

							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @SaleNumber Is Null 
         
		  RAISERROR('AddToCart  - Required parameter: @ItemCode', 16,1)

		  Else 
if @Quantity Is Null 
         
		  RAISERROR('AddToCart  - Required parameter: @ItemCode', 16,1)


 Begin 
   
select si.ItemCode  ,ic.description,ic.unitprice, @Quantity as Quantity  , @Quantity * ic.unitprice as ItemTotal  from Item ic 
inner join saleitem si on ic.itemCode = si.ItemCode

	where ic.ItemCode = @ItemCode

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('AddToCart   -  The Item that you provide is not exist. Please try again : Item table', 16,1) 

			end

			
			
	Return @ReturnCode



Create Procedure AddToCart (
                             @ItemCode varchar(10) = null,
							 @Quantity int = null
							
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @ItemCode Is Null 
         
		  RAISERROR('AddToCart  - Required parameter: @ItemCode', 16,1)

		  Else 
if @Quantity Is Null 
         
		  RAISERROR('AddToCart  - Required parameter: @ItemCode', 16,1)


 Begin 

select si.ItemCode  ,ic.description,ic.unitprice, @Quantity as Quantity  , @Quantity * ic.unitprice as ItemTotal  from Item ic 
inner join saleitem si on ic.itemCode = si.ItemCode

	where ic.ItemCode = @ItemCode

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('AddToCart   -  The Item that you provide is not exist. Please try again : Item table', 16,1) 

			end

			
			
	Return @ReturnCode
	drop procedure AddToCart
	EXECUTE AddToCart L12847,2
	select * from Item
	EXECUTE AddToCart L12345,2
	
	
-----------------------------------------------------------------------------------------------------------------------

Create Procedure AddItem (
                             @ItemCode varchar(10) = null,
                             @Description varchar(20) =null,
							 @UnitPrice int = null,
							 @Quantity int = null
							
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @ItemCode Is Null 
         
		  RAISERROR('AddItem  - Required parameter: @ItemCode', 16,1)

		  Else 
if @Description IS NULL 
         
		 RAISERROR('AddItem - Reuired parameter: @Description', 16,1)

		  Else 
if @UnitPrice IS NULL 
         
		 RAISERROR('AddItem - Reuired parameter: @UnitPrice', 16,1)

	
		  
		  
 Begin 
       insert into Item (ItemCode, [Description], UnitPrice, Quantity ) values ( @ItemCode,@Description, @UnitPrice, @Quantity);

	

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('AddItem   -  The Item that you provide is already exist. Please try again : Item table', 16,1) 

			end

			
			
	Return @ReturnCode

	EXECUTE additem 'l1345', 'Vice Grip', '10'
	------------------------------------------------Update Item Procedure --------------------------------------------------------
	
	create procedure UpdateItem (@ItemCode char(10) = null,
                             @Description char (20)=null,
							 @UnitPrice int =null,
							 @Quantity int =null
						
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @ItemCode Is Null 
         
		  RAISERROR('UpdateItem  - Required parameter: @ItemCode', 16,1)

		  Else 
if @Description IS NULL 
         
		 RAISERROR('UpdateItem  - Reuired parameter: @Description', 16,1)

		  Else 
if @UnitPrice IS NULL 
         
		 RAISERROR('UpdateItem  - Reuired parameter: @UnitPrice', 16,1)

Else 
if @Quantity IS NULL 
         
		 RAISERROR('UpdateItem  - Reuired parameter: @Quantity', 16,1)







 
  BEGIN
            UPDATE Item
            SET    ItemCode = @ItemCode,
                   Description = @Description,
                   UnitPrice = @UnitPrice,
				   Quantity = @Quantity
              
            WHERE  ItemCode = @ItemCode	

		If @@ERROR  = 0
		   
		    set @ReturnCode = 0 
		     Else

			RAISERROR ('UpdateItem    - The item can not be updated , please check the item code: Item table', 16,1) 

			end

			

	Return @ReturnCode


	-----------------------------------------------Delete Item Procedure --------------------------------------------------


create procedure DeleteItem (@ItemCode char(10) = null
                             
						
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @ItemCode Is Null 
         
		  RAISERROR('DeleteItem  - Required parameter: @ItemCode', 16,1)

 
  BEGIN
          Delete from Item where ItemCode = @ItemCode

		If @@ERROR  = 0
		   
		    set @ReturnCode = 0 
		     Else

			RAISERROR ('DeleteItem    - The item can not be deleted , please check the item code: Item table', 16,1) 

			end

			

	Return @ReturnCode


	--------------------------------------------- AddCustomer Procedute ---------------------------------------------
	
	Create Procedure AddCustomer (
                              @CustomerID varchar(10) = null,
                             @CustomerName varchar(50) =null,
							 @Addresses varchar(100) = null,
							 @City varchar(50) = null,
							 @Province varchar(50) = null,
							 @PostalCode varchar(70)
							
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @CustomerID Is Null 
         
		  RAISERROR('AddCustomer  - Required parameter: @CustomerID', 16,1)

		  Else 
if @CustomerName IS NULL 
         
		 RAISERROR('AddCustomer - Reuired parameter: @@CustomerName', 16,1)

		  Else 
if @Addresses IS NULL 
         
		 RAISERROR('AddCustomer - Reuired parameter: @Addresses', 16,1)

		  Else 

if @City IS NULL 
         
		 RAISERROR('AddCustomer - Reuired parameter: @City', 16,1)

		  Else

if @Province IS NULL 
         
		 RAISERROR('AddCustomer - Reuired parameter: @Province', 16,1)

		  Else

if @PostalCode IS NULL 
         
		 RAISERROR('AddCustomer - Reuired parameter: @PostalCode', 16,1)

		  Else

		  
 Begin 
       insert into Customer (CustomerID ,customerName, Addresses, City, province, postalCode )values ( @CustomerID,@CustomerName, @Addresses, @City, @Province, @PostalCode);

	

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('AddCustomer   - The Customer Can not be Added. Please try again : Customer table', 16,1) 

			end

	
	Return @ReturnCode

	EXECUTE AddCustomer 
	-------------------------------------------------------Update Customer Procedure  ---------------------------------------------------------------


Create Procedure UpdateCustomer (
                              @CustomerID varchar(10) = null,
                             @CustomerName varchar(50) =null,
							 @Addresses varchar(100) = null,
							 @City varchar(50) = null,
							 @Province varchar(50) = null,
							 @PostalCode varchar(70)
							
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @CustomerID IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @CustomerID', 16,1)

		  Else 


if @CustomerName IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @CustomerName', 16,1)

		  Else 
if @Addresses IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @Addresses', 16,1)

		  Else 

if @City IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @City', 16,1)

		  Else

if @Province IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @Province', 16,1)

		  Else

if @PostalCode IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @PostalCode', 16,1)

		  Else

		  
 Begin 

	   
            UPDATE customer
            SET    CustomerID = @CustomerID,
			       CustomerName = @CustomerName,
                   Addresses = @Addresses,
                   City = @City,
				   Province= @Province,
				   PostalCode = @PostalCode

              
            WHERE  CustomerID = @CustomerID
	

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('UpdateCustomer   - The Customer Can not be Updated. Please try again : Customer table', 16,1) 

			end

			
			
	Return @ReturnCode


	---------------------------------------------------DeleteCustomer-------------------------------------------------------------------

Create Procedure DeleteCustomer (
                              @CustomerID varchar(10) = null
                        
							
							 )

As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @CustomerID IS NULL 
         
		 RAISERROR('UpdateCustomer - Reuired parameter: @CustomerID', 16,1)


		  
 Begin 

	   Delete From Customer where CustomerID = @CustomerID

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('DeleteCustomer   - The Customer Can not be Deleted. Please try again : Customer table', 16,1) 

			end

			
			
	Return @ReturnCode
	
	----------------------------------------------------GetItem---------------------------
	EXECUTE GetItem l12847
	Create Procedure GetItem (
                              @ItemCode varchar(10) = null
                        
							
							 )
							 
As 

DECLARE @ReturnCode int 
set @ReturnCode = 1 

if @ItemCode IS NULL 
         
		 RAISERROR('GetItem - Reuired parameter: @ItemCode', 16,1)

 Begin 

	     select * from Item where ItemCode = @ItemCode

			If @@ERROR  = 0
		   
		    set @ReturnCode = 0 

			 else 

			RAISERROR ('GetItem   - The Item that you provide is not exsit . Please try again : Item table', 16,1) 

			end

			
			
	Return @ReturnCode

	-------------------------------------------------------------------------
	
	Insert into item(itemCode,[description],unitprice)
values('N22475','claw hammer',20,3)

INSERT INTO Sale(SaleNumber,saleDate,SalePerson,CustomerID,SubTotal,GST,SaleTotal)
VALUES ('10002',getDate(),'Janil','S54321',30,10,50);

insert into saleitem values (10001, 'N22475',1,20)


select ss.saleperson ,ss.SaleNumber,ss.saleDate, cc.customerName,cc.Addresses,cc.City,cc.province,cc.postalCode, ii.itemCode, ii.description, ii.unitprice, si.quantity, si.itemtotal,
,ss.saleTotal, ss.GST,
ss.GST * ii.unitprice as Total_GST, ss.saleTotal + (ss.GST * ss.saleTotal) as
Total_After_GST
from sale ss
inner join saleitem si on ss.saleNumber = si.saleNumber
inner join item ii on si.itemCode = ii.itemCode
inner join customer cc on ss.CustomerID = cc.CustomerID


Create USER aspnetcore FOR Login[BUILTIN\IIS_IUSER]

Grant EXECUTE ON AddItem To aspnetcore
Grant EXECUTE ON AddCustomer To aspnetcore
Grant EXECUTE ON AddToCart To aspnetcore
Grant EXECUTE ON DeleteCustomer To aspnetcore
Grant EXECUTE ON DeleteItem  To aspnetcore
Grant EXECUTE ON GetItem  To aspnetcore
Grant EXECUTE ON UpdateCustomer  To aspnetcore
Grant EXECUTE ON UpdateItem  To aspnetcore
