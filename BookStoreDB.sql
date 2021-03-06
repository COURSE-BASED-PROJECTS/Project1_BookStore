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
    bookPrice MONEY DEFAULT 0,
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
    promoEndTime DATE,
	promoStatus BIT,

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
	ordersPrice MONEY DEFAULT 0,
    ordersTime DATETIME

	PRIMARY KEY(ordersID)
)

CREATE TABLE ORDERSDETAIL
(
    ordersID CHAR(10),
    bookID CHAR(5),
    odCurrentPrice MONEY DEFAULT 0,
    odQuantity INT,
	odDiscountedPrice MONEY DEFAULT 0,
	odTempPrice MONEY DEFAULT 0

	PRIMARY KEY(ordersID, bookID)
)

CREATE TABLE CUSTOMER
(
    cusPhoneNumber CHAR(10),
    cusName NVARCHAR(100)

	PRIMARY KEY(cusPhoneNumber)
)

CREATE TABLE ACCOUNT
(
    accUsername VARCHAR(25),
    accPassword VARCHAR(250)

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
    VALUES  ('admin', '$2a$11$cONPep1srXy.2xtBG4EhjerAo0asLvLlLIJW3e9500wkArQ4N4Fe.'),
            ('quanlyDA', '$2a$11$VbsQyZ6E3SFj8PnOBDypvu2ADenGlZQ1PltV0..JFZ8nSHURllphC'),
            ('nvNguyenHa', '$2a$11$gVgL3NBaegri2scH4nVp5ennyfJ9PacLB13valr7frqZiYqP/vkDu')

GO
INSERT INTO CUSTOMER(cusPhoneNumber, cusName)
    VALUES  ('0912001222', N'Tr????ng M???nh'),
            ('0912712723', N'Kha??i My'),
            ('0798181991', N'Tr???n L?? H???ng Nhi'),
            ('0866901801', N'Tr???n Th??i'),
            ('0783450303', N'Tr???n V??n ?????c'),
            ('0328373723', N'Tr???n Thanh Nh??'),
            ('0911111222', N'Nguy???n Minh B???o'),
            ('0769696982', N'L?? Ho??ng B???o Nam'),
            ('0369634889', N'Ho??ng Gia B???o'),
            ('0866923401', N'Nguy???n Ng???c Qu???nh'),
            ('0375812786', N'Ph???m L?? Th??y Dung')

GO
INSERT INTO TYPEOFBOOK(tobID, tobName)
    VALUES  ('TB001', N'V??n h???c N?????c ngo??i'),
            ('TB002', N'S??ch Thi???u nhi'),
            ('TB003', N'S??ch K??? n??ng s???ng'),
            ('TB004', N'Truy???n ng???n'),
            ('TB005', N'Ti???u thuy???t'),
            ('TB006', N'S??ch Ngh??? thu???t s???ng ?????p'),
            ('TB007', N'S??ch T??n gi??o - T??m linh')

GO
INSERT INTO BOOK(bookID, tobID, bookName, bookAuthor, bookPrice, bookPublishedYear, bookQuantity)
    VALUES  ('A0001', 'TB001', N'Chi???n Th???ng Con Qu??? Trong B???n', N'Napoleon Hill', 115000, 2011, 12),
            ('A0002', 'TB003', N'Ngh??? Thu???t T?? Duy Ph???n Bi???n', N'Albert Rutherford',129000, 2021, 11),
            ('A0003', 'TB005', N'Kh??ng gia ????nh (T??i B???n 2019)', N'Hector Malot', 104000, 2021, 23),
            ('A0004', 'TB001', N'Ngh??n L??? M???t ????m (B??a c???ng)', N'Antoine Galland', 990000, 2021, 33),
            ('A0005', 'TB005', N'R???ng Na Uy (T??i B???n L???n 4)', N'Haruki Murakami', 145000, 2018, 21),
            ('A0006', 'TB001', N'??ng Gi?? V?? Bi???n C???', N'Ernest Hemingway', 70400, 2018, 25),
            ('A0007', 'TB005', N'Gi???t Con Chim Nh???i (B??a c???ng)', N'Harper Lee', 110000, 2021, 34),
            ('A0008', 'TB007', N'Nh?? Gi??? Kim (T??i B???n 2020)', N'Paulo Coelho', 63200, 2020, 4),
            ('A0009', 'TB001', N'Ba Ng?????i L??nh Ng??? L??m', N'Alexandre Dumas', 156000, 2019, 28),
            ('A0010', 'TB005', N'Kh??ng Gia ????nh (Phi??n B???n M???i)', N'Hector Malot', 132000, 2021, 32),
            ('A0011', 'TB002', N'Ho??ng T??? B?? (T??i B???n 2019)', N'Antoine De Saint-Exup??ry', 75000, 2019, 55),
            ('A0012', 'TB002', N'T??i Th???y Hoa V??ng Tr??n C??? Xanh', N'Nguy???n Nh???t ??nh', 113500, 2018, 56),
            ('A0013', 'TB006', N'N??i Chuy???n L?? B???n N??ng, Gi??? Mi???ng L?? Tu D?????ng, Im L???ng L?? Tr?? Tu???', N'Tr????ng Ti????u H????ng', 129000, 2019, 52),
            ('A0014', 'TB006', N'Th??ng ??i???p C???a N?????c', N'Masaru Emoto', 89000, 2020, 21),
            ('A0015', 'TB003', N'Th??ng ??i???p T??? Nh???ng Bi???u C???m V?? Ng??n Ng??? C?? Th???', N'K??? V??', 94000, 2019, 31),
            ('A0016', 'TB003', N'Ng?????i Nh???y C???m Trong Th??? Gi???i V?? C???m', N'Ilse Sand', 85000, 2021, 35),
            ('A0017', 'TB003', N'G???i b???n, ng?????i c?? tr??i tim v?? c??ng nh???y c???m', N'Jeon Hong Jin', 89640, 2021, 36),
            ('A0018', 'TB003', N'X?? v??i trang thanh xu??n, ?????i l???y m???t b???n th??n n??? l???c', N'V??n C??t Nhi', 96000, 2021, 42),
            ('A0019', 'TB006', N'Omoiyari - Ngh??? Thu???t ?????i Nh??n X??? Th??? C???a Ng?????i Nh???t', N'Erin Niimi Longhurst', 142000, 2020, 51),
            ('A0020', 'TB005', N'N??i em quay v??? c?? t??i ?????ng ?????i', N'Ichikawa Takuji', 80000, 2020, 11),
            ('A0021', 'TB005', N'Em s??? ?????n c??ng c??n m??a', N'Ichikawa Takuji', 90000, 2020, 11),
            ('A0022', 'TB005', N'T???m ???nh t??nh y??u, v?? m???t c??u chuy???n kh??c', N'Ichikawa Takuji', 86000, 2020, 11),
            ('A0023', 'TB005', N'N???u g???p ng?????i ???y cho t??i g???i l???i ch??o', N'Ichikawa Takuji', 98600, 2020, 11),
            ('A0024', 'TB005', N'T??i v???n nghe ti???ng em th???m g???i', N'Ichikawa Takuji', 62000, 2020, 11),
            ('A0025', 'TB005', N'Th??? gi???i k???t th??c d???u d??ng ?????n th???', N'Ichikawa Takuji', 120000, 2020, 11),
            ('A0026', 'TB005', N'B??n tay cho em', N'Ichikawa Takuji', 90000, 2020, 11),
            ('A0027', 'TB005', N'MM, chuy???n v??? c?? g??i ???y', N'Ichikawa Takuji', 108000, 2020, 11),
            ('A0028', 'TB005', N'Anh S??? ??i T??m Em Tr??n Chi???c Xe ?????p H???ng', N'Ichikawa Takuji', 128000, 2020, 11),
            ('A0029', 'TB006', N'C??n B???ng C???m X??c, C??? L??c B??o Gi??ng', N'Richard Nicholls', 105000, 2020, 19),
            ('A0030', 'TB006', N'Qu??n M???t Ng?????i L?? Chuy???n C???a Th???i Gian', N'A T??n', 89000, 2020, 11),
            ('A0031', 'TB007', N'D???u Ch??n Tr??n C??t', N'Mika Waltari', 148000, 2020, 11),
            ('A0032', 'TB007', N'B??n R???ng Tuy???t S??n', N'Swami Amar Jyoti', 88000, 2020, 16),
            ('A0033', 'TB003', N'T??? Th????ng M??nh Sau Nh???ng N??m Th??ng Th????ng Ng?????i', N'Tr??', 78000, 2020, 28),
            ('A0034', 'TB005', N'M???t L??t N?????c M???t', N'Kito Aya', 80000, 2020, 34),
            ('A0035', 'TB003', N'Nh?? B??y Gi??? V???n ???n', N'?????i s?? Pomnyun Sunim', 106000, 2020, 53),
            ('A0036', 'TB003', N'Chuy???n T??u M???t Chi???u Kh??ng Tr??? L???i', N'Ki??n Tr???n', 120000, 2020, 47),
            ('A0037', 'TB003', N'N??ng Gi???n L?? B???n N??ng , T??nh L???ng L?? B???n L??nh', N'T???ng M???c', 89000, 2020, 47),
            ('A0038', 'TB007', N'T??m Bu??ng B???, ?????i B??nh An - B?? K??p S???ng H???nh Ph??c C???a Ng?????i Nh???t', N'Natori Hougen', 78000, 2020, 45),
            ('A0039', 'TB007', N'T??? Bi - Tr??n C??? Tr???c ???n V?? Y??u Th????ng', N'Osho', 183000, 2020, 44)

GO
INSERT INTO PROMOTION(promoID, promoName,promoDiscount, promoDescription, promoStartTime, promoEndTime, promoStatus)
    VALUES  ('KM-GIAM15%', N'KM Gi???m 15%', 0.15, N'Khuy???n m??i Gi???m 15% t???ng gi?? tr??? h??a ????n', '2022/04/11', '2022/05/07',1),
			('KM-GIAM50K', N'KM Gi???m 50K', 0.15, N'Khuy???n m??i Gi???m 15% t???ng gi?? tr??? h??a ????n t???i ??a 50K', '2022/04/08', '2022/04/18',1),
            ('KM-GIAM30%', N'KM Gi???m 30%', 0.3, N'Khuy???n m??i Gi???m 30% cho nh???ng s??ch thu???c danh m???c Ti???u thuy???t, Truy???n ng???n', '2022/02/08', '2022/03/08',1),
            ('KM-DACBIET', N'KM ?????c bi???t', 0.75, N'Khuy???n m??i Gi???m 75% t???ng gi?? tr??? h??a ????n t???i ??a 500K', '2021/12/31', '2021/12/27',1),
            ('KM-GIAM100K', N'KM Gi???m 100K', 0.3, N'Khuy???n m??i Gi???m 30% t???i ??a 100K cho nh???ng s??ch thu???c danh m???c S??ch Ngh??? thu???t s???ng ?????p, S??ch K??? n??ng s???ng', '2021/08/08', '2021/09/09',1),
            ('KM-GIAM70%', N'KM Gi???m 70%', 0.7, N'Khuy???n m??i Gi???m 70% cho nh???ng s??ch thu???c danh m???c S??ch Thi???u nhi', '2021/06/06', '2021/05/27',1),
            ('KM-GIAM50%', N'KM Gi???m 50%', 0.5, N'Khuy???n m??i Gi???m 50% cho nh???ng s??ch thu???c danh m???c S??ch T??n gi??o - T??m linh', '2021/04/08', '2021/04/18',1)

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
INSERT INTO ORDERS(ordersID, ordersTime)
    VALUES  ('220421DFS', '2022-04-21 07:21:35'),
            ('220421FDV', '2022-04-21 10:20:34'),
            ('220421FDS', '2022-04-21 11:19:33'),
            ('220420RTR', '2022-04-20 12:18:32'),
            ('220420KTH', '2022-04-20 13:17:31'),
            ('220420TJJ', '2022-04-20 15:16:30'),
            ('220419LIE', '2022-04-19 17:15:29'),
            ('220418FGT', '2022-04-18 18:14:28'),
            ('220417WWW', '2022-04-17 19:13:27'),
            ('220416RGH', '2022-04-16 20:12:26'),
            ('220416YUY', '2022-04-16 11:11:11'),
			('220415LEH', '2022-04-15 07:21:35'),
			('220415PQK', '2022-04-15 07:21:35'),
            ('220414GKR', '2022-04-14 10:20:34'),
            ('220414KKH', '2022-04-14 11:19:33'),
            ('220414JEK', '2022-04-14 12:18:32'),
            ('220414RIJ', '2022-04-14 13:17:31'),
            ('220413WKR', '2022-04-13 15:16:30'),
            ('220413KAS', '2022-04-13 17:15:29'),
            ('220412EWQ', '2022-04-12 18:14:28'),
            ('220412DDD', '2022-04-12 19:13:27'),
            ('220412SDF', '2022-04-12 20:12:26'),
            ('220411KAS', '2022-04-11 11:11:11'),
			('220411KSD', '2022-04-11 07:21:35'),
            ('220411MNI', '2022-04-11 10:20:34'),
            ('220411SLL', '2022-04-11 11:19:33'),
            ('220411QWE', '2022-04-11 12:18:32'),
            ('220411IBM', '2022-04-11 13:17:31'),
            ('220411EGN', '2022-04-11 15:16:30'),
            ('220411IGH', '2022-04-11 17:15:29'),
            ('220411LKH', '2022-04-11 18:14:28'),
            ('220409JQK', '2022-04-09 18:14:28'),
            ('220409MNI', '2022-04-09 18:14:28'),
            ('220408SLL', '2022-04-08 18:14:28'),
            ('220408QWE', '2022-04-08 18:14:28'),
            ('220408IBM', '2022-04-08 18:14:28'),
            ('220407EGN', '2022-04-07 18:14:28'),
            ('220406IGH', '2022-04-06 18:14:28'),
            ('220405LKH', '2022-04-05 18:14:28'),
            ('220404HYY', '2022-04-04 19:13:27'),
            ('220404UYU', '2022-04-04 20:12:26'),
            ('220404UYD', '2022-04-04 11:11:11')

GO
INSERT INTO ORDERSDETAIL(ordersID, bookID, odCurrentPrice, odQuantity, odTempPrice)
    VALUES  ('220421DFS', 'A0011', 75000 , 1, 75000 ),
            ('220421DFS', 'A0029', 105000, 1, 105000),
            ('220421DFS', 'A0015', 94000 , 1, 94000 ),
            ('220421FDV', 'A0015', 94000 , 1, 94000 ),
            ('220421FDV', 'A0013', 129000, 1, 129000),
            ('220421FDV', 'A0012', 113500, 1, 113500),
            ('220421FDS', 'A0036', 120000, 1, 120000),
            ('220421FDS', 'A0013', 129000, 1, 129000),
            ('220421FDS', 'A0019', 142000, 1, 142000),
            ('220421FDS', 'A0015', 94000 , 1, 94000 ),
            ('220420RTR', 'A0011', 75000 , 1, 75000 ),
            ('220420RTR', 'A0021', 90000 , 1, 90000 ),
            ('220420RTR', 'A0031', 148000, 1, 148000),
            ('220420RTR', 'A0014', 89000 , 1, 89000 ),
            ('220418FGT', 'A0015', 94000 , 1, 94000 ),
            ('220420KTH', 'A0021', 90000 , 1, 90000 ),
            ('220420KTH', 'A0016', 85000 , 1, 85000 ),
            ('220420KTH', 'A0026', 90000 , 1, 90000 ),
            ('220420KTH', 'A0017', 89640 , 1, 89640 ),
            ('220420KTH', 'A0015', 94000 , 1, 94000 ),
            ('220420RTR', 'A0001', 115000, 1, 115000),
            ('220420TJJ', 'A0002', 129000, 1, 129000),
            ('220420TJJ', 'A0001', 115000, 1, 115000),
			('220420TJJ', 'A0003', 104000, 1, 104000),
            ('220420TJJ', 'A0018', 96000 , 1, 96000 ),
            ('220420TJJ', 'A0013', 129000, 1, 129000),
            ('220420TJJ', 'A0019', 142000, 1, 142000),
            ('220420TJJ', 'A0020', 80000 , 1, 80000 ),
            ('220412DDD', 'A0013', 129000, 1, 129000),
            ('220420TJJ', 'A0021', 90000 , 1, 90000 ),
            ('220419LIE', 'A0015', 94000 , 1, 94000 ),
			('220419LIE', 'A0022', 86000 , 1, 86000 ),
			('220419LIE', 'A0023', 98600 , 1, 98600 ),
            ('220419LIE', 'A0024', 62000 , 1, 62000 ),
            ('220419LIE', 'A0019', 142000, 1, 142000),
			('220419LIE', 'A0025', 120000, 1, 120000),
            ('220418FGT', 'A0026', 90000 , 1, 90000 ),
            ('220417WWW', 'A0027', 108000, 1, 108000),
            ('220417WWW', 'A0031', 148000, 1, 148000),
            ('220417WWW', 'A0028', 128000, 1, 128000),
            ('220416RGH', 'A0029', 105000, 1, 105000),
            ('220416RGH', 'A0015', 94000 , 1, 94000 ),
            ('220416RGH', 'A0030', 89000 , 1, 89000 ),
            ('220416YUY', 'A0031', 148000, 1, 148000),
            ('220416YUY', 'A0032', 88000 , 1, 88000 ),
            ('220416YUY', 'A0037', 183000, 1, 183000),
            ('220416YUY', 'A0002', 129000, 1, 129000),
            ('220415LEH', 'A0033', 78000 , 1, 78000 ),
			('220415LEH', 'A0034', 80000 , 1, 80000 ),
            ('220415LEH', 'A0005', 145000, 5, 145000),
            ('220415LEH', 'A0039', 183000, 1, 183000),
            ('220415LEH', 'A0035', 106000, 4, 106000),
            ('220411QWE', 'A0035', 106000, 1, 106000),
            ('220415LEH', 'A0036', 120000, 1, 120000),
            ('220415LEH', 'A0024', 62000 , 1, 62000 ),
            ('220411QWE', 'A0034', 80000 , 1, 80000 ),
            ('220415PQK', 'A0001', 115000, 1, 115000),
            ('220415PQK', 'A0011', 75000 , 1, 75000 ),
            ('220415PQK', 'A0021', 90000 , 1, 90000 ),
            ('220414GKR', 'A0038', 89000 , 1, 89000 ),
            ('220414GKR', 'A0039', 78000 , 1, 78000 ),
            ('220414KKH', 'A0037', 183000, 1, 183000),
            ('220412EWQ', 'A0002', 129000, 1, 129000),
            ('220414KKH', 'A0001', 115000, 1, 115000),
			('220414JEK', 'A0003', 104000, 1, 104000),
            ('220414JEK', 'A0026', 90000 , 1, 90000 ),
            ('220412DDD', 'A0029', 105000, 1, 105000),
            ('220414RIJ', 'A0005', 145000, 1, 145000),
            ('220414RIJ', 'A0009', 156000, 1, 156000),
            ('220414RIJ', 'A0015', 94000 , 1, 94000 ),
            ('220412SDF', 'A0025', 120000, 1, 120000),
            ('220413WKR', 'A0032', 88000 , 1, 88000 ),
            ('220413WKR', 'A0039', 183000, 2, 183000),
            ('220413WKR', 'A0001', 115000, 1, 115000),
            ('220413KAS', 'A0011', 75000 , 1, 75000 ),
            ('220413KAS', 'A0013', 129000, 1, 129000),
            ('220412EWQ', 'A0014', 89000 , 2, 89000 ),
            ('220412DDD', 'A0033', 78000 , 1, 78000 ),
            ('220412DDD', 'A0005', 145000, 5, 145000),
            ('220411LKH', 'A0039', 183000, 1, 183000),
			('220411LKH', 'A0013', 129000, 1, 129000),
            ('220411LKH', 'A0021', 90000 , 1, 90000 ),
            ('220411LKH', 'A0004', 990000, 1, 990000),
			('220411LKH', 'A0028', 128000, 1, 128000),
            ('220411KSD', 'A0029', 105000, 1, 105000),
            ('220411KAS', 'A0035', 106000, 4, 106000),
			('220411IGH', 'A0003', 104000, 1, 104000),
            ('220411IGH', 'A0018', 96000 , 1, 96000 ),
            ('220411IGH', 'A0013', 129000, 1, 129000),
            ('220411IGH', 'A0019', 142000, 1, 142000),
            ('220411SLL', 'A0020', 80000 , 1, 80000 ),
            ('220411QWE', 'A0013', 129000, 1, 129000),
            ('220409MNI', 'A0021', 90000 , 1, 90000 ),
            ('220409MNI', 'A0004', 990000, 1, 990000),
			('220409MNI', 'A0028', 128000, 1, 128000),
            ('220409MNI', 'A0029', 105000, 1, 105000),
            ('220409MNI', 'A0015', 94000 , 1, 94000 ),
            ('220404HYY', 'A0014', 89000 , 1, 89000 ),
            ('220404HYY', 'A0024', 62000 , 1, 62000 ),
            ('220404HYY', 'A0034', 80000 , 1, 80000 ),
            ('220404UYU', 'A0001', 115000, 1, 115000),
            ('220404UYU', 'A0011', 75000 , 1, 75000 ),
            ('220404UYU', 'A0021', 90000 , 1, 90000 ),
            ('220404UYU', 'A0031', 148000, 1, 148000),
            ('220404UYD', 'A0006', 70400 , 1, 70400 ),
            ('220404UYD', 'A0016', 85000 , 1, 85000 ),
            ('220404UYD', 'A0026', 90000 , 1, 90000 ),
            ('220404UYD', 'A0036', 120000, 1, 120000),
			('220405LKH', 'A0024', 62000 , 1, 62000 ),
            ('220406IGH', 'A0034', 80000 , 1, 80000 ),
            ('220407EGN', 'A0001', 115000, 1, 115000),
            ('220408IBM', 'A0011', 75000 , 1, 75000 ),
            ('220408QWE', 'A0021', 90000 , 1, 90000 ),
            ('220408SLL', 'A0031', 148000, 1, 148000),
            ('220409JQK', 'A0006', 70400 , 1, 70400 ),
            ('220411EGN', 'A0016', 85000 , 1, 85000 ),
            ('220411IBM', 'A0026', 90000 , 1, 90000 ),
            ('220411MNI', 'A0036', 120000, 1, 120000)

------------------------------------------------------------------------------------------------
GO
UPDATE ORDERS SET cusPhoneNumber = '0912001222', accUsername = 'quanlyDA'	WHERE ordersID = '220421DFS'
UPDATE ORDERS SET cusPhoneNumber = '0912712723', accUsername = 'quanlyDA'	WHERE ordersID = '220421FDV'
UPDATE ORDERS SET cusPhoneNumber = '0798181991', accUsername = 'quanlyDA'	WHERE ordersID = '220421FDS'
UPDATE ORDERS SET cusPhoneNumber = '0866901801', accUsername = 'quanlyDA'	WHERE ordersID = '220420RTR'
UPDATE ORDERS SET cusPhoneNumber = '0783450303', accUsername = 'quanlyDA'	WHERE ordersID = '220420KTH'
UPDATE ORDERS SET cusPhoneNumber = '0328373723', accUsername = 'quanlyDA'	WHERE ordersID = '220420TJJ'
UPDATE ORDERS SET cusPhoneNumber = '0911111222', accUsername = 'quanlyDA'	WHERE ordersID = '220419LIE'
UPDATE ORDERS SET cusPhoneNumber = '0769696982', accUsername = 'quanlyDA'	WHERE ordersID = '220418FGT'
UPDATE ORDERS SET cusPhoneNumber = '0369634889', accUsername = 'quanlyDA'	WHERE ordersID = '220417WWW'
UPDATE ORDERS SET cusPhoneNumber = '0866923401', accUsername = 'quanlyDA'	WHERE ordersID = '220416RGH'
UPDATE ORDERS SET cusPhoneNumber = '0375812786', accUsername = 'quanlyDA'	WHERE ordersID = '220416YUY'
UPDATE ORDERS SET cusPhoneNumber = '0912001222', accUsername = 'quanlyDA'	WHERE ordersID = '220415LEH'
UPDATE ORDERS SET cusPhoneNumber = '0912712723', accUsername = 'quanlyDA'	WHERE ordersID = '220415PQK'
UPDATE ORDERS SET cusPhoneNumber = '0798181991', accUsername = 'admin'		WHERE ordersID = '220414GKR'
UPDATE ORDERS SET cusPhoneNumber = '0866901801', accUsername = 'admin'		WHERE ordersID = '220414KKH'
UPDATE ORDERS SET cusPhoneNumber = '0783450303', accUsername = 'admin'		WHERE ordersID = '220414JEK'
UPDATE ORDERS SET cusPhoneNumber = '0328373723', accUsername = 'admin'		WHERE ordersID = '220414RIJ'
UPDATE ORDERS SET cusPhoneNumber = '0911111222', accUsername = 'admin'		WHERE ordersID = '220413WKR'
UPDATE ORDERS SET cusPhoneNumber = '0769696982', accUsername = 'admin'		WHERE ordersID = '220413KAS'
UPDATE ORDERS SET cusPhoneNumber = '0369634889', accUsername = 'admin'		WHERE ordersID = '220412EWQ'
UPDATE ORDERS SET cusPhoneNumber = '0866923401', accUsername = 'admin'		WHERE ordersID = '220412DDD'
UPDATE ORDERS SET cusPhoneNumber = '0912001222', accUsername = 'admin'		WHERE ordersID = '220412SDF'
UPDATE ORDERS SET cusPhoneNumber = '0912712723', accUsername = 'admin'		WHERE ordersID = '220411KAS'
UPDATE ORDERS SET cusPhoneNumber = '0798181991', accUsername = 'admin'		WHERE ordersID = '220411KSD'
UPDATE ORDERS SET cusPhoneNumber = '0866901801', accUsername = 'nvNguyenHa' WHERE ordersID = '220411MNI'
UPDATE ORDERS SET cusPhoneNumber = '0783450303', accUsername = 'nvNguyenHa' WHERE ordersID = '220411SLL'
UPDATE ORDERS SET cusPhoneNumber = '0328373723', accUsername = 'nvNguyenHa' WHERE ordersID = '220411QWE'
UPDATE ORDERS SET cusPhoneNumber = '0911111222', accUsername = 'nvNguyenHa' WHERE ordersID = '220411IBM'
UPDATE ORDERS SET cusPhoneNumber = '0769696982', accUsername = 'nvNguyenHa' WHERE ordersID = '220411EGN'
UPDATE ORDERS SET cusPhoneNumber = '0369634889', accUsername = 'nvNguyenHa' WHERE ordersID = '220411IGH'
UPDATE ORDERS SET cusPhoneNumber = '0866923401', accUsername = 'nvNguyenHa' WHERE ordersID = '220411LKH'
UPDATE ORDERS SET cusPhoneNumber = '0375812786', accUsername = 'nvNguyenHa' WHERE ordersID = '220409JQK'
UPDATE ORDERS SET cusPhoneNumber = '0783450303', accUsername = 'nvNguyenHa' WHERE ordersID = '220409MNI'
UPDATE ORDERS SET cusPhoneNumber = '0375812786', accUsername = 'nvNguyenHa' WHERE ordersID = '220408SLL'
UPDATE ORDERS SET cusPhoneNumber = '0866901801', accUsername = 'nvNguyenHa' WHERE ordersID = '220408QWE'
UPDATE ORDERS SET cusPhoneNumber = '0783450303', accUsername = 'nvNguyenHa' WHERE ordersID = '220408IBM'
UPDATE ORDERS SET cusPhoneNumber = '0328373723', accUsername = 'nvNguyenHa' WHERE ordersID = '220407EGN'
UPDATE ORDERS SET cusPhoneNumber = '0911111222', accUsername = 'nvNguyenHa' WHERE ordersID = '220406IGH'
UPDATE ORDERS SET cusPhoneNumber = '0769696982', accUsername = 'nvNguyenHa' WHERE ordersID = '220405LKH'
UPDATE ORDERS SET cusPhoneNumber = '0369634889', accUsername = 'nvNguyenHa' WHERE ordersID = '220404HYY'
UPDATE ORDERS SET cusPhoneNumber = '0866923401', accUsername = 'nvNguyenHa' WHERE ordersID = '220404UYU'
UPDATE ORDERS SET cusPhoneNumber = '0912001222', accUsername = 'nvNguyenHa' WHERE ordersID = '220404UYD'

------------------------------------------------------------------------------------------------

GO
CREATE PROC CALC_TOTAL
    @ORDERID CHAR(10)
AS
BEGIN TRAN
	UPDATE ORDERSDETAIL
		SET odTempPrice = (odCurrentPrice - odDiscountedPrice)* odQuantity
		WHERE ordersID = @ORDERID
    UPDATE ORDERS
		SET ordersPrice = (SELECT SUM(odCurrentPrice) FROM ORDERSDETAIL WHERE ordersID = @ORDERID)
		WHERE ordersID = @ORDERID
COMMIT
GO

EXEC CALC_TOTAL '220421DFS'
EXEC CALC_TOTAL '220421FDV'
EXEC CALC_TOTAL '220421FDS'
EXEC CALC_TOTAL '220420RTR'
EXEC CALC_TOTAL '220420KTH'
EXEC CALC_TOTAL '220420TJJ'
EXEC CALC_TOTAL '220419LIE'
EXEC CALC_TOTAL '220418FGT'
EXEC CALC_TOTAL '220417WWW'
EXEC CALC_TOTAL '220416RGH'
EXEC CALC_TOTAL '220416YUY'
EXEC CALC_TOTAL '220415LEH'
EXEC CALC_TOTAL '220415PQK'
EXEC CALC_TOTAL '220414GKR'
EXEC CALC_TOTAL '220414KKH'
EXEC CALC_TOTAL '220414JEK'
EXEC CALC_TOTAL '220414RIJ'
EXEC CALC_TOTAL '220413WKR'
EXEC CALC_TOTAL '220413KAS'
EXEC CALC_TOTAL '220412EWQ'
EXEC CALC_TOTAL '220412DDD'
EXEC CALC_TOTAL '220412SDF'
EXEC CALC_TOTAL '220411KAS'
EXEC CALC_TOTAL '220411KSD'
EXEC CALC_TOTAL '220411MNI'
EXEC CALC_TOTAL '220411SLL'
EXEC CALC_TOTAL '220411QWE'
EXEC CALC_TOTAL '220411IBM'
EXEC CALC_TOTAL '220411EGN'
EXEC CALC_TOTAL '220411IGH'
EXEC CALC_TOTAL '220411LKH'
EXEC CALC_TOTAL '220409JQK'
EXEC CALC_TOTAL '220409MNI'
EXEC CALC_TOTAL '220408SLL'
EXEC CALC_TOTAL '220408QWE'
EXEC CALC_TOTAL '220408IBM'
EXEC CALC_TOTAL '220407EGN'
EXEC CALC_TOTAL '220406IGH'
EXEC CALC_TOTAL '220405LKH'
EXEC CALC_TOTAL '220404HYY'
EXEC CALC_TOTAL '220404UYU'
EXEC CALC_TOTAL '220404UYD'