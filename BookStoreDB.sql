CREATE DATABASE BookStoreDB
GO 
USE BookStoreDB
GO

CREATE TABLE TYPEOFBOOK
(
    tobID CHAR(10),
    tobName NVARCHAR(100)

	PRIMARY KEY(tobID)
)

CREATE TABLE BOOK
(
    bookID CHAR(5),
    bookName NVARCHAR(100),
    bookAuthor NVARCHAR(100),
    tobID CHAR(10),
    bookPrice money,
    bookQuantity int,
    bookPublishedYear int

	PRIMARY KEY(bookID)
)

CREATE TABLE PROMOTION
(
    promoID CHAR(15),
    promoName NVARCHAR(100),
    promoDiscount FLOAT(2),
    promoDescription NVARCHAR(500),
    promoStartTime DATE,
    promoEndTime DATE

	PRIMARY KEY(promoID)
)

CREATE TABLE PROMOTIONDETAIL
(
    promoID CHAR(15),
    tobID CHAR(10)

	PRIMARY KEY(promoID, tobID)
)

CREATE TABLE ORDERS
(
    ordersID CHAR(10),
    cusPhoneNumber CHAR(10),
    accUsername VARCHAR(25),
    ordersPrice MONEY,
    ordersTime TIMESTAMP 

	PRIMARY KEY(ordersID)
)

CREATE TABLE ORDERSDETAIL
(
    ordersID CHAR(10),
    bookID CHAR(5),
    odCurrentPrice INT,
    odQuantity INT

	PRIMARY KEY(ordersID, bookID)
)

CREATE TABLE CUSTOMER
(
    cusPhoneNumber CHAR(10),
    cusName CHAR(25)

	PRIMARY KEY(cusPhoneNumber)
)

CREATE TABLE ACCOUNT
(
    accUsername varchar(25),
    accPassword varchar(250)

	PRIMARY KEY(accUsername)
)

ALTER TABLE BOOK ADD 
	CONSTRAINT FK_BOOK_TYPEOFBOOK FOREIGN KEY (tobID) REFERENCES TYPEOFBOOK(tobID)
GO

ALTER TABLE PROMOTIONDETAIL ADD 
	CONSTRAINT FK_PROMOTIONDETAIL_TYPEOFBOOK FOREIGN KEY (tobID) REFERENCES TYPEOFBOOK(tobID)
GO
ALTER TABLE PROMOTIONDETAIL ADD 
	CONSTRAINT FK_PROMOTIONDETAIL_PROMOTION FOREIGN KEY (promoID) REFERENCES PROMOTION(promoID)
GO

ALTER TABLE ORDERS ADD 
	CONSTRAINT FK_ORDERS_CUSTOMER FOREIGN KEY (cusPhoneNumber) REFERENCES CUSTOMER(cusPhoneNumber)
GO
ALTER TABLE ORDERS ADD 
	CONSTRAINT FK_ORDERS_ACCOUNT FOREIGN KEY (accUsername) REFERENCES ACCOUNT(accUsername)
GO

ALTER TABLE ORDERSDETAIL ADD 
	CONSTRAINT FK_ORDERSDETAIL_BOOK FOREIGN KEY (bookID) REFERENCES BOOK(bookID)
GO
ALTER TABLE ORDERSDETAIL ADD 
	CONSTRAINT FK_ORDERSDETAIL_ORDERS FOREIGN KEY (ordersID) REFERENCES ORDERS(ordersID)
GO

------------------------------------------------------------------------------------------------
GO
INSERT INTO ACCOUNT(accUsername, accPassword)
    VALUES  ('admin', 'password'),
            ('quanlyDA', 'quanlyDA')

GO
INSERT INTO CUSTOMER(cusPhoneNumber, cusName)
    VALUES  ('0912001222', N'Trương Mạnh'),
            ('0912712723', N'Khải My'),
            ('0798181991', N'Trần Lê Hồng Nhi'),
            ('0866901801', N'Trần Thái'),
            ('0783450303', N'Trần Văn Đức'),
            ('0328373723', N'Trần Thanh Như'),
            ('0911111222', N'Nguyễn Minh Bảo'),
            ('0769696982', N'Lê Hoàng Bảo Nam'),
            ('0369634889', N'Hoàng Gia Bảo'),
            ('0866923401', N'Nguyễn Ngọc Quỳnh'),
            ('0375812786', N'Phạm Lê Thùy Dung')

