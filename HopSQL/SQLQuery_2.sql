
create table Stores(
    Id int primary key identity(1,1), /* starts with one and increments by 1 */
    Name varchar(100) not null,
    City VARCHAR(50),
    State VARCHAR(50)
);

CREATE TABLE Beer(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) not null,
    Price DECIMAL,
    Stock INT
)

INSERT INTO Stores(Name, City, State) VALUES
('Hopcity', 'Atlanta', 'Georgia'),
('Hopcity Krog', 'Atlanta', 'Georgia');

SELECT * FROM Stores;

INSERT INTO Beer(Name, Price, Stock) VALUES
('Corona', 3.00, 20),
('MondayNightBlindPirate',5.50, 30);

SELECT * FROM Beer;