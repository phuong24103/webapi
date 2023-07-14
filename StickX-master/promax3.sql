use StickX
go

select * from colors
select * from sizes
select * from products
select * from roles
select * from accounts
select * from ranks
select * from vouchers
select * from FavoriteProducts
select * from Bills
select * from Billdetails
select * from Carts
select * from Cartdetails

insert into colors values
('c182c31d-df33-4a03-8e21-f45ad985008d', 'black', 0),
('c182c31d-df33-4a03-8e22-f45ad985008d', 'white', 0),
('c182c31d-df33-4a03-8e23-f45ad985008d', 'red', 0)
go
insert into sizes values 
('c182c31d-df33-4a03-8e26-f45ad985001d', '37', 0),
('c182c31d-df33-4a03-8e26-f45ad985002d', '38', 0),
('c182c31d-df33-4a03-8e26-f45ad985003d', '40', 0),
('c182c31d-df33-4a03-8e26-f45ad985004d', '41', 0),
('c182c31d-df33-4a03-8e26-f45ad985005d', '42', 0)
go
insert into products values 
('68b79481-b660-43cf-9c06-3f1f627328f1','Jordan 6 Retro', 740000, 99,'Air_Jordan-6_Retro_Metalli_Silver.jpeg','Nike', 0, 2,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985001d'),
('68b79481-b660-43cf-9c06-3f1f627328f2','Jordan 6 Retro', 750000, 99,'Air_Jordan-6_Retro_Metalli_Silver.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985002d'),
('68b79481-b660-43cf-9c06-3f1f627328f3','Jordan 6 Retro', 760000, 99,'Air_Jordan-6_Retro_Metalli_Silver.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627328f4','Jordan 6 Retro', 180000, 99,'Air_Jordan_6_Retro_BP_White.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985001d'),
('68b79481-b660-43cf-9c06-3f1f627328f5','Jordan 6 Retro', 190000, 99,'Air_Jordan_6_Retro_BP_White.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985002d'),
('68b79481-b660-43cf-9c06-3f1f627328f6','Jordan 6 Retro', 200000, 100,'Air_Jordan_6_Retro_BP_White.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627328f7','Jordan 6 Retro', 430000, 100,'Air_Jordan_6_Retro_Toro_Bravo.jpeg','Nike', 0, 1,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985001d'),
('68b79481-b660-43cf-9c06-3f1f627328f8','Jordan 6 Retro', 440000, 100,'Air_Jordan_6_Retro_Toro_Bravo.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985002d'),
('68b79481-b660-43cf-9c06-3f1f627328f9','Jordan 6 Retro', 450000, 100,'Air_Jordan_6_Retro_Toro_Bravo.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627321f0','Yeezy Boost 350 V2', 560000, 100,'adidas_Yeezy_Boost_350_V2_Onyx.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627322f0','Yeezy Boost 350 V2', 570000, 100,'adidas_Yeezy_Boost_350_V2_Onyx.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627323f0','Yeezy Boost 350 V2', 580000, 100,'adidas_Yeezy_Boost_350_V2_Onyx.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627324f0','Yeezy Boost 350 V2', 890000, 100,'Adidas_Yeezy_Boost_350_V2_Cream_White_1_1.jpeg','Adidas', 0, 1,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627325f0','Yeezy Boost 350 V2', 900000, 100,'Adidas_Yeezy_Boost_350_V2_Cream_White_1_1.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627326f0','Yeezy Boost 350 V2', 910000, 100,'Adidas_Yeezy_Boost_350_V2_Cream_White_1_1.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627327f0','Yeezy Boost 350 V2', 750000, 100,'Adidas_Yeezy_Boost_350_V2_Core_Black_Red.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627328f0','Yeezy Boost 350 V2', 760000, 100,'Adidas_Yeezy_Boost_350_V2_Core_Black_Red.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627329f0','Yeezy Boost 350 V2', 770000, 100,'Adidas_Yeezy_Boost_350_V2_Core_Black_Red.jpeg','Adidas', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627301f0','Nike Air Force 1 Low', 300000, 100,'Nike-Air-Force-1-Low-07-Black-White-Pebbled-Leather-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627312f0','Nike Air Force 1 Low', 310000, 100,'Nike-Air-Force-1-Low-07-Black-White-Pebbled-Leather-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627393f0','Nike Air Force 1 Low', 320000, 100,'Nike-Air-Force-1-Low-07-Black-White-Pebbled-Leather-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627334f0','Nike Air Force 1 Low', 220000, 100,'Nike-Air-Force-1-Low-White-07_V2-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627345f0','Nike Air Force 1 Low', 230000, 100,'Nike-Air-Force-1-Low-White-07_V2-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627356f0','Nike Air Force 1 Low', 240000, 100,'Nike-Air-Force-1-Low-White-07_V2-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627367f0','Nike Air Force 1 Low', 250000, 100,'Nike-Air-Force-1-Low-07-Retro-Color-of-the-Month-University-Red-White-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627378f0','Nike Air Force 1 Low', 260000, 100,'Nike-Air-Force-1-Low-07-Retro-Color-of-the-Month-University-Red-White-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627389f0','Nike Air Force 1 Low', 270000, 100,'Nike-Air-Force-1-Low-07-Retro-Color-of-the-Month-University-Red-White-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627101f0','Vans Old Skool', 150000, 100,'Vans-Old-Skool-Black-White-Product.jpeg','Vans', 0, 1,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627212f0','Vans Old Skool', 160000, 100,'Vans-Old-Skool-Black-White-Product.jpeg','Vans', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627434f0','Vans Old Skool', 150000, 100,'Vans-Old-Skool-True-White-2019-Product.jpeg','Vans', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627545f0','Vans Old Skool', 160000, 100,'Vans-Old-Skool-True-White-2019-Product.jpeg','Vans', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627667f0','Vans Old Skool', 200000, 100,'Vans-Old-Skool-Checkerboard-Racing-Red-Product.jpeg','Vans', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627778f0','Vans Old Skool', 210000, 100,'Vans-Old-Skool-Checkerboard-Racing-Red-Product.jpeg','Vans', 0, 0,'Fantastic','c182c31d-df33-4a03-8e23-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627181f0','SB Dunk Low', 360000, 100,'Nike-SB-Dunk-Low-Black-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985001d'),
('68b79481-b660-43cf-9c06-3f1f627292f0','SB Dunk Low', 370000, 100,'Nike-SB-Dunk-Low-Black-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985002d'),
('68b79481-b660-43cf-9c06-3f1f627100f0','SB Dunk Low', 380000, 100,'Nike-SB-Dunk-Low-Black-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627200f0','SB Dunk Low', 390000, 100,'Nike-SB-Dunk-Low-Black-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627381f0','SB Dunk Low', 400000, 100,'Nike-SB-Dunk-Low-Black-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e21-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d'),
('68b79481-b660-43cf-9c06-3f1f627400f0','SB Dunk Low', 380000, 100,'Nike-SB-Dunk-Low-White-Gum-Product.jpeg','Nike', 0, 1,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985001d'),
('68b79481-b660-43cf-9c06-3f1f627500f0','SB Dunk Low', 390000, 100,'Nike-SB-Dunk-Low-White-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985002d'),
('68b79481-b660-43cf-9c06-3f1f627600f0','SB Dunk Low', 400000, 100,'Nike-SB-Dunk-Low-White-Gum-Product.jpeg','Nike', 0, 1,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985003d'),
('68b79481-b660-43cf-9c06-3f1f627700f0','SB Dunk Low', 410000, 100,'Nike-SB-Dunk-Low-White-Gum-Product.jpeg','Nike', 0, 0,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985004d'),
('68b79481-b660-43cf-9c06-3f1f627800f0','SB Dunk Low', 420000, 100,'Nike-SB-Dunk-Low-White-Gum-Product.jpeg','Nike', 0, 1,'Fantastic','c182c31d-df33-4a03-8e22-f45ad985008d','c182c31d-df33-4a03-8e26-f45ad985005d')
go
insert into roles values
('9d76eb12-8c3c-4dcf-a389-4a807ecf0a31','Admin','active','0'),
('9d76eb12-8c3c-4dcf-a389-4a807ecf0a32','Customer','active','0')
go
insert into ranks values
('eaee20af-2adc-4b77-908a-67efb1188731','Diamond','2003'),
('eaee20af-2adc-4b77-908a-67efb1188732','Gold','1000'),
('eaee20af-2adc-4b77-908a-67efb1188733','Silver','500'),
('eaee20af-2adc-4b77-908a-67efb1188734','Not Rated','0')
go
insert into accounts values
('95487798-68cd-4518-8e49-fef358ab8cc1','phuongdeptraipromax','123','10/24/2003',0,'0349152003','phuongpnqph28229@fpt.edu.vn','Nam Dinh','3000','0','9D76EB12-8C3C-4DCF-A389-4A807ECF0A31','eaee20af-2adc-4b77-908a-67efb1188731'),
('95487798-68cd-4518-8e49-fef358ab8cc2','thanhtungmtp','123','10/20/2003',0,'0787175709','tunghtph28750@fpt.edu.vn','Ninh Binh','243','0','9D76EB12-8C3C-4DCF-A389-4A807ECF0A32','eaee20af-2adc-4b77-908a-67efb1188734'),
('95487798-68cd-4518-8e49-fef358ab8cc3','vuthecuong','123','3/8/2003',0,'0969523808','cuongvtph28428@fpt.edu.vn','Ha Noi','38','0','9D76EB12-8C3C-4DCF-A389-4A807ECF0A32','eaee20af-2adc-4b77-908a-67efb1188734')
go
insert into vouchers values 
('99fa04db-de10-4891-baf4-0188541db333','discount ','20','6/1/2023','1/8/2023','0'),
('99fa04db-de10-4891-baf4-0188541db331','Shocking discount','50','6/1/2023','7/1/2023','0'),
('99fa04db-de10-4891-baf4-0188541db332','discount','10','5/25/2023','5/27/2023','0')
go
insert into FavoriteProducts values
('95487798-68cd-4518-8e49-fef358ab8cc1', '68b79481-b660-43cf-9c06-3f1f627328f1', ''),
('95487798-68cd-4518-8e49-fef358ab8cc2', '68b79481-b660-43cf-9c06-3f1f627101f0', ''),
('95487798-68cd-4518-8e49-fef358ab8cc3', '68b79481-b660-43cf-9c06-3f1f627328f1', ''),
('95487798-68cd-4518-8e49-fef358ab8cc1', '68b79481-b660-43cf-9c06-3f1f627100f0', ''),
('95487798-68cd-4518-8e49-fef358ab8cc2', '68b79481-b660-43cf-9c06-3f1f627324f0', ''),
('95487798-68cd-4518-8e49-fef358ab8cc3', '68b79481-b660-43cf-9c06-3f1f627328f7', '')
go
insert into Bills values
('e6ba166b-a6e1-4b47-add8-da02b7d653f2', 1490000, '6/6/2023', 0, '99fa04db-de10-4891-baf4-0188541db331', '95487798-68cd-4518-8e49-fef358ab8cc2'),
('e6ba166b-a6e1-4b47-add8-da02b7d653f1', 940000, '6/6/2023', 0, '99fa04db-de10-4891-baf4-0188541db331', '95487798-68cd-4518-8e49-fef358ab8cc2'),
('e6ba166b-a6e1-4b47-add8-da02b7d653f3', 380000, '6/6/2023', 0, '99fa04db-de10-4891-baf4-0188541db331', '95487798-68cd-4518-8e49-fef358ab8cc3')
go
insert into Billdetails values
('77b34117-58a6-4dab-95df-8b4333dce07d', 1, 740000, 'e6ba166b-a6e1-4b47-add8-da02b7d653f2', '68b79481-b660-43cf-9c06-3f1f627328f1'),
('77b34117-58a6-4dab-95df-8b4333dce08d', 1, 750000, 'e6ba166b-a6e1-4b47-add8-da02b7d653f2', '68b79481-b660-43cf-9c06-3f1f627328f2'),
('77b34117-58a6-4dab-95df-8b4333dce09d', 1, 760000, 'e6ba166b-a6e1-4b47-add8-da02b7d653f1', '68b79481-b660-43cf-9c06-3f1f627328f3'),
('77b34117-58a6-4dab-95df-8b4333dce00d', 1, 180000, 'e6ba166b-a6e1-4b47-add8-da02b7d653f1', '68b79481-b660-43cf-9c06-3f1f627328f4'),
('77b34117-58a6-4dab-95df-8b4333dce01d', 2, 190000, 'e6ba166b-a6e1-4b47-add8-da02b7d653f3', '68b79481-b660-43cf-9c06-3f1f627328f5')
go
insert into Carts values
('95487798-68cd-4518-8e49-fef358ab8cc2', ''),
('95487798-68cd-4518-8e49-fef358ab8cc3', '')
go
insert into Cartdetails(Id, Quantity, AccountID, ProductID) values
('6dc673e4-1aa3-4067-b1dc-e2609d3051ba', 1, '95487798-68cd-4518-8e49-fef358ab8cc2', '68b79481-b660-43cf-9c06-3f1f627328f5'),
('6dc673e4-1aa3-4067-b1dc-e2609d3052ba', 1, '95487798-68cd-4518-8e49-fef358ab8cc2', '68b79481-b660-43cf-9c06-3f1f627328f3'),
('6dc673e4-1aa3-4067-b1dc-e2609d3053ba', 1, '95487798-68cd-4518-8e49-fef358ab8cc3', '68b79481-b660-43cf-9c06-3f1f627328f1')
go