-- Kontrakty
create table Kontrakty(
    ID_Kontrakt serial primary key,
    Data_rozpoczecia Date not null,
    Data_zakonczenia Date not null,
    Pensja decimal(7,2) null
);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',30000.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',24000.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',31000.00);

insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',15000.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',15500.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',29000.00);

insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',5000.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',5000.00);

insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',14000.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',12000.00);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',18000.00);

insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',null);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',null);
insert into Kontrakty(Data_rozpoczecia, Data_zakonczenia,Pensja)
values('2018-01-01','2021-10-01',null);

-- Trenerzy
create table Trenerzy(
    ID_Trener serial primary key,
    Imie varchar (40) not null,
    Nazwisko varchar (40) not null,
    Data_urodzenia date not null,
    Plec varchar(1) check (Plec in('M','K')),
    Narodowosc varchar(40) not null,
    Kontrakt_ID int REFERENCES Kontrakty(ID_Kontrakt) ON DELETE SET NULL
);
insert into Trenerzy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Kontrakt_ID)
values('Roman','Borawski','1972-02-20','M','Polska',1);
insert into Trenerzy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Kontrakt_ID)
values('Grzegorz','Pastuszak','1984-06-24','M','Polska',2);
insert into Trenerzy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Kontrakt_ID)
values('Stefano','Pioli','1979-06-25','M','Włochy',3);

-- Zespoły
create table Zespoly(
    ID_Zespol serial primary key,
    Nazwa varchar(50) not null,
    Trener_ID int REFERENCES Trenerzy(ID_Trener) ON DELETE SET NULL
);
insert into Zespoly(Nazwa, Trener_ID)
values('Zespół Piłkarski-Juniorzy',1);
insert into Zespoly(Nazwa, Trener_ID)
values('Zespół Siatkarski',2);
insert into Zespoly(Nazwa, Trener_ID)
values('Zespół Piłkarski-Seniorzy',3);


-- Zawodnicy
create table Zawodnicy(
    ID_Zawodnik serial primary key,
    Imie varchar (40) not null,
    Nazwisko varchar (40) not null,
    Data_urodzenia Date not null,
    Plec varchar(1) check (Plec in('M','K')),
    Narodowosc varchar(40) not null,
    Zespol_ID int REFERENCES Zespoly(ID_Zespol) ON DELETE SET NULL,
    Kontrakt_ID int REFERENCES Kontrakty(ID_Kontrakt) ON DELETE SET NULL
    -- Pozycja ???????????
);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Szymon','Feret','1997-01-10','M','Polska',1,4);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Sylwester','Lusiusz','1999-07-14','M','Polska',1,5);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Dawid','Burka','1992-08-11','M','Polska',1,6);

insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Piotr','Siudi','1999-05-11','M','Polska',2,9);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Adrian','Lusterko','1998-02-11','M','Polska',2,10);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Maximilian','Kolarov','1994-12-25','M','Rosja',2,11);

insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Kamil','Sobota','2005-01-02','M','Polska',3,12);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Adam','Małysz','2005-08-29','M','Polska',3,13);
insert into Zawodnicy(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Zespol_ID, Kontrakt_ID)
values('Miłosz','Barański','2003-07-02','M','Polska',3,14);

-- Fizjoterapeuci
create table Fizjoterapeuci(
    ID_Fizjoterapeuta serial primary key,
    Imie varchar (40) not null,
    Nazwisko varchar (40) not null,
    Data_urodzenia Date not null,
    Plec varchar(1) check (Plec in('M','K')),
    Narodowosc varchar(40) not null,
    Kontrakt_ID int REFERENCES Kontrakty(ID_Kontrakt) ON DELETE SET NULL
);
insert into Fizjoterapeuci(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Kontrakt_ID)
values('Olivia','Kovalsky','1989-02-18','K','USA',7);
insert into Fizjoterapeuci(Imie, Nazwisko, Data_urodzenia, Plec, Narodowosc, Kontrakt_ID)
values('Jolene','Parton','1991-07-02','K','Anglia',8);

-- Kontuzje
create table Kontuzje(
    ID_Kontuzja serial primary key,
    Opis varchar(50),
    Data_doznania Date not null,
    Data_wyleczenia Date,
    Zawodnik_ID int REFERENCES Zawodnicy(ID_Zawodnik) ON DELETE SET NULL,
    Fizjoterapeuta_ID int REFERENCES Fizjoterapeuci(ID_Fizjoterapeuta) ON DELETE SET NULL
);
insert into Kontuzje(Opis, Data_doznania, Data_wyleczenia, Zawodnik_ID, Fizjoterapeuta_ID)
values('Stłuczenie mięsnia dwugłowego prawego uda','2020-12-07','2020-12-29',1,1);
insert into Kontuzje(Opis, Data_doznania, Data_wyleczenia, Zawodnik_ID, Fizjoterapeuta_ID)
values('Złamanie obojczyka lewego','2020-12-14','2021-01-20',4,2);













