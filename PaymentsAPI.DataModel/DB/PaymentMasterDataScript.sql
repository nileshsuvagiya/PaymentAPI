USE [PaymentDB]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Address]) VALUES (1, N'Nilesh', N'Suvagiya', N'Pune')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Address]) VALUES (2, N'Abhijit', N'Desai', N'Pune')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Address]) VALUES (3, N'Carlos', N'Rocha', N'Switzerland')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([Id], [AccountType]) VALUES (1, N'Saving')
INSERT [dbo].[AccountType] ([Id], [AccountType]) VALUES (2, N'Current')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [CustomerId], [AccountName], [AccountTypeId], [IBAN], [AccountNumber], [Currency], [CurrentBalance]) VALUES (1, 1, N'Nilesh-ICICI-Saving', 1, N'IBAN01', N'35933158286', N'INR', CAST(200000.00 AS Numeric(18, 2)))
INSERT [dbo].[Account] ([Id], [CustomerId], [AccountName], [AccountTypeId], [IBAN], [AccountNumber], [Currency], [CurrentBalance]) VALUES (2, 2, N'Abhijit-HSBC-Current', 2, N'IBAN02', N'70872490', N'GBP', CAST(500000.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'AUD', CAST(1.3754 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'CAD', CAST(1.3139 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'CHF', CAST(0.9942 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'EUR', CAST(0.8739 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'GBP', CAST(0.7616 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'INR', CAST(70.9600 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'JPY', CAST(108.8800 AS Numeric(18, 4)))
INSERT [dbo].[CurrencyExchangeRates] ([CurrencyCode], [ExchangeRate]) VALUES (N'USD', CAST(1.0000 AS Numeric(18, 4)))
SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 

INSERT [dbo].[PaymentMethod] ([Id], [PaymentMethodName], [PaymentMethodCode]) VALUES (1, N'InternetBanking', N'NET')
INSERT [dbo].[PaymentMethod] ([Id], [PaymentMethodName], [PaymentMethodCode]) VALUES (2, N'CreditCard', N'CC')
INSERT [dbo].[PaymentMethod] ([Id], [PaymentMethodName], [PaymentMethodCode]) VALUES (3, N'DebitCard', N'DC')
INSERT [dbo].[PaymentMethod] ([Id], [PaymentMethodName], [PaymentMethodCode]) VALUES (4, N'Cash', N'CASH')
SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
SET IDENTITY_INSERT [dbo].[PaymentStatus] ON 

INSERT [dbo].[PaymentStatus] ([Id], [Status], [Description]) VALUES (1, N'Cancelled', N'Cancelled the  payment')
INSERT [dbo].[PaymentStatus] ([Id], [Status], [Description]) VALUES (2, N'Completed', N'Payment Done')
INSERT [dbo].[PaymentStatus] ([Id], [Status], [Description]) VALUES (3, N'InProcess', N'Payment is in process')
INSERT [dbo].[PaymentStatus] ([Id], [Status], [Description]) VALUES (4, N'Rejected', N'Payment is rejected due to insufficient amoutn')
SET IDENTITY_INSERT [dbo].[PaymentStatus] OFF
