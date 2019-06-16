USE QLBanVeXeKhach
GO

INSERT INTO dbo.QUYEN
VALUES
(1, N'Administrator'),
(2, N'Khách Hàng')
GO

INSERT INTO dbo.TAIKHOAN
VALUES
(1, 'vuongdq', '123456', N'Đinh Quang Vương', '1998-08-05', N'Ninh Bình', '0366613688', 'quangvuong0805@gmail.com', 1),
(2, 'truongtn', '123456', N'Trần Nhật Trường', '1997-01-01', N'Nam Định', '0961234567', 'nhattruongtran@gmail.com', 1),
(3, 'guest1', '123456', N'GUEST1', '1997-02-05', N'Sơn La', '0336661234', 'guest1@gmail.com', 2)
GO

INSERT INTO dbo.PHUONGTHUCTHANHTOAN
VALUES
(1, N'Tiền mặt', N'Thanh toán bằng tiền mặt khi đi xe'),
(2, N'Ví MoMo', N'Thanh toán qua ví điện tử MoMo'),
(3, N'Thẻ ATM nội địa', N'Thanh toán bằng thẻ ATM nội địa'),
(4, N'Thẻ Visa quốc tế', N'Thanh toán bằng thẻ ATM Visa Debit'),
(5, N'Thẻ Mastercard quốc tế', N'Thanh toán bằng thẻ ATM Matercard Debit')
GO

INSERT INTO dbo.HANGXE
VALUES
(1, N'Nhà xe Phúc Lợi', '/Content/images/pl250_2.jpg', N'Hãng xe Phúc Lợi chuyên cung cấp xe giường nằm cao cấp chạy tuyến Hà Nội – Vinh – Cửa Lò, Hà Nội – Vinh – Nam Đàn và ngược lại. Xe không bắt khách dọc đường, không chạy quá tốc độ, xuất bến đúng giờ, bán đúng số giường quy định, không tăng giá vé ngày lễ và được công ty niêm yết giá. Với phương châm: "Mang đến sự hài lòng cho quý khách", Phúc Lợi xác định việc lắng nghe ý kiến đóng góp của khách hàng là mục tiêu hàng đầu để phát triển và khẳng định thương hiệu của mình. Bên cạnh đó, công ty đã đầu tư xây dựng theo hướng bài bản và chuyên nghiệp.'),
(2, N'Nhà xe Văn Minh', '/Content/images/VAN_MINH_02.jpg', N'Hãng xe Văn Minh chuyên cung cấp xe giường nằm cao cấp chạy tuyến Hà Nội – Hà Tĩnh, Hà Nội – Cửa Lò – Vinh (Nghệ An). Đúng như tên gọi của mình, Nhà xe Văn Minh luôn giữ chữ tín, thân thiện với khách hàng, có xe trung chuyển đón và trả khách tận nhà. Xe luôn xuất phát đúng giờ, đi đúng tốc độ quy định, không bao giờ dừng lại bắt khách dọc đường (dù trên xe vẫn còn chỗ trống). Hãng xe Văn Minh cũng luôn giữ những quy định nghiêm khắc với đội ngũ tài xế lái xe để đảm bảo tối đa an toàn cho khách hàng. Sau 10 năm thành lập, Văn Minh đã phát triển vững mạnh, số lượng xe lên tới 24 xe giường nằm chất lượng cao. '),
(3, N'Nhà xe Phú Quý', '/Content/images/PHU_QUY_02.jpg', N'Là một trong những nhà xe đã tạo được thương hiệu lâu năm tại thị trường Hà Tĩnh, nhà xe Phú Quý luôn luôn được khách hàng tin tưởng lựa chọn qua nhiều năm phục vụ. Để phục vụ nhu cầu ngày càng cao của quý khách, xe Phú Quý không ngừng đổi mới, nâng cao chất lượng phục vụ để mang lại một dịch vụ hoàn hảo. Với hệ thống 6 chiếc xe giường nằm đời mới, chất lượng cao, trang thiết bị sang trọng, hiện đại. Trong xe có hệ thống điều hòa, máy lạnh, tivi phục vụ nhu cầu giải trí cho hành khách trên quãng đường gần 500 km từ Hà Tĩnh đi Hà Nội và ngược lại. Thêm vào đó, nhà xe còn phục vụ miễn phí nước uống, khăn lạnh, chăn gối đầy đủ.'),
(4, N'Nhà xe Việt Khánh', '/Content/images/vk250_3.jpg', N'Việt Khánh là thương hiệu mới xuất hiện ở tuy nhiên mỗi khi nhắc đến cái tên Việt Khánh thì khách hàng sẽ nghĩ ngay đến một hãng xe chuyên nghiệp. Bây giờ thì tiếng tăm của xe khách chất lượng cao mang thương hiệu Việt Khánh đã và đang khẳng định vị trí ở xứ Nghệ. Người ta bảo nhau tìm đến Việt Khánh, bởi nơi đây khách hàng mới thật sự được coi trọng. Với Việt Khánh, đội ngũ từ nhân viên lái xe, phụ lái đều được đào tạo bài bản về phong cách phục vụ, nói năng nhẹ nhàng, lịch sự, tận tình, chu đáo với khách hàng đến từng chi tiết nhỏ nhặt nhất.'),
(5, N'Nhà xe Hoàng Phú', '/Content/images/xe-hoang-phu-2.jpg', N'Công ty TNHH Dịch vụ Vận tải Hoàng Phú chạy tuyến Hà Nội – Quảng Ninh - Uông Bí – Hạ Long – Hòn Gai – Cẩm Phả. Được ra mắt vào 17/05/2007 xe Hoàng Phú cung cấp dịch vụ vận chuyển hành khách chuyên tuyến miền Bắc ngoài ra còn tuyến Hà Nội Quảng Ninh với số lượng xe lớn. Hiện tại, Dịch vụ xe Vip Limousine Transit Dcar New 9 chỗ hoạt động với thương hiệu “Hoàng Phú Limousine” cùng phương châm “Sự hài lòng của quý khách là mong mỏi của công ty” chúng tôi sẽ phục vụ đón trả quý khách tận nơi trong tuyến đường Quảng Ninh – Hà Nội, Hà Nội – Quảng Ninh.'),
(6, N'Nhà xe Vĩnh Thịnh', '/Content/images/vt.jpg', N'Xe Vĩnh Thịnh Limousine chuyên cung cấp dịch vụ xe limousine 9 chỗ VIP chạy tuyến Hà Nội – Thái Bình, và ngược lại. Với phương châm: “Mang đến sự hài lòng cho quý khách”, Công ty chúng tôi xác định việc lắng nghe ý kiến đóng góp của khách hàng là mục tiêu hàng đầu để xây dựng và khẳng định thương hiệu của mình.')
GO

