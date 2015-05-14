CREATE TABLE [dbo].[Customer_Addresss] (
    [Customer_Address_Id] INT            IDENTITY (1, 1) NOT NULL,
    [Customer_Id]          INT            NOT NULL,
    [Address_Type]        INT            NOT NULL,
    [Addresss]            NVARCHAR (255) NOT NULL,
    [Landline1]           NVARCHAR (20)  NULL,
    [landline2]           NVARCHAR (20)  NULL,
    [FaxNo]               NVARCHAR (15)  NULL,
    [Is_Active]           BIT            DEFAULT ((1)) NOT NULL,
    [CreatedOn]           DATETIME       NOT NULL,
    [CreatedBy]           INT            NOT NULL,
    [UpdatedOn]           DATETIME       NOT NULL,
    [UpdatedBy]           INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Customer_Address_Id] ASC)
);

