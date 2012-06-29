using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel;

namespace Mvc.Ajax.DataTables
{
    public static class AjaxExtensions
    {
        public static MvcHtmlString DataTable(this AjaxHelper ajaxHelper,
            String tableName,
            AjaxOptions ajaxOptions,
            DataTableAttributes dataTableParams
            )
        {
            //ajaxOptions.Confirm
            //ajaxOptions.HttpMethod  // fnServerData :: type
            //ajaxOptions.InsertionMode
            //ajaxOptions.LoadingElementDuration
            //ajaxOptions.LoadingElementId
            //ajaxOptions.OnBegin // fnServerParams ??
            //ajaxOptions.OnComplete // $.ajax :: complete(jqXHR, textStatus)
            //ajaxOptions.OnFailure // $.ajax :: error(jqXHR, textStatus, errorThrown)
            //ajaxOptions.OnSuccess // $.ajax :: success 
            //ajaxOptions.UpdateTargetId ???
            //ajaxOptions.Url= // sAjaxSource 


            //            string tableId = ResolveTableId(tableName, ajaxOptions.UpdateTargetId);
            //            TagBuilder tableTag = TableTagBuilder(tableId, tableName, ajaxOptions.UpdateTargetId);

            //            TagBuilder builder = new TagBuilder("script");

            //            builder.InnerHtml = @"
            ////var oTable;
            ////var generated_aoColumnDefs = [@generateColumnsForOTable()];
            ////var generated_sAjaxSource = '@Url.Action(""GetTableRows"", new { TableName = Model.TableDefinition.Name })';
            //
            //$(document).ready(function () {
            //
            //    var oTable = $('#tblRows').dataTable({
            //        ""aoColumnDefs"": {0},
            //        ""bJQueryUI"": true,
            //        ""aLengthMenu"": [[5, 10, 25, 100, -1], [5, 10, 25, 100, ""All""]],
            //        ""bSort"": true,
            //        ""aaSorting"": [[1, ""asc""]],
            //        ""bFilter"": false, /* Searching will not be implemented in the this release */
            //        ""bPaginate"": true,
            //        ""sPaginationType"": ""full_numbers"",
            //        ""bAutoWidth"": false,
            //        ""bProcessing"": true,
            //        ""bServerSide"": true,
            //        ""bStateSave"": true, //why it doesn't work?
            //        ""sAjaxSource"": generated_sAjaxSource,
            //        ""fnServerData"": function (sSource, aoData, fnCallback) {
            //            UpdateUrl();
            //            FetchServerData(this, sSource, aoData, fnCallback);
            //        }
            //
            //});
            //";






            //return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
            return MvcHtmlString.Create(string.Format("<script type='text/javascript'>\n{0}\n</script>", GenerateOTableScript(tableName, dataTableParams, ajaxOptions)));
        }

        public static string ToLowerString(this bool boolean)
        {
            return boolean.ToString().ToLower();
        }


        private static string GenerateOTableScript(String tableName, DataTableAttributes dataTableParams, AjaxOptions ajaxOptions)
        {
            string scriptText = string.Empty;
            scriptText += "$(document).ready(function () {\n";
            //scriptText += "alert('hey!');\n";
            scriptText += string.Format("\tvar oTable = $('#{0}').dataTable({{\n", tableName);
            scriptText += string.Format("\t\"aoColumnDefs\": {0},\n", GenerateColumnDefsForOTable(dataTableParams.ColumnDefs));
            scriptText += string.Format("\t\"bAutoWidth\": {0},\n", dataTableParams.AutoWidth.ToLowerString());
            scriptText += string.Format("\t\"bDeferRender\": {0},\n", dataTableParams.DeferRender.ToLowerString());
            scriptText += string.Format("\t\"bFilter\": {0},\n", dataTableParams.Filter.ToLowerString());
            scriptText += string.Format("\t\"bInfo\": {0},\n", dataTableParams.Info.ToLowerString());
            scriptText += string.Format("\t\"bJQueryUI\": {0},\n", dataTableParams.JQueryUI.ToLowerString());
            scriptText += string.Format("\t\"bLengthChange\": {0},\n", dataTableParams.LengthChange.ToLowerString());
            scriptText += string.Format("\t\"bPaginate\": {0},\n", true.ToLowerString());
            scriptText += string.Format("\t\"bProcessing\": {0},\n", true.ToLowerString());
            scriptText += string.Format("\t\"bScrollInfinite\": {0},\n", dataTableParams.ScrollInfinite.ToLowerString());
            scriptText += string.Format("\t\"bServerSide\": {0},\n", true.ToLowerString());
            scriptText += string.Format("\t\"bSort\": {0},\n", dataTableParams.Sort.ToLowerString());
            scriptText += string.Format("\t\"bSortClasses\": {0},\n", dataTableParams.SortClasses.ToLowerString());
            scriptText += string.Format("\t\"bStateSave\": {0},\n", dataTableParams.StateSave.ToLowerString());
            if (!string.IsNullOrEmpty(dataTableParams.ScrollX))
                scriptText += string.Format("\t\"sScrollX\": {0},\n", dataTableParams.ScrollX);
            if (!string.IsNullOrEmpty(dataTableParams.ScrollY))
                scriptText += string.Format("\t\"sScrollY\": {0},\n", dataTableParams.ScrollY);
            scriptText += string.Format("\t\"sPaginationType\": \"{0}\",\n", GetDescription(dataTableParams.PaginationType));

            scriptText += string.Format("\t\"sAjaxSource\": \"{0}\",\n", ajaxOptions.Url);
            scriptText += string.Format("\t\"sServerMethod\": \"{0}\"\n", ajaxOptions.HttpMethod);

            scriptText += "\t}); \n";
            scriptText += "});";

            //+ string.Format("\t\"\": {0},\n", )

            return scriptText;
        }




