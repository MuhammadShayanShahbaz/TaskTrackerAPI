create database TaskTrackerAPI
use TaskTrackerAPI

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName VARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID),
    TaskTitle VARCHAR(150) NOT NULL,
    Status VARCHAR(50) DEFAULT 'Pending',
    DueDate DATETIME
);

-- Insert a dummy project
INSERT INTO Projects (ProjectName) VALUES ('asapta');

-- 2. Create Stored Procedures
GO
CREATE PROCEDURE sp_GetAllTasks
AS
BEGIN
    SELECT TaskID, ProjectID, TaskTitle, Status, DueDate 
    FROM Tasks;
END
GO

CREATE PROCEDURE sp_CreateTask
    @ProjectID INT,
    @TaskTitle VARCHAR(150),
    @Status VARCHAR(50)
AS
BEGIN
    INSERT INTO Tasks (ProjectID, TaskTitle, Status, DueDate)
    VALUES (@ProjectID, @TaskTitle, @Status, GETDATE() + 7); -- Defaults due date to 7 days from now
END
GO

-- 1. Procedure to Update a Task
CREATE PROCEDURE sp_UpdateTask
    @TaskID INT,
    @TaskTitle VARCHAR(150),
    @Status VARCHAR(50)
AS
BEGIN
    UPDATE Tasks
    SET TaskTitle = @TaskTitle,
        Status = @Status
    WHERE TaskID = @TaskID;
END
GO

-- 2. Procedure to Delete a Task
CREATE PROCEDURE sp_DeleteTask
    @TaskID INT
AS
BEGIN
    DELETE FROM Tasks
    WHERE TaskID = @TaskID;
END
GO
