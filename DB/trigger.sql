-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Thien Phu
-- Create date: 9.11.2021
-- Description:	Trigger  for good's quantity
-- =============================================
CREATE OR ALTER TRIGGER updateGoodQty 
   ON  order_details	
   after INSERT AS
   DECLARE
    @totalQty INT;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @totalQty = 
		(select g.quantity
		from goods g
		inner join inserted
		on g.id = inserted.good_id);

	IF (select od.quantity
		from order_details od
		inner join inserted
		on od.id = inserted.id)
		>
		@totalQty
		BEGIN
			RAISERROR(N'Số lượng nhập đã vượt quá tổng lượng hàng, tổng lượng hàng: %i',16,1,@totalQty);
			--Print N'Số lượng nhập đã vượt quá tổng lượng hàng, tổng lượng hàng: ' + CAST(@totalQty as varchar)
			Rollback Tran;
		END
	ELSE
		UPDATE goods
		SET goods.quantity = goods.quantity - (
			SELECT quantity
			FROM inserted
			WHERE good_id = goods.id
		)
		FROM goods
		JOIN inserted ON goods.id = inserted.good_id
	
END
GO

CREATE OR ALTER TRIGGER updateGoodQty2 
	on order_details 
	after update AS
	DECLARE
		@totalQty INT;
BEGIN
	SET NOCOUNT ON;

	SET @totalQty = 
		(select 
		g.quantity
		from goods g
		join deleted
		on g.id = deleted.good_id);

	IF	@totalQty
		-
		(SELECT i.quantity 
		FROM inserted i
		inner join goods g
		on i.good_id = g.id)
		+
		(SELECT d.quantity 
		FROM deleted d
		inner join goods g
		on d.good_id = g.id)
		< 0
		BEGIN
			RAISERROR(N'Số lượng thay đổi đã vượt quá tổng lượng hàng, tổng lượng hàng: %i',16,1,@totalQty);
			Rollback Tran;
		END
	ELSE
		UPDATE goods SET goods.quantity = goods.quantity -
			(SELECT quantity FROM inserted WHERE inserted.good_id = goods.id) +
			(SELECT quantity FROM deleted WHERE deleted.good_id = good_id)
		FROM goods 
		JOIN deleted ON goods.id = deleted.good_id
end
GO


create OR ALTER TRIGGER updateGoodQty3 
	ON order_details 
	FOR DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	UPDATE goods
	SET goods.quantity = goods.quantity + 
		(SELECT quantity FROM deleted WHERE good_id = goods.id)
	FROM goods 
	JOIN deleted ON goods.id = deleted.good_id
END