using myTarantulas.Domain;
using myTarantulas.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class TarantulaHelper
    {
        public int NumberOfTarantula(ITarantulaRepository tarantulaRepository, IUserRepository userRepository, string username)
        {
            var user = userRepository.Users.Where(u => u.Username == username).FirstOrDefault();
            int tNumber = 0;
            foreach (var item in tarantulaRepository.Tarantulas)
            {
                if (item.UserID == user.UserID)
                {
                    if (item.NumberOf > 1)
                        tNumber += item.NumberOf;
                    else
                        tNumber += 1;
                }
            }
            return tNumber;
        }
    }
}