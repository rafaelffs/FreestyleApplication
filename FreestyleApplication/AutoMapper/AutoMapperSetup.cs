using AutoMapper;
using FreestyleApplication.Models;
using FreestyleApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region .   ViewModel to Model   .

            CreateMap<UserViewModel, User>();
            CreateMap<CompetitionViewModel, Competition>();

            #endregion

            #region .   Model to ViewModel   .

            CreateMap<User, UserViewModel>();
            CreateMap<Competition, CompetitionViewModel>();

            #endregion
        }
    }
}
