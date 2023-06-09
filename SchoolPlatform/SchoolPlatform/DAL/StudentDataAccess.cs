﻿using SchoolPlatform.Data;
using SchoolPlatform.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;
using Microsoft.EntityFrameworkCore;
using SchoolPlatform.ViewModels;
using System.Runtime.Remoting.Contexts;
using System.Collections.ObjectModel;

namespace SchoolPlatform.DAL
{
    public class StudentDataAccess
    {
        UserDataAccess _userDataAccess;
        private readonly DataContext _dbContext;
        public StudentDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
            _userDataAccess = new UserDataAccess();
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.Students.FirstOrDefault(u => u.StudentId == id);
        }

        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Student student, int id)
        {
            var existingStudent = GetStudentById(id);

            if (existingStudent != null)
            {
                existingStudent.StudentName = student.StudentName;
                existingStudent.Class = student.Class;
                existingStudent.ClassId = student.ClassId;
                _dbContext.SaveChanges();
            }
        }
    }
}