GO
INSERT INTO TYPEOFBOOK(tobID, tobName)
    VALUES  ('TB001', N'Văn học Nước ngoài'),
            ('TB002', N'Sách Thiếu nhi'),
            ('TB003', N'Sách Kỹ năng sống'),
            ('TB004', N'Truyện ngắn'),
            ('TB005', N'Tiểu thuyết'),
            ('TB006', N'Sách Nghệ thuật sống đẹp'),
            ('TB007', N'Sách Tôn giáo - Tâm linh')

GO
INSERT INTO BOOK(bookID, tobID, bookName, bookAuthor, bookPrice, bookPublishedYear, bookQuantity)
    VALUES  ('A0001', 'TB001', N'Chiến Thắng Con Quỷ Trong Bạn', N'Napoleon Hill', 115000, 2011, 2),
            ('A0002', 'TB003', N'Nghệ Thuật Tư Duy Phản Biện', N'Albert Rutherford',129000, 2021, 1),
            ('A0003', 'TB005', N'Không gia đình (Tái Bản 2019)', N'Hector Malot', 104000, 2021, 11),
            ('A0004', 'TB001', N'Nghìn Lẻ Một Đêm (Bìa cứng)', N'Antoine Galland', 990000, 2021, 3),
            ('A0005', 'TB005', N'Rừng Na Uy (Tái Bản Lần 4)', N'Haruki Murakami', 145000, 2018, 21),
            ('A0006', 'TB001', N'Ông Già Và Biển Cả', N'Ernest Hemingway', 70400, 2018, 15),
            ('A0007', 'TB005', N'Giết Con Chim Nhại (Bìa cứng)', N'Harper Lee', 110000, 2021, 14),
            ('A0008', 'TB007', N'Nhà Giả Kim (Tái Bản 2020)', N'Paulo Coelho', 63200, 2020, 4),
            ('A0009', 'TB001', N'Ba Người Lính Ngự Lâm', N'Alexandre Dumas', 156000, 2019, 8),
            ('A0010', 'TB005', N'Không Gia Đình (Phiên Bản Mới)', N'Hector Malot', 132000, 2021, 23),
            ('A0011', 'TB002', N'Hoàng Tử Bé (Tái Bản 2019)', N'Antoine De Saint-Exupéry', 75000, 2019, 5),
            ('A0012', 'TB002', N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', N'Nguyễn Nhật Ánh', 113500, 2018, 11),
            ('A0013', 'TB006', N'Nói Chuyện Là Bản Năng, Giữ Miệng Là Tu Dưỡng, Im Lặng Là Trí Tuệ', N'Trương Tiếu Hằng', 129000, 2019, 2),
            ('A0014', 'TB006', N'Thông Điệp Của Nước', N'Masaru Emoto', 89000, 2020, 11),
            ('A0015', 'TB003', N'Thông Điệp Từ Những Biểu Cảm Và Ngôn Ngữ Cơ Thể', N'Kỷ Vũ', 94000, 2019, 11),
            ('A0016', 'TB003', N'Người Nhạy Cảm Trong Thế Giới Vô Cảm', N'Ilse Sand', 85000, 2021, 5),
            ('A0017', 'TB003', N'Gửi bạn, người có trái tim vô cùng nhạy cảm', N'Jeon Hong Jin', 89640, 2021, 3),
            ('A0018', 'TB003', N'Xé vài trang thanh xuân, đổi lấy một bản thân nỗ lực', N'Văn Cát Nhi', 96000, 2021, 11),
            ('A0019', 'TB006', N'Omoiyari - Nghệ Thuật Đối Nhân Xử Thế Của Người Nhật', N'Erin Niimi Longhurst', 142000, 2020, 1),
            ('A0020', 'TB005', N'Nơi em quay về có tôi đứng đợi', N'Ichikawa Takuji', 80000, 2020, 11),
            ('A0021', 'TB005', N'Em sẽ đến cùng cơn mưa', N'Ichikawa Takuji', 90000, 2020, 11),
            ('A0022', 'TB005', N'Tấm ảnh tình yêu, và một câu chuyện khác', N'Ichikawa Takuji', 86000, 2020, 11),
            ('A0023', 'TB005', N'Nếu gặp người ấy cho tôi gửi lời chào', N'Ichikawa Takuji', 98600, 2020, 11),
            ('A0024', 'TB005', N'Tôi vẫn nghe tiếng em thầm gọi', N'Ichikawa Takuji', 62000, 2020, 11),
            ('A0025', 'TB005', N'Thế giới kết thúc dịu dàng đến thế', N'Ichikawa Takuji', 120000, 2020, 11),
            ('A0026', 'TB005', N'Bàn tay cho em', N'Ichikawa Takuji', 90000, 2020, 11),
            ('A0027', 'TB005', N'MM, chuyện về cô gái ấy', N'Ichikawa Takuji', 108000, 2020, 11),
            ('A0028', 'TB005', N'Anh Sẽ Đi Tìm Em Trên Chiếc Xe Đạp Hỏng', N'Ichikawa Takuji', 128000, 2020, 11),
            ('A0029', 'TB006', N'Cân Bằng Cảm Xúc, Cả Lúc Bão Giông', N'Richard Nicholls', 105000, 2020, 9),
            ('A0030', 'TB006', N'Quên Một Người Là Chuyện Của Thời Gian', N'A Tòn', 89000, 2020, 11),
            ('A0031', 'TB007', N'Dấu Chân Trên Cát', N'Mika Waltari', 148000, 2020, 11),
            ('A0032', 'TB007', N'Bên Rặng Tuyết Sơn', N'Swami Amar Jyoti', 88000, 2020, 16),
            ('A0033', 'TB003', N'Tự Thương Mình Sau Những Năm Tháng Thương Người', N'Trí', 78000, 2020, 8),
            ('A0034', 'TB005', N'Một Lít Nước Mắt', N'Kito Aya', 80000, 2020, 12),
            ('A0035', 'TB003', N'Như Bây Giờ Vẫn Ổn', N'Đại sư Pomnyun Sunim', 106000, 2020, 21),
            ('A0036', 'TB003', N'Chuyến Tàu Một Chiều Không Trở Lại', N'Kiên Trần', 120000, 2020, 17),
            ('A0037', 'TB003', N'Nóng Giận Là Bản Năng , Tĩnh Lặng Là Bản Lĩnh', N'Tống Mặc', 89000, 2020, 7),
            ('A0038', 'TB007', N'Tâm Buông Bỏ, Đời Bình An - Bí Kíp Sống Hạnh Phúc Của Người Nhật', N'Natori Hougen', 78000, 2020, 15),
            ('A0039', 'TB007', N'Từ Bi - Trên Cả Trắc Ẩn Và Yêu Thương', N'Osho', 183000, 2020, 4)

GO
INSERT INTO PROMOTION(promoID, promoName,promoDiscount, promoDescription, promoStartTime, promoEndTime)
    VALUES  ('KM-GIAM50K', N'KM Giảm 50K', 0.15, N'Khuyến mãi Giảm 15% tổng giá trị hóa đơn tối đa 50K', '2022/04/08', '2022/04/18'),
            ('KM-GIAM30%', N'KM Giảm 30%', 0.3, N'Khuyến mãi Giảm 30% cho những sách thuộc danh mục Tiểu thuyết, Truyện ngắn', '2022/02/08', '2022/03/08'),
            ('KM-DACBIET', N'KM Đặc biệt', 0.75, N'Khuyến mãi Giảm 75% tổng giá trị hóa đơn tối đa 500K', '2021/12/31', '2021/12/27'),
            ('KM-GIAM100K', N'KM Giảm 100K', 0.3, N'Khuyến mãi Giảm 30% tối đa 100K cho những sách thuộc danh mục Sách Nghệ thuật sống đẹp, Sách Kỹ năng sống', '2021/08/08', '2021/09/09'),
            ('KM-GIAM70%', N'KM Giảm 70%', 0.7, N'Khuyến mãi Giảm 70% cho những sách thuộc danh mục Sách Thiếu nhi', '2021/06/06', '2021/05/27'),
            ('KM-GIAM50%', N'KM Giảm 50%', 0.5, N'Khuyến mãi Giảm 50% cho những sách thuộc danh mục Sách Tôn giáo - Tâm linh', '2021/04/08', '2021/04/18')

GO
INSERT INTO PROMOTIONDETAIL(promoID, tobID)
    VALUES  ('KM-GIAM50K','TB001'),
            ('KM-GIAM50K','TB002'),
            ('KM-GIAM50K','TB003'),
            ('KM-GIAM50K','TB004'),
            ('KM-GIAM50K','TB005'),
            ('KM-GIAM50K','TB006'),
            ('KM-GIAM50K','TB007'),
            ('KM-GIAM30%','TB004'),
            ('KM-GIAM30%','TB005'),
            ('KM-DACBIET','TB001'),
            ('KM-DACBIET','TB002'),
            ('KM-DACBIET','TB003'),
            ('KM-DACBIET','TB004'),
            ('KM-DACBIET','TB005'),
            ('KM-DACBIET','TB006'),
            ('KM-DACBIET','TB007'),
            ('KM-GIAM100K','TB003'),
            ('KM-GIAM100K','TB006'),
            ('KM-GIAM70%','TB002'),
            ('KM-GIAM50%','TB007')

GO
INSERT INTO ORDERS(ordersID)
    VALUES  ('220409JQK'),
            ('220409MNI'),
            ('220408SLL'),
            ('220408QWE'),
            ('220408IBM'),
            ('220407EGN'),
            ('220406IGH'),
            ('220405LKH'),
            ('220404HYY'),
            ('220404UYU'),
            ('220404UYD')

GO
INSERT INTO ORDERSDETAIL(ordersID, bookID, odCurrentPrice, odQuantity)
    VALUES  ('220409JQK', 'A0011', 75000, 1),
            ('220409JQK', 'A0026', 90000, 1),
            ('220409JQK', 'A0029', 105000, 1),

            ('220409MNI', 'A0005', 145000, 1),
            ('220409MNI', 'A0009', 156000, 1),
            ('220409MNI', 'A0015', 94000, 1),
            ('220409MNI', 'A0025', 120000, 1),
            ('220409MNI', 'A0032', 88000, 1),

            ('220408SLL', 'A0039', 183000, 2),

            ('220408QWE', 'A0001', 115000, 1),
            ('220408QWE', 'A0011', 75000, 1),

            ('220408IBM', 'A0013', 129000, 1),
            ('220408IBM', 'A0014', 89000, 2),
            ('220408IBM', 'A0033', 78000, 1),

            ('220407EGN', 'A0005', 145000, 5),

            ('220406IGH', 'A0039', 183000, 1),

            ('220405LKH', 'A0035', 106000, 4),

            ('220404HYY', 'A0004', 990000, 1),
            ('220404HYY', 'A0014', 89000, 1),
            ('220404HYY', 'A0024', 62000, 1),
            ('220404HYY', 'A0034', 80000, 1),

            ('220404UYU', 'A0001', 115000, 1),
            ('220404UYU', 'A0011', 75000, 1),
            ('220404UYU', 'A0021', 90000, 1),
            ('220404UYU', 'A0031', 148000, 1),

            ('220404UYD', 'A0006', 70400, 1),
            ('220404UYD', 'A0016', 85000, 1),
            ('220404UYD', 'A0026', 90000, 1),
            ('220404UYD', 'A0036', 120000, 1)

------------------------------------------------------------------------------------------------
GO
UPDATE ORDERS SET cusPhoneNumber = '0912001222', accUsername = 'quanlyDA' WHERE ordersID = '220409JQK'
UPDATE ORDERS SET cusPhoneNumber = '0912712723', accUsername = 'quanlyDA' WHERE ordersID = '220409MNI'
UPDATE ORDERS SET cusPhoneNumber = '0798181991', accUsername = 'quanlyDA' WHERE ordersID = '220408SLL'
UPDATE ORDERS SET cusPhoneNumber = '0866901801', accUsername = 'quanlyDA' WHERE ordersID = '220408QWE'
UPDATE ORDERS SET cusPhoneNumber = '0783450303', accUsername = 'quanlyDA' WHERE ordersID = '220408IBM'
UPDATE ORDERS SET cusPhoneNumber = '0328373723', accUsername = 'quanlyDA' WHERE ordersID = '220407EGN'
UPDATE ORDERS SET cusPhoneNumber = '0911111222', accUsername = 'quanlyDA' WHERE ordersID = '220406IGH'
UPDATE ORDERS SET cusPhoneNumber = '0769696982', accUsername = 'quanlyDA' WHERE ordersID = '220405LKH'
UPDATE ORDERS SET cusPhoneNumber = '0369634889', accUsername = 'quanlyDA' WHERE ordersID = '220404HYY'
UPDATE ORDERS SET cusPhoneNumber = '0866923401', accUsername = 'quanlyDA' WHERE ordersID = '220404UYU'
UPDATE ORDERS SET cusPhoneNumber = '0375812786', accUsername = 'quanlyDA' WHERE ordersID = '220404UYD'