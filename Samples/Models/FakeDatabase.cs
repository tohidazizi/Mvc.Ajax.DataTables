using System.Collections.Generic;
using Mvc.Ajax.DataTables;
using System.Linq;


namespace Samples.Models
{
    public class FakeDatabase
    {
        private static List<BrowserInfo> browserInfoList;

        public FakeDatabase()
        {
            if (browserInfoList == null)
                InitiateFakeData();
        }

        public List<BrowserInfo> GetData(DataTableParameters dataTableParameters, out int TotalRecords, out int TotalDisplayRecords)
        {
            TotalRecords = browserInfoList.Count;
            TotalDisplayRecords = browserInfoList.Count;

            if (dataTableParameters.DisplayLength == 0)
                return browserInfoList;

            var query = browserInfoList
                        .Skip(dataTableParameters.DisplayStart)
                        .Take(dataTableParameters.DisplayLength);                        

            return query.ToList<BrowserInfo>();                        
        }


        private void InitiateFakeData()
        {
            browserInfoList = new List<BrowserInfo>();
            browserInfoList.Add(new BrowserInfo() { Id = 1, Engine = "Trident", Browser = "Internet Explorer 4.0", Platform = "Win 95+", Version = 4F, Grade = "X" });
            browserInfoList.Add(new BrowserInfo() { Id = 2, Engine = "Trident", Browser = "Internet Explorer 5.0", Platform = "Win 95+", Version = 5F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 3, Engine = "Trident", Browser = "Internet Explorer 5.5", Platform = "Win 95+", Version = 5.5F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 4, Engine = "Trident", Browser = "Internet Explorer 6", Platform = "Win 98+", Version = 6F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 5, Engine = "Trident", Browser = "Internet Explorer 7", Platform = "Win XP SP2+", Version = 7F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 6, Engine = "Trident", Browser = "AOL browser (AOL desktop)", Platform = "Win XP", Version = 6F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 7, Engine = "Gecko", Browser = "Firefox 1.0", Platform = "Win 98+ / OSX.2+", Version = 1.7F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 8, Engine = "Gecko", Browser = "Firefox 1.5", Platform = "Win 98+ / OSX.2+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 9, Engine = "Gecko", Browser = "Firefox 2.0", Platform = "Win 98+ / OSX.2+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 10, Engine = "Gecko", Browser = "Firefox 3.0", Platform = "Win 2k+ / OSX.3+", Version = 1.9F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 11, Engine = "Gecko", Browser = "Camino 1.0", Platform = "OSX.2+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 12, Engine = "Gecko", Browser = "Camino 1.5", Platform = "OSX.3+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 13, Engine = "Gecko", Browser = "Netscape 7.2", Platform = "Win 95+ / Mac OS 8.6-9.2", Version = 1.7F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 14, Engine = "Gecko", Browser = "Netscape Browser 8", Platform = "Win 98SE+", Version = 1.7F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 15, Engine = "Gecko", Browser = "Netscape Navigator 9", Platform = "Win 98+ / OSX.2+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 16, Engine = "Gecko", Browser = "Mozilla 1.0", Platform = "Win 95+ / OSX.1+", Version = 1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 17, Engine = "Gecko", Browser = "Mozilla 1.1", Platform = "Win 95+ / OSX.1+", Version = 1.1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 18, Engine = "Gecko", Browser = "Mozilla 1.2", Platform = "Win 95+ / OSX.1+", Version = 1.2F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 19, Engine = "Gecko", Browser = "Mozilla 1.3", Platform = "Win 95+ / OSX.1+", Version = 1.3F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 20, Engine = "Gecko", Browser = "Mozilla 1.4", Platform = "Win 95+ / OSX.1+", Version = 1.4F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 21, Engine = "Gecko", Browser = "Mozilla 1.5", Platform = "Win 95+ / OSX.1+", Version = 1.5F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 22, Engine = "Gecko", Browser = "Mozilla 1.6", Platform = "Win 95+ / OSX.1+", Version = 1.6F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 23, Engine = "Gecko", Browser = "Mozilla 1.7", Platform = "Win 98+ / OSX.1+", Version = 1.7F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 24, Engine = "Gecko", Browser = "Mozilla 1.8", Platform = "Win 98+ / OSX.1+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 25, Engine = "Gecko", Browser = "Seamonkey 1.1", Platform = "Win 98+ / OSX.2+", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 26, Engine = "Gecko", Browser = "Epiphany 2.20", Platform = "Gnome", Version = 1.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 27, Engine = "Webkit", Browser = "Safari 1.2", Platform = "OSX.3", Version = 125.5F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 28, Engine = "Webkit", Browser = "Safari 1.3", Platform = "OSX.3", Version = 312.8F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 29, Engine = "Webkit", Browser = "Safari 2.0", Platform = "OSX.4+", Version = 419.3F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 30, Engine = "Webkit", Browser = "Safari 3.0", Platform = "OSX.4+", Version = 522.1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 31, Engine = "Webkit", Browser = "OmniWeb 5.5", Platform = "OSX.4+", Version = 420F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 32, Engine = "Webkit", Browser = "iPod Touch / iPhone", Platform = "iPod", Version = 420.1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 33, Engine = "Webkit", Browser = "S60", Platform = "S60", Version = 413F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 35, Engine = "Presto", Browser = "Opera 7.0", Platform = "Win 95+ / OSX.1+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 36, Engine = "Presto", Browser = "Opera 7.5", Platform = "Win 95+ / OSX.2+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 37, Engine = "Presto", Browser = "Opera 8.0", Platform = "Win 95+ / OSX.2+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 38, Engine = "Presto", Browser = "Opera 8.5", Platform = "Win 95+ / OSX.2+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 39, Engine = "Presto", Browser = "Opera 9.0", Platform = "Win 95+ / OSX.3+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 40, Engine = "Presto", Browser = "Opera 9.2", Platform = "Win 88+ / OSX.3+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 41, Engine = "Presto", Browser = "Opera 9.5", Platform = "Win 88+ / OSX.3+", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 42, Engine = "Presto", Browser = "Opera for Wii", Platform = "Wii", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 43, Engine = "Presto", Browser = "Nokia N800", Platform = "N800", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 44, Engine = "Presto", Browser = "Nintendo DS browser", Platform = "Nintendo DS", Version = 8.5F, Grade = "C/A<sup>1</sup>" });
            browserInfoList.Add(new BrowserInfo() { Id = 45, Engine = "KHTML", Browser = "Konqureror 3.1", Platform = "KDE 3.1", Version = 3.1F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 46, Engine = "KHTML", Browser = "Konqureror 3.3", Platform = "KDE 3.3", Version = 3.3F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 47, Engine = "KHTML", Browser = "Konqureror 3.5", Platform = "KDE 3.5", Version = 3.5F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 48, Engine = "Tasman", Browser = "Internet Explorer 4.5", Platform = "Mac OS 8-9", Version = -1F, Grade = "X" });
            browserInfoList.Add(new BrowserInfo() { Id = 49, Engine = "Tasman", Browser = "Internet Explorer 5.1", Platform = "Mac OS 7.6-9", Version = 1F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 50, Engine = "Tasman", Browser = "Internet Explorer 5.2", Platform = "Mac OS 8-X", Version = 1F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 51, Engine = "Misc", Browser = "NetFront 3.1", Platform = "Embedded devices", Version = -1F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 52, Engine = "Misc", Browser = "NetFront 3.4", Platform = "Embedded devices", Version = -1F, Grade = "A" });
            browserInfoList.Add(new BrowserInfo() { Id = 53, Engine = "Misc", Browser = "Dillo 0.8", Platform = "Embedded devices", Version = -1F, Grade = "X" });
            browserInfoList.Add(new BrowserInfo() { Id = 54, Engine = "Misc", Browser = "Links", Platform = "Text only", Version = -1F, Grade = "X" });
            browserInfoList.Add(new BrowserInfo() { Id = 55, Engine = "Misc", Browser = "Lynx", Platform = "Text only", Version = -1F, Grade = "X" });
            browserInfoList.Add(new BrowserInfo() { Id = 56, Engine = "Misc", Browser = "IE Mobile", Platform = "Windows Mobile 6", Version = -1F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 57, Engine = "Misc", Browser = "PSP browser", Platform = "PSP", Version = -1F, Grade = "C" });
            browserInfoList.Add(new BrowserInfo() { Id = 58, Engine = "Other browsers", Browser = "All others", Platform = "-1", Version = -1F, Grade = "U" });
        }
    }
}
