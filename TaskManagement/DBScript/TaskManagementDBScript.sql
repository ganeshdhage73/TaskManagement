USE [master]
GO
/****** Object:  Database [TaskManagement]    Script Date: 18-04-2023 09:46:56 ******/
CREATE DATABASE [TaskManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TaskManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TaskManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TaskManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [TaskManagement] SET  MULTI_USER 
GO
ALTER DATABASE [TaskManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TaskManagement', N'ON'
GO
ALTER DATABASE [TaskManagement] SET QUERY_STORE = OFF
GO
USE [TaskManagement]
GO
/****** Object:  Table [dbo].[tblPriority]    Script Date: 18-04-2023 09:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPriority](
	[PriorityID] [int] IDENTITY(1,1) NOT NULL,
	[PriorityName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblPriority] PRIMARY KEY CLUSTERED 
(
	[PriorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStatus]    Script Date: 18-04-2023 09:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaskActivity]    Script Date: 18-04-2023 09:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaskActivity](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](50) NOT NULL,
	[Priority] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[AssignedTo] [int] NOT NULL,
	[TaskCreatedOn] [date] NOT NULL,
	[EstimatedTime] [int] NOT NULL,
	[ActualTime] [int] NULL,
 CONSTRAINT [PK_tblTaskActivity] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 18-04-2023 09:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTaskList]    Script Date: 18-04-2023 09:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetTaskList] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		t.TaskId
		,t.TaskName
		,p.PriorityID
		,p.PriorityName
		,s.StatusID
		,s.StatusName
		,u.UserID
		,u.UserName
		,t.TaskCreatedOn
		,t.EstimatedTime
		,t.ActualTime
	From tblTaskActivity t
	Join tblPriority p ON t.Priority = p.PriorityID
	Join tblStatus s ON t.Status = s.StatusID
	Join tblUser u ON t.AssignedTo =u.UserID
	ORDER By t.TaskName
END

GO
USE [master]
GO
ALTER DATABASE [TaskManagement] SET  READ_WRITE 
GO
