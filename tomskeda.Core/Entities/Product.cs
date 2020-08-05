using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Tomskeda.Core.Entities
{
    public class Product
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Информация о продукте(Ккал, Белки, Жиры, Углеводы)
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// Цена продукта
        /// </summary>
        public uint Price { get; set; }
        /// <summary>
        /// описание продукта
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Путь к картинке продукта
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Категория продукта
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// День заказа продукта
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// Комплексный жень заказа продукта
        /// </summary>
        public string Komplex { get; set; }
    }
}