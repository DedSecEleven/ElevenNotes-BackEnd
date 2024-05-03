-- Active: 1714697949194@@bmymb9wmz5gxovy9rf36-mysql.services.clever-cloud.com@3306@bmymb9wmz5gxovy9rf36
CREATE TABLE Users(
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(100) NOT NULL
);

CREATE TABLE Notes(
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Title VARCHAR(100) NOT NULL,
  Content TEXT(50000) NOT NULL,
  UserId INT NOT NULL,
  DateModified DATETIME NOT NULL,
  FOREIGN KEY (UserId) REFERENCES Users(Id)
);

insert into `Users` (`Id`, `Name`) values 
(1,"Juanky"),
(2,"Dani");