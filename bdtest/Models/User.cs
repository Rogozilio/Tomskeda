using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bdtest.Models
{
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public uint id { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string House { get; set; }
        /// <summary>
        /// Номер подъезда
        /// </summary>
        public string Porch { get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        public string Floor { get; set; }
        /// <summary>
        /// Кв/Офис
        /// </summary>
        public string Apartment { get; set; }
        /// <summary>
        /// Контекст данных пользователя
        /// </summary>
        private UserContext _base;
        /// <summary>
        /// Конструктор
        /// </summary>
        public User()
        {
            _base = new UserContext();
           
        }
        /// <summary>
        /// Добавить пользователя в базу после регестрации
        /// </summary>
        /// <param name="user">Данные о пользователе</param>
        public void AddUser()
        {
            Password = HashPassword();
            _base.Add(this);
            _base.SaveChanges();
        }
        /// <summary>
        /// Хеширование пароля
        /// </summary>
        /// <returns>Результат хеширования в виде строки</returns>
        private string HashPassword()
        {
            string result = null;
            Encoding enc = Encoding.UTF8;
            SHA512 shaM = new SHA512Managed();
            byte[] hash = shaM.ComputeHash(enc.GetBytes(Password));
            foreach(var item in hash)
            {
                result += item;
            }
            return result;
        }
        /// <summary>
        /// Существует ли в базе пользователь
        /// </summary>
        /// <returns></returns>
        public bool IsAccountExist()
        {
            foreach(var user in _base.User.ToList())
            {
                if (user.Phone == Phone)
                    return true;
            }
            return false;
        }
    }
}
