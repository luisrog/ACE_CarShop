--------------------------------------------------------
-- Archivo creado  - sábado-septiembre-19-2015   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table US_STATE
--------------------------------------------------------

  CREATE TABLE "U_APP"."US_STATE" 
   (	"ID" NUMBER(*,0), 
	"NAME" VARCHAR2(50 BYTE), 
	"USERCREATE" VARCHAR2(50 BYTE), 
	"DATECREATE" DATE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index US_STATE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "U_APP"."US_STATE_PK" ON "U_APP"."US_STATE" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table US_STATE
--------------------------------------------------------

  ALTER TABLE "U_APP"."US_STATE" ADD CONSTRAINT "US_STATE_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "U_APP"."US_STATE" MODIFY ("DATECREATE" NOT NULL ENABLE);
  ALTER TABLE "U_APP"."US_STATE" MODIFY ("USERCREATE" NOT NULL ENABLE);
  ALTER TABLE "U_APP"."US_STATE" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "U_APP"."US_STATE" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Trigger US_STATE_TRG1
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "U_APP"."US_STATE_TRG1" 
BEFORE INSERT ON US_STATE 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    NULL;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "U_APP"."US_STATE_TRG1" ENABLE;
--------------------------------------------------------
--  DDL for Trigger US_STATE_TRG
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "U_APP"."US_STATE_TRG" 
BEFORE INSERT ON US_STATE 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    NULL;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "U_APP"."US_STATE_TRG" ENABLE;
