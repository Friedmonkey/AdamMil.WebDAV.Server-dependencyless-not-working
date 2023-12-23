using AdamMil.WebDAV.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Xml;

namespace AdamMil.Collections
{
    /// <summary>
    /// A class to fix a missing thingy
    /// </summary>
    public static class DictionaryFix
    {
        ///// <summary>
        ///// a fix for a change or a missing thingy
        ///// </summary>
        ///// <param name=""></param>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static Dictionary<XmlQualifiedName, XmlQualifiedName> TryGetValue(this Dictionary<ConditionCode,Dictionary<XmlQualifiedName, XmlQualifiedName>> dict, ConditionCode key)
        //{
        //    Dictionary<XmlQualifiedName, XmlQualifiedName> output;
        //    var success = dict.TryGetValue(key, out output);
        //    if (success)
        //    {
        //        return output;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// a generic fix
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static B TryGetValue<A,B>(this IDictionary<A, B> dict, A key)
        {
            B output;
            var success = dict.TryGetValue(key, out output);
            if (success)
            {
                return output;
            }
            else
            {
                return default(B);
            }
        }

        public static void RemoveRange<A, B>(this IDictionary<A, B> dict, IEnumerable<A> keys)
        {
            foreach (var key in keys)
            {
                if (dict.ContainsKey(key))
                    dict.Remove(key);
            }
        }
    }
}
