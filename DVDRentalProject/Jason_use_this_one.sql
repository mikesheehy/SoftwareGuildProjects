USE [master]
GO

/****** Object:  Database [DVDLibrary]    Script Date: 4/13/2016 10:55:33 AM ******/
CREATE DATABASE [DVDLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVDLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DVDLibrary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVDLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DVDLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [DVDLibrary] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DVDLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DVDLibrary] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DVDLibrary] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DVDLibrary] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DVDLibrary] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DVDLibrary] SET ARITHABORT OFF 
GO

ALTER DATABASE [DVDLibrary] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DVDLibrary] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DVDLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DVDLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DVDLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DVDLibrary] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DVDLibrary] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DVDLibrary] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DVDLibrary] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DVDLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DVDLibrary] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DVDLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DVDLibrary] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DVDLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DVDLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DVDLibrary] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [DVDLibrary] SET  MULTI_USER 
GO

ALTER DATABASE [DVDLibrary] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DVDLibrary] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DVDLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DVDLibrary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [DVDLibrary] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DVDLibrary] SET  READ_WRITE 
GO

USE [DVDLibrary]
GO


USE [DVDLibrary]
GO

/****** Object:  Table [dbo].[MovieList]    Script Date: 4/13/2016 10:57:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovieList](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[ReleaseDate] [date] NULL,
	[MPAARating] [varchar](5) NULL,
	[DirectorName] [varchar](50) NULL,
	[Studio] [varchar](50) NULL,
	[UserRating] [int] NULL,
	[UserNote] [varchar](max) NULL,
 CONSTRAINT [PK_MovieList] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

Insert Into MovieList (Title, ReleaseDate, MPAARating, DirectorName, Studio, UserRating, UserNote)
 Values ('Invasion of the Body Snatchers', '12/20/1978', 'PG', 'Philip Kaufman', 'MGM', '7', 'Sci Fi'),
 ('The Fly', '8/15/1986', 'R', 'David Cronenberg', '20th Century Fox', '7', 'Horror'),
 ('Jurassic Park', '6/11/1993', 'PG-13', 'Steven Spielberg', 'Universal', '8', 'Adventure'),
 ('Independence Day', '7/3/1996', 'PG-13', 'Roland Emmerich', '20th Century Fox', '7', 'Action'),
 ('The Life Aquatic with Steve Zissou', '12/25/2004', 'R', 'Wes Anderson', 'Touchstone Pictures', '7', 'Adventure'),
 ('The Grand Budapest Hotel', '3/28/2014', 'R', 'Wes Anderson', 'Fox Seachlight', '8', 'Adventure')

 USE [DVDLibrary]
GO

/****** Object:  Table [dbo].[Borrow]    Script Date: 4/13/2016 10:58:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Borrow](
	[BorrowID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[DateBorrowed] [date] NULL,
	[DateReturned] [date] NULL,
	[Rating] [int] NULL,
	[BorrowName] [varchar](50) NULL,
 CONSTRAINT [PK_Borrow] PRIMARY KEY CLUSTERED 
(
	[BorrowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Borrow]  WITH CHECK ADD  CONSTRAINT [FK_Borrow_MovieList] FOREIGN KEY([MovieID])
REFERENCES [dbo].[MovieList] ([MovieID])
GO

ALTER TABLE [dbo].[Borrow] CHECK CONSTRAINT [FK_Borrow_MovieList]
GO

Insert Into Borrow (MovieID, DateBorrowed, DateReturned, Rating, BorrowName)
Values(4, '1/1/2016', '1/3/2016', 10, 'Chuck Norris'),(3, '3/10/2016', '3/12/2016', 7, 'Jackie Chan'),
(1, '2/1/2016', '2/3/2016', 1, 'Kanye West'),(5, '1/31/2016', null, null, 'Jared Fogle'), 
(6, '1/6/2016', null, null, 'Bill Cosby'), (4, '2/2/2016', '2/23/2016', 4, 'Gordon Ramsey'), 
(6, '1/14/2016','1/17/2016', 10, 'Wes Anderson')


/****** Object:  Table [dbo].[Actors]    Script Date: 4/13/2016 10:55:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Actors](
	[ActorID] [int] IDENTITY(1,1) NOT NULL,
	[ActorName] [varchar](50) NULL,
	[MovieID] [int] NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Actors]  WITH CHECK ADD  CONSTRAINT [FK_Actors_MovieList] FOREIGN KEY([MovieID])
REFERENCES [dbo].[MovieList] ([MovieID])
GO

ALTER TABLE [dbo].[Actors] CHECK CONSTRAINT [FK_Actors_MovieList]
GO

Insert Into Actors (ActorName, MovieID)
 Values('Jeff Goldblum', 1),('Will Smith', 4),('Jeff Goldblum', 2),('Bill Murray', 5),('Jeff Goldblum', 3),
 ('Geena Davis', 2),('Jeff Goldblum', 4),('Sam Neill', 3),('Jeff Goldblum', 5),('Jeff Goldblum', 6),
 ('Bill Murray', 6),('Jeff Goldblum', 6)


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[addmovierow]    Script Date: 4/13/2016 11:01:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[addmovierow]
(
	   @Title varchar(50),
	   @ReleaseDate date,
	   @MPAARating varchar(50),
	   @DirectorName varchar(50),
	   @Studio varchar(50),
	   @UserRating int,
	   @UserNote varchar(max)
)AS 

INSERT INTO MovieList
( 
	   Title,
	   ReleaseDate,
	   MPAARating,
	   DirectorName,
	   Studio,
	   UserRating,
	   UserNote
)
VALUES
(
	   @Title,
	   @ReleaseDate,
	   @MPAARating,
	   @DirectorName,
	   @Studio,
	   @UserRating,
	   @UserNote
)


GO


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[allmovieborrowhistory]    Script Date: 4/13/2016 11:03:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[allmovieborrowhistory]
as
SELECT *
From Borrow
LEFT JOIN MovieList
ON Borrow.MovieID=MovieList.MovieID;

GO


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[deletemovierow]    Script Date: 4/13/2016 11:03:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deletemovierow]
(
@MovieID int
)
AS

DELETE FROM Actors
WHERE MovieId = @MovieID

DELETE FROM Borrow
WHERE MovieId = @MovieID

DELETE FROM MovieList
WHERE MovieId = @MovieID


GO


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[getmovieactors]    Script Date: 4/13/2016 11:04:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getmovieactors]
(
	@ActorID int
) AS

select *
from MovieList
where ActorID = @ActorID

select *
from ActorList
where ActorID = @ActorID


GO


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[moviedetails]    Script Date: 4/13/2016 11:04:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[moviedetails]
(
	@MovieID int
)AS

SELECT *
FROM MovieList
Where MovieID = @MovieID

SELECT *
From Borrow
LEFT JOIN MovieList
ON Borrow.MovieID=MovieList.MovieID;




GO


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[searchbytitle]    Script Date: 4/13/2016 11:05:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[searchbytitle]
(
	@Title varchar(50)
)AS

SELECT *
FROM MovieList
WHERE Title LIKE @Title

GO


USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[viewcheckedout]    Script Date: 4/13/2016 11:05:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[viewcheckedout]
(
	@MovieID int
)AS

SELECT *
FROM Borrow
WHERE MovieID=@MovieID
AND DateReturned is NULL

GO





