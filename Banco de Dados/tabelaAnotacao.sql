USE [PRII16164]
GO

/****** Object:  Table [PRII16164].[pp3_Anotacao]    Script Date: 17/08/2017 11:24:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [PRII16164].[pp3_Anotacao](
	[idAnotacao] [int] IDENTITY(1,1) NOT NULL,
	[idConsulta] [int] NOT NULL,
	[diagnostico] [text] NOT NULL,
	[exames] [text] NULL,
	[medicacao] [text] NULL,
 CONSTRAINT [PK_pp3_Anotacao] PRIMARY KEY CLUSTERED 
(
	[idAnotacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [PRII16164].[pp3_Anotacao]  WITH CHECK ADD  CONSTRAINT [FK_pp3_Anotacao_pp3_Consulta] FOREIGN KEY([idConsulta])
REFERENCES [PRII16164].[pp3_Consulta] ([idConsulta])
GO

ALTER TABLE [PRII16164].[pp3_Anotacao] CHECK CONSTRAINT [FK_pp3_Anotacao_pp3_Consulta]
GO

