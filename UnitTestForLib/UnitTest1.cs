using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MainPart;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System;
using TestGeneratorLib;

namespace UnitTestForLib
{
    public class Tests
    {
        public static int i  = 0;
        string Path = @"D:\Projects\mpp-labs\lab4\UnitTestForLib\Files";
        string PathToFolder = @"D:\Projects\mpp-labs\lab4\UnitTestForLib\Generated\";

        IEnumerable<string> files;
        string[] generatedFiles;
        ITestGenerator gen;

        [SetUp]
        public void Setup()
        {
            files = Directory.GetFiles(Path);
        }

        [Test]
        public void FilesNumber()
        {
            Assert.AreEqual(files.Count(),2,"Another nuber of files");
        }

        [Test]
        public void TaskExec()
        {
            if (!Directory.Exists(PathToFolder))
            {
                Directory.CreateDirectory(PathToFolder);
            }
            try
            {
                gen = new TestsGenerator();
                Task task = new Pipeline().Generate(files,PathToFolder, gen);
                task.Wait();
                Assert.True(true);
            }catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void NumOfGeneratedFiles()
        {
            if (!Directory.Exists(PathToFolder))
            {
                Directory.CreateDirectory(PathToFolder);
            }
            gen = new TestsGenerator();
            Task task = new Pipeline().Generate(files, PathToFolder, gen);
            task.Wait();
            generatedFiles = Directory.GetFiles(PathToFolder);
            Assert.AreEqual(generatedFiles.Length, 3, "Wrong number of generated files.");
        }

        
    }


    class DumbTestGenerator : ITestGenerator
    {
        Dictionary<string, string> ITestGenerator.GenerateTests(TestGeneratorLib.Info.FileInfo fileInfo)
        {
            Tests.i++;
            return new Dictionary<string, string>();
        }
    }
}