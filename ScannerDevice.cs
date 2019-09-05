using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POSReader
{
    public class ScannerDevice : IDisposable
    {
        private Semaphore awaitableobject;
        private SerialPort iSerialPort;
        private PropertyInfo Owner;
        public readonly ReaderPropertyAttribute PAttribute;
        private bool FoundPort = false;
        public ScannerDevice(PropertyInfo _onwer, ReaderPropertyAttribute attribute)
        {
            this.Owner = _onwer;
            this.PAttribute = attribute;
            this.awaitableobject = new Semaphore(0, 3);
            this.iSerialPort = new SerialPort(GetScannerPort(out this.FoundPort), 19200);
            if (this.FoundPort)
            {
                this.iSerialPort.Parity = Parity.None;
                this.iSerialPort.StopBits = StopBits.One;
                this.iSerialPort.DataBits = 8;
                this.iSerialPort.Handshake = Handshake.None;
                this.iSerialPort.DataReceived += iSerialPort_DataReceived;
                this.iSerialPort.ReadTimeout = this.PAttribute.ReadTimeOut;
                this.iSerialPort.ReadBufferSize = this.PAttribute.ReadBufferSize;
                this.iSerialPort.Open();
            }
        }
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        internal static string GetScannerPort(out bool Found)
        {
            string SelectedPort = null;
            try
            {
                foreach (string str in SerialPort.GetPortNames())
                {
                    using (var port = new SerialPort(str, 19200))
                    {
                        try
                        {
                            port.Open();
                            SelectedPort = str;
                            port.Close();
                            break;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            catch
            {
                SelectedPort = null;
                throw;
            }
            Found = SelectedPort != null;
            return SelectedPort;
        }
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        private void iSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.iSerialPort.IsOpen == false)
                    this.iSerialPort.Open();
                this.awaitableobject.WaitOne();
                if (this.iSerialPort.BytesToRead > 0)
                {
                    string data = this.iSerialPort.ReadLine();
                    this.Owner.SetValue(this.Owner, data);
                }
                Thread.Sleep(this.iSerialPort.ReadTimeout);
                this.awaitableobject.Release();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        ~ScannerDevice()
        {
            this.Dispose();
        }
        public void Dispose()
        {
            this.iSerialPort.Close();
            this.iSerialPort.Dispose();
            GC.Collect();
        }
    }
}
