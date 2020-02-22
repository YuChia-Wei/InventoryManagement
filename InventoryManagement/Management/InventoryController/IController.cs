using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Management.InventoryController
{
    /// <summary>
    /// 庫存數量計算
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// 依據已確認庫存交易計算數量餘額
        /// </summary>
        /// <param name="confirmedStockTranList"></param>
        /// <param name="productCode"></param>
        /// <returns></returns>
        IEnumerable<QuantityBalanceModel> Calculating(
            IEnumerable<StockTransactionModel> confirmedStockTranList,
            string productCode);

        /// <summary>
        /// 依據現有的數量餘額紀錄計算新庫存交易確認後的數量餘額
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="quantityBalanceModels"></param>
        /// <returns></returns>
        (bool isUpdateExist, QuantityBalanceModel balance) Calculating(
            StockTransactionModel transaction,
            IEnumerable<QuantityBalanceModel> quantityBalanceModels);
    }
}