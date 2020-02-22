using System;

namespace InventoryManagement.Models.Balance
{
    /// <summary>
    /// 數量餘額
    /// </summary>
    public class QuantityBalanceModel
    {
        /// <summary>
        /// 到期日
        /// </summary>
        public DateTime ExpiryDate { get; set; }

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
    }
}