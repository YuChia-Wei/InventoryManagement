namespace InventoryManagement.Enum
{
    /// <summary>
    /// 庫存管理方式
    /// </summary>
    public enum InventoryControlMethod
    {
        /// <summary>
        /// 先進先出
        /// </summary>
        FirstInFirstOut = 'F',

        /// <summary>
        /// 即時生產
        /// </summary>
        JustInTime = 'J',

        /// <summary>
        /// 採購限額
        /// </summary>
        OpenToBuy = 'O'
    }
}