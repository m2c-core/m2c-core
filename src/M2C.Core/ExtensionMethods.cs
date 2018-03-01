
namespace M2C.Core
{
    using System;
    public static class ExtensionMethods
    {
        public static Guid ToSpecial(this Guid guid)
        {
            DateTime now = DateTime.Now;
            string token = guid.ToString();
            string s = String.Format("{0}{1}{2}{3}{4}{5}{6}",
                                    token.Substring(0, 11),
                                    now.ToString("MM"),
                                    token.Substring(13, 3),
                                    now.ToString("dd"),
                                    token.Substring(18, 4),
                                    (int)now.DayOfWeek,
                                    token.Substring(23, 13));
            return new Guid(s);
        }
    }
}
