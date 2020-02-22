using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Management.InventoryController
{
    /// <summary>
    /// 庫存控制器 - 即時生產
    /// </summary>
    public class JitController : IController
    {
        public IEnumerable<QuantityBalanceModel> Calculating(IEnumerable<StockTransactionModel> confirmedStockTranList, string productCode)
        {
            throw new System.NotImplementedException();
        }

        public (bool isUpdateExist, QuantityBalanceModel balance) Calculating(StockTransactionModel transaction,
            IEnumerable<QuantityBalanceModel> quantityBalanceModels)
        {
            throw new System.NotImplementedException();
        }
    }
}