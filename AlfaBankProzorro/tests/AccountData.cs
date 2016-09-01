using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaBankProzorro
{
    //для авторизации пользователя в тестовый класс будем передавать объект класса AccountData
    // вместо логина и пароля
    public class AccountData
    {
        //создаем значения для авторизации
        public string phone;
        public string sms;

        //конструктор для создания объекта 
        public AccountData(string phone, string sms)
        {
            this.phone = phone;
            this.sms = sms;
        }

        //создаем свойства для авторизации
        public string Phone { get; set; }
        public string Sms { get; set; }
    }
}
