Create TABLE Sales.dbo.[User] (
        Id uniqueidentifier primary key,
        HasUsed bit not null default(0)
)

CREATE table Sales.dbo.[Book] (
    Id int primary key Identity (1, 1),
    Title nvarchar(255),
    Author nvarchar(255),
    PublicationYear int,
    Isbn varchar(20),
    CoverPicture varchar(max),
    Price decimal,
    CopiesNumber int
)

create table Sales.dbo.[ShoppingCart](
    Id int primary key Identity (1, 1),
    BookId int not null,
    UserId uniqueidentifier not null,
    CONSTRAINT FK_ShoppingCart_Book FOREIGN KEY (BookId) references Sales.dbo.[Book](Id),
    CONSTRAINT FK_ShoppingCart_User FOREIGN KEY (UserId) references Sales.dbo.[User](Id)
)

create table Sales.dbo.[Order](
    Id int primary key Identity (1, 1),
    UserId uniqueidentifier not null,
    BookIds varchar(max),
    Price decimal,
    CONSTRAINT FK_Order_User FOREIGN KEY (UserId) references Sales.dbo.[User](Id)
)