USE [18ip14]
GO
/****** Object:  Table [dbo].[doljnosti]    Script Date: 21.02.2022 10:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doljnosti](
	[id_должности] [int] IDENTITY(1,1) NOT NULL,
	[должность] [nvarchar](100) NULL,
 CONSTRAINT [PK_doljnosti] PRIMARY KEY CLUSTERED 
(
	[id_должности] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[otzivi]    Script Date: 21.02.2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[otzivi](
	[id_отзыва] [int] IDENTITY(1,1) NOT NULL,
	[дата] [nvarchar](100) NULL,
	[состояние] [nvarchar](100) NULL,
	[id_заявителя] [int] NOT NULL,
 CONSTRAINT [PK_otzivi] PRIMARY KEY CLUSTERED 
(
	[id_отзыва] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rehennie_zayvleniy]    Script Date: 21.02.2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rehennie_zayvleniy](
	[Номер_закрытия_заявления] [int] IDENTITY(1,1) NOT NULL,
	[Дата] [nvarchar](100) NULL,
	[id_свойств] [int] NOT NULL,
	[id_отзыва] [int] NOT NULL,
 CONSTRAINT [PK_rehennie_zayvleniy] PRIMARY KEY CLUSTERED 
(
	[Номер_закрытия_заявления] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sotrudniki]    Script Date: 21.02.2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sotrudniki](
	[id_сотрудника] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия] [nvarchar](100) NULL,
	[Имя] [nvarchar](100) NULL,
	[Отчество] [nvarchar](100) NULL,
	[Логин] [nvarchar](100) NULL,
	[Пароль] [nvarchar](100) NULL,
	[Номер_телефона] [nvarchar](100) NULL,
	[id_должности] [int] NOT NULL,
 CONSTRAINT [PK_sotrudniki] PRIMARY KEY CLUSTERED 
(
	[id_сотрудника] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[svoistva_zayvleni]    Script Date: 21.02.2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[svoistva_zayvleni](
	[id_свойств] [int] IDENTITY(1,1) NOT NULL,
	[срок] [nvarchar](100) NULL,
	[id_сотрудник] [int] NOT NULL,
	[вид] [nvarchar](100) NULL,
	[статус] [nvarchar](100) NULL,
 CONSTRAINT [PK_svoistva_zayvleni] PRIMARY KEY CLUSTERED 
(
	[id_свойств] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zayvitel]    Script Date: 21.02.2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zayvitel](
	[id_заявителя] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия] [nvarchar](100) NULL,
	[Имя] [nvarchar](100) NULL,
	[Отчество] [nvarchar](100) NULL,
	[Номер_телефона] [nvarchar](100) NULL,
	[серия_паспорта] [nvarchar](100) NULL,
	[номер_паспорта] [nvarchar](100) NULL,
 CONSTRAINT [PK_zayvitel] PRIMARY KEY CLUSTERED 
(
	[id_заявителя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zayvleniy]    Script Date: 21.02.2022 10:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zayvleniy](
	[Номер_заявления] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](100) NULL,
	[id_свойств] [int] NOT NULL,
 CONSTRAINT [PK_Zayvleniy] PRIMARY KEY CLUSTERED 
(
	[Номер_заявления] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[otzivi]  WITH CHECK ADD  CONSTRAINT [FK_otzivi_zayvitel] FOREIGN KEY([id_заявителя])
REFERENCES [dbo].[zayvitel] ([id_заявителя])
GO
ALTER TABLE [dbo].[otzivi] CHECK CONSTRAINT [FK_otzivi_zayvitel]
GO
ALTER TABLE [dbo].[rehennie_zayvleniy]  WITH CHECK ADD  CONSTRAINT [FK_rehennie_zayvleniy_otzivi] FOREIGN KEY([id_отзыва])
REFERENCES [dbo].[otzivi] ([id_отзыва])
GO
ALTER TABLE [dbo].[rehennie_zayvleniy] CHECK CONSTRAINT [FK_rehennie_zayvleniy_otzivi]
GO
ALTER TABLE [dbo].[rehennie_zayvleniy]  WITH CHECK ADD  CONSTRAINT [FK_rehennie_zayvleniy_svoistva_zayvleni] FOREIGN KEY([id_свойств])
REFERENCES [dbo].[svoistva_zayvleni] ([id_свойств])
GO
ALTER TABLE [dbo].[rehennie_zayvleniy] CHECK CONSTRAINT [FK_rehennie_zayvleniy_svoistva_zayvleni]
GO
ALTER TABLE [dbo].[sotrudniki]  WITH CHECK ADD  CONSTRAINT [FK_sotrudniki_doljnosti] FOREIGN KEY([id_должности])
REFERENCES [dbo].[doljnosti] ([id_должности])
GO
ALTER TABLE [dbo].[sotrudniki] CHECK CONSTRAINT [FK_sotrudniki_doljnosti]
GO
ALTER TABLE [dbo].[svoistva_zayvleni]  WITH CHECK ADD  CONSTRAINT [FK_svoistva_zayvleni_sotrudniki] FOREIGN KEY([id_сотрудник])
REFERENCES [dbo].[sotrudniki] ([id_сотрудника])
GO
ALTER TABLE [dbo].[svoistva_zayvleni] CHECK CONSTRAINT [FK_svoistva_zayvleni_sotrudniki]
GO
ALTER TABLE [dbo].[Zayvleniy]  WITH CHECK ADD  CONSTRAINT [FK_Zayvleniy_svoistva_zayvleni] FOREIGN KEY([id_свойств])
REFERENCES [dbo].[svoistva_zayvleni] ([id_свойств])
GO
ALTER TABLE [dbo].[Zayvleniy] CHECK CONSTRAINT [FK_Zayvleniy_svoistva_zayvleni]
GO
