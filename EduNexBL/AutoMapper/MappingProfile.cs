﻿using AutoMapper;
using EduNexBL.DTOs.AuthDtos;
using EduNexBL.DTOs.CourseDTOs;
using EduNexBL.DTOs.ExamintionDtos;
using EduNexDB.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNexBL.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ExamDto, Exam>()
                        .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<Exam, ExamDto>();
            CreateMap<QuestionDto, Question>();
            CreateMap<Question, QuestionDto >();
            CreateMap<AnswerDto, Answer>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<RegisterTeacherDto, Teacher>();

            CreateMap<Course, CourseMainData>()
               .ForMember(dest => dest.CourseType, opt => opt.MapFrom(src => src.CourseType.ToString()))
               .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Subject.Level.LevelName))
               .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
               .ForMember(dest => dest.ProfilePhoto, opt => opt.MapFrom(src => src.Teacher.ProfilePhoto))
               .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName+' '+ src.Teacher.LastName));
        }
    }
}
