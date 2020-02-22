using System;
using InventoryManagement.Enum;

namespace InventoryManagement.Models
{
    /// <summary>
    /// 庫存交易資料
    /// </summary>
    public class StockTransactionModel
    {
        /// <summary>
        /// 文件號碼
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 交易行為 (I/O/Move)
        /// </summary>
        public StockIo Io { get; set; }

        /// <summary>
        /// 交易倉
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// 貨品編號
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 交易數量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 貨品入庫時間
        /// </summary>
        public DateTime TimeToStock { get; set; }

        /// <summary>
        /// 交易時間
        /// </summary>
        public DateTime TransactionDateTime { get; set; }

        /// <summary>
        /// 單位金額
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}