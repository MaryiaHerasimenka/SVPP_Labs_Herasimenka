CREATE TABLE [dbo].[Tracks]
(
	[TrackID] INT IDENTITY(1,1) PRIMARY KEY,
    [TrackTitle] VARCHAR(100) NOT NULL, 
    [ArtistName] VARCHAR(100) NULL, 
    [TrackDuration] TIME NOT NULL, 
    [AlbumTitle] VARCHAR(100) NULL
)
