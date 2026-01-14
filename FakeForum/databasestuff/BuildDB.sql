
CREATE TABLE AppUser (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Bio VARCHAR(1000),
    AvatarUrl VARCHAR(255)
);

CREATE TABLE FThread (
	ThreadId INT PRIMARY KEY IDENTITY(1, 1),
    Title VARCHAR(50) NOT NULL,
    DateCreated DATETIME NOT NULL,
    UserId INT NOT NULL,
    Body VARCHAR(5000) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES AppUser(Id)

)

CREATE TABLE FPost (
    PostId INT PRIMARY KEY IDENTITY(1, 1),
    DateCreated DATETIME NOT NULL,
    UserId INT NOT NULL,
    ThreadId INT NOT NULL,
    Body VARCHAR(5000) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES AppUser(Id),
    FOREIGN KEY (ThreadId) REFERENCES FThread(ThreadId)
);