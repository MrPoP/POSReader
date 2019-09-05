using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSReader
{
    [AttributeUsage(AttributeTargets.Property, Inherited=false, AllowMultiple=false)]
    public class ReaderPropertyAttribute : Attribute
    {
        public readonly BarCodeTargets ValidOn;
        private TextExistance _textPlace = TextExistance.None;
        public TextExistance TextPosition { get { return this._textPlace; } set { this._textPlace = value; } }
        private int _readTimeOut = 0;
        public int ReadTimeOut { get { return this._readTimeOut; } set { this._readTimeOut = value; } }
        private int _readBufferSize = 0;
        public int ReadBufferSize { get { return this._readBufferSize; } set { this._readBufferSize = value; } }
        public ReaderPropertyAttribute(BarCodeTargets validon)
        {
            this.ValidOn = validon;
            this._readTimeOut = 500;
            this._readBufferSize = 0;
            ResourceFactory.LoadAssembly();
        }
    }
}
