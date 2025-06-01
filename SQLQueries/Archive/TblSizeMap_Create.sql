USE [AA_2023_2024]
GO

/****** Object:  Table [dbo].[tblSizeMap]    Script Date: 26-05-2024 03:18:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblSizeMap](
	[ParentSize] [varchar](10) NOT NULL,
	[ChildSize] [varchar](10) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

