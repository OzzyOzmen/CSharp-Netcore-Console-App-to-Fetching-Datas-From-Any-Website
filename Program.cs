using System;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Console_App
{
    class Program
    {

        ///////////////////////////////////////////
        //                                       //
        //   Only for education                  //
        //                                       //
        //  Created by Ozzy Ozmen Celik          //
        //                                       //
        //////////////////////////////////////////


        static void Main(string[] args)
        {
            // Calling task void for running the program
            ReadData().Wait();
        }

        public static async Task ReadData()
        {

            /* Fetching Populer 5 Posts */

            // var link = "http://emrecin.com/";  // set web address to link variable / i used my friend's website and got permission by him to use

            // Uri url = new Uri(link); // set link into url variable 

            // var client = new WebClient(); // Used webclient method 

            // client.Encoding = Encoding.UTF8; // set the character with encoding type which we will use ( u can change to ur character type)

            // string html = await client.DownloadStringTaskAsync(url); // Fetched all html with joining to target URL and set it to html variable

            // HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // Created htmldocument with using HtmlAgilityPack

            //  document.LoadHtml(html);// set fetched html datas to document variable's html




            // var fetchedhtml = @"//*[@id=""sidebar""]/div[2]/div/div/div[2]/ul"; // set xpath of the datas we will fetch

            // StringBuilder st = new StringBuilder(); // Created a stringbuilder for appending the reuslts into

            // var fetchedhtmlList = document.DocumentNode.SelectNodes(fetchedhtml); // used selectnodes mothod to get xpath of set html 

            // foreach (var items in fetchedhtmlList)
            // {
                   // Only Post Titles ( but u can add only div tag in to selectNodes if u want to fetch Titles,Pictures and description of posts )
            //     foreach (var item in items.SelectNodes("li//div//h3"))
            //     {
            //         for (int i = 0; i < secilenHtmlList.Count; i++)
            //         {
            //             st.AppendLine(item.InnerText);
            //         }
            //     }


            // }


           /* Fetching Posts from Spesific Category */


            var catergory = "http://emrecin.com/category/teknoloji"; // set web address to link variable / i used my friend's website and got permission by him to use

            Uri url = new Uri(catergory); // set link into url variable 

            var client = new WebClient(); // Used webclient method 

            client.Encoding = Encoding.UTF8; // set the character type which we will use ( u can change to ur character type) with encoding

            string html = await client.DownloadStringTaskAsync(url); // Fetched all html with joined to target URL and set it to html variable

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // Used HtmlAgilityPack to create HtmlDocument.

            document.LoadHtml(html);// set fetched html datas into document variable's loadhtml


            var fetchedhtml = @"//*[@id=""content""]/div"; // set xpath of the datas we will fetch

            StringBuilder st = new StringBuilder(); // Created a stringbuilder for appending the reuslts into

            var fetchedhtmlList = document.DocumentNode.SelectNodes(fetchedhtml); //used selectnodes mothod to get xpath of set html 

            foreach (var items in fetchedhtmlList)
            {
                // Only Post Titles ( but u can add only div tag in to selectNodes if u want to fetch Titles,Pictures and description of posts )
                foreach (var item in items.SelectNodes("div//div//div//div//h3"))
                {
                    for (int i = 0; i < fetchedhtmlList.Count; i++)
                    {
                        st.AppendLine(item.InnerText);
                    }
                }


            }


            var result = st.ToString();

            Console.WriteLine(result);
            Console.ReadLine();

        }

    }
}
