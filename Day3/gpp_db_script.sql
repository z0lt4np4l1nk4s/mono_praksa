create table public."Location"
(
	"Id" UUID not null,
	"Country" varchar not null,
	"City" varchar not null,
	"Address" varchar not null,
	"ZipCode" varchar not null,
	constraint "PK_Location_Id" primary key ("Id")
);

create table public."User" 
(
	"Id" UUID not null,
	"FirstName" varchar not null,
	"LastName" varchar not null,
	"Email" varchar,
	"PhoneNumber" varchar,
	"DateOfBirth" TIMESTAMP not null,
	"LocationId" UUID not null,
	constraint "PK_User_Id" primary key ("Id"),
	constraint "FK_User_Location_LocationId" foreign key ("LocationId") references public."Location"("Id")
);

create table public."Employee"
(
	"Id" UUID not null,
	"Department" varchar not null,
	"JoinDate" timestamp not null,
	constraint "PK_Employee_Id" primary key ("Id"),
	constraint "FK_Employee_User_Id" foreign key ("Id") references public."User"("Id")
);

create table public."Customer"
(
	"Id" UUID not null,
	"RegisterDate" timestamp not null,
	constraint "PK_Customer_Id" primary key ("Id"),
	constraint "FK_Customer_User_Id" foreign key ("Id") references public."User"("Id")
);

create table public."SellingPoint"
(
	"Id" UUID not null,
	"Name" varchar not null,
	"LocationId" UUID not null,
	"CreationTime" timestamp not null,
	constraint "PK_SellingPoint_Id" primary key ("Id"),
	constraint "FK_SellingPoint_Location_LocationId" foreign key ("LocationId") references public."Location"("Id")
);

create table public."ZoneType"
(
	"Id" UUID not null,
	"Name" varchar not null,
	constraint "PK_ZoneType_Id" primary key ("Id")
);

create table public."TicketType"
(
	"Id" UUID not null,
	"Name" varchar not null,
	constraint "PK_TicketType_Id" primary key ("Id")
);

create table public."PaymentType"
(
	"Id" UUID not null,
	"Name" varchar not null,
	constraint "PK_PaymentType_Id" primary key ("Id")
);

create table public."Ticket"
(
	"Id" UUID not null,
	"Price" decimal not null,
	"ZoneTypeId" UUID not null,
	"TicketTypeId" UUID not null,
	constraint "PK_Ticket_Id" primary key ("Id"),
	constraint "FK_Ticket_ZoneType_ZoneTypeId" foreign key ("ZoneTypeId") references public."ZoneType"("Id"),
	constraint "FK_Ticket_TicketType_TicketTypeId" foreign key ("TicketTypeId") references public."TicketType"("Id")
);

create table public."SoldTicket"
(
	"Id" UUID not null,
	"TicketId" UUID not null,
	"EmployeeId" UUID not null,
	"CustomerId" UUID not null,
	"SellingPointId" UUID not null,
	"PaymentTypeId" UUID not null,
	"CreationTime" timestamp not null,
	constraint "PK_SoldTicket_Id" primary key ("Id"),
	constraint "FK_SoldTicket_Ticket_TicketId" foreign key ("TicketId") references public."Ticket"("Id"),
	constraint "FK_SoldTicket_Employee_EmployeeId" foreign key ("EmployeeId") references public."Employee"("Id"),
	constraint "FK_SoldTicket_Customer_CustomerId" foreign key ("CustomerId") references public."Customer"("Id"),
	constraint "FK_SoldTicket_SellingPoint_SellingPointId" foreign key ("SellingPointId") references public."SellingPoint"("Id"),
	constraint "FK_SoldTicket_PaymentType_PaymentTypeId" foreign key ("PaymentTypeId") references public."PaymentType"("Id")
);

