using System;

namespace InventoryManagement.Factory
{
    public class GenericFactory
    {
        // SkillTree 設計模式課程中取得的工廠範例
        // 因為使用 .net standard 作為專案框架，故動態載入 DLL 的部分會出現編譯錯誤，目前先註解掉
        //public static T CreateInstance<T>(string assemblyName, string typename)
        //{
        //    return CreateInstance<T>(assemblyName, typename, null);
        //}
        //public static T CreateInstance<T>(string assemblyName, string typename, object[] args)
        //{
        //    object instance = Activator.CreateInstance(assemblyName, typename, args).Unwrap();
        //    return (T)instance;
        //}

        public static T CreateInstance<T>(Type type)
        {
            return CreateInstance<T>(type, null);
        }

        public static T CreateInstance<T>(Type type, object[] args)
        {
            object instance = Activator.CreateInstance(type, args);
            return (T)instance;
        }
    }
}