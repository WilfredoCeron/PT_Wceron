
--Eliminar la base de datos si ya existe
IF EXISTS(SELECT * FROM sys.databases WHERE name='ScoreCard')
BEGIN
    DROP DATABASE ScoreCard;
END
GO
---Creación la base de datos
CREATE DATABASE ScoreCard;
GO
USE ScoreCard;
GO
--Eliminar la tabla Parameters si ya existe
IF OBJECT_ID('Parameters', 'U') IS NOT NULL
BEGIN
    DROP TABLE Parameter;
END

GO
--- Creación la tabla Parameters ---
CREATE TABLE Parameter(
    IdParameter INT IDENTITY(1,1) PRIMARY KEY,
    NameParameter VARCHAR(200),
    ValueParameter VARCHAR(10),
    TypeParameter VARCHAR(50)
);
GO

--Eliminar la tabla Card si ya existe
IF OBJECT_ID('Card', 'U') IS NOT NULL
BEGIN
    DROP TABLE Card;
END
GO
--- Creación la tabla Card ---
CREATE TABLE Cards(
    CardNumber VARCHAR(16) PRIMARY KEY,
    AssociatedName VARCHAR(300),
    DateExpiration VARCHAR(7),
	Cvv INT,
    Limit MONEY,
    SaldoActual MONEY,
    SaldoDisponible MONEY,
    FechadeCorte DATE,
	CuotaMinimaPagar Money,
	MontoTotalContado Money,
	InteresConfigurableMinimo Money,
	InteresConfigurable Money,
	InteresBonificable Money
);
GO
--Eliminar la tabla CardBuy si ya existe
IF OBJECT_ID('CardBuy', 'U') IS NOT NULL
BEGIN
    DROP TABLE CardBuy;
END
GO
--- Creación la tabla CardBuy ---
CREATE TABLE CardBuy(
    IdBuy INT IDENTITY(1,1) PRIMARY KEY,
    CardNumber VARCHAR(16),
    DateBuy DATE,
    MonthT INT,
    YearT INT,
    DescriptionT VARCHAR(300),
    Amount MONEY,
    FOREIGN KEY (CardNumber) REFERENCES Cards(CardNumber)
);
GO
--- Eliminar la tabla CardPayment si ya existe ---
IF OBJECT_ID('CardPayment', 'U') IS NOT NULL
BEGIN
    DROP TABLE CardPayment;
END
GO
--- Creación la tabla PAGOSTARJETA ---
CREATE TABLE CardPayment(
    IdPayment INT IDENTITY(1,1) PRIMARY KEY,
    CardNumber VARCHAR(16),
    DatePayment DATE,
    MonthT INT,
    YearT INT,
    DescriptionT VARCHAR(200),
    Amount MONEY,
    FOREIGN KEY (CardNumber) REFERENCES Cards(CardNumber)
);
GO
---------------------------------------------------------------
--- CREACIÓN DE PROCEDIMIENTOS ALMACENADOS PARA LAS TABLAS  ---
---------------------------------------------------------------

--- CONSULTA DE HISTORIAL DE TRANSACCIONES ---
CREATE OR ALTER PROCEDURE sp_GetHistoryCard
    @CardNumber VARCHAR(16),
    @MonthT INT,
    @YearT INT
AS
BEGIN
    SELECT 
        IdPayment, CardNumber, DatePayment, MonthT, YearT, DescriptionT, Amount, 'P' AS TypeTransaction
    FROM 
        CardPayment
    WHERE 
        CardNumber = @CardNumber AND MonthT = @MonthT AND YearT = @YearT
    UNION
    SELECT 
        IdBuy, CardNumber, DateBuy, MonthT, YearT, DescriptionT, Amount, 'C' AS TypeTransaction
    FROM 
        CardBuy
    WHERE 
        CardNumber = @CardNumber AND MonthT = @MonthT AND YearT = @YearT
    ORDER BY 
        DatePayment DESC;
END;
GO
-- EXEC sp_GetHistoryCard '6164892848967402', 10, 2025;
--------------------------------------------------------------------------

--- CONSULTA EL HISTORIAL DE COMPRAS ---

CREATE OR ALTER PROCEDURE sp_GetHistoryBuy
    @CardNumber VARCHAR(16),
    @MonthT INT,
    @YearT INT
AS
BEGIN
	SELECT 
        IdBuy, CardNumber, DateBuy, MonthT, YearT, DescriptionT, Amount, 'C' AS TypeTransaction
    FROM 
        CardBuy
    WHERE 
        CardNumber = @CardNumber AND MonthT = @MonthT AND YearT = @YearT
    ORDER BY 
        DateBuy DESC;
END;
GO
--EXEC sp_GetHistoryBuy '6164892848967402', 10, 2025;

--------------------------------------------------------------------------

--- CONSULTA EL HISTORIAL DE PAGOS ---

CREATE OR ALTER PROCEDURE sp_GetHistoryPayment
    @CardNumber VARCHAR(16),
    @MonthT INT,
    @YearT INT
AS
BEGIN
	 SELECT 
		IdPayment, CardNumber, DatePayment, MonthT, YearT, DescriptionT, Amount, 'P' AS TypeTransaction
    FROM 
        CardPayment
    WHERE 
        CardNumber = @CardNumber AND MonthT = @MonthT AND YearT = @YearT
    ORDER BY 
        DatePayment DESC;
END;
GO
--EXEC sp_GetHistoryPayment '6164892848967402', 10, 2025;

--------------------------------------------------------------------------

--- CONSULTA LA INFORMACION DE LA TARJETA ---

CREATE OR ALTER PROCEDURE sp_GetDataCard
    @CardNumber VARCHAR(16)
