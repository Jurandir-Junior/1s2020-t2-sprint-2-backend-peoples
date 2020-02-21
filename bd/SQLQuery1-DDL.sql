CREATE DATABASE M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios (
	idFuncionario INT PRIMARY KEY IDENTITY,
	NomeFuncionario VARCHAR (255),
	SobrenomeFuncionario VARCHAR (255)
);

ALTER TABLE Funcionarios
ADD DataNascimento DATE 

ALTER TABLE Funcionarios
ALTER COLUMN NomeFuncionario VARCHAR (255) NOT NULL
