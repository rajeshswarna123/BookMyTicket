CREATE TABLE [dbo].[seat_reservation] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [seat_number] VARCHAR (50) NOT NULL,
    [ticket_id]   INT          NOT NULL,
    CONSTRAINT [PK_seat_reservation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK__seat_rese__ticke__236943A5] FOREIGN KEY ([ticket_id]) REFERENCES [dbo].[ticket] ([ID])
);

