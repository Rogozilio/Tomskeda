using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tomskeda.Core.Entities
{
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public uint Id { get; set; }
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
        [RegularExpression(@"^[A-Za-zА-Яа-я]+$", ErrorMessage = "Значение «Имя» должно содержать только буквенные символы.")]
        [StringLength(20, ErrorMessage = "Количество знаков превышает лимит 20.")]
        public string Name { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Значение «Email» не является правильным email адресом.")]
        [StringLength(50, ErrorMessage = "Количество знаков превышает лимит 50.")]
        public string Email { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        [RegularExpression(@"^[^a-zA-Z]+$", ErrorMessage = "Значение «Улица» не должно содержать английские символы.")]
        [StringLength(50, ErrorMessage = "Количество знаков превышает лимит 50.")]
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        [StringLength(50, ErrorMessage = "Количество знаков превышает лимит 50.")]
        public string House { get; set; }
        /// <summary>
        /// Номер подъезда
        /// </summary>
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Значение «Подъезд» должно содержать только цифры.")]
        [StringLength(2, ErrorMessage = "Количество знаков превышает лимит 2.")]
        public string Porch { get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Значение «Этаж» должно содержать только цифры.")]
        [StringLength(2, ErrorMessage = "Количество знаков превышает лимит 2.")]
        public string Floor { get; set; }
        /// <summary>
        /// Кв/Офис
        /// </summary>
        [StringLength(50, ErrorMessage = "Количество знаков превышает лимит 50.")]
        public string Apartment { get; set; }
    }
}
