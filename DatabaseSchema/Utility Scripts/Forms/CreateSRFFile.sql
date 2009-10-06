SET IDENTITY_INSERT forms ON
INSERT INTO forms 
	(id, name, shortname, tfsfnumber, remarks, deleted, createdon)
	VALUES (101, 'Safety Read File', 'SRF', '91-50', 'PREVIOUS EDITION OBSOLETE', 0, '11-6-2007')
SET IDENTITY_INSERT forms OFF

INSERT INTO formfields VALUES (101, 'SUBJECT', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'SRF NUMBER', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'NARRATIVE', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'AUTHORITY', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'DESIGN AIRCRAFT', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'POSTING DATE', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'CREW POSITION', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (101, 'IMPLEMENTATION', null, 0, null, null, null, null)