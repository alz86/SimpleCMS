namespace DecisionTree.Plugins.SimpleCMS
{
    public static class SimpleCMSConsts
    {
        /// <summary>
        /// Class containing information relative
        /// to entity's fields configuration
        /// </summary>
        public static class FieldsConfiguration
        {
            public const int NameMaxLength = 250;
            public const int TitleMaxLength = 100;
            public const int ContentMaxLength = 10000;
        }

        public static class LocalizedTexts
        {
            public const string Prefix = "SimpleCMS:";

            public const string PagesMenuItem = Prefix + "Pages:Name";

            public const string ManagePageMenuItem = Prefix + "Pages:Manage";

            public static class Permissions
            {
                public const string GroupName = Prefix + "Permissions:GroupName";

                public const string Edit = Prefix + "Permissions:Edit";
            }
        }
    }
}
