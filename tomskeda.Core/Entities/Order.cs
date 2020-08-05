using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tomskeda.Core.Entities
{
    public class Order : User
    {
        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Время заказа
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Способ оплаты
        /// </summary>
        public string Pay { get; set; }
        /// <summary>
        /// Подготовка к отправка заказа
        /// </summary>
        /// <param name="cookie">Данные куки</param>
    }
}
