USE [HMS]
GO
/****** Object:  Trigger [dbo].[beds2]    Script Date: 06-07-2023 17:46:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[beds2] 
ON [dbo].[IPD]
 AFTER INSERT 
AS UPDATE Rooms SET Vacant_beds=Vacant_beds-1 WHERE Rid=(SELECT i.Room_No FROM inserted AS i);