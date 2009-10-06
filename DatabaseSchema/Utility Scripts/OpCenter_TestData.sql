INSERT INTO persons VALUES ('Joseph', 'Daigle', 'joseph@cridion.com', 'j.daigle', 'Joseph Daigle', 0, null, null, null, null)
INSERT INTO persons VALUES ('Bill', 'Petit', 'w.petit@tfs2.com', 'w.petit', 'Bill Petit', 0, null, null, null, null)

insert into forms values ('Personnel Files', default, null, null, null, null)

insert into formfields values (1, 'Social Security Number', default, null, null, null, null)
insert into formfields values (1, 'Birthdate', default, null, null, null, null)
insert into formfields values (1, 'Position', default, null, null, null, null)
insert into formfields values (1, 'Certification', default, null, null, null, null)

INSERT into formcodes values (3, 'Admin', default, null, null, null, null)
INSERT into formcodes values (3, 'Pilot', default, null, null, null, null)
INSERT into formcodes values (3, 'FE', default, null, null, null, null)
INSERT into formcodes values (3, 'Nav', default, null, null, null, null)
INSERT into formcodes values (3, 'Staff', default, null, null, null, null)

INSERT into formcodes values (4, 'FAA1', default, null, null, null, null)
INSERT into formcodes values (4, 'FAA2', default, null, null, null, null)
INSERT into formcodes values (4, 'FAA3', default, null, null, null, null)
INSERT into formcodes values (4, 'FAA4', default, null, null, null, null)
INSERT into formcodes values (4, 'FAA5', default, null, null, null, null)

INSERt INTO formfiles values (1, 1, default, null, null, null, null)
INSERt INTO formfiles values (1, 2, default, null, null, null, null)

INSERT into formrecords values (1, 1, null, '111-11-1111', default, null, null, null, null)
INSERT into formrecords values (1, 2, null, '5-2-1985', default, null, null, null, null)
INSERT into formrecords values (1, 3, 5, null, default, null, null, null, null)
