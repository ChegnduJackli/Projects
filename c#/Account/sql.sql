USE [Account]
GO

/****** Object:  Table [dbo].[AccountInfo]    Script Date: 05/06/2014 14:05:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AccountInfo](
	[UserName] [varchar](100) NOT NULL,
	[Amount] [decimal](18, 0) NULL,
	[Description] [varchar](100) NULL,
	[AddTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


