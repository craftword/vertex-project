using System;
using System.Collections.Generic;
using System.Linq;
using VertexCore.Models;
using VertexCore.ViewModels;

namespace VertexTest
{
    public static class Helper
    {
       public static List<UserViewModel> GetListUsers ()
        {
            var users = new List<UserViewModel>()
            {
                new UserViewModel { Id="2ccd5586-51f2-444c-aa63-e13012748dfa", FirstName="bimbo", LastName="ola", Email= "hvandijk0@umn.edu", Address="7 Nobel Ave",
                                              City="Arepo", Phone="08027313450", Zip="100234", MiddleName="Itinu"},
                new UserViewModel { Id="6c0998e8-f505-49c0-8efc-0d5d90a50152", FirstName="Nicki", LastName="Kesterton", Email= "gkesterton1@yandex.ru", Address="7 Nobel Ave",
                                              City="Arepo", Phone="08027313450", Zip="100234", MiddleName="Itinu"},
                new UserViewModel { Id="bd4760cf-c01c-4aac-8fde-4071b238241c", FirstName="Dougy", LastName="Ramsey", Email= "eramsey5@geocities.com", Address="7 Nobel Ave",
                                              City="Arepo", Phone="08027313450", Zip="100234", MiddleName="Itinu"}

            };

            return users;
        }

        public static UserViewModel GetAUser(string Id)
        {
            var user = GetListUsers().Where(x => x.Id == Id).SingleOrDefault();

            if(user != null)
            {
                UserViewModel result = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    City = user.City,
                    MiddleName = user.MiddleName,
                    Phone = user.Phone,
                    Zip = user.Zip
                };

                return result;
            }


            return null;

        }

        public static List<User> GetAllUsers()
        {
            var users = new List<User>()
            {
                new User { Id="2ccd5586-51f2-444c-aa63-e13012748dfa", FirstName="bimbo", LastName="ola", Email= "hvandijk0@umn.edu", Address="7 Nobel Ave",
                                              City="Arepo", Phone="08027313450", Zip="100234", MiddleName="Itinu"},
                new User { Id="6c0998e8-f505-49c0-8efc-0d5d90a50152", FirstName="Nicki", LastName="Kesterton", Email= "gkesterton1@yandex.ru", Address="7 Nobel Ave",
                                              City="Arepo", Phone="08027313450", Zip="100234", MiddleName="Itinu"},
                new User { Id="bd4760cf-c01c-4aac-8fde-4071b238241c", FirstName="Dougy", LastName="Ramsey", Email= "eramsey5@geocities.com", Address="7 Nobel Ave",
                                              City="Arepo", Phone="08027313450", Zip="100234", MiddleName="Itinu"}

            };

            return users;
        }

        public static User GetUser(string Id)
        {
            var user = GetAllUsers().Find(x => x.Id == Id);

            if (user != null)
            {

                return user;
            }


            return null;

        }

        public static User GetUserByEmail(string email)
        {
            var user = GetAllUsers().Find(x => x.Email == email);

            if (user != null)
            {

                return user;
            }


            return null;

        }
    }
}
