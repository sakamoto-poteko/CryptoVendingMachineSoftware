﻿DECLARE @EmptyGuid UNIQUEIDENTIFIER
SET @EmptyGuid = (SELECT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER))
UPDATE VendingMachines SET ExclusiveUseLock = @EmptyGuid