INSERT INTO dbo.XEKHACH
VALUES
('29A-12345', '/Content/images/', 29, N'Quốc lộ 1', 2),
('29A-22222', '/Content/images/', 29, N'Quốc lộ 1', 2),
('29A-11111', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 2),
('29A-12789', '/Content/images/', 29, N'Quốc lộ 1', 2),
('29A-62871', '/Content/images/', 29, N'Quốc lộ 1', 2),
('29A-14789', '/Content/images/', 29, N'Quốc lộ 1', 1),
('29A-44444', '/Content/images/', 29, N'Quốc lộ 1', 1),
('29A-33333', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 1),
('29A-99999', '/Content/images/', 29, N'Quốc lộ 1', 1),
('29A-55555', '/Content/images/', 29, N'Quốc lộ 1', 1),
('29A-66666', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 3),
('29A-10666', '/Content/images/', 29, N'Quốc lộ 1', 3),
('29A-00001', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 3),
('29A-10001', '/Content/images/', 29, N'Quốc lộ 1', 3),
('29A-11115', '/Content/images/', 29, N'Quốc lộ 1', 3),
('29A-11113', '/Content/images/', 29, N'Quốc lộ 1', 4),
('29A-00011', '/Content/images/', 29, N'Quốc lộ 1', 4),
('29A-11001', '/Content/images/', 29, N'Quốc lộ 1', 4),
('29A-55883', '/Content/images/', 29, N'Quốc lộ 1', 4),
('29A-99872', '/Content/images/', 29, N'Quốc lộ 1', 4),
('29A-22547', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 5),
('29A-66777', '/Content/images/', 29, N'Quốc lộ 1', 5),
('29A-66886', '/Content/images/', 29, N'Quốc lộ 1', 5),
('29A-55789', '/Content/images/', 29, N'Quốc lộ 1', 5),
('29A-43210', '/Content/images/', 29, N'Quốc lộ 1', 5),
('29A-54321', '/Content/images/', 29, N'Quốc lộ 1', 6),
('29A-65432', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 6),
('29A-87654', '/Content/images/', 29, N'Quốc lộ 1', 6),
('29A-98765', '/Content/images/', 29, N'Quốc lộ 1', 6),
('29A-11689', '/Content/images/', 29, N'Cung đường: Đang cập nhật ...', 6)
GO 

INSERT INTO DIEMDEN
VALUES
(1, N'Hà Nội'),
(2, N'Sơn La'),
(3, N'Nam Định'),
(4, N'Thái Bình'),
(5, N'Hà Nam'),
(6, N'Ninh Bình'),
(7, N'Hòa Bình'),
(8, N'TPHCM'),
(9, N'Cao Bằng'),
(10, N'Quảng Ninh')
GO

INSERT INTO DIEMXUATPHAT
VALUES
(1, N'Hà Nội'),
(2, N'Sơn La'),
(3, N'Nam Định'),
(4, N'Thái Bình'),
(5, N'Hà Nam'),
(6, N'Ninh Bình'),
(7, N'Hòa Bình'),
(8, N'TPHCM'),
(9, N'Cao Bằng'),
(10, N'Quảng Ninh')
GO

INSERT INTO dbo.CHUYENXE
VALUES
(1, 1, 6, '2019-6-6 15:00:00', '2019-6-6 17:00:00', 10,70000.0, '29A-99999'),
(2, 1, 3, '2019-6-6 15:00:00', '2019-6-6 19:00:00', 10,170000.0, '29A-44444'),
(3, 1, 2, '2019-6-6 15:00:00', '2019-6-6 21:00:00', 10,270000.0, '29A-33333'),
(4, 1, 10, '2019-6-6 15:00:00', '2019-6-6 23:00:00', 10,370000.0, '29A-22222'),
(5, 1, 8, '2019-6-6 15:00:00', '2019-6-9 19:00:00', 10,970000.0, '29A-11111')
GO
