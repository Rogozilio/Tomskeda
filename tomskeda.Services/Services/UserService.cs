using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tomskeda.Core.Entities;
using Tomskeda.Date;
using Tomskeda.Services.Interfaces;

namespace Tomskeda.Services.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// </summary>
        /// Контекст данных user
        private readonly UserContext _base;
        /// <summary>
        /// Конструктор
        /// </summary>
        public UserService(UserContext userBase)
        {
            _base = userBase;
        }
        /// <summary>
        /// Добавить пользователя в базу после регестрации
        /// </summary>
        /// <param name="user">Данные о пользователе</param>
        public void AddUser(User user)
        {
            user.Password = HashPassword(user);
            _base.Add(this);
            _base.SaveChanges();
        }
        /// <summary>
        /// Хеширование пароля
        /// </summary>
        /// <returns>Результат хеширования в виде строки</returns>
        private string HashPassword(User user)
        {
            string result = null;
            Encoding enc = Encoding.UTF8;
            SHA512 shaM = new SHA512Managed();
            byte[] hash = shaM.ComputeHash(enc.GetBytes(user.Password));
            foreach (var item in hash)
            {
                result += item;
            }
            return result;
        }
        /// <summary>
        /// Существует ли в базе пользователь
        /// </summary>
        /// <returns></returns>
        public bool IsAccountExist(User user)
        {
            foreach (var bduser in _base.User.ToList())
            {
                if (user.Phone == bduser.Phone)
                    return true;
            }
            return false;
        }
    }
}
