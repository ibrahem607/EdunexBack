﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EduNexBL.DTOs;
using EduNexBL.DTOs.AuthDtos;
using EduNexBL.IRepository;
using EduNexDB.Context;
using EduNexDB.Entites;
using Microsoft.EntityFrameworkCore;

namespace EduNexBL.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EduNexContext _context;
        private readonly IMapper _mapper;


        public AdminRepository(EduNexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<TeacherDto>> GetTeachersAsync()
        {
            var teachers = await _context.Teachers
                .Select(t => _mapper.Map<TeacherDto>(t))
                .ToListAsync();

            return teachers;
        }
        public async Task<IEnumerable<TeacherDto>> GetTeachersPendingAsync()
        {
            var teachers = await _context.Teachers.Where(i => i.Status == TeacherStatus.Pending).Select(t => _mapper.Map<TeacherDto>(t))
               .ToListAsync();

            return teachers;
        }

        public async Task<bool> ApproveTeacherAsync(string id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return false;

            teacher.Status = TeacherStatus.Approved;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectTeacherAsync(string id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return false;

            teacher.Status = TeacherStatus.Rejected;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(string id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return null;

            var teacherDto = new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                AboutMe = teacher.AboutMe,
                AccountNote = teacher.AccountNote,
                gender = teacher.gender.ToString(),
                Address = teacher.Address,
                PhoneNumber = teacher.PhoneNumber,
                NationalId = teacher.NationalId,
                subject = teacher.subject,
                ProfilePhoto = teacher.ProfilePhoto,
                FacebookAccount = teacher.FacebookAccount,
                City = teacher.City,
                DateOfBirth = teacher.DateOfBirth,
                status = teacher.Status.ToString()

            };

            return teacherDto;
        }

        public async Task<StudentDto> GetStudentByIdAsync(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return null;

            var studentDto = new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                // Map other properties as needed
            };

            return studentDto;
        }

        public async Task<IEnumerable<UserDto>> SearchUsersAsync(SearchQuery query)
        {
            // Implement logic to search for users based on the query
            // Example:
            var users = await _context.Users
                .Where(u => u.FirstName.Contains(query.Term) || u.LastName.Contains(query.Term))
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    // Map other properties as needed
                })
                .ToListAsync();

            return users;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    // Map other properties as needed
                })
                .ToListAsync();

            return students;
        }

        public async Task UpdateTeachersAboutMe(string id, AboutinfoDto Aboutinfo)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                teacher.AboutMe = Aboutinfo.AboutMe;
                //teacher.AccountNote=Aboutinfo.AccountNote;
                _context.SaveChanges();
            }
        }
        public async Task UpdateTeachersAccountNote(string id, AccountNoteDto Aboutinfo)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                //teacher.AboutMe = Aboutinfo.AboutMe;
                teacher.AccountNote = Aboutinfo.AccountNote;
                _context.SaveChanges();
            }
        }

        public async Task UpdateTeacher(string id, UpdateTeacherDto teacherDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                teacher.PhoneNumber = teacherDto.PhoneNumber;
                teacher.subject = teacherDto.subject;
                teacher.Address = teacherDto.Address;
                _context.SaveChanges();
            }
        }
        public async Task AddedTeachersPhoto(string id, string path)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                teacher.ProfilePhoto = path;

                _context.SaveChanges();
            }


        }

        public async Task UpdateAllTeacherData(string id, TeacherDto teachDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                teacher.PhoneNumber = teachDto.PhoneNumber;
                teacher.subject = teachDto.subject;
                teacher.Address = teachDto.Address;
                teacher.AboutMe = teachDto.AboutMe;
                teacher.AccountNote = teachDto.AccountNote;
                teacher.FirstName = teachDto.FirstName;
                teacher.gender = teacher.gender;
                teacher.Email = teachDto.Email;
                teacher.Address = teacher.Address;
                teacher.City = teacher.City;
                teacher.Status = teacher.Status;
                teacher.Description = teacher.Description;
                teacher.NationalId = teacher.NationalId;
                teacher.subject = teacher.subject;
                _context.SaveChanges();
            }

        }
    }
}
