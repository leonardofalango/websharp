USE master;
GO

CREATE DATABASE WebSharp;
GO
USE WebSharp;
GO

CREATE TABLE dbo.Countries(
	Id INT PRIMARY KEY IDENTITY,
	CountryName VARCHAR(255) NOT NULL,
	-- Continent foreign ....
)
GO

CREATE TABLE dbo.States(
	Id INT PRIMARY KEY IDENTITY,
	StateName VARCHAR(255) NOT NULL,
	IdCountry INT FOREIGN KEY REFERENCES dbo.Countries(Id)
);
GO

CREATE TABLE dbo.Cities(
	Id INT PRIMARY KEY IDENTITY,
	CityName VARCHAR(255) NOT NULL,
	IdState INT FOREIGN KEY REFERENCES dbo.States(Id)
);
GO


CREATE TABLE dbo.News(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	Thumbnail VARCHAR(MAX) NOT NULL,
	Content VARCHAR(MAX) NOT NULL,
	IdCity INT FOREIGN KEY REFERENCES dbo.Cities(Id),
	NewsDate DATETIME DEFAULT(GETDATE())
	-- Topics
);
GO


CREATE TABLE dbo.Topics(
	Id INT PRIMARY KEY IDENTITY,
	TopicName VARCHAR(80) NOT NULL,
	Quantity INT
);
GO

CREATE TABLE dbo.TopicsXNews(
	Id INT PRIMARY KEY IDENTITY,
	IdTopic INT FOREIGN KEY REFERENCES dbo.Topics(Id),
	IdNews INT FOREIGN KEY REFERENCES dbo.News(Id)
)
GO


INSERT INTO Countries (CountryName) VALUES
	('Brazil');
GO

INSERT INTO States(StateName, IdCountry) VALUES
	('São Paulo', 1)
GO

INSERT INTO Cities(CityName, IdState) VALUES
	('São paulo', 1)
GO

INSERT INTO News(Title, Thumbnail, Content, IdCity, NewsDate) VALUES
	('PlayStation 5 na nuvem? Sony começa testes com streaming',
	'https://tm.ibxk.com.br/2023/06/15/15083211459013.jpg?ims=704x264',
	'Por mais que o catálogo da nova PlayStation Plus Extra e Deluxe venha melhorando a cada atualização, um departamento onde o serviço por assinatura da Sony deixa muito a desejar em relação ao rival Xbox Game Pass da Microsoft é o cloud gaming. No entanto, parece que a gigante japonesa está disposta a começar a trabalhar em uma solução.

	Hoje (14) a Sony revelou que está "atualmente testando o streaming na nuvem para jogos de PS5 compatíveis. Isso inclui títulos do catálogo da PlayStation Plus e Trials, além de jogos digitais que a pessoa já possui".

	Em comunicado enviado ao site The Verge, Nick Maguire, vice-presidente de serviços globais e operações da Sony, completou o raciocínio afirmando que "quando esse recurso for lançado, o streaming de jogos na nuvem para jogos compatíveis de PS5 se tornará disponível diretamente no seu console."',
	1, GETDATE())
GO

SELECT * FROM News