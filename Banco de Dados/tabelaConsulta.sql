USE [PRII16164]
GO

/****** Object:  Table [PRII16164].[pp3_Consulta]    Script Date: 17/08/2017 11:25:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [PRII16164].[pp3_Consulta](
	[idConsulta] [int] IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL,
	[inicio] [time](4) NOT NULL,
	[duracao] [time](4) NOT NULL,
	[idPaciente] [int] NOT NULL,
	[idMedico] [int] NOT NULL,
	[status] [varchar](13) NOT NULL,
 CONSTRAINT [PK_pp3_Consulta] PRIMARY KEY CLUSTERED 
(
	[idConsulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [PRII16164].[pp3_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_pp3_Consulta_pp3_Medico] FOREIGN KEY([idMedico])
REFERENCES [PRII16164].[pp3_Medico] ([idMedico])
GO

ALTER TABLE [PRII16164].[pp3_Consulta] CHECK CONSTRAINT [FK_pp3_Consulta_pp3_Medico]
GO

ALTER TABLE [PRII16164].[pp3_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_pp3_Consulta_pp3_Paciente] FOREIGN KEY([idPaciente])
REFERENCES [PRII16164].[pp3_Paciente] ([idPaciente])
GO

ALTER TABLE [PRII16164].[pp3_Consulta] CHECK CONSTRAINT [FK_pp3_Consulta_pp3_Paciente]
GO

