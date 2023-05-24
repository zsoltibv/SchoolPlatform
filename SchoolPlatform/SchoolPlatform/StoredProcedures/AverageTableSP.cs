using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.StoredProcedures
{
    public class AverageTableSP
    {
        private DataContext _dbContext;
        public AverageTableSP(DataContext context)
        {
            _dbContext = context;
        }

        public void CreateAddAverageStoredProcedure()
        {
            string addProcedureSql = @"
                    CREATE PROCEDURE AddAverage
                    @AverageGrade FLOAT,
                    @IsFinal BIT,
                    @StudentId INT,
                    @SubjectId INT
                    AS
                    BEGIN
                        SET NOCOUNT ON;

                        INSERT INTO Averages (AverageGrade, IsFinal, StudentId, SubjectId)
                        VALUES (@AverageGrade, @IsFinal, @StudentId, @SubjectId);
                    END";

            _dbContext.Database.ExecuteSqlRaw(addProcedureSql);
        }

        public void CreateDeleteAverageStoredProcedure()
        {
            string deleteProcedureSql = @"
                    CREATE PROCEDURE DeleteAverage
                        @Id INT
                    AS
                    BEGIN
                        DELETE FROM Averages WHERE AverageId = @Id;
                    END";

            _dbContext.Database.ExecuteSqlRaw(deleteProcedureSql);
        }

        public void CreateUpdateAverageStoredProcedure()
        {
            string updateProcedureSql = @"
                    CREATE PROCEDURE UpdateAverage
                        @Id INT,
                        @AverageGrade FLOAT,
                        @IsFinal BIT
                    AS
                    BEGIN
                        UPDATE Averages SET AverageGrade = @AverageGrade, IsFinal = @IsFinal WHERE AverageId = @Id;
                    END";

            _dbContext.Database.ExecuteSqlRaw(updateProcedureSql);
        }

        public void CreateGetAveragesStoredProcedure()
        {
            string getAveragesProcedureSql = @"
                    CREATE PROCEDURE GetAverages
                        @StudentId INT,
                        @SubjectId INT
                    AS
                    BEGIN
                        SELECT * FROM Averages WHERE StudentId = @StudentId AND SubjectId = @SubjectId;
                    END";

            _dbContext.Database.ExecuteSqlRaw(getAveragesProcedureSql);
        }

        public void CreateGetAllAveragesStoredProcedure()
        {
            string getAveragesProcedureSql = @"
            CREATE PROCEDURE GetAllAverages
                @StudentId INT
            AS
            BEGIN
                SELECT Averages.*, Subjects.SubjectName
                FROM Averages
                INNER JOIN Subjects ON Averages.SubjectId = Subjects.SubjectId
                WHERE Averages.StudentId = @StudentId;
            END";

            _dbContext.Database.ExecuteSqlRaw(getAveragesProcedureSql);
        }

        public void CreateGetAverageByIdStoredProcedure()
        {
            string getAverageByIdProcedureSql = @"
                    CREATE PROCEDURE GetAverageById
                        @Id INT
                    AS
                    BEGIN
                        SELECT * FROM Averages WHERE AverageId = @Id;
                    END";

            _dbContext.Database.ExecuteSqlRaw(getAverageByIdProcedureSql);
        }
    }
}
