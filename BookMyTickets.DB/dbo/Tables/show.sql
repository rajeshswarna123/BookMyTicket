CREATE TABLE [dbo].[show] (
    [ID]        INT      IDENTITY (1, 1) NOT NULL,
    [show_time] DATETIME NOT NULL,
    CONSTRAINT [PK_show] PRIMARY KEY CLUSTERED ([ID] ASC)
);

