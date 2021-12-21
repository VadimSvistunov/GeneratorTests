using System;
using NUnit.Framework;
using MainPart.Files;
using Moq;
using System.Collections.Generic;
using UnitTestForLib.Files;

[TestFixture]
class SecretTest
{
    private Secret _secret;
    [SetUp]
    public void SetUp()
    {
        _secret = new Secret();
    }
}