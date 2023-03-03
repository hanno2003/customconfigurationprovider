# customconfigurationprovider
A Custom Configuration Provider using a SQL Database with Entity Framework


# Setup Database to run as docker on Macbook M2
```
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

# Database Model
```
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestConfig](
	[key] [varchar](50) NOT NULL,
	[label] [char](10) NOT NULL,
	[value] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[TestConfig] ADD  CONSTRAINT [PK_TestConfig] PRIMARY KEY CLUSTERED 
(
	[key] ASC,
	[label] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

```
