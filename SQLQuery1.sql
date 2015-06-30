select c.*, n.NationName as Nation_Name from Customer c
	 left outer join M_Nation n on n.NationId = c.Head_Office_Nation
	 where Customer_Id = 13 