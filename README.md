# Prueba Tecnica TDC 🚀

![Version](https://img.shields.io/badge/version-1.0.0-blue)

## Descripción 📝
El proyecto consiste en una REST API que interactúa con una base de datos SQL Server.

Requisitos Técnicos
**REST API**: Implementada con ASP.NET Web API.

**Frontend**: Desarrollado con Razor, jQuery, y MVC.

**Base de Datos**: SQL Server con procesos almacenados en PL/SQL.

**Manejo de Excepciones**: Implementación adecuada para errores.

**Healthcheck**: Implementación para monitorear el estado de la aplicación.

## **Patrones de Diseño, herramientas y conceptos Utilizados 🏗️**
Uso de SOLID, UnitOfWork, CQRS, DTOs, Automapper, FluentValidation, Swagger, y GlobalExceptions.

### Componentes Principales
1. **API**: API REST para la interacción entre Base de datos y el FrondEnd.
2. **Base de Datos**: Utilizamos SQL Server.
3. **Frontend**: Requisito no entregado.

## **Endpoints de la API 🌐**

A continuación se describen los endpoints disponibles en la API.

### Tarjetas de Crédito
- **GET /api/EndPoint/Card/GetInfoCard**: Obtener información de una tarjeta.
  - Parámetros:
    - `CardNumber`: 6164892848967402
  - Respuesta:
    ```json
	json
    {
		"item": {
		"cardNumber": "6164892848967402",
		"associatedName": "ALEXIS BARAHONA",
		"saldoActual": 1540,
		"saldoDisponible": 360,
		"dateExpiration": "10/2027",
		"cvv": 545,
		"limit": 2500,
		"fechadeCorte": "2024-09-14T00:00:00",
		"cuotaMinimaPagar": 3080,
		"montoTotalContado": 1925,
		"interesConfigurableMinimo": 2,
		"interesConfigurable": 0.25,
		"interesBonificable": 385
		},
		"code": 1,
		"msj": "Éxito"
	}
    ```
	
- **GET /api/EndPoint/Transaction/GetHistoryTransactions**: Obtener información de una tarjeta.
  - Parámetros:
    - `CardNumber`: 6164892848967402
	- `Month`: 10
	- `Year`: 2025
  - Respuesta:
    ```json
	json
    {
		"item": [
		{
			"idTransactions": 0,
			"cardNumber": "6164892848967402",
			"monthT": 10,
			"yearT": 2025,
			"descriptionT": "Pago de intereses",
			"amount": 50,
			"transactionsType": null,
			"dateTransactions": "0001-01-01T00:00:00"
		},
		{
			"idTransactions": 0,
			"cardNumber": "6164892848967402",
			"monthT": 10,
			"yearT": 2025,
			"descriptionT": "Compra de Telefono",
			"amount": 650,
			"transactionsType": null,
			"dateTransactions": "0001-01-01T00:00:00"
		},
		{
			"idTransactions": 0,
			"cardNumber": "6164892848967402",
			"monthT": 10,
			"yearT": 2025,
			"descriptionT": "Pago total de tarjeta",
			"amount": 500,
			"transactionsType": null,
			"dateTransactions": "0001-01-01T00:00:00"
		},
		{
			"idTransactions": 0,
			"cardNumber": "6164892848967402",
			"monthT": 10,
			"yearT": 2025,
			"descriptionT": "Compra en Wallmart",
			"amount": 300.76,
			"transactionsType": null,
			"dateTransactions": "0001-01-01T00:00:00"
		},
		{
			"idTransactions": 0,
			"cardNumber": "6164892848967402",
			"monthT": 10,
			"yearT": 2025,
			"descriptionT": "Pago parcial de tarjeta",
			"amount": 185,
			"transactionsType": null,
			"dateTransactions": "0001-01-01T00:00:00"
		},
		{
			"idTransactions": 0,
			"cardNumber": "6164892848967402",
			"monthT": 10,
			"yearT": 2025,
			"descriptionT": "Pago de Tarjeta",
			"amount": 110,
			"transactionsType": null,
			"dateTransactions": "0001-01-01T00:00:00"
		}
		],
			"code": 1,
			"msj": "Éxito"
	}
    ```

API de Tarjetas de Crédito

GET
Obtener información de la tarjeta
```bash
https://localhost:7177/api/EndPoint/Card/GetInfoCard?CardNumber=6164892848967402
```

Query Parameters
CardNumber
6164892848967402
GET
GetHistoryTransactions
```bash
https://localhost:7177/api/EndPoint/Transaction/GetHistoryTransactions?CardNumber=6164892848967402&Month=10&Year=2025
```

Query Parameters
CardNumber
6164892848967402
Month
10
Year
2025
GET
GetHistoryBuy
```bash
https://localhost:7177/api/EndPoint/Transaction/GetHistoryBuy?CardNumber=6164892848967402&Month=10&Year=2025
```

Query Parameters
CardNumber
6164892848967402
Month
10
Year
2025
GET
GetHistoryPayment
```bash
https://localhost:7177/api/EndPoint/Transaction/GetHistoryPayment?CardNumber=6164892848967402&Month=10&Year=2025
```

Query Parameters
CardNumber
6164892848967402
Month
10
Year
2025
POST
CreateNewBuy
https://localhost:7177/api/EndPoint/Transaction/CreateNewBuy


Body
raw (json)
```json
json
{
  "cardNumber": "6164892848967402",
  "amount": 10,
  "description": "comprar el pan",
  "dateBuy": "2025-03-16T03:55:30.895Z"
}
```

POST
CreateNewPayment
https://localhost:7177/api/EndPoint/Transaction/CreateNewBuy


Body
raw (json)
```json
json
{
  "cardNumber": "6164892848967402",
  "amount": 10,
  "description": "comprar el pan",
  "dateBuy": "2025-03-16T03:55:30.895Z"
}
```
## **Cómo Probar la Aplicación 🧪**

### Requisitos Previos
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/downloads/) (opcional, para probar la API)

### Pasos para Ejecutar el Proyecto
1. Clona el repositorio:
   ```bash
		git clone https://github.com/WilfredoCeron/PT_Wceron.git
	```
 
 2. Clona el repositorio via SSH:
	```bash
		git clone git@github.com:WilfredoCeron/PT_Wceron.git
	```