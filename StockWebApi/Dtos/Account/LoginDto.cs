﻿using System.ComponentModel.DataAnnotations;

namespace StockWebApi.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
