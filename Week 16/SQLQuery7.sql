--TSQL
--1
SELECT contactname, city, orderdate FROM Sales.Customers C 
JOIN Sales.Orders O ON C.custid = O.custid
WHERE city in ('Madrid', 'London')

--2
SELECT UPPER(productname), unitprice, categoryname FROM Production.Products P
JOIN Production.Categories C ON P.categoryid = C.categoryid
WHERE unitprice BETWEEN 20 and 40

--3
SELECT firstname, lastname, orderid FROM HR.Employees E
JOIN Sales.Orders O ON E.empid = O.empid
WHERE freight > 50

--4
SELECT orderdate, C.contactname, C.city, C.[address] FROM Sales.Orders O
JOIN Sales.Customers C ON O.custid = C.custid
JOIN Sales.OrderDetails OD ON OD.orderid = O.orderid
JOIN Production.Products P ON P.productid = OD.productid
JOIN Production.Suppliers S ON S.supplierid = P.supplierid
WHERE YEAR(orderdate) = 2007 AND S.country = 'USA'

--5
SELECT DISTINCT shipcity FROM Sales.Orders O
JOIN HR.Employees E ON O.empid = E.empid
WHERE lastname = 'Cameron'

--6 -- აქ მემგონი typo არის ამოცანაში და "საიდანაც" უნდა ეწეროს, თორე ჯოინი იდეაში საერთოდ არ უნდოდა.
SELECT O.orderid, city, country FROM Sales.Orders O
JOIN Sales.OrderDetails OD ON OD.orderid = O.orderid
JOIN Production.Products P ON P.productid = OD.productid
JOIN Production.Suppliers S ON S.supplierid = P.supplierid
WHERE shipcountry in ('Germany', 'Austria')

--7
SELECT * FROM Production.Products P
JOIN Production.Suppliers S ON P.supplierid = S.supplierid
JOIN Sales.OrderDetails OD ON OD.productid = P.productid
WHERE discount > 0 and city = 'Tokyo'

--8
SELECT productname, categoryname FROM Production.Products P
JOIN Production.Categories C ON C.categoryid = P.categoryid
JOIN Production.Suppliers S ON S.supplierid = P.supplierid
WHERE country = 'Japan' AND categoryname in ('Beverages', 'Seafood')

--9
SELECT firstname, lastname, companyname FROM HR.Employees E
JOIN Sales.Orders O ON O.empid = E.empid
JOIN Sales.OrderDetails OD ON OD.orderid = O.orderid
JOIN Production.Products P ON P.productid = OD.productid
JOIN Production.Suppliers S ON S.supplierid = P.supplierid
WHERE YEAR(orderdate) = 2007 AND CONCAT(firstname, ' ', lastname) in ('Sara Davis', 'Maria Cameron')

--10
SELECT productname, categoryname FROM Production.Products P
JOIN Production.Categories C ON C.categoryid = P.categoryid
JOIN Production.Suppliers S ON P.supplierid = S.supplierid
WHERE country = 'USA' AND categoryname not in ('Beverages', 'Seafood')

--11
SELECT orderid, lastname, firstname, E.city, contactname FROM Sales.Orders O
JOIN HR.Employees E ON E.empid = O.empid
JOIN Sales.Customers C ON C.custid = O.custid
WHERE E.city = C.city

--12
SELECT DISTINCT contactname FROM Sales.Customers C
JOIN Sales.Orders O ON C.custid = O.custid
JOIN Sales.OrderDetails OD ON OD.orderid = O.orderid
JOIN Production.Products P ON P.productid = OD.productid
JOIN Production.Categories CA ON CA.categoryid = P.categoryid
WHERE categoryname in ('Beverages', 'Dairy Products')