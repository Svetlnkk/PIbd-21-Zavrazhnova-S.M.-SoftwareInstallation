﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SoftwareInstallationContracts.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО клиента")]
        public string FIO { get; set; }
        [DisplayName("Логин клиента")]
        public string Login { get; set; }
        [DisplayName("Пароль клиента")]
        public string Password { get; set; }
    }
}
