﻿using EduNexBL.Base;
using EduNexBL.DTOs;
using EduNexBL.DTOs.CourseDTOs;
using EduNexBL.ENums;
using EduNexDB.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexBL.IRepository
{
    public interface ICourse : IRepository<Course>
    {
        public Task<ICollection<CourseMainData>> GetAllCoursesMainData();
        public Task<CourseDTO?> GetCourseById(int id);
        public CourseDTO MapCourseToCourseDTO(Course course);
        public LectureDto MapLectureToLectureDTO(Lecture lecture);
        public Task<List<StudentCoursesDTO?>> CoursesEnrolledByStudent(string studentId);
        public Task<EnrollmentResult> EnrollStudentInCourse(string studentId, int courseId);
        public Task<bool> IsStudentEnrolledInCourse(string studentId, int courseId);
        public Task<bool> IsTeacherRelatedToCourse(string teacherId, int courseId);
        public Task<int> CountEnrolledStudentsInCourse(int courseId);
        public Task<int> CountCourseLectures(int courseId);



    }
}
