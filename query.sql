
CREATE TABLE `DecorationTypes` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Size` varchar(8) CHARACTER SET utf8mb4 NOT NULL,
    `Model` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `ObjectURL` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Category` int NOT NULL,
    `TagsJSON` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_DecorationTypes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Locations` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `CEP` varchar(8) CHARACTER SET utf8mb4 NOT NULL,
    `Category` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Address` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Cords` varchar(16) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `AreaSize` double NULL,
    `RentPerDay` decimal(5,2) NOT NULL,
    `ImagesJson` longtext CHARACTER SET utf8mb4 NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NOT NULL,
    CONSTRAINT `PK_Locations` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Managers` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Email` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Password` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Salt` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Managers` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `ThirdParties` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Address` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `LoginEmail` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Salt` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Password` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ProfissionalPhone` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `ContactEmail` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `ContactPhone` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `CNPJ` varchar(14) CHARACTER SET utf8mb4 NOT NULL,
    `AuthorizationStatus` int NOT NULL,
    `ProfilePictureURL` longtext CHARACTER SET utf8mb4 NOT NULL,
    `TagJSON` longtext CHARACTER SET utf8mb4 NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_ThirdParties` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Users` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Fullname` varchar(80) CHARACTER SET utf8mb4 NOT NULL,
    `UserName` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Email` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Password` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Salt` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CPF` varchar(11) CHARACTER SET utf8mb4 NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    `RolesJson` longtext CHARACTER SET utf8mb4 NULL,
    `Location` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ProfilePictureURL` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `DecorationInfos` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Color` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `Material` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `IsAvaible` tinyint(1) NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `TextureURL` longtext CHARACTER SET utf8mb4 NOT NULL,
    `DecorationTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_DecorationInfos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_DecorationInfos_DecorationTypes_DecorationTypeId` FOREIGN KEY (`DecorationTypeId`) REFERENCES `DecorationTypes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `FoodTypes` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(35) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Category` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ThirdPartyId` char(36) COLLATE ascii_general_ci NOT NULL,
    `TagsJSON` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_FoodTypes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodTypes_ThirdParties_ThirdPartyId` FOREIGN KEY (`ThirdPartyId`) REFERENCES `ThirdParties` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `ServiceTypes` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Category` int NOT NULL,
    `ThirdPartyId` char(36) COLLATE ascii_general_ci NOT NULL,
    `TagsJSON` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_ServiceTypes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ServiceTypes_ThirdParties_ThirdPartyId` FOREIGN KEY (`ThirdPartyId`) REFERENCES `ThirdParties` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `PartyTemplates` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `ExpectedGuests` int NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `LocationId` char(36) COLLATE ascii_general_ci NOT NULL,
    `OriginalPartyTemplateId` char(36) COLLATE ascii_general_ci NULL,
    CONSTRAINT `PK_PartyTemplates` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PartyTemplates_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_PartyTemplates_PartyTemplates_OriginalPartyTemplateId` FOREIGN KEY (`OriginalPartyTemplateId`) REFERENCES `PartyTemplates` (`Id`),
    CONSTRAINT `FK_PartyTemplates_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `UserConfirmations` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ValidFor` datetime(6) NOT NULL,
    CONSTRAINT `PK_UserConfirmations` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserConfirmations_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `FoodInfos` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Flavour` varchar(35) CHARACTER SET utf8mb4 NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `Available` tinyint(1) NOT NULL,
    `ImagesJson` longtext CHARACTER SET utf8mb4 NULL,
    `FoodTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_FoodInfos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodInfos_FoodTypes_FoodTypeId` FOREIGN KEY (`FoodTypeId`) REFERENCES `FoodTypes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `ServiceInfos` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `IsAvaible` tinyint(1) NOT NULL,
    `Plan` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `ImagesJson` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ServiceTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_ServiceInfos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ServiceInfos_ServiceTypes_ServiceTypeId` FOREIGN KEY (`ServiceTypeId`) REFERENCES `ServiceTypes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `DecorationGroups` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Quantity` int NOT NULL,
    `Note` longtext CHARACTER SET utf8mb4 NOT NULL,
    `DecorationInfoId` char(36) COLLATE ascii_general_ci NOT NULL,
    `PartyTemplateId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_DecorationGroups` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_DecorationGroups_DecorationInfos_DecorationInfoId` FOREIGN KEY (`DecorationInfoId`) REFERENCES `DecorationInfos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_DecorationGroups_PartyTemplates_PartyTemplateId` FOREIGN KEY (`PartyTemplateId`) REFERENCES `PartyTemplates` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `Schedules` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `ExpectedGuests` int NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `LocationId` char(36) COLLATE ascii_general_ci NOT NULL,
    `PartyId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_Schedules` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Schedules_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Schedules_PartyTemplates_PartyId` FOREIGN KEY (`PartyId`) REFERENCES `PartyTemplates` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Schedules_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `FoodGroups` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Quantity` int NOT NULL,
    `Note` longtext CHARACTER SET utf8mb4 NOT NULL,
    `PartyTemplateId` char(36) COLLATE ascii_general_ci NOT NULL,
    `FoodInfoId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_FoodGroups` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodGroups_FoodInfos_FoodInfoId` FOREIGN KEY (`FoodInfoId`) REFERENCES `FoodInfos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FoodGroups_PartyTemplates_PartyTemplateId` FOREIGN KEY (`PartyTemplateId`) REFERENCES `PartyTemplates` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `ServiceGroups` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Note` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ServiceInfoId` char(36) COLLATE ascii_general_ci NOT NULL,
    `PartyTemplateId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_ServiceGroups` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ServiceGroups_PartyTemplates_PartyTemplateId` FOREIGN KEY (`PartyTemplateId`) REFERENCES `PartyTemplates` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ServiceGroups_ServiceInfos_ServiceInfoId` FOREIGN KEY (`ServiceInfoId`) REFERENCES `ServiceInfos` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `DecorationOrders` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Quantity` int NOT NULL,
    `EventDate` datetime(6) NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `Note` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Status` int NOT NULL,
    `DecorationId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ScheduleId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_DecorationOrders` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_DecorationOrders_DecorationInfos_DecorationId` FOREIGN KEY (`DecorationId`) REFERENCES `DecorationInfos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_DecorationOrders_Schedules_ScheduleId` FOREIGN KEY (`ScheduleId`) REFERENCES `Schedules` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `FoodOrders` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Quantity` int NOT NULL,
    `Note` varchar(256) CHARACTER SET utf8mb4 NULL,
    `Status` int NOT NULL,
    `EventDate` datetime(6) NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `PartyTemplateId` char(36) COLLATE ascii_general_ci NOT NULL,
    `FoodInfoId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ThirdPartyId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ScheduleId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_FoodOrders` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodOrders_FoodInfos_FoodInfoId` FOREIGN KEY (`FoodInfoId`) REFERENCES `FoodInfos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FoodOrders_PartyTemplates_PartyTemplateId` FOREIGN KEY (`PartyTemplateId`) REFERENCES `PartyTemplates` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FoodOrders_Schedules_ScheduleId` FOREIGN KEY (`ScheduleId`) REFERENCES `Schedules` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FoodOrders_ThirdParties_ThirdPartyId` FOREIGN KEY (`ThirdPartyId`) REFERENCES `ThirdParties` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `ServiceOrders` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Note` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Price` decimal(5,2) NOT NULL,
    `EventDate` datetime(6) NOT NULL,
    `Status` int NOT NULL,
    `ServiceInfoId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ScheduleId` char(36) COLLATE ascii_general_ci NOT NULL,
    `ThirdPartyId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_ServiceOrders` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ServiceOrders_Schedules_ScheduleId` FOREIGN KEY (`ScheduleId`) REFERENCES `Schedules` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ServiceOrders_ServiceInfos_ServiceInfoId` FOREIGN KEY (`ServiceInfoId`) REFERENCES `ServiceInfos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ServiceOrders_ThirdParties_ThirdPartyId` FOREIGN KEY (`ThirdPartyId`) REFERENCES `ThirdParties` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE INDEX `IX_DecorationGroups_DecorationInfoId` ON `DecorationGroups` (`DecorationInfoId`);


