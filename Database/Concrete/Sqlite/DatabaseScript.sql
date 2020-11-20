
CREATE TABLE [Kategoriler] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [KategoriAdi] text NOT NULL unique
);
insert into [Kategoriler] (KategoriAdi) VALUES ('Para Transferi');
CREATE TABLE [HesapKart] (
  [HesapId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [HesapKartAdi] text NOT NULL
, [HesapTuru] text NOT NULL
, [Bakiye] real NOT NULL
, [BaslangicBakiye] real NOT NULL
);
CREATE TABLE [Giderler] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [GiderAdi] text NOT NULL
, [Miktar] real NOT NULL
, [Tarih] text NOT NULL DEFAULT CURRENT_TIMESTAMP
, [HesapId] INTEGER NOT NULL
, [KategoriId] integer not null
, FOREIGN KEY ([HesapId])
       REFERENCES [HesapKart] ([HesapId])
,foreign key ([KategoriId])
references [KategoriId] ([Id])
);
CREATE TABLE [Gelirler] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [GelirAdi] text NOT NULL
, [Miktar] real NOT NULL
, [Tarih] text NOT NULL DEFAULT CURRENT_TIMESTAMP
, [HesapId] INTEGER NOT NULL
, [KategoriId] integer not null
, FOREIGN KEY ([HesapId])
       REFERENCES [HesapKart] ([HesapId])
       ,foreign key ([KategoriId])
references [KategoriId] ([Id])
);


