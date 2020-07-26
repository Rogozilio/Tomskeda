using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace bdtest.Models
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
        /// <summary>
        /// Контекст базы данных продукта
        /// </summary>
        private ProductContext _base;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Product()
        {
            _base = new ProductContext();
        }
        /// <summary>
        /// Получение категорий блюд на выбранный день
        /// </summary>
        /// <param name="day">День</param>
        /// <returns>Список категорий</returns>
        public List<String> GetKind(int day)
        {
            List<string> kinds = new List<string> { "Первые блюда",
                        "Вторые блюда", "Овощные блюда и гарниры", "Салаты и закуски",
                        "Десерты, выпечка", "Блины", "Бутерброды", "Напитки",
                        "Диетическое питание", "Праздничные блюда", "Соусы и приправы",
                        "Хлеб", "Одноразовая посуда"};
            List<string> allKind = new List<string>();
            if (day > 0 && day < 6)
                allKind.Add("Комплексные обеды");
            foreach (var kind in kinds.ToList())
                foreach (var product in _base.Products.ToList())
                {
                    if (product.Day.Contains(day.ToString()) && kind == product.Kind)
                    {
                        allKind.Add(product.Kind);
                        break;
                    }
                }
            return allKind;
        }
        /// <summary>
        /// Получить категори для комплексных обедов
        /// </summary>
        /// <param name="day">День</param>
        /// <param name="isExtra">Для дополнительных блюд?</param>
        /// <returns>Список категорий для комплексных блюд</returns>
        public List<string> GetKomplexKind(int day, bool isExtra = false)
        {
            List<String> list = GetKind(day);
            list.RemoveAt(0);
            list = new List<string>(list.Distinct());
            if (isExtra)
                list.RemoveRange(0, list.IndexOf("Салаты и закуски"));
            else
                list = list.GetRange(0, list.IndexOf("Салаты и закуски"));
            return list;

        }
        /// <summary>
        /// Получить продукт по дню и категории
        /// </summary>
        /// <param name="day">День</param>
        /// <param name="kind">Категория</param>
        /// <returns>Список продуктов</returns>
        public IEnumerable<Product> GetProductOnDayAndKind(int day, string kind)
        {
            var list = from product in _base.Products.ToList()
                       where product.Kind == kind && product.Day.Contains(day.ToString())
                       select product;
            return list;
        }
        /// <summary>
        /// Получить комплексные обеды по дню и категории
        /// </summary>
        /// <param name="day">День</param>
        /// <param name="kind">Категория</param>
        /// <returns>Список комплексных обедов</returns>
        public IEnumerable<Product> GetKomplexOnDayAndKind(int day, string kind)
        {
            var list = from product in _base.Products.ToList()
                       where product.Kind == kind && product.Komplex.Contains(day.ToString())
                       select product;
            return list;
        }
        /// <summary>
        /// Получить все продукты
        /// </summary>
        /// <returns>Список всех продуктов</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _base.Products;
        }
        /// <summary>
        /// Получить продукт по id
        /// </summary>
        /// <param name="cookieId">id блюд</param>
        /// <param name="cookieCount">Количество блюд на еденицу товара</param>
        /// <returns>Массив строк блюд</returns>
        public string[] GetProductOnId(string cookieId, string cookieCount)
        {
            if (cookieId == null || cookieCount == null)
            {
                return null;
            }
            int i = 0;
            int j = 0;
            bool isKomplex = false;
            string[] count = cookieCount.Split(',');
            string[] list = new string[count.Length * 5];
            foreach (var cookie in cookieId.Split(','))
                foreach (var product in _base.Products.ToList())
                {
                    if (product.Id.ToString() == cookie)
                    {
                        if (!isKomplex)
                        {
                            list[i++] = product.Id.ToString();
                            list[i++] = product.Image;
                            list[i++] = product.Name;
                            list[i++] = product.Price.ToString();
                            list[i++] = count[j++].ToString();
                            if (cookie == 2.ToString())
                            {
                                list[i - 3] += ':';
                                isKomplex = true;
                            }
                        }
                        else
                        {
                            list[i - 5] += ',' + product.Id.ToString();
                            list[i - 3] += "<br> -" + product.Name;
                            if (cookie == 348.ToString())
                                isKomplex = false;
                        }
                        break;
                    }
                }
            return list;
        }
        /// <summary>
        /// Получить цены продуктов
        /// </summary>
        /// <param name="cookieId">id продуктов</param>
        /// <param name="cookieCount">Количество продуктов на еденицу товара</param>
        /// <param name="isDelivery">Учитывать доставку?</param>
        /// <returns>Сумму заказа</returns>
        public int GetPriceProducts(string cookieId, string cookieCount, bool isDelivery = true)
        {
            if (cookieId == null || cookieCount == null)
            {
                return 0;
            }
            int j = 0;
            int price = 0;
            string[] count = cookieCount.Split(',');
            string[] product = GetProductOnId(cookieId, cookieCount);
            for (int i = 3; i < product.Length; i = i + 5)
            {
                price += int.Parse(product[i]) * int.Parse(count[j++]);
            }
            if (isDelivery)
                return (price < 300) ? price + 50 : price;
            else
                return price;
        }
    }
}