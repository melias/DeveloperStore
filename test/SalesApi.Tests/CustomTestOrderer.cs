using Xunit.Abstractions;
using Xunit.Sdk;

namespace SalesApi.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute
    {
        public int Priority { get; }
        public TestPriorityAttribute(int priority) => Priority = priority;
    }

    public class CustomTestOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var sortedMethods = new SortedDictionary<int, List<TTestCase>>();
            foreach (var testCase in testCases)
            {
                int priority = 0;
                foreach (var attr in testCase.TestMethod.Method.GetCustomAttributes((typeof(TestPriorityAttribute).AssemblyQualifiedName)))
                {
                    priority = attr.GetNamedArgument<int>("Priority");
                }
                GetOrCreate(sortedMethods, priority).Add(testCase);
            }

            foreach (var list in sortedMethods.Keys.Select(priority => sortedMethods[priority]))
            {
                foreach (var testCase in list)
                    yield return testCase;
            }
        }

        private static List<TTestCase> GetOrCreate<TTestCase>(IDictionary<int, List<TTestCase>> dictionary, int priority)
        {
            if (!dictionary.TryGetValue(priority, out var list))
            {
                list = new List<TTestCase>();
                dictionary[priority] = list;
            }
            return list;
        }
    }
}
