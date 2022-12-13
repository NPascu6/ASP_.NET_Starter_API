--Script to create test data.

INSERT INTO UserRoles(RoleId, RoleName)
VALUES (1, 'Pro');
INSERT INTO UserRoles(RoleId, RoleName)
VALUES (2, 'User');
INSERT INTO UserRoles(RoleId, RoleName)
VALUES (3, 'Trial');

INSERT INTO Users (LastName, FirstName, Email) 
VALUES ('Test', 'Pro', 'testPro@test.com');
INSERT INTO Users (LastName, FirstName, Email) 
VALUES ('Test', 'User', 'testUser@test.com');
INSERT INTO Users (LastName, FirstName, Email) 
VALUES ('Test', 'Trial', 'testTrial@test.com');

INSERT INTO Wallets(WalletName)
VALUES ('Test Wallet Pro');
INSERT INTO Wallets(WalletName)
VALUES ('Test Wallet User');
INSERT INTO Wallets(WalletName)
VALUES ('Test Wallet Trial' );

INSERT INTO UserDetails(UserId, PhoneNumber, Address, BirthDate, UserRoleId, WalletId)
VALUES (1, 765952211 , 'Test Address Pro', '12.12.1994', 1,1);
INSERT INTO UserDetails(UserId, PhoneNumber, Address, BirthDate, UserRoleId, WalletId)
VALUES (2, 764952313 , 'Test Address User', '02.11.1996',2,2);
INSERT INTO UserDetails(UserId, PhoneNumber, Address, BirthDate, UserRoleId, WalletId)
VALUES (3, 742952323 , 'Test Address Trial', '04.06.1998',3,3);

INSERT INTO Assets(WalletId, AssetName, AssetQuantity)
VALUES (1, 'Test Asset Pro 1', 11.5);
INSERT INTO Assets(WalletId, AssetName, AssetQuantity)
VALUES (2, 'Test Asset User 1', 202.32);
INSERT INTO Assets(WalletId, AssetName, AssetQuantity)
VALUES (3, 'Test Asset Trial 1', 42.1112);


--Script to delete test data tables.

GO

DROP TABLE [dbo].[Assets]
DROP TABLE [dbo].[UserDetails]
DROP TABLE [dbo].[Wallets]
DROP TABLE [dbo].[UserRoles]
DROP TABLE [dbo].[Users]
GO