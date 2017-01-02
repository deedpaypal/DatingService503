CREATE DATABASE DatingService;
GO

USE DatingService;
GO
CREATE TABLE Users(
Id int PRIMARY KEY IDENTITY,
Username varchar(30),
UserPassword varchar(30));
GO


CREATE TABLE Person(
Id int PRIMARY KEY,
FirstName nvarchar(35),
LastName nvarchar(35),
Sex nvarchar(7),
Birthday DATE,
CONSTRAINT fk_person_id FOREIGN KEY (id) REFERENCES users(id));

GO

create table PrivateInf(
Id int PRIMARY KEY,
Height decimal,
Weight decimal,
Phone nvarchar(11), CONSTRAINT	CK_phone CHECK (phone like '[6-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
constraint pffk_personId FOREIGN KEY (id) REFERENCES Person (id)
);

GO

CREATE TABLE Requirements(
Id int PRIMARY KEY,
AgeFrom int,
AgeAbove int,
PartnerCity varchar(20),
PartnerEducation varchar(30),
PartnerSex nvarchar(6)
CONSTRAINT fk_id FOREIGN KEY (Id) REFERENCES Person(id)
ON DELETE CASCADE    
 ON UPDATE CASCADE 
);
GO


CREATE TABLE City(
Id int PRIMARY KEY,
PersonCity nvarchar(20),
CONSTRAINT fk_city FOREIGN KEY (Id) REFERENCES Person(Id)
);

GO

CREATE TABLE Education(
id int PRIMARY KEY,
personEducation nvarchar(30),
constraint fk_education FOREIGN KEY (id) REFERENCES Person(id)
);

GO