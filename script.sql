USE [dbFinancial]
GO
/****** Object:  Table [dbo].[tbCategory]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCategory](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[strName] [varchar](50) NULL,
	[iniValue] [decimal](18, 3) NULL,
	[finValue] [decimal](18, 3) NULL,
 CONSTRAINT [PK_tbCategory] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbFinancialInstrument]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbFinancialInstrument](
	[idFinancialInstrument] [int] IDENTITY(1,1) NOT NULL,
	[vlMarketValue] [decimal](18, 3) NOT NULL,
	[strName] [varchar](100) NOT NULL,
	[intType] [int] NULL,
	[dtInsert] [datetime] NOT NULL,
	[dtUpdate] [datetime] NULL,
 CONSTRAINT [PK_tbFinancialInstrument] PRIMARY KEY CLUSTERED 
(
	[idFinancialInstrument] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[prDeleteCategory]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE  [dbo].[prDeleteCategory] @idCategory int 
AS
SET NOCOUNT ON
BEGIN
DELETE FROM tbCategory WHERE idCategory = @idCategory
END
GO
/****** Object:  StoredProcedure [dbo].[prDeleteFinancialInstrument]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE  [dbo].[prDeleteFinancialInstrument] @idFinancialInstrument int 
AS
SET NOCOUNT ON
BEGIN
DELETE FROM tbFinancialInstrument WHERE idFinancialInstrument = @idFinancialInstrument
END
GO
/****** Object:  StoredProcedure [dbo].[prFindAllCategory]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[prFindAllCategory]
AS
SET NOCOUNT ON
BEGIN

	SELECT 
		ct.idCategory,
		ct.strName,
		ct.iniValue,
		ct.finValue
	FROM
		tbCategory ct 
	ORDER BY
		ct.idCategory 

END
GO
/****** Object:  StoredProcedure [dbo].[prFindAllFinnancialInstrument]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[prFindAllFinnancialInstrument]
AS
SET NOCOUNT ON
BEGIN

	SELECT 
		fi.idFinancialInstrument,
		fi.vlMarketValue,
		fi.strName,
		fi.intType,
		fi.dtInsert,
		fi.dtUpdate
	FROM
		tbFinancialInstrument fi 
	ORDER BY
		fi.idFinancialInstrument

END
GO
/****** Object:  StoredProcedure [dbo].[prFindByIdCategory]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[prFindByIdCategory] @idCategory INT
AS
SET NOCOUNT ON
BEGIN

	SELECT 
		ct.idCategory,
		ct.strName,
		ct.iniValue,
		ct.finValue
	FROM
		tbCategory ct 
	WHERE
		ct.idCategory = @idCategory

END
GO
/****** Object:  StoredProcedure [dbo].[prFindByIdFinnancialInstrument]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[prFindByIdFinnancialInstrument] @idFinancialInstrument INT
AS
SET NOCOUNT ON
BEGIN

	SELECT 
		fi.idFinancialInstrument,
		fi.vlMarketValue,
		fi.strName,
		fi.intType,
		fi.dtInsert,
		fi.dtUpdate
	FROM
		tbFinancialInstrument fi 
	WHERE
		fi.idFinancialInstrument = @idFinancialInstrument

END
GO
/****** Object:  StoredProcedure [dbo].[prFindByMarketValue]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[prFindByMarketValue] @MarketValue decimal(18,3)
AS
SET NOCOUNT ON
BEGIN

	SELECT 
		ct.idCategory,
		ct.strName,
		ct.iniValue,
		ct.finValue
	FROM
		tbCategory ct 
	WHERE
		@MarketValue  BETWEEN ct.iniValue AND ct.finValue

END
GO
/****** Object:  StoredProcedure [dbo].[prFindByRange]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[prFindByRange] @idCategory int, @iniValue decimal(18,3),@finValue decimal(18,3)
AS
SET NOCOUNT ON
BEGIN

	SELECT 
		ct.idCategory,
		ct.strName,
		ct.iniValue,
		ct.finValue
	FROM
		tbCategory ct 
	WHERE
		@iniValue <= ct.finValue AND
        @finValue >= ct.iniValue AND
		idCategory <> @idCategory

END
GO
/****** Object:  StoredProcedure [dbo].[prInsertCategory]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE  [dbo].[prInsertCategory] @StrName NVARCHAR(50),@iniValue DECIMAL(18,3), @finValue DECIMAL (18,3)

AS
SET NOCOUNT ON
BEGIN
INSERT INTO tbCategory
					 (strName,iniValue, finValue) 
	VALUES 
					 (@StrName,@iniValue, @finValue)
END
GO
/****** Object:  StoredProcedure [dbo].[prInsertFinancialInstrument]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE  [dbo].[prInsertFinancialInstrument] @vlMarketvalue Decimal(18,3),@StrName NVARCHAR(100), @intType INT

AS
SET NOCOUNT ON
BEGIN
INSERT INTO tbFinancialInstrument
					 (vlMarketValue,strName,intType,dtInsert,dtUpdate) 
	VALUES 
					 (@vlMarketvalue,@StrName,@intType,getDate(),getDate())
END
GO
/****** Object:  StoredProcedure [dbo].[prUpdateCategory]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE  [dbo].[prUpdateCategory] @idCategory int ,@StrName NVARCHAR(50),@iniValue DECIMAL(18,3), @finValue DECIMAL (18,3)

AS
SET NOCOUNT ON
BEGIN
UPDATE  tbCategory SET strName=@StrName,iniValue = @iniValue, finValue=@finValue
WHERE idCategory = @idCategory
END
GO
/****** Object:  StoredProcedure [dbo].[prUpdateFinancialInstrument]    Script Date: 18/03/2024 02:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE  [dbo].[prUpdateFinancialInstrument] @idFinancialInstrument int ,@vlMarketvalue Decimal(18,3),@StrName NVARCHAR(100),@intType int

AS
SET NOCOUNT ON
BEGIN
UPDATE  tbFinancialInstrument SET vlMarketValue=@vlMarketvalue,strName=@StrName,intType=@intType,dtInsert=getDate(),dtUpdate= getDate()
WHERE idFinancialInstrument = @idFinancialInstrument
END
GO
