USE [PRN221_TatooLover]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([CustomerID], [Code], [Email], [Password], [Name], [Address], [Phone], [Avatar], [Status]) VALUES (1, N'CUST006', N'Tunvm@example.com', N'Password@1', N'Nguyễn Văn Minh Tú', N'123 Đường Hải Thượng Lãn Ông, Quận 1, TP.HCM', N'0901234567', NULL, 1)
GO
INSERT [dbo].[Customer] ([CustomerID], [Code], [Email], [Password], [Name], [Address], [Phone], [Avatar], [Status]) VALUES (2, N'CUST005', N'Trangntm2@example.com', N'Password@1', N'Nguyễn Thị Minh Trang', N'456 Đường Sư Vạn Hạnh, Quận 2, TP.HCM', N'0912345678', NULL, 1)
GO
INSERT [dbo].[Customer] ([CustomerID], [Code], [Email], [Password], [Name], [Address], [Phone], [Avatar], [Status]) VALUES (3, N'CUST001', N'hang.nt@example.com', N'Password@1', N'Nguyễn Thị Hằng', N'456 Đường Nguyễn Du, Quận 1, TP.HCM', N'0978123456', NULL, 1)
GO
INSERT [dbo].[Customer] ([CustomerID], [Code], [Email], [Password], [Name], [Address], [Phone], [Avatar], [Status]) VALUES (4, N'CUST002', N'long.vt@example.com', N'Password@1', N'Trần Văn Long', N'789 Đường Lê Lai, Quận 3, TP.HCM', N'0909988776', NULL, 1)
GO
INSERT [dbo].[Customer] ([CustomerID], [Code], [Email], [Password], [Name], [Address], [Phone], [Avatar], [Status]) VALUES (5, N'CUST003', N'hoa.pt@example.com', N'Password@1', N'Phạm Thị Hoa', N'101 Đường Nguyễn Thị Minh Khai, Quận 5, TP.HCM', N'0888112233', NULL, 1)
GO
INSERT [dbo].[Customer] ([CustomerID], [Code], [Email], [Password], [Name], [Address], [Phone], [Avatar], [Status]) VALUES (6, N'CUST004', N'duc.lv@example.com', N'Password@1', N'Lê Văn Đức', N'234 Đường Lê Văn Sỹ, Quận Tân Bình, TP.HCM', N'0777111222', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 
GO
INSERT [dbo].[Studio] ([StudioID], [Code], [Password], [Name], [Address], [Phone], [OpenHour], [CloseHour], [IsWeekendOff], [Status]) VALUES (1, N'STUDIO001', N'Password@1', N'Inkfinity Studio', N'789 Đường Nguyễn Đình Chính, Quận Phú Nhuận, TP.HCM', N'0777123456', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), 0, 1)
GO
INSERT [dbo].[Studio] ([StudioID], [Code], [Password], [Name], [Address], [Phone], [OpenHour], [CloseHour], [IsWeekendOff], [Status]) VALUES (2, N'STUDIO002', N'Password@1', N'Phoenix Rising Tattoos', N'101 Đường Nguyễn Thị Minh Khai, Quận 5, TP.HCM', N'0888222333', CAST(N'08:30:00' AS Time), CAST(N'17:30:00' AS Time), 1, 1)
GO
INSERT [dbo].[Studio] ([StudioID], [Code], [Password], [Name], [Address], [Phone], [OpenHour], [CloseHour], [IsWeekendOff], [Status]) VALUES (3, N'STUDIO003', N'Password@1', N'Enigma Tattoo Parlor', N'105 Đường Nguyễn Thị Minh Khai, Quận 2, TP.HCM', N'0983552987', CAST(N'08:30:00' AS Time), CAST(N'17:30:00' AS Time), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (1, 1, N'SERV001', N'Tạo hình Tattoo Cơ Bản', N'Tạo hình tattoo cơ bản với mẫu thiết kế tự do.', 90, 500000, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (2, 1, N'SERV002', N'Tattoo Màu Nền', N'Tạo hình tattoo với màu nền độc đáo và sáng tạo.', 120, 750000, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (3, 2, N'SERV003', N'Tattoo Hình Xăm Từ Nguyên', N'Tattoo hình xăm dựa trên ý tưởng của bạn hoặc nguyên mẫu.', 60, 350000, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (4, 2, N'SERV004', N'Tattoo Chữ Thư Pháp', N'Tattoo chữ thư pháp độc đáo và tinh tế.', 45, 300000, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (5, 3, N'SERV005', N'Tattoo Họa Tiết Truyền Thống', N'Tattoo họa tiết truyền thống với sự kỹ thuật tinh xảo.', 90, 600000, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (6, 3, N'SERV006', N'Tattoo Phong Cách Nhật Bản', N'Tattoo với phong cách Nhật Bản và hình ảnh độc đáo.', 120, 800000, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (7, 1, N'DV001', N'Tattoo Đen Trắng Cổ Điển', N'Mẫu xăm đen trắng đẹp và thanh lịch cho vẻ ngoại hình vĩnh cửu.', 120, 200, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (8, 1, N'DV002', N'Tattoo Toàn Bộ Tay Sáng Tạo', N'Tattoo toàn bộ tay sáng tạo với sự kết hợp của nhiều màu sắc và chi tiết tinh tế.', 180, 300, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (9, 1, N'DV003', N'Tattoo Ngón Tay Tối Giản', N'Mẫu xăm đơn giản và nhỏ cho ngón tay, tạo ra một tuyên bố tinh tế và phong cách.', 30, 50, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (10, 1, N'DV004', N'Tattoo Chân Dung Chân Thực', N'Tattoo chân dung chi tiết và chân thực, chụp lấy bản chất của người.', 240, 400, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (11, 1, N'DV005', N'Tattoo Nước Màu Trừu Tượng', N'Thiết kế tattoo nước màu trừu tượng và nghệ thuật để tạo nên một diện mạo độc đáo và sáng tạo.', 150, 250, 1)
GO
INSERT [dbo].[Service] ([ServiceID], [StudioID], [Code], [Name], [Description], [Time], [Price], [Status]) VALUES (12, 1, N'DV006', N'Tattoo Hình Nguyên Tộc Mang Tính Biểu Tượng', N'Tattoo hình nguyên tộc mang tính biểu tượng được truyền cảm hứng từ những thiết kế truyền thống và ý nghĩa văn hóa.', 90, 150, 1)
GO
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[Artist] ON 
GO
INSERT [dbo].[Artist] ([ArtistID], [StudioID], [Code], [Name], [Email], [Password], [Phone], [Address], [Avatar], [Certificate], [Status]) VALUES (1, 1, N'ARTIST001', N'Nguyễn Thanh Trà', N'artist1@example.com', N'Password@1', N'0123456789', N'321 Đường Nguyễn Lương Bằng, Quận 4, TP.HCM', NULL, N'Certificate Link', 1)
GO
INSERT [dbo].[Artist] ([ArtistID], [StudioID], [Code], [Name], [Email], [Password], [Phone], [Address], [Avatar], [Certificate], [Status]) VALUES (2, 1, N'ARTIST002', N'Trần Hồng Hạnh', N'artist2@example.com', N'Password@1', N'0123456789', N'543 Đường Trần Trọng Kim, Quận 5, TP.HCM', NULL, N'Certificate Link', 1)
GO
INSERT [dbo].[Artist] ([ArtistID], [StudioID], [Code], [Name], [Email], [Password], [Phone], [Address], [Avatar], [Certificate], [Status]) VALUES (3, 1, N'ARTIST001', N'Nguyễn Văn Anh', N'nguyen.anh@example.com', N'Password@1', N'0987654321', N'123 Đường Lê Lợi, Quận 1, TP.HCM', NULL, N'Certificate Link', 1)
GO
INSERT [dbo].[Artist] ([ArtistID], [StudioID], [Code], [Name], [Email], [Password], [Phone], [Address], [Avatar], [Certificate], [Status]) VALUES (4, 1, N'ARTIST002', N'Trần Thị Bảo', N'bao.tran@example.com', N'Password@1', N'0901234567', N'456 Đường Nguyễn Đình Chính, Quận Phú Nhuận, TP.HCM', NULL, N'Certificate Link', 1)
GO
INSERT [dbo].[Artist] ([ArtistID], [StudioID], [Code], [Name], [Email], [Password], [Phone], [Address], [Avatar], [Certificate], [Status]) VALUES (5, 2, N'ARTIST003', N'Lê Minh Trí', N'tri.le@example.com', N'Password@1', N'0777123456', N'789 Đường Nguyễn Văn Sỹ, Quận Tân Bình, TP.HCM', NULL, N'Certificate Link', 1)
GO
INSERT [dbo].[Artist] ([ArtistID], [StudioID], [Code], [Name], [Email], [Password], [Phone], [Address], [Avatar], [Certificate], [Status]) VALUES (6, 2, N'ARTIST004', N'Phạm Thị Mai', N'mai.pham@example.com', N'Password@1', N'0888222333', N'101 Đường Nguyễn Thị Minh Khai, Quận 5, TP.HCM', NULL, N'Certificate Link', 1)
GO
SET IDENTITY_INSERT [dbo].[Artist] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (1, 1, 1, 1, 100, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-13T10:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (2, 2, 2, 2, 150, CAST(N'2023-11-02T00:00:00.000' AS DateTime), CAST(N'2023-11-14T14:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (3, 1, 1, 1, 100, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-01T10:00:00.000' AS DateTime), N'Không', 5, N'Rất hài lòng với tác phẩm của nghệ sĩ', N'Đẹp và chất lượng cao', 2)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (4, 2, 2, 2, 150, CAST(N'2023-01-02T00:00:00.000' AS DateTime), CAST(N'2023-01-02T14:00:00.000' AS DateTime), N'Không', 4, N'Chị Hạnh rất OK', N'Hài lòng với trải nghiệm', 2)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (5, 1, 1, 1, 100, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T10:00:00.000' AS DateTime), N'Không', 5, N'Rất hài lòng', N'Đẹp và chất lượng cao', 2)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (6, 2, 2, 2, 150, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T14:00:00.000' AS DateTime), N'Không', 4, N'Cảm ơn bạn', N'Hài lòng với trải nghiệm', 2)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (7, 3, 3, 3, 120, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T18:00:00.000' AS DateTime), N'Không', 3, N'Cảm ơn', N'Chất lượng tốt', 2)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (8, 4, 1, 1, 100, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T11:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (9, 5, 2, 2, 150, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T15:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (10, 6, 3, 3, 120, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T12:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 3)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (11, 1, 1, 1, 100, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T13:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 4)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (12, 3, 2, 2, 150, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T10:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ArtistID], [ServiceID], [Price], [BookingDate], [BookingDateTime], [Note], [Point], [ArtistFeedBack], [ServiceFeedBack], [Status]) VALUES (13, 4, 3, 3, 120, CAST(N'2023-10-11T00:00:00.000' AS DateTime), CAST(N'2023-10-11T15:00:00.000' AS DateTime), N'Không', NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[ArtistDetail] ON 
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (1, 1, 10)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (2, 2, 12)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (3, 1, 5)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (4, 2, 7)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (5, 1, 8)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (6, 2, 10)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (7, 1, 9)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (8, 3, 12)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (9, 4, 6)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (10, 5, 12)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (11, 1, 10)
GO
INSERT [dbo].[ArtistDetail] ([ArtistDetailID], [ArtistID], [ServiceID]) VALUES (12, 1, 12)
GO
SET IDENTITY_INSERT [dbo].[ArtistDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 
GO
INSERT [dbo].[Schedule] ([ScheduleID], [ArtistID], [Date], [TimeFrom], [TimeTo], [Status]) VALUES (1, 3, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), 1)
GO
INSERT [dbo].[Schedule] ([ScheduleID], [ArtistID], [Date], [TimeFrom], [TimeTo], [Status]) VALUES (2, 5, CAST(N'2023-01-02T00:00:00.000' AS DateTime), CAST(N'14:00:00' AS Time), CAST(N'16:00:00' AS Time), 1)
GO
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (1, 1, N'Note cho Bill 1', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (2, 2, N'Note cho Bill 2', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (3, 3, N'Note cho Bill 3', 2)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (4, 4, N'Note cho Bill 4', 2)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (5, 5, N'Note cho Bill 5', 2)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (6, 6, N'Note cho Bill 6', 2)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (7, 7, N'Note cho Bill 7', 2)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (8, 8, N'Note cho Bill 8', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (9, 9, N'Note cho Bill 9', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (10, 10, N'Note cho Bill 10', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (11, 11, N'Note cho Bill 11', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (12, 12, N'Note cho Bill 12', 0)
GO
INSERT [dbo].[Bill] ([BillID], [BookingID], [Note], [Status]) VALUES (13, 13, N'Note cho Bill 13', 0)
GO
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
