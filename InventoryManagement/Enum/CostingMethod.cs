namespace InventoryManagement.Enum
{
    /// <summary>
    /// 成本計算方式
    /// </summary>
    public enum CostingMethod
    {
        /// <summary>
        /// 先進先出
        /// </summary>
        FirstInFirstOut = 'F',

        /// <summary>
        /// 加權平均
        /// </summary>
        WeightedAverage = 'A',

        /// <summary>
        /// 移動平均
        /// </summary>
        MovingAverage = 'M'
    }
}