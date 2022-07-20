create database Estudos

CREATE TABLE ProductPrice (
    IdProduct int PRIMARY KEY, 
    Price decimal(9, 2) NOT NULL,
    PriceCost decimal(9, 2) NOT NULL,
    CreateDate Datetime NOT NULL,
    UpdateDate Datetime NOT NULL 
);