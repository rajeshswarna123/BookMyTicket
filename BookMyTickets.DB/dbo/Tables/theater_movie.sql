CREATE TABLE [dbo].[theater_movie] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [theater_id] INT NOT NULL,
    [movie_id]   INT NOT NULL,
    [isLive]     BIT NOT NULL,
    CONSTRAINT [PK_theater_movie] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK__theater_m__movie__01142BA1] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([ID]),
    CONSTRAINT [FK__theater_m__theat__00200768] FOREIGN KEY ([theater_id]) REFERENCES [dbo].[theater] ([ID])
);

