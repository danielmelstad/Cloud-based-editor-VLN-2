﻿using Cloud_based_editor_VLN_2.Models;
using Cloud_based_editor_VLN_2.Models.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Cloud_based_editor_VLN_2.Services {
    public class AppUserService : BaseService   {

        public AppUserService(IAppDataContext context) : base(context) {
            
        }

        public void addUser(AppUser newUser) {
            Db.AppUsers.Add(newUser);
            Db.SaveChanges();
        }

        public void addUserToProject(UserProjects user) {
            Db.UserProjects.Add(user);
            Db.SaveChanges();
        }

        public List<AppUser> getAllUsers() {
            List<AppUser> AllUsers = (from user in Db.AppUsers
                                      select user).ToList();
            return AllUsers;
        }

        public IEnumerable<AppUser> getLimitedUserList(string searchString) {
            IEnumerable<AppUser> users = (from user in Db.AppUsers
                                          where user.UserName.Contains(searchString) || user.Email.Contains(searchString)
                                          select user).Take(10);
            return users;
        }

        public List<UserProjects> getAllUserProjects() {
            List<UserProjects> AllUserProjects = (from userProject in Db.UserProjects
                                                  select userProject).ToList();
            return AllUserProjects;
        }

        public List<AppUser> getAllUsersInProject(Project project) {
            List<AppUser> allUsersInProject = (from users in _db.AppUsers
                                               join up in _db.UserProjects on users.ID equals up.AppUserID
                                               join au in _db.Projects on up.ProjectID equals au.ID
                                               where project.ID == up.ProjectID
                                               select users).ToList();
            return allUsersInProject;
        }
    }
}