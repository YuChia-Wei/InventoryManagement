using InventoryManagement.Models;

namespace InventoryManagement.Management.Costs
{
    /// <summary>
    /// 移動平均計算成本
    /// </summary>
    internal class MovingAverageCosting : AverageCostingBase
    {
        protected override (bool isDataExist, CostsBalanceModel balance) GetInCalculateResult(
            StockTransactionModel transaction,
            CostsBalanceModel currentBalanceData, string targetLocationId)
        {
            if (currentBalanceData is default(CostsBalanceModel))
            {
                return (false, TranDataToValueBalanceModel(true, targetLocationId, transaction));
            }

            currentBalanceData.Quantity += transaction.Quantity;
            currentBalanceData.Values += transaction.UnitPrice * transaction.Quantity;
            currentBalanceData.UnitValues = currentBalanceData.Values / currentBalanceData.Quantity;
            return (true, currentBalanceData);
        }

        protected override (bool isDataExist, CostsBalanceModel balance) GetOutCalculateResult(
            StockTransactionModel transaction,
            CostsBalanceModel currentBalanceData, string targetLocationId)
        {
            if (currentBalanceData is default(CostsBalanceModel))
            {
                return (false, TranDataToValueBalanceModel(false, targetLocationId, transaction));
            }

            currentBalanceData.Quantity -= transaction.Quantity;
            currentBalanceData.Values -= currentBalanceData.UnitValues * transaction.Quantity;
            currentBalanceData.UnitValues = currentBalanceData.Values / currentBalanceData.Quantity;
            return (true, currentBalanceData);
        }
    }
}