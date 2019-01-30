USE [PaymentDB]
GO
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([Id], [AccountType]) VALUES (1, N'Saving')
INSERT [dbo].[AccountType] ([Id], [AccountType]) VALUES (2, N'Current')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
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
