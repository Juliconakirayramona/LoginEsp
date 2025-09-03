CREATE TABLE Estudiantes (
	Id INT,
	Nombre VARCHAR2(20 BYTE)
);

CREATE TABLE Matwrias (
	Id INT,
	Nombre VARCHAR2(20 BYTE),
	Nota NUMBER (18, 2),
	EstudianteId INT
);