-- INSERT statements for "Location" table
INSERT INTO public."Location" ("Id", "Country", "City", "Address", "ZipCode")
VALUES
    ('2a335953-d63f-481f-8bdb-1a37edbf6b0a', 'Croatia', 'Osijek', '123 Main St', '31000'),
    ('88619290-ca6c-4dba-85f6-4f7ee4ea211e', 'Croatia', 'Osijek', '456 Park Ave', '31000'),
    ('00a632e1-4195-4a9a-bf63-35e29cdb0a2c', 'Croatia', 'Osijek', '789 Elm St', '31000'),
    ('1ff4281a-0716-4b92-864a-c61883ddbf54', 'Croatia', 'Osijek', '321 Oak St', '31000'),
    ('f58964bc-833f-4bfe-95c5-1cbfb115acb2', 'Croatia', 'Osijek', '987 Maple St', '31000'),
    ('70f20752-0083-427f-9c59-3f347abf2d45', 'Croatia', 'Osijek', '654 Pine St', '31000'),
    ('c9c7b9a5-4f17-4c2c-bbf0-4b199c43f5fd', 'Croatia', 'Osijek', '321 Cherry St', '31000'),
    ('16e6a7d2-f38b-4845-94b4-97ecbc3cacf0', 'Croatia', 'Osijek', '789 Walnut St', '31000'),
    ('62726bc5-ef70-4c9c-a71a-87334092b204', 'Croatia', 'Osijek', '987 Cedar St', '31000'),
    ('de2d1f9a-f93d-4c68-a3eb-89db49a8b153', 'Croatia', 'Osijek', '456 Birch St', '31000'),
    ('ebe3d8d9-3d5e-4d47-a8c4-6540eaa3e5c0', 'Croatia', 'Osijek', 'Street 1', '31000'),
    ('95170f46-91d7-4f4b-92a3-55d5a8a73e76', 'Croatia', 'Osijek', 'Street 2', '31000'),
    ('335cf0ab-5941-4f20-87d2-2f01d826ca7a', 'Croatia', 'Osijek', 'Street 3', '31000');

-- INSERT statements for "User" table
INSERT INTO public."User" ("Id", "FirstName", "LastName", "Email", "PhoneNumber", "DateOfBirth", "LocationId")
VALUES
    ('69cf1121-5f78-4b9b-b12b-7f8a52685376', 'John', 'Doe', 'johndoe@example.com', '1234567890', '1990-01-01', '2a335953-d63f-481f-8bdb-1a37edbf6b0a'),
    ('0fd6d25f-bbd4-417d-9c60-4e1b7cbf16a1', 'Jane', 'Smith', 'janesmith@example.com', '0987654321', '1995-02-15', '88619290-ca6c-4dba-85f6-4f7ee4ea211e'),
    ('4f5e7e02-c22e-4f0d-9ea5-74a131305b61', 'Mike', 'Johnson', 'mikejohnson@example.com', '5555555555', '1988-07-10', '00a632e1-4195-4a9a-bf63-35e29cdb0a2c'),
    ('8bbedd7a-2880-4f4a-9ae5-8ef3e35463e9', 'Emily', 'Davis', 'emilydavis@example.com', '9876543210', '1992-04-30', '1ff4281a-0716-4b92-864a-c61883ddbf54'),
    ('e0aafcd4-d288-4e22-9fb1-22f362cd75b3', 'Sarah', 'Wilson', 'sarahwilson@example.com', '1111111111', '1998-09-20', 'f58964bc-833f-4bfe-95c5-1cbfb115acb2'),
    ('2c4a9c34-48c6-4e61-a2a9-981b6c3e9b0d', 'Michael', 'Brown', 'michaelbrown@example.com', '2222222222', '1991-11-05', '70f20752-0083-427f-9c59-3f347abf2d45'),
    ('a29272a2-68ea-4827-92c1-04925dd5666c', 'Jessica', 'Taylor', 'jessicataylor@example.com', '3333333333', '1994-08-12', 'c9c7b9a5-4f17-4c2c-bbf0-4b199c43f5fd'),
    ('8f4e76c7-8432-4023-bb99-bd120fa437de', 'David', 'Wilson', 'davidwilson@example.com', '4444444444', '1987-03-25', '16e6a7d2-f38b-4845-94b4-97ecbc3cacf0'),
    ('7423037e-4e17-4d8e-a370-6d0de8828a48', 'Amanda', 'Clark', 'amandaclark@example.com', '5555555555', '1993-06-18', '62726bc5-ef70-4c9c-a71a-87334092b204'),
    ('c942d0c6-ba5c-46e1-8e48-2d4e5cfa15b7', 'Ryan', 'Miller', 'ryanmiller@example.com', '6666666666', '1997-12-08', 'de2d1f9a-f93d-4c68-a3eb-89db49a8b153');

-- INSERT statements for "Employee" table
INSERT INTO public."Employee" ("Id", "Department", "JoinDate")
VALUES
    ('69cf1121-5f78-4b9b-b12b-7f8a52685376', 'IT', NOW()),
    ('0fd6d25f-bbd4-417d-9c60-4e1b7cbf16a1', 'Sales', NOW()),
    ('4f5e7e02-c22e-4f0d-9ea5-74a131305b61', 'HR', NOW()),
    ('8bbedd7a-2880-4f4a-9ae5-8ef3e35463e9', 'Finance', NOW()),
    ('e0aafcd4-d288-4e22-9fb1-22f362cd75b3', 'Marketing', NOW());
   
