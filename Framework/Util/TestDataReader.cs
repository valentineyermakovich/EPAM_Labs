using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Framework.Model;

namespace Framework.Util
{
    internal class TestDataReader
    {
        public static TestsSettings GetTestsSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName)
                .AddJsonFile("Framework/Resources/data.json").Build();

            var section = config.GetSection(nameof(TestsSettings));

            var testsSettings = section.Get<TestsSettings>();

            return testsSettings;
        }
    }
}
