﻿CREATE TABLE Activities(
ActivityID INTEGER NOT NULL AUTO_INCREMENT,
ActivityImage VARCHAR(255) NOT NULL,
ActivityName VARCHAR(50) NOT NULL,
ActivityDesc VARCHAR(1000) NOT NULL,
ActivityType VARCHAR(30) NOT NULL,
ActivityPlace JSON NOT NULL,
EntranceFee DOUBLE DEFAULT 0,
PRIMARY KEY(ActivityID)
);



CREATE TABLE Users(
UserID INTEGER NOT NULL AUTO_INCREMENT,
Email VARCHAR(50) NOT NULL,
FullName VARCHAR(40) NOT NULL,
Password VARCHAR(50) NOT NULL,
PRIMARY KEY(UserID),
UNIQUE (Email)
);



CREATE TABLE Reviews(
ReviewID INTEGER NOT NULL AUTO_INCREMENT,
ReviewTitle VARCHAR(100) NOT NULL,
Rating INTEGER NOT NULL,
ReviewDESC VARCHAR(1000) NOT NULL,
ReviewWriter INTEGER NOT NULL,
Activity INTEGER NOT NULL,
PRIMARY KEY(ReviewID),
FOREIGN KEY(ReviewWriter) REFERENCES Users(UserID),
FOREIGN KEY(Activity) REFERENCES Activities(ActivityID)
);



CREATE TABLE Suggestions(
SuggestionID INTEGER NOT NULL AUTO_INCREMENT,
ActivityIdea VARCHAR(50) NOT NULL,
ActivityLocation VARCHAR(50) NOT NULL,
ActivityDesc VARCHAR(1000) NOT NULL,
PRIMARY KEY(SuggestionID)
);