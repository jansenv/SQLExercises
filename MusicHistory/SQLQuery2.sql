SELECT Title FROM Album
WHERE Label = 'Columbia'

SELECT al.Title, ar.ArtistName FROM Album al
Left join Artist ar ON ar.Id = al.ArtistId

SELECT al.Title, ar.ArtistName, g.Label FROM Album al
Left join Artist ar ON ar.Id = al.ArtistId
Left join Genre g ON g.id = al.GenreId
WHERE al.Id = 17

UPDATE Album
SET Title = 'Eliminator 2: Judgementday'
WHERE Id = 17

SELECT * FROM Album
WHERE Id = 17

SELECT Id, Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId FROM Song

SELECT Id, Title, ReleaseDate FROM Song;

Does the same as line 12:
SELECT * FROM Song;

SELECT Id, Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId FROM Song
WHERE SongLength > 100;

SELECT s.Title, a.ArtistName FROM Song s
LEFT JOIN Artist a on s.ArtistId = a.id

INSERT INTO Genre (Label) VALUES ('Techno');

SELECT SongLength from Song where Id = 18;

UPDATE Song
SET SongLength = 515
WHERE Id = 18;

SELECT SongLength from Song where Id = 18;

DELETE FROM Song WHERE Id = 18;

--1

SELECT * 
FROM Genre;

--2

INSERT INTO Artist VALUES ('The Artist Formerly Known As Prince', 1978);

--3

INSERT INTO Album VALUES ('Purple Rain', 3/23/1984, 2100, 'Columbia', 29, 7);

--4

INSERT INTO Song VALUES ('Darling Nikki', 360, 3/23/1984, 7, 29, 23)

--5

SELECT s.Title, al.Title, ar.ArtistName 
FROM Song s
LEFT JOIN Album al ON s.AlbumId = al.Id
LEFT JOIN Artist ar ON s.ArtistId = ar.Id
WHERE s.Id = 22

--6

SELECT COUNT (AlbumId) AS 'Song Count', al.Title 
FROM Song S
LEFT JOIN Album al ON s.AlbumId = al.Id
GROUP BY AlbumId, al.Title
ORDER BY COUNT(AlbumId) desc;

--7

SELECT COUNT (ArtistId) AS 'Song Count', ar.ArtistName 
FROM Song S
LEFT JOIN Artist ar ON s.ArtistId = ar.Id
GROUP BY ArtistId, ar.ArtistName
ORDER BY COUNT(AlbumId) desc;

--8

SELECT COUNT (GenreId) AS 'Song Count', g.[Label]
FROM Song S
LEFT JOIN Genre g ON s.GenreId = g.Id
GROUP BY GenreId, g.[Label]
ORDER BY COUNT(AlbumId) desc;

--9

SELECT Title, AlbumLength
FROM Album
WHERE AlbumLength=(SELECT MAX(AlbumLength) from Album);

--10

SELECT Title, SongLength
FROM Song S
WHERE SongLength=(SELECT MAX(SongLength) from Song);

--11

SELECT s.Title, a.Title, SongLength as 'Song Length'
from Song s
LEFT JOIN Album a ON s.AlbumId = a.Id
WHERE SongLength=(SELECT MAX(SongLength) from Song);

SELECT * FROM Album;