-- INSERT statements for "Customer" table
INSERT INTO public."Customer" ("Id", "RegisterDate")
VALUES
    ('2c4a9c34-48c6-4e61-a2a9-981b6c3e9b0d', TIMESTAMP '2023-06-20 09:30:00'),
    ('a29272a2-68ea-4827-92c1-04925dd5666c', TIMESTAMP '2023-07-01 14:45:00'),
    ('8f4e76c7-8432-4023-bb99-bd120fa437de', TIMESTAMP '2023-06-25 18:20:00'),
    ('7423037e-4e17-4d8e-a370-6d0de8828a48', TIMESTAMP '2023-06-27 11:10:00'),
    ('c942d0c6-ba5c-46e1-8e48-2d4e5cfa15b7', TIMESTAMP '2023-06-18 16:55:00');

-- INSERT statements for "SellingPoint" table
INSERT INTO public."SellingPoint" ("Id", "Name", "LocationId", "CreationTime")
VALUES
    ('6887bca5-5d22-4b07-8919-604e8a786982', 'Selling Point 1', 'ebe3d8d9-3d5e-4d47-a8c4-6540eaa3e5c0', NOW()),
    ('3e7d822d-9c2e-4f1e-b6c1-4f4f14a0a5da', 'Selling Point 2', '95170f46-91d7-4f4b-92a3-55d5a8a73e76', NOW()),
    ('9b6ac5a0-d01d-4a32-8a8e-758d3ebf8c17', 'Selling Point 3', '335cf0ab-5941-4f20-87d2-2f01d826ca7a', NOW());
   
-- INSERT statements for "ZoneType" table
INSERT INTO public."ZoneType" ("Id", "Name")
VALUES
    ('1245f720-ca18-4079-8830-51c459adc32a', 'Zone 1'),
    ('18320869-3e3e-4b1f-a217-6d1b17b835b1', 'Zone 2');
   
-- INSERT statements for "TicketType" table
INSERT INTO public."TicketType" ("Id", "Name")
VALUES
    ('dbd6a6e2-24c0-4eb0-aab4-7eef2e82c2cc', 'Student'),
    ('42e8fb42-5324-4b10-9b4f-8a8eb0d5a0c4', 'Pensioner'),
    ('1966c85b-48ff-4d33-8e20-5b2ed3048998', 'Adult'),
    ('f8f4a1b2-bcda-4a0d-bc75-6f3a8a4a3c5d', 'Child'),
    ('e67e5c94-0571-4b79-b8b6-cd33d9b1d6ff', 'Family');

-- INSERT statements for "PaymentType" table
INSERT INTO public."PaymentType" ("Id", "Name")
VALUES
    ('bb25ddf2-831a-4166-a231-d914d390d627', 'Cash'),
    ('931c3f64-c88e-4a7b-84e2-ea1a3b6ed79a', 'Card');
   
-- INSERT statements for "Ticket" table
INSERT INTO public."Ticket" ("Id", "Price", "ZoneTypeId", "TicketTypeId")
VALUES
    ('c8a5b15e-8bdc-4c9d-aecd-6f4ac5f0485d', 25.99, '1245f720-ca18-4079-8830-51c459adc32a', 'dbd6a6e2-24c0-4eb0-aab4-7eef2e82c2cc'),
    ('d29d3ae7-4ab2-4c24-98a6-5247dfb86232', 12.50, '1245f720-ca18-4079-8830-51c459adc32a', '42e8fb42-5324-4b10-9b4f-8a8eb0d5a0c4'),
    ('c45dc172-43a3-4b2a-bf78-7f6c6867e3e0', 18.75, '18320869-3e3e-4b1f-a217-6d1b17b835b1', '1966c85b-48ff-4d33-8e20-5b2ed3048998'),
    ('f5f7b5d6-cc20-4a74-92ff-ecb6e0ff1b44', 8.99, '18320869-3e3e-4b1f-a217-6d1b17b835b1', 'f8f4a1b2-bcda-4a0d-bc75-6f3a8a4a3c5d'),
    ('7d901be3-9a6b-48bc-932b-9c5df6464d42', 35.00, '1245f720-ca18-4079-8830-51c459adc32a', 'e67e5c94-0571-4b79-b8b6-cd33d9b1d6ff'),
    ('ecde8489-43e1-4427-9b8e-91a02d2a9b59', 14.99, '1245f720-ca18-4079-8830-51c459adc32a', '42e8fb42-5324-4b10-9b4f-8a8eb0d5a0c4'),
    ('d4e5e0c4-3a6d-4e54-84af-7b5c0ee5daeb', 29.50, '18320869-3e3e-4b1f-a217-6d1b17b835b1', '1966c85b-48ff-4d33-8e20-5b2ed3048998'),
    ('9011e422-2d9a-48b1-9a56-b03452f5459a', 9.99, '1245f720-ca18-4079-8830-51c459adc32a', 'f8f4a1b2-bcda-4a0d-bc75-6f3a8a4a3c5d');

