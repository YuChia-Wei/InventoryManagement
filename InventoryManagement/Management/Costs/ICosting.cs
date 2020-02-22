using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Management.Costs
{
    /// <summary>
    /// 成本計算
    /// </summary>
    public interface ICosting
    {
        /// <summary>
        /// 依據已確認庫存交易計算成本餘額
        /// </summary>
        /// <param name="confirmedStockTranList"></param>
        /// <param name="productCode"></param>
        /// <param name="byLocationId"></param>
        /// <returns></returns>
        IEnumerable<CostsBalanceModel> Calculating(
            IEnumerable<StockTransactionModel> confirmedStockTranList,
            string productCode,
            bool byLocationId);

        /// <summary>
        /// 依據現有的成本餘額紀錄計算新庫存交易確認後的成本餘額
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="costsBalanceModels"></param>
        /// <param name="byLocationId"></param>
        /// <returns></returns>
        (bool isUpdateExist, CostsBalanceModel balance) Calculating(
            StockTransactionModel transaction,
            IEnumerable<CostsBalanceModel> costsBalanceModels,
            bool byLocationId);
    }
}