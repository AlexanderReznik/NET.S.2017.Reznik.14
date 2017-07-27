using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GenericCollection;

namespace GenericCollection.NUnitTests
{
    public class SetTests
    {
        [TestCase(ExpectedResult = true)]
        public bool SetTest_String()
        {
            Set<string> set = new Set<string>();
            set.Add("1");
            set.Add("2");
            set.Add("1");
            set.Add("2");
            set.Add("3");
            set.Add("4");
            set.Add("5");
            set.Add("6");
            if (ToString(set) != "123456") return false;

            Set<string> set1 = new Set<string>(set);
            set1.Add("7");
            set1.Remove("3");
            set1.Remove("4");

            Set<string> set2 = ToSet("1", "2", "3", "4", "5", "6", "7");
            if (!set2.Equals(Set<string>.Union(set, set1))) return false;
            set2 = ToSet("3", "4");
            if (!set2.Equals(Set<string>.Complement(set, set1))) return false;
            set2 = ToSet("3", "4", "7");
            if (!set2.Equals(Set<string>.SymmetricDifference(set, set1))) return false;
            set2 = ToSet("1", "2", "5", "6");
            if (!set2.Equals(Set<string>.Intersection(set, set1))) return false;

            return true;
        }

        public static string ToString(Set<string> set)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in set)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public static Set<string> ToSet(params string[] arr)
        {
            Set < string > set = new Set<string>();
            foreach (var s in arr)
            {
                set.Add(s);
            }
            return set;
        }
    }
}
