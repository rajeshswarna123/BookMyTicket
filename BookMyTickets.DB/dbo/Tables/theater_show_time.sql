CREATE TABLE [dbo].[theater_show_time] (
    [ID]               INT  IDENTITY (1, 1) NOT NULL,
    [theater_movie_id] INT  NOT NULL,
    [show_id]          INT  NOT NULL,
    [start_date]       DATE NOT NULL,
    [end_date]         DATE NOT NULL,
    CONSTRAINT [PK_theater_show_time] PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([theater_movie_id]) REFERENCES [dbo].[theater_movie] ([ID]),
    CONSTRAINT [FK__theater_s__show___17F790F9] FOREIGN KEY ([show_id]) REFERENCES [dbo].[show] ([ID])
);

