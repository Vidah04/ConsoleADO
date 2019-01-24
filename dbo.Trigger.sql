CREATE TRIGGER Kurangistok
	ON [dbo].[TransactionItems]
	FOR INSERT
	AS
	BEGIN
	UPDATE i set i.Stock = i.Stock - t.quantity
	FROM Item i join inserted t on
	i.id=t.items_id;
	END
