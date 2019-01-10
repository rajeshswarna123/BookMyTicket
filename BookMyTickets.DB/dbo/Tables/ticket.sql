CREATE TABLE [dbo].[ticket] (
    [ID]               INT  IDENTITY (1, 1) NOT NULL,
    [theater_movie_id] INT  NOT NULL,
    [date_of_booking]  DATE NOT NULL,
    [show_id]          INT  NOT NULL,
    [seat_cost]        INT  NOT NULL,
    [seats_count]      INT  NOT NULL,
    [total_amount]     INT  NOT NULL,
    CONSTRAINT [PK_ticket] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK__ticket__show_id__14270015] FOREIGN KEY ([show_id]) REFERENCES [dbo].[show] ([ID])
);

