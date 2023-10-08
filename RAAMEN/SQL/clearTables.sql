delete from Detail;
delete from Header;

DBCC CHECKIDENT ('Header', RESEED, 0);
