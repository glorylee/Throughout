﻿using System.IO;
using System.Reflection;

namespace Throughout.Message.Email
{
    internal static class EmbeddedResourceHelper
    {
        internal static string GetResourceAsString(Assembly assembly, string path)
        {
            string result;

            using (var stream = assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
