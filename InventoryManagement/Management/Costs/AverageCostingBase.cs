using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Enum;
using InventoryManagement.Models;

namespace InventoryManagement.Management.Costs
{
    internal abstract class AverageCostingBase : ICosting
    {
        public IEnumerable<CostsBalanceModel> Calculating(
            IEnumerable<StockTransactionModel> confirmedStockTranList,
            string productCode,
            bool byLocationId)
        {
            throw new NotImplementedException();
        }

        public (bool isUpdateExist, CostsBalanceModel balance) Calculating(StockTransactionModel transaction,
            IEnumerable<CostsBalanceModel> costsBalanceModels,
            bool byLocationId)
        {
            var targetLocationId = byLocationId ? transaction.LocationId : string.Empty;

            var orderResult = GetOrderResult(costsBalanceModels);

            var currentBalanceData = GetCurrentBalanceData(orderResult, transaction.ProductCode, targetLocationId);

            switch (transaction.Io)
            {
                case StockIo.Out:
                    return GetOutCalculateResult(transaction, currentBalanceData, targetLocationId);

                case StockIo.In:
                    return GetInCalculateResult(transaction, currentBalanceData, targetLocationId);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected CostsBalanceModel TranDataToValueBalanceModel(bool isIntoStock, string locationId,
            StockTransactionModel transactionItem)
        {
            return new CostsBalanceModel
            {
                LocationId = locationId,
                ProductCode = transactionItem.ProductCode,
                Quantity = transactionItem.Quantity * (isIntoStock ? 1 : -1),
                TimeToStock = transactionItem.TimeToStock,
                Values = transactionItem.UnitPrice * transactionItem.Quantity,
                UnitValues = transactionItem.UnitPrice
            };
        }

        protected CostsBalanceModel GetCurrentBalanceData(IOrderedEnumerable<CostsBalanceModel> orderResult, string productCode, string locationId)
        {
            var currentBalanceData = orderResult.FirstOrDefault(
                p =>
                    p.ProductCode.Equals(productCode) &&
                    p.LocationId.Equals(locationId));
            return currentBalanceData;
        }

        protected IOrderedEnumerable<CostsBalanceModel> GetOrderResult(IEnumerable<CostsBalanceModel> costsBalanceModels)
        {
            var orderResult =
                costsBalanceModels
                    .OrderBy(p => p.ProductCode)
                    .ThenBy(p => p.LocationId);
            return orderResult;
        }

        protected abstract (bool isDataExist, CostsBalanceModel balance) GetInCalculateResult(StockTransactionModel transaction,
            CostsBalanceModel currentBalanceData, string targetLocationId);

        protected abstract (bool isDataExist, CostsBalanceModel balance) GetOutCalculateResult(StockTransactionModel transaction,
            CostsBalanceModel currentBalanceData, string targetLocationId);
    }
}