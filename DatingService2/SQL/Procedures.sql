USE DatingService;
GO
CREATE PROCEDURE dbo.Users_Delete(
@id int)
as
DELETE FROM Users WHERE id = @id;

GO

CREATE PROCEDURE [dbo].[Requirements_Update](
@id int,
@agefrom int,
@ageabove int,
@partnercity nvarchar(20),
@partnereducation nvarchar(30),
@partnersex nvarchar(6)
)
as
begin
update Requirements set
AgeFrom = @agefrom, AgeAbove = @ageabove, PartnerCity = @partnercity,
PartnerEducation = @partnereducation, PartnerSex = @partnersex where Id = @id
end 

GO

CREATE PROCEDURE [dbo].[Requirements_Insert](
@id int,
@agefrom int,
@ageabove int,
@city varchar(20),
@education varchar(30),
@sex nvarchar(6)
)
as

SET NOCOUNT ON
INSERT INTO Requirements(Id, AgeFrom, AgeAbove, PartnerCity, PartnerEducation,PartnerSex)
VALUES(@id, @agefrom, @ageabove, @city, @education, @sex);

GO

CREATE PROCEDURE [dbo].[Requirements_Delete](
@id int)
as
DELETE FROM Requirements WHERE id = @id;

GO

CREATE PROCEDURE [dbo].[PrivateInf_Update](
@id int,
@height decimal,
@weight decimal,
@phone nvarchar(11)
)
as
begin
update PrivateInf set
Height = @height, Weight = @height, phone = @phone where Id = @id
end  

GO

CREATE PROCEDURE [dbo].[PrivateInf_Insert](
@id int,
@height decimal,
@weight decimal,
@phone nvarchar(11)
)
as

SET NOCOUNT ON
INSERT INTO PrivateInf(Id, Height, Weight, phone)
VALUES(@id, @height, @weight, @phone); 

GO

CREATE PROCEDURE dbo.PrivateInf_Delete(
@id int)
as
DELETE FROM PrivateInf WHERE id = @id;

GO

CREATE PROCEDURE [dbo].[Education_Update](
@id int,
@personeducation nvarchar(30)
)
as
begin
update Education set
 PersonEducation = @personeducation where Id = @id
end ;

GO

CREATE PROCEDURE [dbo].[Education_Insert](
@Id int,
@PersonEducation nvarchar(20)
)
as

SET NOCOUNT ON
INSERT INTO dbo.Education(Id, PersonEducation)
VALUES(@id, @PersonEducation);

GO

CREATE PROCEDURE [dbo].[Education_Delete](
@id int)
as
DELETE FROM PrivateInf WHERE id = @id;

GO

CREATE PROCEDURE [dbo].[City_Update](
@id int,
@personcity nvarchar(20)
)
as
begin
update City set
PersonCity = @personcity where Id = @id
end ;

GO

CREATE PROCEDURE [dbo].[City_Insert](
@Id int,
@PersonCity nvarchar(20)
)
as

SET NOCOUNT ON
INSERT INTO dbo.City (Id, PersonCity)
VALUES(@id, @PersonCity);

GO

CREATE PROCEDURE [dbo].[City_Delete](
@id int)
as
DELETE FROM PrivateInf WHERE id = @id;
GO  
