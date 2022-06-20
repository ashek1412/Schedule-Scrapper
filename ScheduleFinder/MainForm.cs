using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using ScheduleFinder.util;
using System.Linq;
using MimeKit;
using MailKit.Net.Smtp;
using System.IO;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.Web;
using System.Globalization;

namespace ScheduleFinder
{
    public partial class MainForm : Form
    {
        Random rand = new Random();
        Timer mytimer = new Timer();
        Stopwatch s1;
        int nextClicked = 1;
        int prevClicked = 1;
        int slotClicked = 0;
        int lastWeekClicked = 0;
        string allNone;
        decimal[] decArray = { 1.00M,1.50M,2.00M,2.50M,3.00M};


        DateTime Dt;
        DateTime cdt;
        DateTime ldt;
        

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Schedule Finder - "+ Application.ProductVersion;
           




        }
        public struct JsonObject
        {
            public string Key;
            public string Value;
        }



        private async Task InitializeAsync()
        {
            try
            {
                Debug.WriteLine("InitializeAsync");
                await webView21.EnsureCoreWebView2Async(null);
                Debug.WriteLine("WebView2 Runtime version: " + webView21.CoreWebView2.Environment.BrowserVersionString);

                //SendMail("test");
            }
            catch (Exception ex1)
            {
                Logger.WriteToFile(ex1.Message);
                MessageBox.Show(ex1.Message);
            }
        }



        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            string sURL = webView21.Source.ToString();

