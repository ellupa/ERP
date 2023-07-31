﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemERP.Data;
using SystemERP.Interface;
using SystemERP.Model;
using SystemERP.Utils;

namespace SystemERP.Controller
{
    public class UserController
    {
        UserData _userData = new UserData();
        IUser? activeUser;

        public bool Login(string name, string pass)
        {
            if (name == "" || name == null)
            {
                return false;
            }

            if(pass == "" ||  pass == null)
            {
                return false;
            }

            IUser user = new User()
            {
                Name= name,
                Password= KeySha256.CalculateSHA256(pass)
            };

            activeUser = _userData.Login(user);

            if (activeUser != null)
            {
                return true;
            }
            return false;
            
        }

        public bool CompareKey(string key)
        {
            if (key == "" || key == null)
            {
                return false;
            }
            string pass = KeySha256.CalculateSHA256(key);
            if (key == activeUser.Password)
            {
                return true;
            }            
            return false;            
        }
 
        
    }
}
