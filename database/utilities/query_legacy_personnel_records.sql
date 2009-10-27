select * from [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[forms]
select * from [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[formfiles] where formid=103
select * from [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].formfields] where formid=103
select formrecords.storedvalue from [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[formrecords]

SELECT formfields.name, formrecords.storedvalue
FROM [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[formrecords] as formrecords
	INNER JOIN [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[formfields] as formfields
	    ON formfields.id = formrecords.fieldid
    INNER JOIN [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[formfiles] as formfiles
        ON formfiles.id = formrecords.fileid
    INNER JOIN [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[persons] as old_persons
        ON old_persons.id = formfiles.personid
WHERE formfields.formid = 103 AND
      old_persons.username = 'w.petit'