        private static TagBuilder TableTagBuilder(string tableId, string tableName, string updateTargetId)
        {
            if (!string.IsNullOrWhiteSpace(updateTargetId))
                return new TagBuilder(string.Empty);

            TagBuilder containerDiv = new TagBuilder("div");

            return containerDiv;


            /*

            <div id="tblRows-table-container" class="ui-widget">
                <table id="tblRows" class="display">
                    <thead>
                        <tr>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="@Model.TableDefinition.ColumnDefinitions.Count" class="dataTables_empty">
                                Trying to load data from server...
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                        </tr>
                    </tfoot>
                </table>
            </div>              
             
             */

        }





        private static MvcHtmlString GenerateColumnDefsForOTable(IEnumerable<ColumnDef> columnDefs)
        {
            if (columnDefs.Count() == 0)
                return MvcHtmlString.Create(string.Empty);

            string result = "[ \n";
            for (int colIndex = 0; colIndex < columnDefs.Count(); colIndex++)
            {
                ColumnDef columnDef = columnDefs.ElementAt(colIndex);
                result += ColumnDefToString(columnDef, colIndex);
                if (colIndex != columnDefs.Count() - 1)
                    result += ", \n";
            }
            result += " ]";

            return MvcHtmlString.Create(result);
        }



        /// <summary>
        /// Generates a formatted string of ColumnDef for oTable object of DataTables.
        /// This method is used by MVC.Ajax.DataTables.GenerateColumnsForOTable(IEnumerable<ColumnDef> columnDefs).
        /// </summary>
        /// <param name="columnDef">
        /// An instance of ColumnDef class.
        /// </param>
        /// <param name="targets">
        ///The aTargets property is an array to target one of many columns and each element in it can be:
        ///  - a string - class name will be matched on the TH for the column
        ///  - 0 or a positive integer - column index counting from the left
        ///  - a negative integer - column index counting from the right
        ///  - the string "_all" - all columns (i.e. assign a default)
        /// But for now, i just accept an int for "targets" which represent aTargets.
        /// (TODO: int targets --» object[] targets)
        /// </param>
        /// <returns></returns>
        private static string ColumnDefToString(ColumnDef columnDef, int targets)
        {
            string result = "\t\t{\n";
            if (columnDef.Sorting != SortingDirections.Both)
                result += string.Format("\t\t\"aDataSort\": [ \"{0}\" ], \n", GetDescription(columnDef.Sorting));
            if (!columnDef.Sortable) //bSortable default is true
                result += string.Format("\t\t\"bSortable\": {0}, \n", columnDef.Sortable.ToString().ToLower());
            if (!columnDef.UseRendered) //bUseRendered default is true
                result += string.Format("\t\t\"bUseRendered\": {0}, \n", columnDef.UseRendered.ToString().ToLower());
            if (!columnDef.Visible) //bVisible default is true 
                result += string.Format("\t\t\"bVisible\": : {0}, \n", columnDef.Visible);
            if (!string.IsNullOrEmpty(columnDef.FnCreatedCell))
                result += string.Format("\t\t\"fnCreatedCell\": {0}, \n", columnDef.FnCreatedCell);
            if (!string.IsNullOrEmpty(columnDef.FnRender))
                result += string.Format("\t\t\"fnRender\": {0}, \n", columnDef.FnRender);
            if (!string.IsNullOrEmpty(columnDef.CssClass))
                result += string.Format("\t\t\"sClass\": \"{0}\", \n", columnDef.CssClass);
            if (!string.IsNullOrEmpty(columnDef.DefaultContent))
                result += string.Format("\t\t\"sDefaultContent\": {0}, \n", columnDef.DefaultContent);
            if (!string.IsNullOrEmpty(columnDef.DataProp))
                result += string.Format("\t\t\"mDataProp\": \"{0}\", \n", columnDef.DataProp);
            if (!string.IsNullOrEmpty(columnDef.Name))
                result += string.Format("\t\t\"sName\": \"{0}\", \n", columnDef.Name);
            if (!string.IsNullOrEmpty(columnDef.Title))
                result += string.Format("\t\t\"sTitle\": \"{0}\", \n", columnDef.Title);
            if (!string.IsNullOrEmpty(columnDef.Width))
                result += string.Format("\t\t\"sWidth\": \"{0}\", \n", columnDef.Width);
            result += string.Format("\t\t\"aTargets\": [ {0} ] }}", targets);
            return result;
        }


        private static string ResolveTableId(string tableName, string updateTargetId)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                if (string.IsNullOrWhiteSpace(updateTargetId))
                    return GenerateTableId();
                else
                    return updateTargetId;
            else
                return tableName;
        }

        private static string GenerateTableId()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return string.Format("table{0}", BitConverter.ToInt64(buffer, 0));
        }

        private static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
        
    }

}
