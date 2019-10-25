CREATE TABLE Gyarto(
	Gyarto_neve VARCHAR(20) NOT NULL,
	Honlap VARCHAR(30),
	E_mail VARCHAR(30),
	Telefon NUMERIC(13),
	Kozpont VARCHAR(20) NOT NULL,
	Adoszam NUMERIC(20) NOT NULL,
	CONSTRAINT gyarto_pk PRIMARY KEY(Gyarto_neve)
);
CREATE TABLE Aruhaz(
	Aruhaz_neve VARCHAR(20) NOT NULL,
	Honlap VARCHAR(30),
	E_mail VARCHAR(30),
	Telefon NUMERIC(13),
	Kozpont VARCHAR(20) NOT NULL,
	Adoszam NUMERIC(20) NOT NULL,
	CONSTRAINT aruhaz_pk PRIMARY KEY(Aruhaz_neve)
);
CREATE TABLE Termek(
	Termek_ID NUMERIC NOT NULL,
	Tipus VARCHAR(30) NOT NULL,
	Megnevezes VARCHAR(30) NOT NULL,
	Kiszereles VARCHAR(30),
	Ar NUMERIC(5),
	Leiras VARCHAR(300),
	Gyarto_neve VARCHAR(20),
	CONSTRAINT termek_pk PRIMARY KEY(Termek_ID),
	CONSTRAINT gyarto_fk FOREIGN KEY(Gyarto_neve)
	REFERENCES Gyarto(Gyarto_neve)
);
CREATE TABLE ID_Kapcsolo(
	Kapcsolo_ID NUMERIC NOT NULL,
	Termek_ID NUMERIC NOT NULL,
	Aruhaz_neve VARCHAR(20) NOT NULL,
	CONSTRAINT kapcsolo_pk PRIMARY KEY(Kapcsolo_ID),
	CONSTRAINT termek_fk FOREIGN KEY(Termek_ID)
	REFERENCES Termek(Termek_ID),
	CONSTRAINT aruhaz_fk FOREIGN KEY(Aruhaz_neve)
	REFERENCES Aruhaz(Aruhaz_neve)
);

