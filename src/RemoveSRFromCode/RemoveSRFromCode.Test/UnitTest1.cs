using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveSRFromCode.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRemoveSRCode()
        {
            String fileData = "throw new NotSupportedException(SR.GetString(SR.ConcurrentCollection_SyncRoot_NotSupported))";
            String resultData = "throw new NotSupportedException(\"SR.GetString(SR.ConcurrentCollection_SyncRoot_NotSupported)\")";
            CodeFileOperator fileOperator = new CodeFileOperator();
            Assert.IsTrue(String.Equals(fileOperator.RemoveSRCode(fileData), resultData));

            fileData = "throw new NotSupportedException(SR.GetString(SR.GetString(SR.ConcurrentCollection_SyncRoot_NotSupported)))";
            resultData = "throw new NotSupportedException(\"SR.GetString(SR.GetString(SR.ConcurrentCollection_SyncRoot_NotSupported))\")";
            Assert.IsTrue(String.Equals(fileOperator.RemoveSRCode(fileData), resultData));
        }
    }
}
