CREATE TABLE [dbo].[Tracks] (
    [TrackID]       INT           IDENTITY (1, 1) NOT NULL,
    [TrackTitle]    NVARCHAR(100) NOT NULL,
    [ArtistName]    NVARCHAR(100) NULL,
    [TrackDuration] TIMESTAMP      NOT NULL,
    [AlbumTitle]    NVARCHAR(100) NULL,
    PRIMARY KEY CLUSTERED ([TrackID] ASC)
);

