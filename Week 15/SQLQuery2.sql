--Students
--1
SELECT * FROM dbo.Students WHERE DoB >= '1990-01-01'

--2
DECLARE @CurrentYear date = GETDATE()

SELECT Firstname, Lastname, (DATEDIFF(year, DoB, @CurrentYear)) AS Age FROM dbo.Students WHERE country = 'Georgia' OR country = 'Libia'

--3
INSERT INTO dbo.Students (Firstname, Lastname, DoB) VALUES ('John', 'Doe', '1993-01-01')

--4 
WITH temp AS(
SELECT Firstname, 
       Lastname, 
       MiddleTest, 
       DENSE_RANK() OVER(ORDER BY MiddleTest DESC) as Rank
FROM Students)

SELECT Firstname, Lastname, MiddleTest FROM temp WHERE Rank <=5

--5 
DELETE Students
OUTPUT deleted.[Lastname], deleted.[Firstname]
WHERE MiddleTest = 19

--6
UPDATE Students
SET MiddleTest = 0
OUTPUT inserted.Firstname
WHERE MiddleTest = 1

--Persons

--1
SELECT * FROM Persons WHERE PrivateId LIKE '163%'

--2
SELECT * FROM Persons WHERE Lastname = City

--3
SELECT * FROM Persons WHERE Country IN ('Canada', 'Monaco')

--4
SELECT Firstname, Lastname, PrivateId FROM Persons WHERE Email IS NULL

--5
SELECT * FROM Persons WHERE Country IN ('Spain', 'Turkey') AND Salary BETWEEN 1000 AND 3000

--6
SELECT WorkPlace FROM Persons WHERE WorkPlace LIKE '%LLC%' OR WorkPlace LIKE '%PC%' OR WorkPlace LIKE '%LLP%'

--7
SELECT *, CASE
WHEN len(Email) - len(replace(Email, '.', '')) > 2 then 'More than 2 dots'
ELSE 'Less than 2 dots'
END AS 'MailInfo'
FROM Persons

--8
SELECT * FROM Persons WHERE PINcode LIKE '%51'

--9
SELECT Country, AVG(Salary) AS 'Average Salary' FROM Persons
GROUP BY Country