-- INSERT statements for "SoldTicket" table
INSERT INTO public."SoldTicket" ("Id", "TicketId", "EmployeeId", "CustomerId", "SellingPointId", "PaymentTypeId", "CreationTime")
VALUES
    ('d262c5a7-8b11-4a8d-a543-6c87c47e7c79', 'c8a5b15e-8bdc-4c9d-aecd-6f4ac5f0485d', '69cf1121-5f78-4b9b-b12b-7f8a52685376', '2c4a9c34-48c6-4e61-a2a9-981b6c3e9b0d', '6887bca5-5d22-4b07-8919-604e8a786982', 'bb25ddf2-831a-4166-a231-d914d390d627', NOW()),
    ('c401d2a1-8b4a-4e1b-9db6-287a0c7379e1', 'd29d3ae7-4ab2-4c24-98a6-5247dfb86232', '0fd6d25f-bbd4-417d-9c60-4e1b7cbf16a1', 'a29272a2-68ea-4827-92c1-04925dd5666c', '3e7d822d-9c2e-4f1e-b6c1-4f4f14a0a5da', '931c3f64-c88e-4a7b-84e2-ea1a3b6ed79a', NOW()),
    ('fd5d5be3-6df8-4e67-9935-7f9e88af3278', 'c45dc172-43a3-4b2a-bf78-7f6c6867e3e0', '4f5e7e02-c22e-4f0d-9ea5-74a131305b61', '8f4e76c7-8432-4023-bb99-bd120fa437de', '9b6ac5a0-d01d-4a32-8a8e-758d3ebf8c17', 'bb25ddf2-831a-4166-a231-d914d390d627', NOW()),
    ('3982e7e5-b4cd-4f5e-b5d7-bcfd85d2270e', 'f5f7b5d6-cc20-4a74-92ff-ecb6e0ff1b44', '8bbedd7a-2880-4f4a-9ae5-8ef3e35463e9', '7423037e-4e17-4d8e-a370-6d0de8828a48', '6887bca5-5d22-4b07-8919-604e8a786982', '931c3f64-c88e-4a7b-84e2-ea1a3b6ed79a', NOW()),
    ('07a348e9-2aae-4009-bbaf-741b234be746', '7d901be3-9a6b-48bc-932b-9c5df6464d42', 'e0aafcd4-d288-4e22-9fb1-22f362cd75b3', 'c942d0c6-ba5c-46e1-8e48-2d4e5cfa15b7', '3e7d822d-9c2e-4f1e-b6c1-4f4f14a0a5da', 'bb25ddf2-831a-4166-a231-d914d390d627', NOW()),
    ('dc74b13c-5f0f-448f-a5d0-25024d4e9e50', 'ecde8489-43e1-4427-9b8e-91a02d2a9b59', '69cf1121-5f78-4b9b-b12b-7f8a52685376', '2c4a9c34-48c6-4e61-a2a9-981b6c3e9b0d', '9b6ac5a0-d01d-4a32-8a8e-758d3ebf8c17', 'bb25ddf2-831a-4166-a231-d914d390d627', NOW()),
    ('4e8cc272-50eb-49eb-bb2d-13ce7f1ddc81', 'd4e5e0c4-3a6d-4e54-84af-7b5c0ee5daeb', '0fd6d25f-bbd4-417d-9c60-4e1b7cbf16a1', 'a29272a2-68ea-4827-92c1-04925dd5666c', '3e7d822d-9c2e-4f1e-b6c1-4f4f14a0a5da', '931c3f64-c88e-4a7b-84e2-ea1a3b6ed79a', NOW()),
    ('1b7f0f79-7be7-4a51-aaaf-1b3b5b2357f7', 'c8a5b15e-8bdc-4c9d-aecd-6f4ac5f0485d', '4f5e7e02-c22e-4f0d-9ea5-74a131305b61', '8f4e76c7-8432-4023-bb99-bd120fa437de', '6887bca5-5d22-4b07-8919-604e8a786982', '931c3f64-c88e-4a7b-84e2-ea1a3b6ed79a', NOW()),
    ('9425f7ad-1e0f-4a17-b3f5-3f97dbdddb54', 'd29d3ae7-4ab2-4c24-98a6-5247dfb86232', 'e0aafcd4-d288-4e22-9fb1-22f362cd75b3', '7423037e-4e17-4d8e-a370-6d0de8828a48', '9b6ac5a0-d01d-4a32-8a8e-758d3ebf8c17', 'bb25ddf2-831a-4166-a231-d914d390d627', NOW()),
    ('c24d91c5-619d-4ab2-9e3a-7372f1d73ef8', '9011e422-2d9a-48b1-9a56-b03452f5459a', '8bbedd7a-2880-4f4a-9ae5-8ef3e35463e9', 'c942d0c6-ba5c-46e1-8e48-2d4e5cfa15b7', '6887bca5-5d22-4b07-8919-604e8a786982', 'bb25ddf2-831a-4166-a231-d914d390d627', NOW());


