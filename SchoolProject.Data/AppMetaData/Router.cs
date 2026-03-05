namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Rule = Root + "/" + Version;

        public const string SingleRout = "/{id}";

        public static class StudentRouting
        {
            public const string Prefix = $"{Rule}/students";
            public const string List = $"{Prefix}/List";
            public const string GetById = Prefix + SingleRout;
            public const string Create = $"{Prefix}/Create";
            public const string Edit = $"{Prefix}/Edit";
        }
    }
}