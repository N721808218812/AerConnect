﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AerConnect.Helper
{
    public class Encrypte
    {
        public static string GetPasswordHash(string input)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
                b = md5.ComputeHash(b);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach(byte x in b)
                {
                    sb.Append(x.ToString("x2"));
                    
                }
                return sb.ToString();

            }
        }
    }
}