USE db_hotel;

CREATE TABLE customers (
	customer_id INT NOT NULL IDENTITY(1,1),
	first_name VARCHAR(32) NOT NULL,
	last_name VARCHAR(32) NOT NULL,
	nik CHAR(16) NOT NULL,
	phone_number CHAR(13) NOT NULL,
	email VARCHAR(64) NOT NULL,
	CONSTRAINT PK_customers PRIMARY KEY(customer_id)
)

CREATE TABLE room_facilities (
	room_type CHAR(3) NOT NULL CHECK(room_type='REG' or room_type='VIP'),
	bed VARCHAR(16) NOT NULL,
	internet CHAR(10) NOT NULL,
	CONSTRAINT PK_facilities PRIMARY KEY(room_type)
)

CREATE TABLE room_facility_bathrooms (
	name_of_facility VARCHAR(128) NOT NULL,
	room_type CHAR(3) NOT NULL CHECK(room_type='REG' or room_type='VIP'),
	CONSTRAINT FK_facilities_bathroom FOREIGN KEY(room_type)
		REFERENCES room_facilities(room_type)
		ON UPDATE CASCADE ON DELETE NO ACTION
)

CREATE TABLE room_facility_others (
	name_of_facility VARCHAR(128) NOT NULL,
	room_type CHAR(3) NOT NULL CHECK(room_type='REG' or room_type='VIP'),
	CONSTRAINT FK_facilities_other FOREIGN KEY(room_type)
		REFERENCES room_facilities(room_type)
		ON UPDATE CASCADE ON DELETE NO ACTION
)

CREATE TABLE rooms (
	room_id INT NOT NULL IDENTITY(1,1),
	room_code VARCHAR(9) NOT NULL,
	room_floor TINYINT NOT NULL,
	room_number TINYINT NOT NULL,
	square_meter TINYINT NOT NULL,
	room_type CHAR(3) NOT NULL CHECK(room_type='REG' or room_type='VIP'),
	CONSTRAINT PK_rooms PRIMARY KEY(room_id),
	CONSTRAINT FK_room_facilities FOREIGN KEY(room_type)
		REFERENCES room_facilities(room_type)
		ON UPDATE CASCADE ON DELETE NO ACTION
)

CREATE TABLE reservations (
	reservation_id INT NOT NULL IDENTITY(1,1),
	reservation_code CHAR(5) NOT NULL,
	number_of_guests TINYINT NOT NULL,
	checkin DATETIME NOT NULL,
	checkout DATETIME NOT NULL,
	reservation_status CHAR(7) NOT NULL CHECK(reservation_status='checkin' or reservation_status='booking'),
	customer_id INT NOT NULL,
	room_id INT NOT NULL,
	CONSTRAINT PK_reservations PRIMARY KEY(reservation_id),
	CONSTRAINT FK_customers_reservations FOREIGN KEY(customer_id) 
		REFERENCES customers(customer_id)
		ON UPDATE CASCADE ON DELETE NO ACTION,
	CONSTRAINT FK_rooms_reservations FOREIGN KEY(room_id)
		REFERENCES rooms(room_id)
		ON UPDATE CASCADE ON DELETE NO ACTION
)

CREATE TABLE histories (
	history_id INT NOT NULL IDENTITY(1,1),
	reservation_code CHAR(5) NOT NULL,
	number_of_guests TINYINT NOT NULL,
	checkin DATETIME NOT NULL,
	checkout DATETIME NOT NULL,
	customer_id INT NOT NULL,
	room_id INT NOT NULL,
	CONSTRAINT PK_histories PRIMARY KEY(history_id),
	CONSTRAINT FK_customers_histories FOREIGN KEY(customer_id) 
		REFERENCES customers(customer_id)
		ON UPDATE CASCADE ON DELETE NO ACTION,
	CONSTRAINT FK_rooms_histories FOREIGN KEY(room_id)
		REFERENCES rooms(room_id)
		ON UPDATE CASCADE ON DELETE NO ACTION
)

--reset seed
--DELETE FROM customers;
--DELETE FROM rooms;
--DELETE FROM facilities;
--DELETE FROM reservations;
--DELETE FROM histories;
--DBCC CHECKIDENT(customers, RESEED, 0);
--DBCC CHECKIDENT(rooms, RESEED, 0);
--DBCC CHECKIDENT(facilities, RESEED, 0);
--DBCC CHECKIDENT(reservations, RESEED, 0);
--DBCC CHECKIDENT(histories, RESEED, 0);