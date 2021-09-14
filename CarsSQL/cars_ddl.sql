USE CarsDB;

IF OBJECT_ID('Car') IS NOT NULL
    DROP TABLE Car;

CREATE Table Car (
    registration VARCHAR(7) PRIMARY KEY,
    make VARCHAR(25),
    model VARCHAR(25),
    yearOfManufacture INT
)
