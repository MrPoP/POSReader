using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSReader
{
    [Flags]
    public enum TextExistance
    {
        Above = -12,
        Below = -13,
        None = -11
    }
    [Flags]
    public enum BarCodeTargets : int
    {
        Ames = 0x87,
        AusPost = 0x12d,
        Aztec = 0xce,
        CanPost = 0x12e,
        Cca = 0x97,
        Ccb = 0x98,
        Ccc = 0x99,
        ChinaPost = 0x12f,
        Codabar = 0x6b,
        Codablock256 = 0xd6,
        CodablockA = 0xd4,
        CodablockF = 0xd5,
        Code11 = 0x8e,
        Code128 = 110,
        Code128Parsed = 0x7b,
        Code16k = 0xd3,
        Code32 = 0x8a,
        Code39 = 0x6c,
        Code39Ck = 0x89,
        Code49 = 210,
        Code93 = 0x6d,
        CodeCIP = 0x8b,
        DataMatrix = 0xcb,
        DutchKix = 0x130,
        Ean128 = 120,
        Ean13S = 0x77,
        Ean8S = 0x76,
        EanJan13 = 0x68,
        EanJan8 = 0x67,
        Gs1DataBar = 0x83,
        Gs1DataBar_Type2 = 0x86,
        Gs1DataBarExpanded = 0x84,
        Gs1DataBarExpandedStacked = 0x86,
        Gs1DataBarStackedOmnidirectional = 0x85,
        Gs1DataMatrix = 0xd0,
        Gs1QRCode = 0xd1,
        HANXIN = 0xd7,
        InfoMail = 0x131,
        ISBT128 = 0x8d,
        Itf = 0x6a,
        ItfCK = 0x85,
        JapanPost = 0x132,
        KoreanPost = 0x133,
        Maxicode = 0xca,
        MicroPDF417 = 0xcf,
        MicroQRCode = 0xcd,
        MSI = 0x8f,
        Ocra = 0x79,
        Ocrb = 0x7a,
        Other = 0x1f5,
        Pdf417 = 0xc9,
        Plessey = 0x90,
        PostNet = 0x138,
        QRCode = 0xcc,
        [Obsolete("Replaced by Gs1DataBar")]
        Rss14 = 0x83,
        [Obsolete("Replaced by Gs1DataBarExpanded")]
        RssExpanded = 0x84,
        SwedenPost = 0x134,
        Telepen = 0x91,
        TF = 0x69,
        TFMAT = 0x88,
        Tlc39 = 0x9a,
        TriOptic39 = 140,
        UkPost = 0x135,
        Unknown = 0,
        Upca = 0x65,
        Upcas = 0x6f,
        Upcd1 = 0x71,
        Upcd2 = 0x72,
        Upcd3 = 0x73,
        Upcd4 = 0x74,
        Upcd5 = 0x75,
        Upce = 0x66,
        Upces = 0x70,
        UsIntelligent = 310,
        UsPlanet = 0x137
    }
}
