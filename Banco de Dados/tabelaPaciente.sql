USE [PRII16164]
GO

/****** Object:  Table [PRII16164].[pp3_Paciente]    Script Date: 17/08/2017 11:25:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [PRII16164].[pp3_Paciente](
	[idPaciente] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[endereco] [varchar](100) NOT NULL,
	[dataAniversario] [date] NOT NULL,
	[idade] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[telefone] [char](13) NOT NULL,
	[celular] [char](14) NOT NULL,
	[foto] [image] NOT NULL,
	[login] [varchar](20) NOT NULL,
	[senha] [varchar](30) NOT NULL,
 CONSTRAINT [PK_pp3_Paciente] PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

