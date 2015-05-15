using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace KusumgarHelper.PageHelper
{
  public static  class PageHelper
    {
        
            /// <summary>
            /// Numeric Pager.
            /// </summary>
            /// <param name="helper">The helper.</param>
            /// <param name="urlFormat">The URL format.</param>
            /// <param name="totalRecords">The total records.</param>
            /// <param name="currentPage">The current page.</param>
            /// <param name="pagesize">The pagesize.</param>
            /// <param name="pagerLength">Length of the pager.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            public static string NumericPager(this HtmlHelper helper, string urlFormat, int totalRecords, int currentPage, int pagesize, int pagerLength)
            {
                int totalPages = totalRecords % pagesize;

                //calculate total pages
                if (totalPages > 0)
                {
                    totalPages = (totalRecords / pagesize) + 1;
                }
                else
                {
                    totalPages = totalRecords / pagesize;
                }

                //Kaushik Jehtva Add Below code 11/06/2012
                //string linkFormat = "<a href=\"{0}\">{1}</a>";
                string startul = "<ul>";
                string endul = "</ul>";
                string linkFormat = "<li><a href=\"{0}\">{1}</a></li>";
                //End Comment 11/06/2012

                bool isFirst = true;

                StringBuilder sb = new StringBuilder();
                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(startul);
                //End Comment 11/06/2012
                double start = (double)currentPage / pagerLength;

                int startPoing = (int)(Math.Ceiling(start) - 1) * pagerLength + 1;

                if (startPoing == 0)
                {
                    startPoing = 1;
                }
                for (int i = 1; i < pagerLength + 1; i++)
                {
                    if (isFirst)
                    {
                        if (currentPage != 1)
                        {
                            //show next if there are more than one pages and current page is not first page
                            //Kaushik Jehtva Add Below code 11/06/2012
                            //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), " Previous");
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), "&laquo; Previous");
                            //End Comment 11/06/2012
                        }
                    }

                    string pageLink = startPoing.ToString();

                    //Test for current page
                    if (currentPage != startPoing)
                    {
                        if (startPoing <= totalPages)
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, startPoing), pageLink);
                    }
                    else
                    {
                        //denote if this isn't the current page
                        //Kaushik Jehtva Add Below code 11/06/2012
                        //sb.AppendFormat("<a class='active'>{0}</a>", pageLink);
                        sb.AppendFormat("<li class='active'><a><b>{0}</b></a></li>", pageLink);
                        //End Comment 11/06/2012
                    }
                    isFirst = false;
                    startPoing = startPoing + 1;
                }

                if (currentPage != totalPages)
                {
                    //show next if there are more than one pages

                    //Kaushik Jehtva Add Below code 11/06/2012
                    //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next "); ;
                    sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next &raquo; "); ;
                    //End Comment 11/06/2012
                }
                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(endul);
                //End Comment 11/06/2012

                return sb.ToString();
            }

            /*Modified By: Shakti R. Pawar | Modification Date: 11212012 | Version: v1.0 | Purpose: To append number of records along with pager.*/
            public static string NumericPager(this HtmlHelper helper, string urlFormat, int totalRecords, int currentPage, int pagesize, int pagerLength, bool withCount)
            {
                int totalPages = totalRecords % pagesize;

                //calculate total pages
                if (totalPages > 0)
                {
                    totalPages = (totalRecords / pagesize) + 1;
                }
                else
                {
                    totalPages = totalRecords / pagesize;
                }

                //Kaushik Jehtva Add Below code 11/06/2012
                //string linkFormat = "<a href=\"{0}\">{1}</a>";
                string startul = "<ul>";
                string endul = "</ul>";
                string linkFormat = "<li><a href=\"{0}\">{1}</a></li>";
                //End Comment 11/06/2012

                bool isFirst = true;

                StringBuilder sb = new StringBuilder();
                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(startul);
                sb.Append("<li>" + totalRecords + " records </li>");
                //End Comment 11/06/2012
                double start = (double)currentPage / pagerLength;

                int startPoing = (int)(Math.Ceiling(start) - 1) * pagerLength + 1;

                if (startPoing == 0)
                {
                    startPoing = 1;
                }
                for (int i = 1; i < pagerLength + 1; i++)
                {
                    if (isFirst)
                    {
                        if (currentPage != 1)
                        {
                            //show next if there are more than one pages and current page is not first page
                            //Kaushik Jehtva Add Below code 11/06/2012
                            //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), " Previous");
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), "&laquo; Previous");
                            //End Comment 11/06/2012
                        }
                    }

                    string pageLink = startPoing.ToString();

                    //Test for current page
                    if (currentPage != startPoing)
                    {
                        if (startPoing <= totalPages)
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, startPoing), pageLink);
                    }
                    else
                    {
                        //denote if this isn't the current page
                        //Kaushik Jehtva Add Below code 11/06/2012
                        //sb.AppendFormat("<a class='active'>{0}</a>", pageLink);
                        sb.AppendFormat("<li><a class='active'><b>{0}</b></a></li>", pageLink);
                        //End Comment 11/06/2012
                    }
                    isFirst = false;
                    startPoing = startPoing + 1;
                }

                if (currentPage != totalPages)
                {
                    //show next if there are more than one pages

                    //Kaushik Jehtva Add Below code 11/06/2012
                    //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next "); ;
                    sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next &raquo; "); ;
                    //End Comment 11/06/2012
                }


                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(endul);
                //End Comment 11/06/2012

                return sb.ToString();
            }
            /*Modification Ends.*/

            /*Modified By: Shakti R. Pawar | Modification Date: 11212012 | Version: v1.0 | Purpose: To append number of records along with pager.*/
            public static string NumericPagerWithDropDown(this HtmlHelper helper, string urlFormat, int totalRecords, int currentPage, int pagesize, int pagerLength, bool withCount)
            {
                int totalPages = totalRecords % pagesize;

                //calculate total pages
                if (totalPages > 0)
                {
                    totalPages = (totalRecords / pagesize) + 1;
                }
                else
                {
                    totalPages = totalRecords / pagesize;
                }

                //Kaushik Jehtva Add Below code 11/06/2012
                //string linkFormat = "<a href=\"{0}\">{1}</a>";
                string startul = "<ul>";
                string endul = "</ul>";
                string linkFormat = "<li><a href=\"{0}\">{1}</a></li>";
                //End Comment 11/06/2012

                bool isFirst = true;

                StringBuilder sb = new StringBuilder();
                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(startul);
                sb.Append("<li>" + totalRecords + " records </li>");
                //End Comment 11/06/2012
                double start = (double)currentPage / pagerLength;

                int startPoing = (int)(Math.Ceiling(start) - 1) * pagerLength + 1;

                if (startPoing == 0)
                {
                    startPoing = 1;
                }
                for (int i = 1; i < pagerLength + 1; i++)
                {
                    if (isFirst)
                    {
                        if (currentPage != 1)
                        {
                            //show next if there are more than one pages and current page is not first page
                            //Kaushik Jehtva Add Below code 11/06/2012
                            //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), " Previous");
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), "&laquo; Previous");
                            //End Comment 11/06/2012
                        }
                    }

                    string pageLink = startPoing.ToString();

                    //Test for current page
                    if (currentPage != startPoing)
                    {
                        if (startPoing <= totalPages)
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, startPoing), pageLink);
                    }
                    else
                    {
                        //denote if this isn't the current page
                        //Kaushik Jehtva Add Below code 11/06/2012
                        //sb.AppendFormat("<a class='active'>{0}</a>", pageLink);
                        sb.AppendFormat("<li><a class='active'><b>{0}</b></a></li>", pageLink);
                        //End Comment 11/06/2012
                    }
                    isFirst = false;
                    startPoing = startPoing + 1;
                }

                if (currentPage != totalPages)
                {
                    //show next if there are more than one pages

                    //Kaushik Jehtva Add Below code 11/06/2012
                    //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next "); ;
                    sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next &raquo; "); ;
                    //End Comment 11/06/2012
                }

                /*Modified By: Shakti R. Pawar | Modification Date: 03062013 | Version: v1.0 | Purpose: To add PageSize dropdown at the the end.*/
                switch (pagesize)
                {
                    case 10:
                        sb.AppendFormat("<li><select id='PageSize'><option value='10' selected>10</option><option value='20'>20</option><option value='30'>30</option></select></li>");
                        break;
                    case 20:
                        sb.AppendFormat("<li><select id='PageSize'><option value='10'>10</option><option value='20' selected>20</option><option value='30'>30</option></select></li>");
                        break;
                    case 30:
                        sb.AppendFormat("<li><select id='PageSize'><option value='10'>10</option><option value='20'>20</option><option value='30' selected>30</option></select></li>");
                        break;
                }
                /*Modification Ends.*/

                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(endul);
                //End Comment 11/06/2012

                return sb.ToString();
            }
            /*Modification Ends.*/

            /*Modified By: Shakti R. Pawar | Modification Date: 06182014 | Version: v1.0 | Purpose: Ajax Pager.*/
            //public static string NumericPager(string urlFormat, int totalRecords, int currentPage, int pagesize, int pagerLength, bool withCount)
            //{

            //    int totalPages = totalRecords % pagesize;

            //    //calculate total pages
            //    if (totalPages > 0)
            //    {
            //        totalPages = (totalRecords / pagesize) + 1;
            //    }
            //    else
            //    {
            //        totalPages = totalRecords / pagesize;
            //    }

            //    //Kaushik Jehtva Add Below code 11/06/2012
            //    //string linkFormat = "<a href=\"{0}\">{1}</a>";
            //    string startul = "<ul>";
            //    string endul = "</ul>";
            //    string linkFormat = "<li><a href=\"{0}\">{1}</a></li>";
            //    //End Comment 11/06/2012

            //    bool isFirst = true;

            //    StringBuilder sb = new StringBuilder();
            //    //Kaushik Jehtva Add Below code 11/06/2012
            //    sb.Append(startul);
            //    sb.Append("<li>" + totalRecords + " records </li>");
            //    //End Comment 11/06/2012
            //    double start = (double)currentPage / pagerLength;

            //    int startPoing = (int)(Math.Ceiling(start) - 1) * pagerLength + 1;

            //    if (startPoing == 0)
            //    {
            //        startPoing = 1;
            //    }
            //    for (int i = 1; i < pagerLength + 1; i++)
            //    {
            //        if (isFirst)
            //        {
            //            if (currentPage != 1)
            //            {
            //                //show next if there are more than one pages and current page is not first page
            //                //Kaushik Jehtva Add Below code 11/06/2012
            //                //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), " Previous");
            //                sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), "&laquo; Previous");
            //                //End Comment 11/06/2012
            //            }
            //        }

            //        string pageLink = startPoing.ToString();

            //        //Test for current page
            //        if (currentPage != startPoing)
            //        {
            //            if (startPoing <= totalPages)
            //                sb.AppendFormat(linkFormat, string.Format(urlFormat, startPoing), pageLink);
            //        }
            //        else
            //        {
            //            //denote if this isn't the current page
            //            //Kaushik Jehtva Add Below code 11/06/2012
            //            //sb.AppendFormat("<a class='active'>{0}</a>", pageLink);
            //            sb.AppendFormat("<li><a class='active'>{0}</a></li>", pageLink);
            //            //End Comment 11/06/2012
            //        }
            //        isFirst = false;
            //        startPoing = startPoing + 1;
            //    }

            //    if (currentPage != totalPages)
            //    {
            //        //show next if there are more than one pages

            //        //Kaushik Jehtva Add Below code 11/06/2012
            //        //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next "); ;
            //        sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next &raquo; "); ;
            //        //End Comment 11/06/2012
            //    }


            //    //Kaushik Jehtva Add Below code 11/06/2012
            //    sb.Append(endul);
            //    //End Comment 11/06/2012

            //    return sb.ToString();
            //}
            /*Modification Ends.*/




            public static string NumericPager(string urlFormat, int totalRecords, int currentPage, int pagesize, int pagerLength, bool withCount)
            {

                int totalPages = totalRecords % pagesize;

                //calculate total pages
                if (totalPages > 0)
                {
                    totalPages = (totalRecords / pagesize) + 1;
                }
                else
                {
                    totalPages = totalRecords / pagesize;
                }

                //Kaushik Jehtva Add Below code 11/06/2012
                //string linkFormat = "<a href=\"{0}\">{1}</a>";
                //string startul = "<li><a href='#'>&laquo</a></li>";
                //string endul =  "<li><a href='#'>&raquo</a></li>";
                string startul = "";
                string endul = "";
                string linkFormat = "<li><a href=\"{0}\">{1}</a></li>";


               
                //End Comment 11/06/2012

                bool isFirst = true;

                StringBuilder sb = new StringBuilder();
                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(startul);
                sb.Append("<li style='padding-left:4px;'><button style='border-color: transparent;background-color: transparent;' disabled='disabled'>" + totalRecords + " records </button></li>");
                //End Comment 11/06/2012
                double start = (double)currentPage / pagerLength;

                int startPoing = (int)(Math.Ceiling(start) - 1) * pagerLength + 1;

                if (startPoing == 0)
                {
                    startPoing = 1;
                }
                for (int i = 1; i < pagerLength + 1; i++)
                {
                    if (isFirst)
                    {
                        if (currentPage != 1)
                        {
                            //show next if there are more than one pages and current page is not first page
                            //Kaushik Jehtva Add Below code 11/06/2012
                            //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), " Previous");
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage - 1), "&laquo; ");
                            //End Comment 11/06/2012
                        }
                    }

                    string pageLink = startPoing.ToString();

                    //Test for current page
                    if (currentPage != startPoing)
                    {
                        if (startPoing <= totalPages)
                            sb.AppendFormat(linkFormat, string.Format(urlFormat, startPoing), pageLink);
                    }
                    else
                    {
                        //denote if this isn't the current page
                        //Kaushik Jehtva Add Below code 11/06/2012
                        //sb.AppendFormat("<a class='active'>{0}</a>", pageLink);
                        sb.AppendFormat("<li><a class='active'><b>{0}</b></a></li>", pageLink);

                       // sb.AppendFormat("<li><a href='#'>1</a></li>", pageLink);
                        //End Comment 11/06/2012
                    }
                    isFirst = false;
                    startPoing = startPoing + 1;
                }

                if (currentPage != totalPages)
                {
                    //show next if there are more than one pages

                    //Kaushik Jehtva Add Below code 11/06/2012
                    //sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " Next "); ;
                    sb.AppendFormat(linkFormat, string.Format(urlFormat, currentPage + 1), " &raquo; "); ;
                    //End Comment 11/06/2012
                }


                //Kaushik Jehtva Add Below code 11/06/2012
                sb.Append(endul);
                //End Comment 11/06/2012

                return sb.ToString();
            }


           


    }




}
