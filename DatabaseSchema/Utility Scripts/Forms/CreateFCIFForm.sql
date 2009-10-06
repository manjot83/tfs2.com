SET IDENTITY_INSERT forms ON
INSERT INTO forms 
	(id, name, shortname, tfsfnumber, remarks, deleted, createdon)
	VALUES (102, 'Flight Crew Information File', 'FCIF', '10-50', 'PREVIOUS EDITION OBSOLETE', 0, '11-6-2007')
SET IDENTITY_INSERT forms OFF

INSERT INTO formfields VALUES (102, 'SUBJECT', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'FCIF NUMBER', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'NARRATIVE', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'AUTHORITY', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'DESIGN AIRCRAFT', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'POSTING DATE', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'CREW POSITION', null, 0, null, null, null, null)
INSERT INTO formfields VALUES (102, 'IMPLEMENTATION', null, 0, null, null, null, null)