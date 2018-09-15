﻿using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTarantulas.WebUI.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}