CREATE INDEX `IX_DecorationGroups_PartyTemplateId` ON `DecorationGroups` (`PartyTemplateId`);


CREATE INDEX `IX_DecorationInfos_DecorationTypeId` ON `DecorationInfos` (`DecorationTypeId`);


CREATE INDEX `IX_DecorationOrders_DecorationId` ON `DecorationOrders` (`DecorationId`);


CREATE INDEX `IX_DecorationOrders_ScheduleId` ON `DecorationOrders` (`ScheduleId`);


CREATE INDEX `IX_FoodGroups_FoodInfoId` ON `FoodGroups` (`FoodInfoId`);


CREATE INDEX `IX_FoodGroups_PartyTemplateId` ON `FoodGroups` (`PartyTemplateId`);


CREATE INDEX `IX_FoodInfos_FoodTypeId` ON `FoodInfos` (`FoodTypeId`);


CREATE INDEX `IX_FoodOrders_FoodInfoId` ON `FoodOrders` (`FoodInfoId`);


CREATE INDEX `IX_FoodOrders_PartyTemplateId` ON `FoodOrders` (`PartyTemplateId`);


CREATE INDEX `IX_FoodOrders_ScheduleId` ON `FoodOrders` (`ScheduleId`);


CREATE INDEX `IX_FoodOrders_ThirdPartyId` ON `FoodOrders` (`ThirdPartyId`);