            // MessageBox.Show(sURL);
            Logger.WriteToFile(sURL);


        }



        private async void buttonStop_Click(object sender, EventArgs e)
        {

            webView21.Refresh();
            if (mytimer.Enabled)
            {
                mytimer.Stop();
                buttonStop.Enabled = false;
                buttonStart.Enabled = true;


            }
            label1.Text = "Elapsed Time :";
            nextClicked = 1;
            prevClicked = 1;

            //slotlFoundLabel.Text = "Slot Found : 0";
            labelSlotBooked.Text = "Slot Booked : 0";
            prevCnt.Text = "0";
            NextCnt.Text = "0";
            s1.Stop();
            await webView21.ExecuteScriptAsync("document.getElementById('timer_stat').innerHTML ='off';");
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //webView21.CoreWebView2InitializationCompleted += webView21_CoreWebView2InitializationCompleted;

            try
            {
                
                dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
                Dt = DateTime.Today.AddDays(10 * 7); ;

                              
                dateTimePicker1.Value= Dt;
                Debug.WriteLine("before InitializeAsync");
                await InitializeAsync();
                Debug.WriteLine("after InitializeAsync");
                if ((webView21 == null) || (webView21.CoreWebView2 == null))
                {
                    Debug.WriteLine("not ready");
                }

                string murl = "https://www.gov.uk/book-pupil-driving-test";

                string testUrl = "https://datatables.net/examples/data_sources/dom";


                webView21.CoreWebView2.Navigate(murl);


                Debug.WriteLine("after NavigateToString");
                s1 = new Stopwatch();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }



        private async void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {

            string mscript = File.ReadAllText("myscript.js");
            await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(mscript);

        }

        private void CoreWebView21_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(e.WebMessageAsJson);
            switch (jsonObject.Key)
            {
                case "click":
                    MessageBox.Show(jsonObject.Value);
                    break;

            }
        }


        public async Task<int> FindSlot()
        {
            try
            {
                string allNone = await webView21.ExecuteScriptAsync("document.documentElement.outerHTML;");
                string slotAid = null;
                allNone = Regex.Unescape(allNone);
                allNone = allNone.Remove(0, 1);
                allNone = allNone.Remove(allNone.Length - 1, 1);
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(allNone);
                var nodes = htmlDoc.DocumentNode.SelectNodes("//td[@class='day slotsavailable']");
                //var nodes = htmlDoc.DocumentNode.SelectNodes("//td[@class='sorting_1']");
                if (nodes != null)
                {
                    if (mytimer.Enabled)
                    {
                        mytimer.Stop();
                        buttonStop.Enabled = false;


                    }
                    buttonStart.Enabled = true;
                    foreach (HtmlNode node in nodes)
                    {
                        HtmlNode a = node.SelectSingleNode("a[@href]");
                        if (a != null)
                        {
                            slotAid = a.Attributes["id"].Value;
                            string res = await webView21.ExecuteScriptAsync("document.getElementById('" + slotAid + "').click()");
                            break;

                        }
                        //MessageBox.Show(node.InnerText);
                        //MessageBox.Show(node.InnerText);


                    }


                    //slotlFoundLabel.Text = "Slot Found : " + nodes.Count;
                    await webView21.ExecuteScriptAsync("document.getElementById('timer_stat').innerHTML ='off';");
                    //buttonStart.Enabled = false;

                    return 1;


                }


            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
                return 2;
            }

            return 0;

        }

        public async void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            try
            {
                //int fortimerinterval = rand.Next(2, 4);
                decimal fortimerinterval = decArray[rand.Next(0, decArray.Length)];

                mytimer.Interval = (int)fortimerinterval*1000;

                int r = 0;
                if (r == 0)
                {
                    
                    string allNone = await webView21.ExecuteScriptAsync("document.documentElement.outerHTML;");
                    allNone = Regex.Unescape(allNone);
                    allNone = allNone.Remove(0, 1);
                    allNone = allNone.Remove(allNone.Length - 1, 1);


                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(allNone);
                    // await Task.Delay(2 * 1000);
                    var nextWeek = htmlDoc.DocumentNode.SelectNodes("//a[@id='searchForWeeklySlotsNextAvailable']");
                   // var prevWeek = htmlDoc.DocumentNode.SelectNodes("//a[@id='searchForWeeklySlotsPreviousAvailable']");

                    label1.Text = "Elapsed Time :" + s1.Elapsed.Hours + ":" + s1.Elapsed.Minutes + ":" + s1.Elapsed.Seconds;

                 //   if ((prevWeek != null && lastWeekClicked == 2) || (prevWeek != null && nextWeek==null))
                    //{
                    //    string res = await webView21.ExecuteScriptAsync("document.getElementById('searchForWeeklySlotsPreviousAvailable').click()");

                    //    prevCnt.Text = " " + prevClicked++;
                    //    lastWeekClicked = 1;
                    //}
                    //else 
                    if (nextWeek != null)
                    {

                        string res = await webView21.ExecuteScriptAsync("document.getElementById('searchForWeeklySlotsNextAvailable').click()");
                        NextCnt.Text = " " + nextClicked++;
                        lastWeekClicked = 2;
                    }

                }
                else
                {
                    if (mytimer.Enabled)
                    {
                        mytimer.Stop();
                        buttonStop.Enabled = false;
                    }
                }

                //int l = await FindSlot();

                if (mytimer.Enabled==false)
                {
                    mytimer.Start();
                    
                }              


            }
            catch(Exception tickerEx)
            {
                MessageBox.Show(tickerEx.Message);

            }
         }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                string sURL = webView21.Source.ToString();
                string live_url = "https://dsa.dft.gov.uk/obs-web/pages/home?execution";
                string test_url = "https://datatables.net/examples/data_sources/dom";

                if (sURL.Contains(live_url))
                {

                    string allNone = await webView21.ExecuteScriptAsync("document.documentElement.outerHTML;");
                    allNone = Regex.Unescape(allNone); 
                    allNone = allNone.Remove(0, 1);
                    allNone = allNone.Remove(allNone.Length - 1, 1);
                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(allNone);
                    var tagNext = htmlDoc.DocumentNode.SelectNodes("//a[@id='searchForWeeklySlotsNextAvailable']");
                   // var tagPrev = htmlDoc.DocumentNode.SelectNodes("//a[@id='searchForWeeklySlotsPreviousAvailable']");
                    slotClicked = 0;
                    await webView21.ExecuteScriptAsync("document.getElementById('timer_stat').innerHTML ='on';");
                    if (lastWeekClicked == 0)
                    {
                        lastWeekClicked = 2;

                        //if (tagNext != null || tagPrev != null)
                         if (tagNext != null)
                         {
                            mytimer.Tick += new EventHandler(TimerEventProcessor);
                            mytimer.Interval = 1000;                            
                            mytimer.Enabled = true;
                            mytimer.Start();
                            buttonStart.Enabled = false;
                            buttonStop.Enabled = true;
                            s1.Start();
                        }
                    }
                    else
                    {
                        mytimer.Start();
                        buttonStart.Enabled = false;
                        buttonStop.Enabled = true;
                        s1.Start();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            try
            {
                 string sURL = webView21.Source.ToString();
                string live_url = "https://dsa.dft.gov.uk/obs-web/pages/home?execution";


                if (sURL.Contains(live_url))
                {
                   
                    string allNone = await webView21.ExecuteScriptAsync("document.documentElement.outerHTML;");
                 
                    if (allNone != null)
                    {
                        allNone = Regex.Unescape(allNone);
                        allNone = allNone.Remove(0, 1);
                        allNone = allNone.Remove(allNone.Length - 1, 1);
                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(allNone);
                        var tag = htmlDoc.DocumentNode.SelectNodes("//a[@id='searchForWeeklySlotsNextAvailable']");
                        var backButtonCloseDialog = htmlDoc.DocumentNode.SelectNodes("//a[@id='backButtonCloseDialog']");
                        var prevtag = htmlDoc.DocumentNode.SelectNodes("//a[@id='searchForWeeklySlotsPreviousAvailable']");
                        var currweek = htmlDoc.DocumentNode.SelectNodes("//div[@class='span-7']/p");
                        var resultAvailbleTest = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

                        if(backButtonCloseDialog!=null)
                        {
                            mytimer.Stop();
                            string res = await webView21.ExecuteScriptAsync("document.getElementById('backButtonCloseDialog').click()");
                            System.Threading.Thread.Sleep(1500);
                            mytimer.Start();
                            buttonStart.Enabled = false;
                            buttonStop.Enabled = true;
                            s1.Start();



                        }

                        //Logger.WriteToFile(tag.ToString());

                        if (tag != null || prevtag != null)
                        {
                            slotClicked = 0;
                            mytimer.Stop();
                            s1.Stop();
                            buttonStart.Enabled = true;
                            //dateTimePicker1.Enabled = false;
                            if (currweek != null)
                            {                                
                                string cweek = null;
                                int i = 1;
                                foreach (HtmlNode cnode in currweek)
                                {
                                    //cweek = cnode.Attributes["InnerText"].Value;
                                    cweek = HttpUtility.HtmlDecode(cnode.InnerText).Trim();

                                    //Logger.WriteToFile(cweek);
                                    if (cweek.Length>1 && i==2)
                                    {

                                        cweek = cweek.Substring(cweek.Length - 18).Trim();
                                        string replacedStr = cweek.Substring(0, 4).Replace("nd", "").Replace("th", "").Replace("rd", "").Replace("st", "")+ cweek.Substring(4);

                                        string format = "d MMMM yyyy";
                                        DateTime dateTime;
                                        if (DateTime.TryParseExact(replacedStr, format, CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out dateTime))
                                        {
                                            cweek = DateTime.Parse(replacedStr).ToString();
                                          
                
                                        }
                                        else
                                        {
                                            cweek = "";
                                        }
                                        await webView21.ExecuteScriptAsync("document.getElementById('curr_date').innerHTML ='" + cweek + "';");
                                    }
                                    i++;
                                }
                            }

                            await webView21.ExecuteScriptAsync("document.getElementById('timer_stat').innerHTML ='off';");
                            await webView21.ExecuteScriptAsync("document.getElementById('last_date').innerHTML ='"+dateTimePicker1.Value.ToString("yyyy-MM-dd") + "';");
                          
                        }
                        else if (resultAvailbleTest != null && resultAvailbleTest.InnerText == "Test centre availability - Book tests")
                        {
                          
                            var slotCountdown = htmlDoc.DocumentNode.SelectNodes("//div[@id='slotCountdown']");


                                var nodes = htmlDoc.DocumentNode.SelectNodes("//td[@class='reserve centre']");
                                //var nodes = htmlDoc.DocumentNode.SelectNodes("//td[@class='sorting_1']");
                                if (nodes != null && mytimer.Enabled==true)
                                {
                                    string resSlot = null;
                                    foreach (HtmlNode node in nodes)
                                    {
                                        HtmlNode a = node.SelectSingleNode("//span/span/a");
                                        if (a != null && slotClicked == 0)
                                        {
                                            resSlot = a.Attributes["id"].Value;
                                            string res = await webView21.ExecuteScriptAsync("document.getElementById('" + resSlot + "').click()");
                                            slotClicked = 1;
                                            buttonStart.Enabled = false;
                                            labelSlotBooked.Text = "Slot Booked :1";
                                             SendMail(a.InnerText);                                     

                                            break;
                                           

                                        }
                                    }

                                }
                            mytimer.Stop();
                            s1.Stop();
                            buttonStop.Enabled = false;
                            await webView21.ExecuteScriptAsync("document.getElementById('timer_stat').innerHTML ='off';");
                            //dateTimePicker1.Enabled = false;

                        }
                    }
                }
                else
                {

                    slotClicked = 0;
                    buttonStart.Enabled = false;
                    //dateTimePicker1.Enabled = true;

                }
            }
            catch (Exception nex)
            {
                // MessageBox.Show(nex.Message);
                Extensions.FlattenException(nex);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
            {
                MessageBox.Show("Closed by calling Close()");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Please Log out before closing. Are you sure ?", "Close", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (mytimer.Enabled)
                    {
                        mytimer.Stop();

                    }
                    e.Cancel = false;
                    Application.Exit();

                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*            var messageOptions = new CreateMessageOptions(
                                    new PhoneNumber("+34622425588"));
                        messageOptions.MessagingServiceSid = "MG0fddc647d5680a4733b4db8f67fadef0";
                        messageOptions.Body = "TEST from App";

                        var message = MessageResource.Create(messageOptions);*/
    

        }

        private async void webView21_DOMContentLoaded(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DOMContentLoadedEventArgs e)
        {
            string allNone = await webView21.ExecuteScriptAsync("document.documentElement.outerHTML;");
        }


        public async void SendMail(string rcenter)
        {

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Scarapper Alert", "testme2576@gmail.com"));
            mailMessage.Cc.Add(new MailboxAddress("Hasan", "ashek1412@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("Thea", "des234567@gmail.com"));
            mailMessage.Subject = "Slot Found !!";
            mailMessage.Body = new TextPart("plain")
            {
                Text =  labelSlotBooked.Text + " . " + rcenter
            };

            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("testme2576@gmail.com", "hzmfsxmlzkztkcmi");
                await smtpClient.SendAsync(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
        }
    }
