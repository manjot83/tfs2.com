
/****************************************************************
** ALTER TABLE commands used to remove Foreign Key constraints **
****************************************************************/

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[categories]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    BEGIN

  /*** Remove foreign keys on [dbo].[categories] ***/
       IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[FK_posts_categories]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
           ALTER TABLE [dbo].[posts] DROP CONSTRAINT FK_posts_categories
   END
GO


/**********************************************
** DROP TABLE commands used to remove tables **
***********************************************/


/*** Drop Table [dbo].[links] ***/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[links]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[links]
GO

/*** Drop Table [dbo].[posts] ***/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[posts]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[posts]
GO

/*** Drop Table [dbo].[categories] ***/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[categories]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[categories]
GO

/*** Drop Table [dbo].[helparticles] ***/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[helparticles]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[helparticles]
GO


/********************************************************
** CREATE TABLE commands used to build database tables **
********************************************************/


/********************************************************
 Create Table [dbo].[categories]
********************************************************/


CREATE TABLE [dbo].[categories] (

  [id] [int] IDENTITY (1,1) NOT NULL,
  [name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [description] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[categories] ([name],[description]) VALUES ('General','New Safety Read File Released');
INSERT INTO [dbo].[categories] ([name],[description]) VALUES ('Safety','Safety Read File Release');

/********************************************************
** CREATE TABLE commands used to build database tables **
********************************************************/


/********************************************************
 Create Table [dbo].[helparticles]
********************************************************/


CREATE TABLE [dbo].[helparticles] (

  [id] [int] IDENTITY (1,1) NOT NULL,
  [postdate] [datetime] NOT NULL,
  [subject] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [content] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[helparticles] ([postdate],[subject],[content]) VALUES ('11/28/2006 5:18:00 PM','Remote Desktop Connection','##Instructions for Remote Desktop Connection for LogBook Pro##' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'In order to connect remotely to the desktop sharing LogBook Pro, you must connect using Windows Remote Desktop Connection. ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'If you are using a Windows XP based computer that is connected to the internet, it will most likely include the "Remote Desktop Connection" software already.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '1. To open, from the start menu select: *Programs->Accessories->Communications->Remote Desktop Connection*' + CHAR(13) + CHAR(10) + '2. Once open enter the following address: *apollo.tfs2.com* and press Connect. This will load in a window with the remote desktop with LogBook Pro.' + CHAR(13) + CHAR(10) + '3. Use the username: manager and the password given to you. LogBook Pro is located on the desktop.' + CHAR(13) + CHAR(10) + '4. When done, please LOGOUT of the remote machine from the start menu.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'If you have connection problems please E-Mail: j.daigle@tfs2.com.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '-------' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'For Accessing the Office Computer in Kennesaw' + CHAR(13) + CHAR(10) + 'Follow the instructions above, but instead connect to the Domain Name *tacticalflight.dynalias.net*');
INSERT INTO [dbo].[helparticles] ([postdate],[subject],[content]) VALUES ('11/28/2006 5:26:00 PM','Connecting to TFS E-Mail using Entourage','##Basic Instructions##' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '1. You want to setup a new account so in Entourage select *Tools->Accounts.*' + CHAR(13) + CHAR(10) + '2. Then click the drop down arrow next to New and select Exchange.' + CHAR(13) + CHAR(10) + '3. Enter your e-mail address.' + CHAR(13) + CHAR(10) + '4. Userid = your username' + CHAR(13) + CHAR(10) + '5. Domain = tfs2' + CHAR(13) + CHAR(10) + '6. Password = your password' + CHAR(13) + CHAR(10) + '7. Then press the button to "configure account manually".' + CHAR(13) + CHAR(10) + '8. Change the name of the account to whatever you want.' + CHAR(13) + CHAR(10) + '9. For exchange server, enter: *https://apollo.tfs2.com/exchange-oma*' + CHAR(13) + CHAR(10) + '10. Click the tab "advanced" and make sure the checkbox next to "DAV Service requires secure connection (SSL)" is checked.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Press okay, and that should be it.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'It might warn you about a connection error initially, but just press okay and try again.');
INSERT INTO [dbo].[helparticles] ([postdate],[subject],[content]) VALUES ('1/3/2007 11:33:00 PM','Using the TFS Online Personal Payroll System','##Looking at Time Cards##' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'The TFS Online Personal Payroll System is designed to assist with the filling out of personal time cards and expense reports. When you click on the *Personal Payroll* link on the intranet site, you are presented with two lists. The first list shows currently active time cards you can fill out, including a short summary and the date that the time card closes. Once a time card is closed, you can no longer edit it. Instead it is listed below where you can run a report of your historical time card data.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '##Filling out a Time Card##' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'When you click edit on an active time card, you are taken to a form that you can fill out. It is important to note: *all changes are saved as you insert data*. There is no final submit, and therefore you cannot reset values after you change them.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###Personal Data Section###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Verify this information is correct. If not contact someone ASAP. Please use the drop down box and indicate how many days per diem you are being compensated for on this time card.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###Hours Worksheet###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Use this to fill out daily hours worked. Select the day and the time-in/time-out values.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'You can edit or delete existing days in a month as needed.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###Expense Report###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Click a date on the calendar, then enter a description and amount for the expense entry. You can also edit or delete existing expense entries as needed.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'If you experience any problems, or if you have any suggestions to improve the form or experience please e-mail j.daigle@tfs2.com');
INSERT INTO [dbo].[helparticles] ([postdate],[subject],[content]) VALUES ('3/22/2007 8:03:00 PM','Creating (Printing) PDFs from any Application','It is possible to easily create PDF documents **for free**. The process involves installing a piece of software that acts like a printer. But instead of printing to a physical printer, it saves the print view as a PDF document.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###To Install###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Navigate to [http://www.cutepdf.com/Products/CutePDF/writer.asp](http://www.cutepdf.com/Products/CutePDF/writer.asp) and click the two "Free Download" links to the left. Both programs need to be installed.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Once downloaded, run each installer and follow the directions. It does not matter which order you install the programs in.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###To Print PDFs###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '1. In any application that you can print from, such as Word or Internet Explorer, open the file you want to convert.' + CHAR(13) + CHAR(10) + '2. By going to the *Print Preview* section under File, you can view what the document would look like printed out. This is what the PDF will look like.' + CHAR(13) + CHAR(10) + '3. *File*->*Print*. Select the printer "CutePDF Writer".' + CHAR(13) + CHAR(10) + '4. After pressing Print, you will be prompted for a file to save as.' + CHAR(13) + CHAR(10) + '5. Once completed the document has been converted to a PDF.');
INSERT INTO [dbo].[helparticles] ([postdate],[subject],[content]) VALUES ('3/22/2007 8:12:00 PM','Connecting to TFS Exchange server (apollo.tfs2.com) with Outlook','With special configuration, you can setup a computer using Microsoft Outlook to connect to the TFS Exchange server. In addition to E-Mail, you will have access to your calendar, contacts and any other Exchange folders.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###Requirements###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '1. Windows XP with Service Pack 2 or Windows Vista' + CHAR(13) + CHAR(10) + '2. Microsoft Outlook 2003 (usually included with Office 2003)' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Testing of Office 2007 is underway. It is not supported yet.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '###Configuration###' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Please e-mail <a href="mailto:j.daigle@tfs2.com">Joseph Daigle</a> for a personalized configuration script.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'This script when run on your computer with Outlook 2003, will configure your mailbox settings and change default delivery locations. This is due to the nature of associating Outlook with Exchange.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'It is possible your current E-mail settings will be distrupted by establishing this association. It is therefore highly recommended that unless you need rich client access you should use the Exchange Outlook Web Access avaiable through the TFS2 intranet.');
INSERT INTO [dbo].[helparticles] ([postdate],[subject],[content]) VALUES ('5/16/2007 4:13:00 PM','Reporting a Bug','To Report a Bug:' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Please use the link to the left "Report a Bug". Fill it out completely. Be sure to select which component and provide as many details as possible.');

/********************************************************
** CREATE TABLE commands used to build database tables **
********************************************************/


/********************************************************
 Create Table [dbo].[links]
********************************************************/


CREATE TABLE [dbo].[links] (

  [id] [int] IDENTITY (1,1) NOT NULL,
  [linkname] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [navurl] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Weather Underground','http://www.weatherunderground.com/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Per Diem Rates','https://secureapp2.hqda.pentagon.mil/perdiem/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('NOAA','http://www.nws.noaa.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('FLIP / IAP / AP / NIMA','http://164.214.2.62/products/usfif/index.html');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Hurricane Center','http://www.nhc.noaa.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('METARS TAFs','http://adds.aviationweather.noaa.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('AETC Pubs','http://www.aetc.randolph.af.mil/im/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('DINS NOTAM System','https://www.notams.jcs.mil/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('FAA NOTAMs','http://www.faa.gov/NTAP/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Baseops','http://www.baseops.net/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Airport Diagrams','http://www.naco.faa.gov/ap_diagrams_acc.asp');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Terminal Apps Plates','http://avn.faa.gov/index.asp?xml=naco/onlineproducts');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Time Hack','http://www.time.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Sunrise/Sunset','http://aa.usno.navy.mil/data/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Weather Channel','http://www.weather.com/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('USAF Pubs','http://www.e-publishing.af.mil/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('FAA','http://www.faa.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Herk Conference','http://www.lockheedmartin.com/ams/2007HerculesOperatorsConference.html');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Intellicast Weather','http://www.intellicast.com/IcastPage/LoadPage.aspx');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('C-130 Headquarters','http://www.spectrumwd.com/c130/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Jet Warbirds','http://www.classicjets.org/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Contractors Registration','http://www.ccr.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('DTIC','http://www.dtic.mil/dtic/registration/#unclas');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Astronautics','http://www.astronautics.com/new/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Breitling','http://www.breitling.com/en/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('USAF Safety Center','http://www.af.mil/factsheets/factsheet.asp?fsID=153');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('OSHA','http://www.osha.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('NTSB','http://www.ntsb.gov/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Air Mobility Support','http://www.lockheedmartin.com/wms/findPage.do?dsp=fec&ci=13952&sc=400');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('ARINC','http://www.arinc.com/products/test_evaluation/flight_operations.html');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('L-3','http://www.crestview-aerospace.com/aircraftmods.html');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('BASH Program','http://www.usahas.com/bam/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Jeppesen','http://www.jeppesen.com/wlcs/index.jsp');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Contractor Law','http://www.outsourcing-law.com/government_contractor_defense.htm');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Contractor Assistance','http://www.govcon.com/content/homepage/default.asp');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Wants Check','http://www.wantscheck.com/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Nametags','http://www.nametags4u.com/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Lockheed','http://www.lockheedmartin.com/wms/findPage.do?dsp=fec&ci=13963&rsbci=0&fti=0&ti=0&sc=400');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Lynden','http://www.lac.lynden.com/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Zaps','http://www.aviationzaps.com');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('PIXS','https://pixs.wpafb.af.mil/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Spar Aerospace','http://www.spar.ca/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Wyle Labs','http://www.wylelabs.com/services/pass.html');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('Cascade','http://cascadeaerospace.com/mro/Herc%20Solutions/index.htm');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('TIMCO','http://www.timco.aero/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('SETP Symposium','http://www.setp.org/HTML/Symposia/losangeles.htm');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('ATA Convention','http://www.atalink.us/registration/convention.asp');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('C-130 WWR','http://www.c130tcgwwr.org/');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('HOC 2008','http://www.lockheedmartin.com/ams/2008HerculesOperatorsConference.html');
INSERT INTO [dbo].[links] ([linkname],[navurl]) VALUES ('DFARS','http://farsite.hill.af.mil/reghtml/regs/far2afmcfars/fardfars/dfars/dfars252_227.htm#P2057_170103');

/********************************************************
** CREATE TABLE commands used to build database tables **
********************************************************/


/********************************************************
 Create Table [dbo].[posts]
********************************************************/


CREATE TABLE [dbo].[posts] (

  [id] [int] IDENTITY (1,1) NOT NULL,
  [postdate] [datetime] NOT NULL,
  [postuser] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [categoryID] [int] NOT NULL,
  [subject] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [content] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[posts] ([postdate],[postuser],[categoryID],[subject],[content]) VALUES ('8/28/2006 9:24:00 PM','j.daigle',5,'Welcome to the TFS Intranet','Alright everyone,' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'I''ve got the new intranet site online and kicking (working this time too). Login of course is the same username and password you use for e-mail. There is a link in the intranet for changing this password. If you haven''t changed it, then it is probably still the default "pirates".' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Let me know right away if you have any login problems. And I''ll try hard to get them fixed right away.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Poke around offline (not through e-mail) with other people to make sure they''re informed about all the changes. Especially the e-mail changes since mail is no longer delivered to the old mailboxes.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'You''ll notice two neat new features of the intranet site.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '1. External Links : Located on the right hand column. There is a link directly below the header that allows (currently anyone) to edit/remove/add links to websites. They all get sorted alphabetically in the list. I''m still working to make it a bit more "pretty" to look at especially with the long names' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '2. TFS2 News : This is a feature that I''ll try out and see how much it gets used. This allows people to add news or "blog" like posts to the intranet site. The management of these posts should be pretty straight forward.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'As always, E-mail me with feedback or questions and I''ll try very hard to get right back to you as soon as possible.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '-- <br>' + CHAR(13) + CHAR(10) + 'Joseph Daigle<br>' + CHAR(13) + CHAR(10) + 'Systems Engineer<br>' + CHAR(13) + CHAR(10) + '[j.daigle@tfs2.com](mailto:j.daigle@tfs2.com)<br>' + CHAR(13) + CHAR(10) + '[joseph.daigle@thefons.com](mailto:joseph.daigle@thefons.com' + CHAR(13) + CHAR(10) + ')<br>' + CHAR(13) + CHAR(10) + '678-296-6166');
INSERT INTO [dbo].[posts] ([postdate],[postuser],[categoryID],[subject],[content]) VALUES ('7/9/2007 12:53:00 PM','w.petit',6,'Intranet Technical Orders','T.O.''s posted on the intranet are for reference and informational purposes only. These are not the offical source for T.O. information. Official and current T.O.''s will be supplied by each Prime Contractor at each specific operating location. For official T.O. guidance, refer to the onsite T.O. library.');
INSERT INTO [dbo].[posts] ([postdate],[postuser],[categoryID],[subject],[content]) VALUES ('5/26/2008 6:23:00 PM','w.petit',6,'SRF 06-08','SRF: 06-08' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'DATE: 14 JUNE 2008' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'JUNE SAFETY MINUTES' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'CREW POSITION: ALL' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'AUTHORITY: DIRECTOR OF OPERATIONS' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'DESIGN AIRCRAFT: C-130' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'SUBJECT: ACTUAL ENGINE FAILURE SIMULTANEOUS WITH FCF ESP:' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Thanks to Bill Petit for this next topic and what a good one!' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'First read what happened to this P-3 FCF crew recently in real life and then I will discuss some of the TFS safety factors we have built in so you don’t experience the same situation!' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'The P-3C that almost went into Puget Sound waters a few days ago was from NAS Whidbey. It was a CPW-10 aircraft being operated by VP-1. Squadrons don''t own aircraft any more. The P-3 fleet has so deteriorated because of under-funding and over-use that there are less than 100 still flyable*. The P-3s belong to the wing and are "lent to the squadrons on an as-needed" basis. ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'The mission was a NATOPS pilot check, with a CPW-10 pilot (LT) aboard, a VP-1 LT and LTJG, plus VP-1 aircrewmen that included two flight engineers. The word is that the crew finally recovered control of the aircraft about 100 feet above MSL by pulling 7 Gs. The bird was landed back at NASW. Max damage was sustained by the aircraft, including almost tearing off a wing. Aircraft BuNo 161331. ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'My first thought is that this was a Vmca incident: ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'At Whidbey, P-3C 161331 was doing a Functional Check Flight. They shut down #1 engine. With #1 off, #2 engine exhibited vibrations and was shutdown. With two engines off on the same side the aircraft stalled. 7 G''s were reported to pull it out of the stall. 45 consecutive rivets were pulled out on the stbd wing during the 7 G pull out (rolling pull), after peaking at negative 2.4g''s as well. They did five spin rotations from 5500 ft -- they bottomed out "between 50 and 200 ft." They could see the inside of the fuel tanks when they landed. They were at 160 KIAS, appr flaps during a prop fails to feather drill on #1 when #2 started surging. They bagged #2, but while doing so got to 122 KIAS. When they added power, they were way below VMC air, and departed. SDRS recorded the flaps being raised and the landing gear being cycled down and then back up. Aircraft released all the fuel in tank #3 when it appears that the seam between planks 3 and 4 split. Tank #4 also lost its fuel load when plank #1 separated from rest of the aircraft wing.' + CHAR(13) + CHAR(10) + ' ' + CHAR(13) + CHAR(10) + 'If you go to this web site you can see some of the aircraft damage.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'http://www.freerepublic.com/focus/f-news/2052559/posts' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'When TFS performs the FCF engine shutdown and airstart tests, it is accomplished above 17,000 feet per the 6CF-1. There are many reasons for accomplishing the test at this altitude envelope.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'One reason is the air loading on the prop and engine at this density altitude is different that say at 5,000. An engine that can airstart at 5,000 feet might not airstart at 17,000 feet. Therefore when TFS performs these tests….we expect you to not deviate from the 6CF-1 guidance, since there are reasons why the book is written in such a manner.' + CHAR(13) + CHAR(10) + 'Second: As you can see with this P-3 crew, if they would have started out at a much higher altitude, ie 17,000 like we do, that would have bought them lots of time to restart a good engine and not resulting in stalling the aircraft.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'If you shutdown the #1 engine for the FCF and subsequently flame out #2 or start experiencing a problem with #2 which will result in a ESP, what will you do? Do you shutdown the #2 engine first and then airstart the #1, or do you airstart #1 first and then shutdown #2? When do you talk to ATC? Simply squwk 7700 and talk to them later? Are you going to try to maintain altitude IFR or quickly declare an emergency and descend to keep your airspeed around 180 kts…far from stall speed and a good airspeed to airstart with?' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Each situation is different and each crew needs to ensure you are prepared for the unexpected and have a game plan. Remember the basics: Aviate, Navigate and then Communicate. ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Trust me. Don’t get complacent. I have had actual tail pipe fires and a prop that when trying to airstart and no NTS was indicated and a subsequent lightoff happened, that prop went so dang fast and out of control in approx 1-2 seconds.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Bottom line is stuff happens fast especially when you are on 2 engines and out of altitude and ideas. Brief contingencies and crew action when the unexpected happens. ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'FLY THE AIRCRAFT AND FLY SAFE!' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '');
INSERT INTO [dbo].[posts] ([postdate],[postuser],[categoryID],[subject],[content]) VALUES ('8/6/2008 9:31:00 AM','w.petit',6,'SRF 07-08','SRF: 07-08' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'DATE: 14 JULY 2008' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'JULY SAFETY MINUTES' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'CREW POSITION: ALL' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'AUTHORITY: DIRECTOR OF OPERATIONS' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'DESIGN AIRCRAFT: C-130' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'SUBJECT: HOT BRAKES' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'We are nearing the hottest days in summer and that can easily mean….you guessed it HOT BRAKES!' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Due to the criticalness of this subject, this is our July safety topic. I will officially post in our Safety Read File but I just wanted to ensure you are thinking now about this topic whether flying for TFS or elsewhere:' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'SCENARIO: The aircraft has a reported nose wheel shimmy and the contractor wants you to evaluate it and after evaluation, if safe to do so, take off and accomplish an Acceptance Check Flight (ACF). To help with the nose wheel shimmy and the ACF you have your TFS crew and 2 maintenance types onboard.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'The allowable runway is fairly short, say 6,500 feet and it is Waco, TX in August and the temperature is 40º C. You have an actual refusal speed of 100 knots.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'You roll down the runway for your planned high speed taxi to approx 90 knots to evaluate the shimmy and sure enough you get the shimmy at 85 knots. You abort the taxi and start to taxi back down the parallel. One mx guys asks the pilot if the NWS was also shaking at the time of shimmy. “Gee. I don’t know, my hand was off the wheel”. So you attempt another high speed taxi to evaluate. Again abort at 85 knots and sure enough, the NWS was shaking. While taxing back again, the other mx troop asks, “Did the nose wheel bearing pointer also shake back and forth”? Pilot says, “Gee, I certainly was not looking at that”. So off you go again for another high speed taxi to determine the status of the pointer. By the way, if you ever experience a shimmy, these are typical trouble shooting questions maintenance will ask, so be prepared.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'After the 3rd high speed taxi, you determine that the pointer did not shake. The crew and maintenance decide to taxi back again and takeoff for the ACF mission since eh shimmy was not severe.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'During this actual takeoff roll to get airborne, you get a fire light at 98 knots, 2 knots prior to refusal. You  abort and go into antiskid braking since you are so close to actual refusal. You accomplish the ESP clear the runway and start taxing back to the parking ramp. About that time guess what? You guessed it. Tower reports smoke pouring out of your right wheel well! Just your day, an emergency ground egress. You set the opposite brake and command the appropriate actions for the egress.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'While you are outside the aircraft, you see the smoke, and parts of the brake assembly start falling onto the ground, the 3 fuse plugs blow per tire, the tires go flat and a fire starts. Fortunately the fire trucks arrive in time to put the fire out.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Lessons learned: During all ground operations, think about the health of your brakes! Especially during flight test operations when you perform unique operations, i.e. multiple high speed taxis. If they start to “chatter”, you really have already screwed up. You should never use the sound of chatter as your determining factor that the brakes are getting hot…nope they are not getting hot…they are hot! Kind of like cooking by a smoke alarm…not a good technique. After a single high speed taxi or an aborted takeoff, warm brakes will not perform with the same efficiency as brakes that are cooler. Hence their performance will go down considerably. What about after 3 high speed aborts?!' + CHAR(13) + CHAR(10) + '	' + CHAR(13) + CHAR(10) + 'Tough to explain to anyone why you allowed the aircraft to get into this type of situation, much less the tens of thousands of dollars to fix the aircraft and the down time.' + CHAR(13) + CHAR(10) + 'Bill and I are very familiar with a similar situation but only after 2 aborted takeoffs. Grant it, the aircraft was not a C-130 but hot brakes and the damage it can cause (and did cause) is all the same.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Scenario #2: You roll into parking and you see the marshaller as depicted below: What does this mean.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'A:  Does he/she mean to beat you to the draw?' + CHAR(13) + CHAR(10) + 'B:  How fast could they be with those guns?' + CHAR(13) + CHAR(10) + 'C:  Loadmaster, pull out your 9mm and get ready for some action!' + CHAR(13) + CHAR(10) + 'D:  ALL the above' + CHAR(13) + CHAR(10) + 'E:  HOT BRAKES!' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'SEE GRAPHIC ON INTRANET TFSF 91-50 SRF' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'TFS PUBLICATIONS/OPERATIONS/FCIF' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + 'Tough one? With this little reminder about the dangers of summertime flying, have a safe summer whether in the aircraft or elsewhere.' + CHAR(13) + CHAR(10) + '  ' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '');

/*******************************************************
** ALTER TABLE commands used to add table constraints **
*******************************************************/

ALTER TABLE [dbo].[categories] WITH NOCHECK ADD
  CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[helparticles] WITH NOCHECK ADD
  CONSTRAINT [PK_helparticles] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[links] WITH NOCHECK ADD
  CONSTRAINT [PK_links] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[posts] WITH NOCHECK ADD
  CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[posts] ADD
  CONSTRAINT [FK_posts_categories] FOREIGN KEY ([categoryID]) REFERENCES [dbo].[categories] ([id])
GO

/*******************************************************
** CREATE VIEW commands used to generate view queries **
*******************************************************/

