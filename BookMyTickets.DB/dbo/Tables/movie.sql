CREATE TABLE [dbo].[movie] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [Title]            VARCHAR (MAX) NOT NULL,
    [Language]         VARCHAR (50)  NOT NULL,
    [Duration_Minutes] INT           NOT NULL,
    CONSTRAINT [PK_movie] PRIMARY KEY CLUSTERED ([ID] ASC)
);

