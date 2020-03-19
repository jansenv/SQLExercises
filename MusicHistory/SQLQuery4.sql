--SELECT Title FROM Album
--WHERE Label = 'Columbia'

--SELECT al.Title, ar.ArtistName FROM Album al
--Left join Artist ar ON ar.Id = al.ArtistId

--SELECT al.Title, ar.ArtistName, g.Label FROM Album al
--Left join Artist ar ON ar.Id = al.ArtistId
--Left join Genre g ON g.id = al.GenreId
--WHERE al.Id = 17

--UPDATE Album
--SET Title = 'Eliminator 2: Judgementday'
--WHERE Id = 17

--SELECT * FROM Album
--WHERE Id = 17

--SELECT Id, Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId FROM Song

--SELECT Id, Title, ReleaseDate FROM Song;

--Does the same as line 12:
--SELECT * FROM Song;

--SELECT Id, Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId FROM Song
--WHERE SongLength > 100;

--SELECT s.Title, a.ArtistName FROM Song s
--LEFT JOIN Artist a on s.ArtistId = a.id

--INSERT INTO Genre (Label) VALUES ('Techno');

--SELECT SongLength from Song where Id = 18;

--UPDATE Song
--SET SongLength = 515
--WHERE Id = 18;

--SELECT SongLength from Song where Id = 18;

--DELETE FROM Song WHERE Id = 18;

--1

--SELECT * FROM Genre;

--2

--INSERT INTO Artist VALUES ('The Artist Formerly Known As Prince', 1978);

--3

--INSERT INTO Album VALUES ('Purple Rain', 3/23/1984, 2100, 'Columbia', 29, 7);