AS
BEGIN
    DECLARE @InteresConfigurableMinimo DECIMAL(5, 2);
    DECLARE @InteresConfigurable DECIMAL(5, 2);
    SELECT @InteresConfigurableMinimo = CAST(ValueParameter AS DECIMAL(5, 2))
    FROM Parameter
    WHERE NameParameter = 'MIN INTERES CONF';
    SELECT @InteresConfigurable = CAST(ValueParameter AS DECIMAL(5, 2)) / 100
    FROM Parameter
    WHERE NameParameter = 'INTERES CONF';
    SELECT 
        c.CardNumber, c.AssociatedName, c.DateExpiration, c.Cvv, c.Limit, c.SaldoActual, c.SaldoDisponible, c.FechadeCorte,
        @InteresConfigurableMinimo AS InteresConfigurableMinimo, -- Interés configurable mínimo
        @InteresConfigurable AS InteresConfigurable, -- Interés configurable
        (c.SaldoActual * @InteresConfigurable) AS InteresBonificable, -- Interés bonificable
        (c.SaldoActual * @InteresConfigurableMinimo) AS CuotaMinimaPagar, -- Cuota mínima a pagar
        (c.SaldoActual + (c.SaldoActual * @InteresConfigurable)) AS MontoTotalContado -- Monto total de contado con intereses
    FROM Cards c
    WHERE c.CardNumber = @CardNumber;
END;
GO

-- EXEC sp_ObtenerDatosTarjeta '6164892848967402'

--------------------------------------------------------------------------

--- CREACIÓN DE UN NUEVO PAGO ---

CREATE OR ALTER PROCEDURE sp_CreatePayment
    @CardNumber VARCHAR(16),
    @DatePayment DATE,
    @DescriptionT VARCHAR(200),
    @Amount MONEY
AS
BEGIN
    DECLARE @saldoActual MONEY;
    DECLARE @saldoDisponible MONEY;

    BEGIN TRANSACTION;

    SELECT @saldoActual = saldoActual, @saldoDisponible = saldoDisponible
    FROM Cards
    WHERE CardNumber = @CardNumber;

    IF @saldoActual < @Amount
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR ('El monto del pago excede el saldo actual.', 16, 1);
        RETURN;
    END

    UPDATE Cards
    SET SaldoDisponible = SaldoDisponible + @Amount, saldoActual = saldoActual - @Amount
    WHERE CardNumber = @CardNumber;

    INSERT INTO CardPayment (CardNumber, DatePayment, MonthT, YearT, DescriptionT, Amount)
    VALUES (
        @CardNumber, @DatePayment, MONTH(@DatePayment), YEAR(@DatePayment), @DescriptionT, @Amount
    );
    COMMIT TRANSACTION;
END;
GO
-- EXEC sp_CreatePayment '6164892848967402', '2025-10-05', 'Pago de tarjeta', 100;
--------------------------------------------------------------------------

--- CREACIÓN DE UNA NUEVA COMPRA --- 

CREATE OR ALTER PROCEDURE sp_CreateBuy
    @CardNumber VARCHAR(16),
    @DateBuy DATE,
    @DescriptionT VARCHAR(300),
    @Amount MONEY
AS
BEGIN
    DECLARE @saldoActual MONEY;
    DECLARE @saldoDisponible MONEY;

    BEGIN TRANSACTION;

    SELECT @saldoActual = saldoActual, @saldoDisponible = saldoDisponible
    FROM Cards
    WHERE CardNumber = @CardNumber;

    IF @Amount > @saldoDisponible
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR ('El monto de la compra excede el saldo disponible.', 16, 1);
        RETURN;
    END

    UPDATE Cards
    SET
        saldoDisponible = saldoDisponible - @Amount, saldoActual = saldoActual + @Amount
    WHERE CardNumber = @CardNumber;

    INSERT INTO CardBuy (CardNumber, DateBuy,  MonthT, YearT, DescriptionT, Amount)
    VALUES (
        @CardNumber, @DateBuy, MONTH(@DateBuy), YEAR(@DateBuy), @DescriptionT, @Amount
    );

    COMMIT TRANSACTION;
END;
GO

---------------------------------------------------------------
---      INSERSIÓN DE DATOS NECESARIOS PARA LAS TABLAS      ---
---------------------------------------------------------------
INSERT INTO Parameter VALUES( 'MIN INTERES CONF', '2', 'PORCENTAJE');
INSERT INTO Parameter VALUES( 'INTERES CONF', '25', 'PORCENTAJE');

INSERT INTO Cards 
(CardNumber, AssociatedName, DateExpiration, Cvv, Limit, SaldoActual, SaldoDisponible, FechadeCorte)
VALUES 
('6164892848967402', 'ALEXIS BARAHONA', '10/2027', 545, 2500, 1500, 400, '2024-09-14');

INSERT INTO CardBuy(CardNumber, DateBuy, MonthT, YearT, DescriptionT, Amount)
VALUES 
('6164892848967402', '2024-09-05', 10, 2025, 'compra de Maquillaje', 110.00),
('6164892848967402', '2024-09-12', 10, 2025, 'Compra en Wallmart', 300.76),
('6164892848967402', '2024-09-20', 10, 2025, 'Compra de Telefono', 650.00);


INSERT INTO CardPayment(CardNumber, DatePayment, MonthT, YearT, DescriptionT, Amount)
VALUES 
('6164892848967402', '2024-09-07', 10, 2025, 'Pago parcial de tarjeta', 185.00),
('6164892848967402', '2024-09-15', 10, 2025, 'Pago total de tarjeta', 500.00),
('6164892848967402', '2024-09-22', 10, 2025, 'Pago de intereses', 50.00);
