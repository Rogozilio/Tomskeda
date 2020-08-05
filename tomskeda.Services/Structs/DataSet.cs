using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomskeda.Core.Entities;
using Tomskeda.Services.Interfaces;
using Tomskeda.Services.Services;

namespace Tomskeda.Services.Structs
{
    /// <summary>
    /// Структура данных для передачи в view через model
    /// </summary>
    public struct DataSet
    {
        /// <summary>
        /// 
        /// </summary>
        public IProductService Product { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IDateService Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Cookie Cookie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Order Order { get; set; }
    }
}