using AdaptableCore;
using NUnit.Framework;
using System.IO;

namespace AdaptableCore.Test
{
    /// <summary>
    /// Test class for verifying the functionality of the AdaptableCore application.
    /// </summary>
    public class MainTests
    {
        private string tempDirectory;

        /// <summary>
        /// Setup method for initializing common resources before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            tempDirectory = "C:\\Users\\mmari\\source\\repos\\AdaptableCore\\AdaptableCore\\bin\\Debug\\net6.0\\AdaptableDLL";
            Directory.CreateDirectory(tempDirectory);
        }

        /// <summary>
        /// Teardown method to release resources after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Directory.Delete(tempDirectory, true);
        }

        /// <summary>
        /// Test to verify that the ProcessPlugins method in AdaptableService correctly handles the presence of a DLL file in the specified directory.
        /// </summary>
        [Test]
        public void TestProcessPlugins()
        {
            string testDllPath = Path.Combine(tempDirectory, "Plugin.dll");
            File.WriteAllText(testDllPath, "Test DLL content");

            try
            {
                AdaptableService adaptableService = new AdaptableService(tempDirectory);
                adaptableService.ProcessPlugins();

                bool fileExists = CheckDllFileExists(tempDirectory);

                Assert.IsTrue(fileExists, "DLL file not found in directory");
            }
            catch (Exception ex)
            {
                Assert.Fail($"The test failed with the error: {ex.Message}");
            }
        }

        /// <summary>
        /// Helper method to check the presence of a DLL file in the specified directory.
        /// </summary>
        /// <param name="directoryPath">Path to the directory to check.</param>
        /// <returns>True if at least one DLL file is found; otherwise, false.</returns>
        private bool CheckDllFileExists(string directoryPath)
        {
            string[] dllFiles = Directory.GetFiles(directoryPath, "*.dll");
            return dllFiles.Length > 0;
        }
    }
}