CREATE INDEX `IX_FoodTypes_ThirdPartyId` ON `FoodTypes` (`ThirdPartyId`);


CREATE UNIQUE INDEX `IX_Managers_Email` ON `Managers` (`Email`);


CREATE INDEX `IX_PartyTemplates_LocationId` ON `PartyTemplates` (`LocationId`);


CREATE INDEX `IX_PartyTemplates_OriginalPartyTemplateId` ON `PartyTemplates` (`OriginalPartyTemplateId`);


CREATE INDEX `IX_PartyTemplates_UserId` ON `PartyTemplates` (`UserId`);


CREATE INDEX `IX_Schedules_LocationId` ON `Schedules` (`LocationId`);


CREATE INDEX `IX_Schedules_PartyId` ON `Schedules` (`PartyId`);


CREATE INDEX `IX_Schedules_UserId` ON `Schedules` (`UserId`);


CREATE INDEX `IX_ServiceGroups_PartyTemplateId` ON `ServiceGroups` (`PartyTemplateId`);


CREATE INDEX `IX_ServiceGroups_ServiceInfoId` ON `ServiceGroups` (`ServiceInfoId`);


CREATE INDEX `IX_ServiceInfos_ServiceTypeId` ON `ServiceInfos` (`ServiceTypeId`);


CREATE INDEX `IX_ServiceOrders_ScheduleId` ON `ServiceOrders` (`ScheduleId`);


CREATE INDEX `IX_ServiceOrders_ServiceInfoId` ON `ServiceOrders` (`ServiceInfoId`);


CREATE INDEX `IX_ServiceOrders_ThirdPartyId` ON `ServiceOrders` (`ThirdPartyId`);


CREATE INDEX `IX_ServiceTypes_ThirdPartyId` ON `ServiceTypes` (`ThirdPartyId`);


CREATE UNIQUE INDEX `IX_ThirdParties_LoginEmail` ON `ThirdParties` (`LoginEmail`);


CREATE INDEX `IX_UserConfirmations_UserId` ON `UserConfirmations` (`UserId`);


CREATE UNIQUE INDEX `IX_Users_CPF` ON `Users` (`CPF`);


CREATE UNIQUE INDEX `IX_Users_Email` ON `Users` (`Email`);



