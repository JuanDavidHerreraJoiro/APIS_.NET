using MessagePack;
using System.Drawing;
using System;
using universityApiBackend.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using universityApiBackend.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace universityApiBackend.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly UniversityDBContext _context;

        public CoursesServices(UniversityDBContext context)
        {
            this._context = context;
        }

        // -> CourseService
        public IEnumerable<Course> GetCoursesForLevelWithStudents(Level level)
            => _context.Courses!.Where(course => course.Level == level && course.Students.Any());

        public IEnumerable<Course> GetCoursesForLevelInCategory(Level level, Category category)
            => _context.Courses!.Where(course => course.Level == level && course.Categories.Contains(category));

        public IEnumerable<Course> GetCoursesWithoutStudents()
            => _context.Courses!.Where(course => !course.Students.Any());

        //Obtener todos los Cursos de una categoría concreta
        public IEnumerable<Course> GetCoursesByCategory(Category category)
            => _context.Courses!.Where(course => course.Categories.Contains(category));

        //Obtener Cursos sin temarios
        public IEnumerable<Course> GetCoursesWithAtChaptersNull() => _context.Courses!.Where(a => a.Chapters == null).ToList();

        //Obtener los Cursos de un Alumno
        public IEnumerable<Course> GetCoursesByStudent(Student student)
            => _context.Courses!.Where(course => course.Students.Contains(student));

    }
}
