using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Mvc.Ajax.DataTables
{
    public class DataTableAttributes
    {
        public bool AutoWidth { get; set; } //bAutoWidth 
        public bool DeferRender { get; set; } //bDeferRender 
        public bool Filter { get; set; } //bFilter 
        public bool Info { get; set; } //bInfo  
        public bool JQueryUI { get; set; } //bJQueryUI  
        public bool LengthChange { get; set; } //bLengthChange  
        //Paginate should be always enabled!
        private bool Paginate { get; set; } //bPaginate  
        public bool ScrollInfinite { get; set; } //bScrollInfinite
        //bServerSide 
        public bool Sort { get; set; } //bSort  
        public bool SortClasses { get; set; } //bSortClasses  
        public bool StateSave { get; set; } //bStateSave 
        public string ScrollX { get; set; } //bStateSave 
        public string ScrollY { get; set; } //sScrollY 
        public List<ColumnDef> ColumnDefs { get; set; }
        public PaginationTypes PaginationType { get; set; } //sPaginationType 

        public DataTableAttributes()
        {
            AutoWidth = true;
            Filter = true;
            Info = true;
            LengthChange = true;
            Paginate = true;
            Sort = true;
            SortClasses = true;
            PaginationType = PaginationTypes.FullNumbers;
        }

    }

    public class ColumnDef
    {
        //public int[] DataSort { get; set; } // DataTables :: aoColumnDefs :: aDataSort
        public SortingDirections Sorting { get; set; } // DataTables :: aoColumnDefs :: asSorting
        //public bool Searchable { get; set; } // DataTables :: aoColumnDefs :: bSearchable 
        public bool Sortable { get; set; } // DataTables :: aoColumnDefs :: bSortable
        public bool UseRendered { get; set; } // DataTables :: aoColumnDefs :: bUseRendered
        public bool Visible { get; set; } // DataTables :: aoColumnDefs :: bVisible 
        public string FnCreatedCell { get; set; } // DataTables :: aoColumnDefs :: fnCreatedCell
        public string FnRender { get; set; } // DataTables :: aoColumnDefs :: fnRender
        //public int DataSort { get; set; } // DataTables :: aoColumnDefs :: iDataSort 
        public string DataProp { get; set; } // DataTables :: aoColumnDefs :: mDataProp
        public string CssClass { get; set; } // DataTables :: aoColumnDefs :: sClass
        public string DefaultContent { get; set; } // DataTables :: aoColumnDefs :: sDefaultContent
        public string Name { get; set; } // DataTables :: aoColumnDefs :: sName
        //public DataTypes?? SortDataType { get; set; } // DataTables :: aoColumnDefs :: sSortDataType
        public string Title { get; set; } // DataTables :: aoColumnDefs :: sTitle
        //public DataTypes?? Type { get; set; } // DataTables :: aoColumnDefs :: sType
        public string Width { get; set; } // DataTables :: aoColumnDefs :: sWidth

        public ColumnDef()
        {
            UseRendered = true;
            Sorting = SortingDirections.Both;
            Sortable = true;
            Visible = true;
        }
    }

    // This class might be temporary, I'm looking for a better solution 
    //     to get the parameters sent to the server by dataTables.
    public class DataTableParameters
    {
        readonly int iDisplayStart;
        readonly int iDisplayLength;
        readonly int iColumns;
        readonly bool bRegex;
        readonly int iSortingCols;
        readonly int sEcho;

        List<bool> bSearchable;
        // Private Constructor with no parameter to force developer to use
        //   this constructor instead: DataTableParameters(NameValueCollection nameValueCollection)
        private DataTableParameters() { }


        public DataTableParameters(System.Collections.Specialized.NameValueCollection queryString)
        {
            if (queryString["iDisplayStart"] == null)
                int.TryParse(queryString["iDisplayStart"], out iDisplayStart);
            if(queryString["iDisplayLength"] == null)
                int.TryParse(queryString["iDisplayLength"], out iDisplayLength);
            if (queryString["iColumns"] == null)
                int.TryParse(queryString["iColumns"], out iDisplayLength);
            if (queryString["sSearch"] == null)
                Search = queryString["sSearch"];
            if (queryString["bRegex"] == null)
                bool.TryParse(queryString["bRegex"], out bRegex);
            if (queryString["iSortingCols"] == null)
                int.TryParse(queryString["iSortingCols"], out iSortingCols);
            if ((queryString["sEcho"] == null)
                || !int.TryParse(queryString["sEcho"], out sEcho))
                throw new Exception("sEcho parameter is not defined well.");
            bSearchable = DataTableParametersHelper<bool>.ConvertToList("bSearchable_", queryString);

        }



        public int DisplayStart { get { return iDisplayLength; } }
        public int DisplayLength { get { return iDisplayLength; } }
        public int Columns { get { return iColumns; } }
        public string Search { get; private set; }
        //True if the global filter should be treated as a regular expression for advanced filtering, false if not.
        public bool Regex { get { return bRegex; } }
        //Number of columns to sort on
        public int SortingCols { get { return iSortingCols; } }
        public string Echo { get { return sEcho.ToString(); } }
    }


     public class DataTableResult
    {
        /*private string _sEcho;
        public string sEcho
        {
            get
            {
                return _sEcho;
            }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                    _sEcho = value;
                else
                    throw new Exception(string.Format("sEcho is expected to be a number, but it's: \"{0}\".", value));
            }
        }*/

        //An unaltered copy of sEcho sent from the client side. This parameter will change with each draw (it is basically a draw count)
        // - so it is important that this is implemented. 
        // Note that it strongly recommended for security reasons that you 'cast' this parameter to
        // an integer in order to prevent Cross Site Scripting (XSS) attacks.
        // TODO: ^
        public string sEcho { get; set; }
        //Total records, before filtering (i.e. the total number of records in the database)
        public int iTotalRecords { get; set; }
        //Total records, after filtering 
        // (i.e. the total number of records after filtering has been applied 
        // - not just the number of records being returned in this result set)
        public int iTotalDisplayRecords { get; set; }

        //public string sColumns { get; set; }
        //public IEnumerable<object> aaData { get; set; }
        public Array aaData { get; set; }

        //(int totalRecords,
        //                                           int totalDisplayRecords,
        //                                           string echo,
        //        //string columns,
        //                                           IEnumerable<T> data,

        //        string contentType,
        //System.Text.Encoding contentEncoding,
        //JsonRequestBehavior behavior

        //        )
    }


    public enum PaginationTypes
    {
        [Description("two_button")]
        TwoButton,
        [Description("full_numbers")]
        FullNumbers
    }

    public enum SortingDirections
    {
        [Description("asc")]
        Assending,
        [Description("desc")]
        Descending,
        Both = 0
    }
}
