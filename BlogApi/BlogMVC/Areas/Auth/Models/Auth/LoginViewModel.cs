﻿using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Areas.Auth.Models.Auth
{
    /// <summary>
    /// Модель для авторизации
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
