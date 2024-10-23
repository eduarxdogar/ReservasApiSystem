IF EXISTS (
   SELECT * FROM sys.procedures
   WHERE NAME = 'spReservation_UpdateRanking'
)
DROP PROCEDURE spReservation_UpdateRanking 
GO

CREATE PROCEDURE spReservation_UpdateRanking
	@id int,
	@rate int
AS
  BEGIN

  DECLARE @ranking float, @count int;

  SELECT @ranking=Ranking, @count=RatesCount 
  FROM Reservation WHERE Reservation.Id=@id;

  UPDATE Reservation SET 
  Reservation.Ranking = (@ranking*@count+@rate)/(@count+1), 
  Reservation.RatesCount= @count+1 
  WHERE Reservation.Id = @id;

  END
GO