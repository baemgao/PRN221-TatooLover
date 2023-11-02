-- Insert sample data into the Customer table
INSERT INTO Customer (Code, Email, Password, Name, Address, Phone, Avatar, Status)
VALUES
    ('CUST001', 'hang.nt@example.com', 'Password@1', 'Nguyễn Thị Hằng', '456 Đường Nguyễn Du, Quận 1, TP.HCM', '0978123456', NULL, 1),
    ('CUST002', 'long.vt@example.com', 'Password@1', 'Trần Văn Long', '789 Đường Lê Lai, Quận 3, TP.HCM', '0909988776', NULL, 1),
    ('CUST003', 'hoa.pt@example.com', 'Password@1', 'Phạm Thị Hoa', '101 Đường Nguyễn Thị Minh Khai, Quận 5, TP.HCM', '0888112233', NULL, 1),
    ('CUST004', 'duc.lv@example.com', 'Password@1', 'Lê Văn Đức', '234 Đường Lê Văn Sỹ, Quận Tân Bình, TP.HCM', '0777111222', NULL, 1);

-- Insert sample data into the Studio table
INSERT INTO Studio (Code, Password, Name, Address, Phone, OpenHour, CloseHour, IsWeekendOff, Status)
VALUES
    ('STUDIO001', 'Password@1', N'Inkfinity Studio', N'789 Đường Nguyễn Đình Chính, Quận Phú Nhuận, TP.HCM', '0777123456', '09:00', '18:00', 0, 1),
    ('STUDIO002', 'Password@1', N'Phoenix Rising Tattoos', N'101 Đường Nguyễn Thị Minh Khai, Quận 5, TP.HCM', '0888222333', '08:30', '17:30', 1, 1),
	('STUDIO003', 'Password@1', N'Enigma Tattoo Parlor', N'105 Đường Nguyễn Thị Minh Khai, Quận 2, TP.HCM', '0983552987', '08:30', '17:30', 1, 1);

-- Insert sample data into the Service table
INSERT INTO Service (StudioID, Code, Name, Description, Time, Price, Status)
VALUES
    (1, 'SERV001', 'Tạo hình Tattoo Cơ Bản', 'Tạo hình tattoo cơ bản với mẫu thiết kế tự do.', 90, 500000, 1),
    (1, 'SERV002', 'Tattoo Màu Nền', 'Tạo hình tattoo với màu nền độc đáo và sáng tạo.', 120, 750000, 1),
    (2, 'SERV003', 'Tattoo Hình Xăm Từ Nguyên', 'Tattoo hình xăm dựa trên ý tưởng của bạn hoặc nguyên mẫu.', 60, 350000, 1),
    (2, 'SERV004', 'Tattoo Chữ Thư Pháp', 'Tattoo chữ thư pháp độc đáo và tinh tế.', 45, 300000, 1),
    (3, 'SERV005', 'Tattoo Họa Tiết Truyền Thống', 'Tattoo họa tiết truyền thống với sự kỹ thuật tinh xảo.', 90, 600000, 1),
    (3, 'SERV006', 'Tattoo Phong Cách Nhật Bản', 'Tattoo với phong cách Nhật Bản và hình ảnh độc đáo.', 120, 800000, 1);

-- Insert sample data into the Artist table
INSERT INTO Artist (StudioID, Code, Name, Email, Password, Phone, Address, Avatar, Certificate, Status)
VALUES
    (1, 'ARTIST001', 'Nguyễn Văn Anh', 'nguyen.anh@example.com', 'Password@1', '0987654321', '123 Đường Lê Lợi, Quận 1, TP.HCM', NULL, 'Chứng chỉ số 1', 1),
    (1, 'ARTIST002', 'Trần Thị Bảo', 'bao.tran@example.com', 'Password@1', '0901234567', '456 Đường Nguyễn Đình Chính, Quận Phú Nhuận, TP.HCM', NULL, 'Chứng chỉ số 2', 1),
    (2, 'ARTIST003', 'Lê Minh Trí', 'tri.le@example.com', 'Password@1', '0777123456', '789 Đường Nguyễn Văn Sỹ, Quận Tân Bình, TP.HCM', NULL, 'Chứng chỉ số 3', 1),
    (2, 'ARTIST004', 'Phạm Thị Mai', 'mai.pham@example.com', 'Password@1', '0888222333', '101 Đường Nguyễn Thị Minh Khai, Quận 5, TP.HCM', NULL, 'Chứng chỉ số 4', 1);

-- Insert sample data into the ArtistDetail table
INSERT INTO ArtistDetail (ArtistID, ServiceID)
VALUES
    (1, 1),
    (1, 2),
    (2, 3);

-- Insert sample data into the Schedule table
INSERT INTO Schedule (ArtistID, Date, TimeFrom, TimeTo, Status)
VALUES
    (1, '2023-10-03', '09:00', '13:00', 1),
    (1, '2023-10-04', '10:00', '15:00', 1),
    (2, '2023-10-03', '12:00', '17:00', 1);

-- Insert sample data into the Booking table
INSERT INTO Booking (CustomerID, ArtistID, Price, BookingDate, BookingDateTime, Note, Point, ArtistFeedBack, ServiceFeedBack, Status)
VALUES
    (1, 1, 50.0, '2023-10-01', '2023-10-09', 'Note for Booking 1', 5, 'Feedback for Artist 1', 'Feedback for Service 1', 1),
    (2, 2, 60.0, '2023-10-03', '2023-10-06', 'Note for Booking 2', 3, 'Feedback for Artist 2', 'Feedback for Service 3', 1);

-- Insert sample data into the BookingDetail table
INSERT INTO BookingDetail (BookingID, ServiceID, Description, Status)
VALUES
    (1, 1, 'Description for Service 1', 1),
    (2, 3, 'Description for Service 3', 1);

-- Insert sample data into the Bill table
INSERT INTO Bill (BookingID, Note, Status)
VALUES
    (1, 'Bill for Booking 1', 0),
    (2, 'Bill for Booking 2', 0)