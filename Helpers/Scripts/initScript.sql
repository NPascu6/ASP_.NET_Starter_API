--Script to create test data.

INSERT INTO UserRoles(RoleName)
VALUES ('Pro');
INSERT INTO UserRoles(RoleName)
VALUES ('User');
INSERT INTO UserRoles(RoleName)
VALUES ('Trial');

INSERT INTO Users (UserName, Email, IsConnected) 
VALUES ('Test', 'testPro@test.com', 0);
INSERT INTO Users (UserName, Email, IsConnected) 
VALUES ('Test', 'testUser@test.com', 0);
INSERT INTO Users (UserName, Email, IsConnected) 
VALUES ('Test', 'testTrial@test.com', 0);

INSERT INTO UserDetails(UserId, PhoneNumber, Address, BirthDate, UserRoleId)
VALUES (1, 765952211, 'Test Address Pro', '12.12.1994', 1);
INSERT INTO UserDetails(UserId, PhoneNumber, Address, BirthDate, UserRoleId)
VALUES (2, 764952313, 'Test Address User', '02.11.1996', 2);
INSERT INTO UserDetails(UserId, PhoneNumber, Address, BirthDate, UserRoleId)
VALUES (3, 742952323, 'Test Address Trial', '04.06.1998', 3);

INSERT INTO Wallets(WalletName , UserDetailsId)
VALUES ('Test Wallet Pro', 1);
INSERT INTO Wallets(WalletName, UserDetailsId)
VALUES ('Test Wallet User', 2);
INSERT INTO Wallets(WalletName, UserDetailsId)
VALUES ('Test Wallet Trial',3);

INSERT INTO Assets(AssetName, AssetQuantity, WalletId)
VALUES ('Test Asset Pro 1', 11.5, 1);
INSERT INTO Assets(AssetName, AssetQuantity, WalletId)
VALUES ('Test Asset User 1', 202.32, 2);
INSERT INTO Assets(AssetName, AssetQuantity, WalletId)
VALUES ('Test Asset Trial 1', 42.1112, 3);


GO

delete from [dbo].[Assets]
delete from [dbo].[UserDetails]
delete from [dbo].[Wallets]
delete from [dbo].[UserRoles]
delete from [dbo].[Users]
GO

GO

DROP TABLE [dbo].[Assets]
DROP TABLE [dbo].[UserDetails]
DROP TABLE [dbo].[Wallets]
DROP TABLE [dbo].[UserRoles]
DROP TABLE [dbo].[Users]
GO