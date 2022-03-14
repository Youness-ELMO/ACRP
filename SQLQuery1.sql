create database EFM_REGIO
use EFM_REGIO

create table Adherent (codeAd int primary key identity ,
						nom varchar(20),
						prénom varchar(20),
						dateNaissance date,
						telephone int, 
						adresse varchar(50),
						dateInscription date)

create table Circuits (codeCircuit int primary key identity,
					Intitule varchar(20),
					duree int,
					distanceAmarcher int,
					caracteristiques varchar(30) )

create table Randonnee (codeRandonnee int primary key,
						CodeCircuit int foreign key references Circuits(codeCircuit),
						dateR date,
						prix float,
						depart int,
						nbPlacemaxi int,
						nomResponsable varchar(20))

create table Participer (codeAd int foreign key references Adherent(codeAd) ,
							codeR int foreign key references Randonnee(codeRandonnee),
							dateInscriptionR date)




