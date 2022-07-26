SELECT c.id, c.UF, c.Nome, p.Id ParcelaId
FROM Cliente c
 INNER JOIN Financiamento f 
	ON f.ClienteId = c.Id
INNER JOIN Parcela p
	ON p.FinanciamentoId = f.Id
	WHERE DataUltimoVencimento > GETDATE() AND  p.DataPagamento IS NULL 


	ON f.id = p.FinanciamentoId
	WHERE p.id = 201


