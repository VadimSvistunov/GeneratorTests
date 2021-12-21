using System;
using NUnit.Framework;
using MainPart.Files;
using Moq;
using System.Collections.Generic;
using UnitTestForLib.Files;

[TestFixture]
class ClassForTest2Test
{
    private ClassForTest2 _classForTest2;
    [SetUp]
    public void SetUp()
    {
        _classForTest2 = new ClassForTest2();
    }
}