using System;

namespace InventoryManagement.Models
{
    /// <summary>
    /// 價值餘額
    /// </summary>
    public class CostsBalanceModel
    {
        /// <summary>
        /// 倉庫編號
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// 貨品編號
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 貨品入庫時間
        /// </summary>
        public DateTime TimeToStock { get; set; }

        /// <summary>
        /// 總價值
        /// </summary>
        public decimal Values { get; set; }

        /// <summary>
        /// 單位價值
        /// </summary>
        public decimal UnitValues { get; set; }
    }
}