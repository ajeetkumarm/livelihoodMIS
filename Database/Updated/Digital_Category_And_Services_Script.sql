USE [HPPI_Livelihood]
GO
SET IDENTITY_INSERT [dbo].[M_DigitalCategory] ON 
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (28, N'Aadhaar Services', N'1', CAST(N'2024-07-09T00:15:00' AS SmallDateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (29, N'Central G2C Services - PM Welfare Schemes', N'1', CAST(N'2024-07-09T11:38:00' AS SmallDateTime), NULL, NULL, 2, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (30, N'Other Central G2C Services', N'1', CAST(N'2024-07-09T11:48:00' AS SmallDateTime), NULL, NULL, 3, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (31, N'State G2C Services', N'1', CAST(N'2024-07-09T11:50:00' AS SmallDateTime), NULL, NULL, 4, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (32, N'Educational Services', N'1', CAST(N'2024-07-09T11:54:00' AS SmallDateTime), NULL, NULL, 5, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (33, N'Legal Services', N'1', CAST(N'2024-07-09T11:55:00' AS SmallDateTime), NULL, NULL, 6, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (34, N'Financial Inclusion Services', N'1', CAST(N'2024-07-09T11:56:00' AS SmallDateTime), NULL, NULL, 7, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (35, N'Tours & Travels', N'1', CAST(N'2024-07-09T11:58:00' AS SmallDateTime), NULL, NULL, 8, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (36, N'Utility Bill Payment Services', N'1', CAST(N'2024-07-09T11:59:00' AS SmallDateTime), NULL, NULL, 9, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (37, N'Healthcare Services', N'1', CAST(N'2024-07-09T12:00:00' AS SmallDateTime), NULL, NULL, 10, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (38, N'Other B2C / B2B Services', N'1', CAST(N'2024-07-09T12:01:00' AS SmallDateTime), NULL, NULL, 11, 0)
GO
INSERT [dbo].[M_DigitalCategory] ([CategoryId], [Category], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted]) VALUES (39, N'Skill Development', N'1', CAST(N'2024-07-09T12:01:00' AS SmallDateTime), NULL, NULL, 12, 0)
GO
SET IDENTITY_INSERT [dbo].[M_DigitalCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[M_DigitalService] ON 
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (98, 28, N'Aadhaar Services – Generation of Aadhaar', N'1', CAST(N'2024-07-09T00:15:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://uidai.gov.in/en/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (99, 28, N'Aadhaar Services – E-KYC & Authentication', N'1', CAST(N'2024-07-09T11:36:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://uidai.gov.in/en/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (100, 28, N'Aadhaar Services – Aadhaar Printing', N'1', CAST(N'2024-07-09T11:37:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://uidai.gov.in/en/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (101, 28, N'Aadhaar Updates (UCL)', N'1', CAST(N'2024-07-09T11:37:00' AS SmallDateTime), NULL, NULL, 4, 0, N'https://uidai.gov.in/en/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (102, 29, N'Ayushman Bharat Yojana', N'1', CAST(N'2024-07-09T11:39:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://abdm.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (103, 29, N'PM FasalBima Yojana', N'1', CAST(N'2024-07-09T11:39:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://pmfby.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (104, 29, N'PM - Ujjwala Scheme (LPG Booking)', N'1', CAST(N'2024-07-09T11:39:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://www.pmuy.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (105, 29, N'PM - Shram Yogi Maan-dhan Yojana', N'1', CAST(N'2024-07-09T11:39:00' AS SmallDateTime), NULL, NULL, 4, 0, N'https://labour.gov.in/pm-sym')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (106, 29, N'PM - Kisan Maan-dhan Yojana', N'1', CAST(N'2024-07-09T11:40:00' AS SmallDateTime), N'1', CAST(N'2024-07-09T11:42:00' AS SmallDateTime), 5, 0, N'https://pmkisan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (107, 29, N'PM - Kisan Samman Nidhi Yojana', N'1', CAST(N'2024-07-09T11:40:00' AS SmallDateTime), NULL, NULL, 6, 0, N'https://pmkisan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (108, 29, N'PM - Merchant Pension Yojana', N'1', CAST(N'2024-07-09T11:40:00' AS SmallDateTime), NULL, NULL, 7, 0, N'https://pmkisan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (109, 29, N'PM - Kisan Credit Cards Yojana', N'1', CAST(N'2024-07-09T11:41:00' AS SmallDateTime), NULL, NULL, 8, 0, N'https://pmkisan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (110, 29, N'PM - SVA Nidhi Yojana', N'1', CAST(N'2024-07-09T11:41:00' AS SmallDateTime), NULL, NULL, 9, 0, N'https://pmkisan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (111, 29, N'E-Shram Registrations', N'1', CAST(N'2024-07-09T11:41:00' AS SmallDateTime), NULL, NULL, 10, 0, N'https://eshram.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (112, 30, N'Election Commission Services', N'1', CAST(N'2024-07-09T11:48:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.eci.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (113, 30, N'Passport Application', N'1', CAST(N'2024-07-09T11:49:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://passportindia.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (114, 30, N'PAN Application', N'1', CAST(N'2024-07-09T11:49:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://www.onlineservices.nsdl.com/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (115, 30, N'Swachh Bharat Abhiyan', N'1', CAST(N'2024-07-09T11:49:00' AS SmallDateTime), NULL, NULL, 4, 0, N'https://swachhbharatmission.ddws.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (116, 30, N'FSSAI Registration/Licence', N'1', CAST(N'2024-07-09T11:49:00' AS SmallDateTime), NULL, NULL, 5, 0, N'https://www.fssai.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (117, 30, N'Jeevan Pramaan', N'1', CAST(N'2024-07-09T11:49:00' AS SmallDateTime), NULL, NULL, 6, 0, N'https://www.jeevanpramaan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (118, 30, N'Udyam Jyoti Parichay', N'1', CAST(N'2024-07-09T11:50:00' AS SmallDateTime), NULL, NULL, 7, 0, N'https://udyamregistration.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (119, 30, N'Recruitment Applications through CSCs', N'1', CAST(N'2024-07-09T11:50:00' AS SmallDateTime), NULL, NULL, 8, 0, N'https://csc.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (120, 31, N'E-District Services', N'1', CAST(N'2024-07-09T11:50:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://edistrict.delhigovt.nic.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (121, 31, N'PDS Services', N'1', CAST(N'2024-07-09T11:51:00' AS SmallDateTime), NULL, NULL, 2, 0, N'http://epds.nic.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (122, 31, N'Labour Registration Services', N'1', CAST(N'2024-07-09T11:51:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://labour.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (123, 31, N'E-Stamp', N'1', CAST(N'2024-07-09T11:51:00' AS SmallDateTime), NULL, NULL, 4, 0, N'https://www.shcilestamp.com/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (124, 31, N'E-Vahan – Sarathi Transport Services', N'1', CAST(N'2024-07-09T11:51:00' AS SmallDateTime), NULL, NULL, 5, 0, N'https://vahan.parivahan.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (125, 31, N'Himachal SwasthyaBima Yojana (HIMCARE)', N'1', CAST(N'2024-07-09T11:51:00' AS SmallDateTime), NULL, NULL, 6, 0, N'https://hpsbys.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (126, 31, N'Other State G2C Services - Recruitment Services', N'1', CAST(N'2024-07-09T11:52:00' AS SmallDateTime), NULL, NULL, 7, 0, N'https://citizenservices.gov.bt/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (127, 31, N'Other State G2C Services - Municipal Services', N'1', CAST(N'2024-07-09T11:52:00' AS SmallDateTime), NULL, NULL, 7, 0, N'https://www.gsa.gov/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (128, 31, N'Other State G2C Services - SwasthaBima', N'1', CAST(N'2024-07-09T11:53:00' AS SmallDateTime), NULL, NULL, 9, 0, N'https://services.india.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (129, 31, N'Other State G2C Services - FasalBima Yojana', N'1', CAST(N'2024-07-09T11:53:00' AS SmallDateTime), NULL, NULL, 10, 0, N'https://pmfby.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (130, 31, N'Education Services – Digital Literacy', N'1', CAST(N'2024-07-09T11:54:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.nielit.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (131, 32, N'Various On-line courses of NIELIT & NIOS, various courses of IGNOU, IITs, Private Universities', N'1', CAST(N'2024-07-09T11:54:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://www.nios.ac.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (132, 32, N'Various courses of CSC Academy', N'1', CAST(N'2024-07-09T11:55:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://jaankari.csccloud.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (133, 33, N'Tele-Legal Consultation Services', N'1', CAST(N'2024-07-09T11:55:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.tele-law.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (134, 33, N'E-Courts Services', N'1', CAST(N'2024-07-09T11:55:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://ecourts.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (135, 34, N'Financial Inclusion – Banking Services', N'1', CAST(N'2024-07-09T11:56:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.worldbank.org/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (136, 34, N'Financial Inclusion – DigiPay (AEPS)', N'1', CAST(N'2024-07-09T11:56:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://cscspv.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (137, 34, N'Financial Inclusion – Insurance Services', N'1', CAST(N'2024-07-09T11:56:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://nationalinsurance.nic.co.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (138, 33, N'Financial Inclusion –   APY & NPS', N'1', CAST(N'2024-07-09T11:57:00' AS SmallDateTime), NULL, NULL, 4, 0, N' https://financialservices.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (139, 34, N'Financial Inclusion – Fastag Services', N'1', CAST(N'2024-07-09T11:57:00' AS SmallDateTime), NULL, NULL, 5, 0, N'')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (140, 34, N'Financial Inclusion - CIBIL Registrations', N'1', CAST(N'2024-07-09T11:57:00' AS SmallDateTime), NULL, NULL, 6, 0, N'https://www.transunioncibil.com/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (141, 35, N'Tours & Travels – IRCTC Services', N'1', CAST(N'2024-07-09T11:58:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.irctctourism.com/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (142, 35, N'Tours & Travels – Other Services', N'1', CAST(N'2024-07-09T11:58:00' AS SmallDateTime), NULL, NULL, 2, 0, N'')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (143, 36, N'Utility Bill Payment – Bharat Bill Payment System (BBPS)', N'1', CAST(N'2024-07-09T11:59:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.bharatbillpay.com/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (144, 36, N'Utility Services – Electricity Bill Payment', N'1', CAST(N'2024-07-09T11:59:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://services.india.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (145, 36, N'Utility Services – Water Bill Payment', N'1', CAST(N'2024-07-09T11:59:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://services.india.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (146, 36, N'Utility Services – LPG Booking', N'1', CAST(N'2024-07-09T11:59:00' AS SmallDateTime), NULL, NULL, 4, 0, N'https://services.india.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (147, 37, N'Healthcare Services – Tele-Medicine', N'1', CAST(N'2024-07-09T12:00:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://main.mohfw.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (148, 36, N'Healthcare Services - Medicine Sales', N'1', CAST(N'2024-07-09T12:01:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://www.pharmaceuticals.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (149, 37, N'Healthcare Services – StreeSwabhiman', N'1', CAST(N'2024-07-09T12:01:00' AS SmallDateTime), NULL, NULL, 3, 0, N'')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (150, 38, N'Grameen E-Store', N'1', CAST(N'2024-07-09T12:01:00' AS SmallDateTime), NULL, NULL, 1, 0, N'https://www.cscestore.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (151, 39, N'Other Services – Products Distribution', N'1', CAST(N'2024-07-09T12:02:00' AS SmallDateTime), NULL, NULL, 2, 0, N'')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (152, 38, N'Other Services – Agriculture Services', N'1', CAST(N'2024-07-09T12:02:00' AS SmallDateTime), NULL, NULL, 3, 0, N'https://www.india.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (153, 38, N'Other Services – Mobile/DTH Recharge', N'1', CAST(N'2024-07-09T12:02:00' AS SmallDateTime), NULL, NULL, 4, 0, N'https://grahaksevakendra.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (154, 38, N'Other Services – IT Return Filing', N'1', CAST(N'2024-07-09T12:02:00' AS SmallDateTime), NULL, NULL, 5, 0, N'https://www.incometax.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (155, 38, N'Other Services – Diginame', N'1', CAST(N'2024-07-09T12:02:00' AS SmallDateTime), NULL, NULL, 6, 0, N'https://www.diginame.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (156, 39, N'Skill Development: Schemes and Courses', N'1', CAST(N'2024-07-09T12:03:00' AS SmallDateTime), N'1', CAST(N'2024-07-09T12:04:00' AS SmallDateTime), 1, 0, N'https://www.skillindiadigital.gov.in/,https://skilldevelopment.gov.in/')
GO
INSERT [dbo].[M_DigitalService] ([ServiceId], [DigitalCategoryId], [ServiceLine], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DisplayOrder], [IsDeleted], [ServiceURL]) VALUES (158, 39, N'Skill Development – Job Portals', N'1', CAST(N'2024-07-09T12:03:00' AS SmallDateTime), NULL, NULL, 2, 0, N'https://www.ncs.gov.in/')
GO
SET IDENTITY_INSERT [dbo].[M_DigitalService] OFF
GO
