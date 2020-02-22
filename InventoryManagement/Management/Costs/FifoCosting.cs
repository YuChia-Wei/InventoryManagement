using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Enum;
using InventoryManagement.Models;
using InventoryManagement.Repository;

namespace InventoryManagement.Management.Costs
{
    /// <summary>
    /// 先進先出計算成本
    /// </summary>
    internal class FifoCosting : ICosting
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
            var orderResult = GetOrderResult(costsBalanceModels);

            var currentBalanceData = GetCurrentBalanceData(orderResult, transaction.ProductCode,
                transaction.TimeToStock, transaction.LocationId);

            switch (transaction.Io)
            {
                case StockIo.Out:
                    return GetOutCalculateResult(transaction, currentBalanceData);

                case StockIo.In:
                    return GetInCalculateResult(transaction, currentBalanceData);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public CostsBalanceModel TranDataToValueBalanceModel(bool isIntoStock,
            string locationId,
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

        /// <summary>
        /// 更新餘額
        /// </summary>
        /// <param name="valueBalanceRepository"></param>
        /// <param name="calculatingResult"></param>
        /// <returns></returns>
        public (bool result, string message) Update(IRepository<CostsBalanceModel> valueBalanceRepository,
            (bool isDataExist, CostsBalanceModel balance) calculatingResult)
        {
            var (isDataExist, balance) = calculatingResult;

            return isDataExist
                ? UpdateExistData(valueBalanceRepository, balance)
                : valueBalanceRepository.Create(balance);
        }

        /// <summary>
        /// 更新已存在資料，當數量為 0 時，刪除 Balance
        /// </summary>
        /// <param name="valueBalanceRepository"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public (bool result, string message) UpdateExistData(IRepository<CostsBalanceModel> valueBalanceRepository,
            CostsBalanceModel balance)
        {
            return balance.Quantity == 0
                ? valueBalanceRepository.Delete(balance)
                : valueBalanceRepository.Update(balance);
        }

        private static CostsBalanceModel GetCurrentBalanceData(IOrderedEnumerable<CostsBalanceModel> orderResult,
            string productCode, DateTime timeToStock, string locationId)
        {
            var currentBalanceData = orderResult.FirstOrDefault(
                p =>
                    p.ProductCode.Equals(productCode) &&
                    p.TimeToStock.Equals(timeToStock) &&
                    p.LocationId.Equals(locationId));
            return currentBalanceData;
        }

        private static IOrderedEnumerable<CostsBalanceModel> GetOrderResult(
            IEnumerable<CostsBalanceModel> costsBalanceModels)
        {
            var orderResult =
                costsBalanceModels
                    .OrderBy(p => p.ProductCode)
                    .ThenBy(p => p.LocationId)
                    .ThenBy(p => p.TimeToStock);
            return orderResult;
        }

        private (bool isUpdateExist, CostsBalanceModel balance) GetInCalculateResult(
            StockTransactionModel transaction,
            CostsBalanceModel currentBalanceData)
        {
            if (currentBalanceData is default(CostsBalanceModel))
            {
                return (false, TranDataToValueBalanceModel(true, transaction.LocationId, transaction));
            }

            currentBalanceData.Quantity += transaction.Quantity;
            currentBalanceData.Values = transaction.UnitPrice * transaction.Quantity;
            return (true, currentBalanceData);
        }

        private (bool isUpdateExist, CostsBalanceModel balance) GetOutCalculateResult(
            StockTransactionModel transaction,
            CostsBalanceModel currentBalanceData)
        {
            if (currentBalanceData is default(CostsBalanceModel))
            {
                return (false, TranDataToValueBalanceModel(false, transaction.LocationId, transaction));
            }

            currentBalanceData.Quantity -= transaction.Quantity;
            currentBalanceData.Values = transaction.UnitPrice * transaction.Quantity;
            return (true, currentBalanceData);
        }
    }
}