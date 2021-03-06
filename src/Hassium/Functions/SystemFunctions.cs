﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Hassium.Functions
{
    public class SystemFunctions : ILibrary
    {
        [IntFunc("exit")]
        public static object Exit(object[] args)
        {
            Environment.Exit(args.Length > 0 ? Convert.ToInt32(args[0]) : 0);

            return null;
        }

        [IntFunc("system")]
        public static object System(object[] args)
        {
            Process.Start(args[0].ToString(), string.Join(" ", args.Skip(1)));
            return null;
        }

        [IntFunc("datetimetime")]
        public static object DateTime(object[] args)
        {
            switch (args.Length)
            {
                case 3:
                    return new DateTime(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2]));
                case 6:
                    return new DateTime(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToInt32(args[5]));
            }
            return global::System.DateTime.Now;
        }

        [IntFunc("currentuser")]
        public static object CurrentUser(object[] args)
        {
            return Environment.UserName;
        }
    }
}
