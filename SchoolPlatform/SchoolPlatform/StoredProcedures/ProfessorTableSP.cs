using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.StoredProcedures
{
    public class ProfessorTableSP
    {
        private DataContext _dbContext;
        public ProfessorTableSP(DataContext context)
        {
            _dbContext = context;
        }

        public void CreateGetAllProfessorsStoredProcedure()
        {
            string getAllProfessorsProcedureSql = @"
                CREATE PROCEDURE GetAllProfessors
                AS
                BEGIN
                    SELECT * FROM Professors;
                END";

            _dbContext.Database.ExecuteSqlRaw(getAllProfessorsProcedureSql);
        }

        public void CreateGetAllClassMastersStoredProcedure()
        {
            string getAllClassMastersProcedureSql = @"
                CREATE PROCEDURE GetAllClassMasters
                AS
                BEGIN
                    SELECT P.* FROM Professors P
                    INNER JOIN Users U ON P.UserId = U.UserId
                    WHERE U.UserType = 4;
                END";

            _dbContext.Database.ExecuteSqlRaw(getAllClassMastersProcedureSql);
        }

        public void CreateGetProfessorByIdStoredProcedure()
        {
            string getProfessorByIdProcedureSql = @"
                CREATE PROCEDURE GetProfessorById
                    @Id INT
                AS
                BEGIN
                    SELECT * FROM Professors WHERE ProfessorId = @Id;
                END";

            _dbContext.Database.ExecuteSqlRaw(getProfessorByIdProcedureSql);
        }

        public void CreateAddProfessorStoredProcedure()
        {
            string addProfessorProcedureSql = @"
                CREATE PROCEDURE AddProfessor
                    @ProfessorName VARCHAR(50),
                    @UserId INT
                AS
                BEGIN
                    INSERT INTO Professors (ProfessorName, UserId)
                    VALUES (@ProfessorName, @UserId);
                END";

            _dbContext.Database.ExecuteSqlRaw(addProfessorProcedureSql);
        }

        public void CreateDeleteProfessorStoredProcedure()
        {
            string deleteProfessorProcedureSql = @"
                CREATE PROCEDURE DeleteProfessor
                    @Id INT
                AS
                BEGIN
                    DELETE FROM Professors WHERE ProfessorId = @Id;
                END";

            _dbContext.Database.ExecuteSqlRaw(deleteProfessorProcedureSql);
        }

        public void CreateUpdateProfessorStoredProcedure()
        {
            string updateProfessorProcedureSql = @"
                CREATE PROCEDURE UpdateProfessor
                    @Id INT,
                    @ProfessorName VARCHAR(50)
                AS
                BEGIN
                    UPDATE Professors SET ProfessorName = @ProfessorName WHERE ProfessorId = @Id;
                END";

            _dbContext.Database.ExecuteSqlRaw(updateProfessorProcedureSql);
        }
    }
}