INSERT INTO Gyarto
VALUES('Spa','spa.hu','info@spa.hu',06709815555,'Hollandia',22222222222);
INSERT INTO Gyarto
VALUES('KicsitSárgaKicsitS',null,null,06305550567,'Magyarország',13131399911);
INSERT INTO Gyarto
VALUES('Zeva','zeva.hu',null,06802301999,'Franciaország',98798700012);
INSERT INTO Gyarto
VALUES('Milk','milk.hu','info@milk.hu',06404880568,'Németország',10001322916);
INSERT INTO Gyarto
VALUES('Tibor','tibor.hu','info@tibor.hu',06301005688,'Magyarország',14441375522);
INSERT INTO Gyarto
VALUES('Csokapik','csoka.hu',null,06301115558,'Németország',99988877743);
INSERT INTO Gyarto
VALUES('Kiscsillag',null,null,06801705690,'Magyarország',14483378911);
INSERT INTO Gyarto
VALUES('Duracella','elem.hu','info@elem.hu',06704005678,'Finnország',99991885522);
INSERT INTO Gyarto
VALUES('Gyermeki',null,'info@gyermeki.hu',06308886978,'Magyarország',78781353521);
INSERT INTO Aruhaz
VALUES('Osan','osan.hu','info@osan.hu',06801231234,'Franciaország',11111111111);
INSERT INTO Aruhaz
VALUES('Spa','spa.hu','info@spa.hu',06709815555,'Hollandia',22222222222);
INSERT INTO Aruhaz
VALUES('Lill','lill.hu','info@lill.hu',06902315987,'Oroszország',92134556755);
INSERT INTO Aruhaz
VALUES('Ilda','ilda.hu','info@ilda.hu',06200714565,'Hollandia',85851000943);
INSERT INTO Aruhaz
VALUES('ABC','abc.hu','info@abc.hu',06306969769,'Magyarország',88843257511);
INSERT INTO Termek
VALUES(1,'Tisztaság','Zsebkendő','100 db:csomag',379,'Mentolos, 4 rétegű','Zeva');
INSERT INTO Termek
VALUES(16,'Tisztaság','Zsebkendő','100 db:csomag',329,'Mentolos, 4 rétegű','Zeva');
INSERT INTO Termek
VALUES(17,'Tisztaság','Zsebkendő','100 db:csomag',419,'Mentolos, 4 rétegű','Zeva');
INSERT INTO Termek
VALUES(2,'Tisztaság','Zsebkendő','90 db:csomag',89,'Sima, 3 rétegű','Zeva');
INSERT INTO Termek
VALUES(19,'Tisztaság','Zsebkendő','90 db:csomag',109,'Sima, 3 rétegű','Zeva');
INSERT INTO Termek
VALUES(20,'Tisztaság','Zsebkendő','90 db:csomag',99,'Sima, 3 rétegű','Zeva');
INSERT INTO Termek
VALUES(3,'Tisztaság','Zsebkendő','100 db:csomag',119,'Sima, 3 rétegű','Spa');
INSERT INTO Termek
VALUES(4,'Tisztaság','Szappan','1 db',199,null,'Zeva');
INSERT INTO Termek
VALUES(21,'Tisztaság','Szappan','1 db',179,null,'Zeva');
INSERT INTO Termek
VALUES(5,'Édesség','Csokoládé','100 g',269,null,'Milk');
INSERT INTO Termek
VALUES(6,'Édesség','Csokoládé','100 g',279,null,'Tibor');
INSERT INTO Termek
VALUES(18,'Édesség','Csokoládé','100 g',269,null,'Tibor');
INSERT INTO Termek
VALUES(7,'Étel','Babkonzerv','500 g',799,'Csípős','Spa');
INSERT INTO Termek
VALUES(8,'Étel','Fagyasztott rántotthús','1000 g',2250,null,'Spa');
INSERT INTO Termek
VALUES(9,'Étel','Gabonapehely','750 g',869,'Csokis','Csokapik');
INSERT INTO Termek
VALUES(10,'Ital','Tej','1 liter',179,'2,8%, kancsós','Spa');
INSERT INTO Termek
VALUES(11,'Hozzávaló','Kockacukor','1 kg',200,null,'Kiscsillag');
INSERT INTO Termek
VALUES(12,'Hozzávaló','Liszt','1 kg',249,null,'Gyermeki');
INSERT INTO Termek
VALUES(13,'Hozzávaló','Liszt','1 kg',229,'Magyar termék','Gyermeki');
INSERT INTO Termek
VALUES(14,'Elektronika','Elem','4 db',240,null,'Duracella');
INSERT INTO Termek
VALUES(22,'Elektronika','Elem','4 db',240,null,'Duracella');
INSERT INTO Termek
VALUES(23,'Elektronika','Elem','4 db',250,null,'Duracella');
INSERT INTO Termek
VALUES(24,'Elektronika','Elem','4 db',180,null,'Duracella');
INSERT INTO Termek
VALUES(25,'Elektronika','Elem','4 db',229,null,'Duracella');
INSERT INTO Termek
VALUES(15,'Ital','Narancslé','1 liter',179,'Magyar termék','KicsitSárgaKicsitS');
INSERT INTO ID_Kapcsolo
VALUES(1,1,'Osan');
INSERT INTO ID_Kapcsolo
VALUES(2,16,'Lill');
INSERT INTO ID_Kapcsolo
VALUES(3,17,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(4,2,'Osan');
INSERT INTO ID_Kapcsolo
VALUES(5,19,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(6,20,'Ilda');
INSERT INTO ID_Kapcsolo
VALUES(7,3,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(8,4,'ABC');
INSERT INTO ID_Kapcsolo
VALUES(9,21,'Osan');
INSERT INTO ID_Kapcsolo
VALUES(10,5,'Osan');
INSERT INTO ID_Kapcsolo
VALUES(11,6,'ABC');
INSERT INTO ID_Kapcsolo
VALUES(12,18,'Ilda');
INSERT INTO ID_Kapcsolo
VALUES(13,7,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(14,8,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(15,9,'ABC');
INSERT INTO ID_Kapcsolo
VALUES(16,10,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(17,11,'ABC');
INSERT INTO ID_Kapcsolo
VALUES(18,12,'Ilda');
INSERT INTO ID_Kapcsolo
VALUES(19,13,'Lill');
INSERT INTO ID_Kapcsolo
VALUES(20,14,'Osan');
INSERT INTO ID_Kapcsolo
VALUES(21,22,'Spa');
INSERT INTO ID_Kapcsolo
VALUES(22,23,'Lill');
INSERT INTO ID_Kapcsolo
VALUES(23,24,'ABC');
INSERT INTO ID_Kapcsolo
VALUES(24,25,'Ilda');
INSERT INTO ID_Kapcsolo
VALUES(25,15,'Spa');