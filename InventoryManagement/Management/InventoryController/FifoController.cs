using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Enum;
using InventoryManagement.Models;

namespace InventoryManagement.Management.InventoryController
{
    /// <summary>
    /// 庫存控制器 - 先進先出
    /// </summary>
    public class FifoController : IController
    {
        public IEnumerable<QuantityBalanceModel> Calculating(IEnumerable<StockTransactionModel> confirmedStockTranList, string productCode)
        {
            throw new System.NotImplementedException();
        }

        public (bool isUpdateExist, QuantityBalanceModel balance) Calculating(StockTransactionModel transaction,
            IEnumerable<QuantityBalanceModel> quantityBalanceModels)
        {
            var qtyBalanceByProduct = quantityBalanceModels
                .FirstOrDefault(p =>
                    p.ProductCode == transaction.ProductCode &&
                    p.TimeToStock == transaction.TimeToStock &&
                    p.LocationId == transaction.LocationId);

            if (qtyBalanceByProduct is default(QuantityBalanceModel))
            {
                return (false, TranDataToQtyBalanceModel(transaction.Io == StockIo.In, transaction));
            }

            if (transaction.Io == StockIo.In)
                qtyBalanceByProduct.Quantity += transaction.Quantity;
            else
                qtyBalanceByProduct.Quantity -= transaction.Quantity;

            return (true, qtyBalanceByProduct);
        }

        public QuantityBalanceModel TranDataToQtyBalanceModel(bool isIntoStock,
            StockTransactionModel transactionItem)
        {
            return new QuantityBalanceModel
            {
                ExpiryDate = default,
                LocationId = transactionItem.LocationId,
                ProductCode = transactionItem.ProductCode,
                Quantity = transactionItem.Quantity * (isIntoStock ? 1 : -1),
                TimeToStock = transactionItem.TimeToStock
            };
        }
    }
}