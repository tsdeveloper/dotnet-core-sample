WITH ClientesAtivos (ClienteId, ClienteUF, ValorParcela, ValorFinanaciamento, Percentual, ParcelId)
AS (
SELECT c.id, c.UF, p.ValorParcela, f.ValorTotal,
SUM((p.ValorParcela/f.valorTotal) * 100) AS Percentual,
p.Id ParcelId
  FROM Cliente c
 INNER JOIN Financiamento f 
	ON f.ClienteId = c.Id
INNER JOIN Parcela p
	ON p.FinanciamentoId = f.Id
	--WHERE  p.id = 229
	GROUP BY c.id,c.UF,p.ValorParcela, f.ValorTotal, p.id
	
	)

SELECT ClienteId, ClienteUF, ValorParcela,ValorFinanaciamento, CAST(Percentual AS DECIMAL(10,2)) FROM ClientesAtivos
WHERE Percentual > 60 AND ClienteUF = 'SP'

--UPDATE Parcela SET ValorParcela = 191
--FROM Parcela
--	WHERE Id BETWEEN 250 AND 260
	
--SELECT * FROM PArcela