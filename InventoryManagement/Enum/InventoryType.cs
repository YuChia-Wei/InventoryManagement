namespace InventoryManagement.Enum
{
    /// <summary>
    /// 庫存類型，控制庫存數量更新方式
    /// </summary>
    public enum InventoryType
    {
        /// <summary>
        /// 空白未設定 - 預設值，不可作業
        /// </summary>
        Empty = ' ',

        /// <summary>
        /// 套組 - 只出，入的話必須確認 BOM 表
        /// </summary>
        Set = 'S',

        /// <summary>
        /// 產品 - 可出入
        /// </summary>
        Product = 'P',

        /// <summary>
        /// 固定資產 - 通常只入，出必須另外處理
        /// </summary>
        FixedAssets = 'F',

        /// <summary>
        /// 消耗品 - 只入
        /// </summary>
        Consumables = 'C',

        /// <summary>
        /// 物料
        /// </summary>
        Materials = 'M'
    }
}