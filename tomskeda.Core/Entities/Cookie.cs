using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomskeda.Core.Entities
{
    public class Cookie
    {
        /// <summary>
        /// Куки хранящие день
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// Куки хранящие id продуктов
        /// </summary>
        public string Ids { get; set; }
        /// <summary>
        /// Куки хранящие количество на еденицу продукта
        /// </summary>
        public string Counts { get; set; }
    }
}
