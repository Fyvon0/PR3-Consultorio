USE [PRII16164]
GO

/****** Object:  Table [PRII16164].[pp3_Medico]    Script Date: 17/08/2017 11:25:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [PRII16164].[pp3_Medico](
	[idMedico] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[dataAniversario] [date] NOT NULL,
	[celular] [char](14) NOT NULL,
	[telefone] [char](13) NOT NULL,
	[idEspecialidade] [int] NOT NULL,
	[foto] [image] NOT NULL,
	[login] [varchar](20) NOT NULL,
	[senha] [varchar](30) NOT NULL,
 CONSTRAINT [PK_pp3_Medico] PRIMARY KEY CLUSTERED 
(
	[idMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [PRII16164].[pp3_Medico]  WITH CHECK ADD  CONSTRAINT [FK_pp3_Medico_pp3_Especialidade] FOREIGN KEY([especialidade])
REFERENCES [PRII16164].[pp3_Especialidade] ([idEspecialidade])
GO

ALTER TABLE [PRII16164].[pp3_Medico] CHECK CONSTRAINT [FK_pp3_Medico_pp3_Especialidade]
GO

