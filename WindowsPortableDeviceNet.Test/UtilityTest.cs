﻿using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPortableDeviceNet.Model;

namespace WindowsPortableDeviceNet.Test
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void Get_GetConnectedDevices_1DeviceDetected()
        {
            MessageBox.Show(
                "Please ensure that a camera is connected.",
                "Test Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
            Utility utility = new Utility();
            List<Device> device = utility.Get();

            Assert.AreEqual(1, device.Count);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void TransferData_WithNoFolderStructure_OnlyFilesCopied()
        {
            MessageBox.Show(
                "Please ensure that a camera is connected.",
                "Test Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
            Utility utility = new Utility();
            List<Device> device = utility.Get();
            device[0].Connect();
            device[0].TransferData("C:\\Users\\Gav\\Desktop\\test", isKeepFolderStructure: false);
            device[0].Disconnect();
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void TransferData_WithFolderStructure_FilesCopiedWithFolderStructure()
        {
            MessageBox.Show(
                "Please ensure that a camera is connected.",
                "Test Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
            Utility utility = new Utility();
            List<Device> device = utility.Get();
            device[0].Connect();
            device[0].TransferData("C:\\Users\\Gav\\Desktop\\test", isKeepFolderStructure: true);
            device[0].Disconnect();
        }
    }
}
