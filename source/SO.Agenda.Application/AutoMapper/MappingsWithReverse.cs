using AutoMapper;
using SO.Agenda.Application.ViewModels;
using SO.Agenda.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Application.AutoMapper
{
    public class MappingsWithReverse : Profile
    {
        public MappingsWithReverse()
        {
            CreateMap<TaskItem, TaskItemViewModel>().ReverseMap();

        }
    }
}
