--Kreiranje baze podataka pod nazivom "MiBospo"
CREATE DATABASE MiBospo;

--Naredba za korištenje prethodno kreirane baze podataka
USE MiBospo;

/*Kreiram tabelu grad*/
CREATE TABLE Grad (
GradID INT IDENTITY(1,1)PRIMARY KEY,
Naziv CHAR(50) UNIQUE NOT NULL,
);

--Ubacujem nazive gradova u varijablu Naziv iz tabele Grad
INSERT INTO Grad VALUES ('Tuzla'), ('Lukavac'), ('Bijeljina'), ('Banja Luka'), ('Sarajevo'), ('Ilidža');

--Kreiram tabelu Komitent
CREATE TABLE Komitent (
JMBG CHAR(13) PRIMARY KEY, 
Ime CHAR(50) NOT NULL,
Prezime CHAR(50) NOT NULL,
DatumRodjenja DATE NOT NULL,
GradID INT NOT NULL,
Adresa CHAR(100) NOT NULL,
CONSTRAINT FK_Komitent_Grad FOREIGN KEY (GradID) REFERENCES Grad(GradID),
);

--Kreiranje tabele Regije
CREATE TABLE Regija (
ID INT PRIMARY KEY,
Naziv VARCHAR(50) NOT NULL,
);

--Kreiranje tabele podružnice
CREATE TABLE Podruznica (
ID INT IDENTITY (1,1) PRIMARY KEY,
Naziv CHAR(50) NOT NULL,
RegijaID INT NOT NULL,
CONSTRAINT FK_Podruznica_Regija FOREIGN KEY (RegijaID) REFERENCES Regija(ID),
);

--Kreiranje tabele Uredi
CREATE TABLE Ured (
ID INT IDENTITY(1,1) PRIMARY KEY,
Naziv CHAR(50) NOT NULL,
PodruznicaID INT NOT NULL,
CONSTRAINT FK_Ured_Podruznica FOREIGN KEY (PodruznicaID) REFERENCES Podruznica(ID),
);
--Kreiranje tabele Krediti
CREATE TABLE Krediti (
ID INT IDENTITY(1,1),
KomitentJMBG CHAR(13) NOT NULL,
BrojKredita CHAR(15) PRIMARY KEY NOT NULL,
DatumIsplate DATE NOT NULL,
IznosIsplacenogKredita NUMERIC(10,2) NOT NULL,
KamatnaStopa NUMERIC(5,2) NOT NULL,
RokOtplateKredita NUMERIC(3,0) NOT NULL,
UredID INT NOT NULL,
CONSTRAINT FK_Kredit_Komitent FOREIGN KEY (KomitentJMBG) REFERENCES Komitent(JMBG),
CONSTRAINT FK_Kredit_Ured FOREIGN KEY(UredID) REFERENCES Ured(ID),
);
--Dodavanje podataka u tabeli regija
INSERT INTO Regija VALUES (1, 'Regija 1'), (2, 'Regija 2'), (3, 'Regija 3');

--Dodavanje podataka u tabelu podruznica
INSERT INTO Podruznica VALUES 
('Podružnica Tuzla', 1), 
('Podružnica Lukavac', 1), 
('Podružnica Bijeljina', 2), 
('Podružnica Banja Luka', 2), 
('Podružnica Sarajevo', 3), 
('Podružnica Ilidža', 3);



--Ubacujem podatke u tabelu ured
INSERT INTO Ured VALUES
--Ured Tuzla
('Ured Tuzla 1', 1), 
('Ured Tuzla 2', 1), 
('Ured Tuzla 3', 1);
--Ured Lukavac
INSERT INTO Ured VALUES
('Ured Lukavac 1', 2), 
('Ured Lukavac 2', 2), 
('Ured Lukavac 3', 2),
--Ured Bijeljina
('Ured Bijeljina 1', 3), 
('Ured Bijeljina 2', 3), 
('Ured Bijeljina 3', 3),
--Ured Banja Luka
('Ured Banja Luka 1', 4), 
('Ured Banja Luka 2', 4), 
('Ured Banja Luka 3', 4),
--Ured Sarajevo
('Ured Sarajevo 1', 5), 
('Ured Sarajevo 2', 5), 
('Ured Sarajevo 3', 5),
--Ured Ilidža
('Ured Ilidža 1', 6), 
('Ured Ilidža 2', 6), 
('Ured Ilidža 3', 6);

ALTER TABLE Komitent 
ALTER COLUMN DatumRodjenja DATE NULL;


ALTER TABLE Krediti
ALTER COLUMN RokOtplateKredita INT NOT NULL;

SELECT * FROM Krediti WHERE IznosIsplacenogKredita > 2000;

SELECT * FROM Krediti WHERE DatumIsplate BETWEEN '2006-11-11' AND '2022-12-30';

INSERT INTO REGIJA VALUES (4, 'MI-BOSPO');

/*GRUPA 1*/
SELECT
  Podruznica.RegijaID,
  Regija.Naziv AS 'Regija',
  Podruznica.Naziv AS 'Podružnica',
  COUNT(*) AS 'COUNT',
  SUM(Krediti.IznosIsplacenogKredita) AS 'SUM',
  MIN(Krediti.IznosIsplacenogKredita) AS 'MIN',
  MAX(Krediti.IznosIsplacenogKredita) AS 'MAX',
  AVG(Krediti.IznosIsplacenogKredita) AS 'AVG'
FROM Krediti
JOIN Ured ON Krediti.UredID = Ured.ID
JOIN Podruznica ON Ured.PodruznicaID = Podruznica.ID
JOIN Regija ON Podruznica.RegijaID = Regija.ID
GROUP BY Podruznica.RegijaID, Regija.Naziv, Podruznica.Naziv
ORDER BY Regija.Naziv DESC, Podruznica.Naziv DESC;

/*GRUPA 2: */
SELECT
  Ured.PodruznicaID,
  Podruznica.Naziv AS 'Podružnica',
  Ured.Naziv AS 'Ured',
  COUNT(*) AS 'COUNT',
  SUM(Krediti.IznosIsplacenogKredita) AS 'SUM',
  MIN(Krediti.IznosIsplacenogKredita) AS 'MIN',
  MAX(Krediti.IznosIsplacenogKredita) AS 'MAX',
  AVG(Krediti.IznosIsplacenogKredita) AS 'AVG'
FROM Krediti
JOIN Ured ON Krediti.UredID = Ured.ID
JOIN Podruznica ON Ured.PodruznicaID = Podruznica.ID
GROUP BY Ured.PodruznicaID, Podruznica.Naziv, Ured.Naziv
ORDER BY Podruznica.Naziv DESC, Ured.Naziv DESC;