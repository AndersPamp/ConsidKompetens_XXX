﻿using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelState = System.Web.WebPages.Html.ModelState;

namespace ConsidKompetens_Services.DataServices
{
    public class GetUserDataService : IGetUserDataService
    {
        //var ctx = new ConsidKompetens_Data.Services.GetUserData();

        private readonly UserDataContext _userDataContext;

        public GetUserDataService(UserDataContext userDataContext)
        {
            _userDataContext = userDataContext;
        }

        public async Task<EmployeeUserModel> GetUserByIdAsync(Guid id)
        {
            try
            {
                return await _userDataContext.EmployeeUsers.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<EmployeeUserModel> EditUserByIdAsync(EmployeeUserModel userModel)
        {
            try
            {
                var user = await _userDataContext.EmployeeUsers.FindAsync(userModel.Id);
                user.AboutMe = userModel.AboutMe;
                user.ProfileImage = userModel.ProfileImage;
                _userDataContext.EmployeeUsers.Update(user);
                await _userDataContext.SaveChangesAsync();
                return await _userDataContext.EmployeeUsers.FindAsync(user.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EmployeeUserModel> CreateNewUserAsync(EmployeeUserModel userModel)
        {
            try
            {
                var newUserModel = new EmployeeUserModel()
                {
                    AboutMe = userModel.AboutMe,
                    ProfileImage = userModel.ProfileImage,
                    Competences = userModel.Competences
                };
                await _userDataContext.EmployeeUsers.AddAsync(newUserModel);
                await _userDataContext.SaveChangesAsync();

                return userModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
