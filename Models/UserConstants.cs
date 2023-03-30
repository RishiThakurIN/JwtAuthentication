using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username="jason_admin",
                EmailAddress="jason.admin@email.com",
                Password="mypass_word",
                GivenName="jason",
                Surname="bryant",
                Role="Administrator"
            },
            new UserModel() { Username="elyse_seller",
                EmailAddress="elyse.seller@email.com",
                Password="mypass_word",
                GivenName="Elyse",
                Surname="Lambert",
                Role="Seller"},
        };
    }
}
