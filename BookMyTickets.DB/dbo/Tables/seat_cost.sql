CREATE TABLE [dbo].[seat_cost] (
    [ID]           INT IDENTITY (1, 1) NOT NULL,
    [theater_id]   INT NOT NULL,
    [price]        INT NOT NULL,
    [seats_in_row] INT NOT NULL,
    [total_rows]   INT NOT NULL,
    CONSTRAINT [PK_seat_cost] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK__seat_cost__theat__06CD04F7] FOREIGN KEY ([theater_id]) REFERENCES [dbo].[theater] ([ID])
);

