-- Run these commands in your query editor to create table and enable tracking

CREATE TABLE [dbo].[wikipedia_weather_articles]
(
	[id] [int] IDENTITY(1,1) PRIMARY KEY,  
	[url] [varchar](1000),
	[title] [varchar](1000) NOT NULL,
	[description] [varchar](max)
)


ALTER DATABASE [YOUR-DATABASE-NAME] -- Replace YOUR-DATABASE-NAME with the name of your database
SET CHANGE_TRACKING = ON
(CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON);

ALTER TABLE [dbo].[wikipedia_weather_articles]
ENABLE CHANGE_TRACKING;