select * from public."User";

select * from public."User" where DATE_PART('year', age(NOW(), "DateOfBirth")) < 31;

INSERT INTO public."User" ("Id", "FirstName", "LastName", "Email", "PhoneNumber", "DateOfBirth", "LocationId")
VALUES
    ('69cfff21-5f78-4b9b-b12b-7f8a52685376', 'Pero', 'Peric', 'peroperic@gmail.com', '45694512347', '1998-05-010', '2a335953-d63f-481f-8bdb-1a37edbf6b0a');
    
select u.*, l."Country", l."City", l."ZipCode", l."Address" from public."User" u left join public."Location" l on u."LocationId" = l."Id";

select u.*, l."Country", l."City", l."ZipCode", l."Address" from public."User" u right join public."Location" l on u."LocationId" = l."Id";

select u.*, l."Country", l."City", l."ZipCode", l."Address" from public."User" u inner join public."Location" l on u."LocationId" = l."Id";

select u.*, l."Country", l."City", l."ZipCode", l."Address" from public."Location" l inner join public."User" u on u."LocationId" = l."Id";

delete from public."User" where "Id" = '69cfff21-5f78-4b9b-b12b-7f8a52685376';

select * from public."User";

update public."User" set "PhoneNumber" = '0918905670' where "Id" = 'e0aafcd4-d288-4e22-9fb1-22f362cd75b3';
   
select u.*, emp."Department", emp."JoinDate"  from public."Employee" emp left join public."User" u ON emp."Id" = u."Id";

select u.*, emp."Department", emp."JoinDate"  from public."Employee" emp right join public."User" u ON emp."Id" = u."Id";

select u.*, emp."Department", emp."JoinDate"  from public."Employee" emp inner join public."User" u ON emp."Id" = u."Id";

select st.*, c."RegisterDate" from public."SoldTicket" st left join public."Customer" c ON st."CustomerId" = c."Id";

select st.*, c."RegisterDate" from public."SoldTicket" st right join public."Customer" c ON st."CustomerId" = c."Id";

select st.*, c."RegisterDate" from public."SoldTicket" st inner join public."Customer" c ON st."CustomerId" = c."Id";

select st.*, e."Department", e."JoinDate" from public."SoldTicket" st left join public."Employee" e ON st."EmployeeId" = e."Id";

select st.*, e."Department", e."JoinDate" from public."SoldTicket" st right join public."Employee" e ON st."EmployeeId" = e."Id";

select st.*, e."Department", e."JoinDate" from public."SoldTicket" st inner join public."Employee" e ON st."EmployeeId" = e."Id";

select * from public."TicketType" tt left join public."Ticket" t on tt."Id" = t."TicketTypeId";

select uc."FirstName" || ' ' || uc."LastName" as "CustomerName", ue."FirstName" || ' ' || ue."LastName" as "EmployeeName", 
	  l."Country" || ', ' || l."ZipCode" || ' ' || l."City" || ', ' || l."Address" as "Location",
	  t."Price", pt."Name" as "PaymentType", tt."Name" as "TicketType", zt."Name" as "ZoneType", st."CreationTime"
      from public."SoldTicket" st 
      inner join public."PaymentType" pt on st."PaymentTypeId" = pt."Id"
      inner join public."SellingPoint" sp on st."SellingPointId" = sp."Id"
      inner join public."Employee" e on st."EmployeeId" = e."Id"
      inner join public."User" ue on ue."Id" = e."Id"
      inner join public."Customer" c on st."CustomerId" = c."Id"
      inner join public."User" uc on uc."Id" = c."Id"
      inner join public."Ticket" t on st."TicketId" = t."Id"
      inner join public."ZoneType" zt on t."ZoneTypeId" = zt."Id"
      inner join public."TicketType" tt on t."TicketTypeId" = tt."Id"
      inner join public."Location" l on sp."LocationId" = l."Id";