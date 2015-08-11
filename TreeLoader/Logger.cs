﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * A simple Logger class.
 * 
 * Apparently C# doesn't come with one built in??
 */
namespace NuoTest
{
    class Logger
    {
        internal static Dictionary<String, Logger> extent = new Dictionary<String, Logger>(32);

        internal String name { get; set; }

        private Logger(String name)
        {
            this.name = name;
        }

        public static Logger getLogger(String name)
        {
            Logger result = extent[name];
            if (result == null) {
                result = new Logger(name);
                extent[name] = result;
            }

            return result;
        }

        public void info(String msg, params Object[] args)
        { write("INFO", msg, args); }

        protected void write(String level, String msg, params Object[] args)
        {
            String now = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
            Console.WriteLine("%s %s\n%s: %s", now, name, level, String.Format(msg, args));
        }

    }
}