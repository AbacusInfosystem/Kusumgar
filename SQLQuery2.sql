/*********************************************
	Author : Kaustubh 
   Date : 05052015
   Purpose : To Update Financial Details
*********************************************/

create procedure Update_Bank_Detials
(
@Bank_Details_Id INT,
@Supplier_Id INT,            
@Customer_Id INT,            
@Bank_Name NVARCHAR (50),  
@Bank_Account_No NVARCHAR (50),  
@Branch_Name NVARCHAR (50), 
@Ifsc_Code NVARCHAR (50),  
@Swift_Code NVARCHAR (50),  
@Rtgs_No NVARCHAR (50),  
@Bank_Address NVARCHAR (255),
@Bank_Code NVARCHAR (50),
@Account_Code NVARCHAR (50),
@Is_Active BIT,
@UpdatedBy INT
)
as
begin

	Update Bank_Details set

	Supplier_Id  = @Supplier_Id, 
	Customer_Id  = @Customer_Id, 
	Bank_Name  = @Bank_Name, 
	Bank_Account_No  = @Bank_Account_No,
	Branch_Name  = @Branch_Name,
	Ifsc_Code  = @Ifsc_Code,
	Swift_Code  = @Swift_Code,
	Rtgs_No  = @Rtgs_No,
	Bank_Address  = @Bank_Address,
	Bank_Code  = @Bank_Code,
	Account_Code  = @Account_Code,
	Is_Active  = @Is_Active,
	UpdatedBy  = @UpdatedBy

	where Bank_Details_Id = @Bank_Details_Id

end

