using AutoMapper;
using SO.Agenda.Application.ViewModels;
using SO.Agenda.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Application.AutoMapper
{
    public class MappingsWithReverse : Profile
    {
        public MappingsWithReverse()
        {
            CreateMap<TaskItem, TaskItemViewModel>().ReverseMap();
            CreateMap<Task<TaskItem>, Task<TaskItemViewModel>>().ReverseMap();
            CreateMap<Task<IEnumerable<TaskItem>>, Task<IEnumerable<TaskItemViewModel>>>().ReverseMap();
       
        }
    }
}
