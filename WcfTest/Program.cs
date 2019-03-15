using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WcfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new Merac.MeracOnlineInterfaceSoapClient())
            {
                client.Endpoint.Behaviors.Add(new TraceServiceBehavior());
                var table = new DataTable("dtRequestedBookings");
                table.Columns.Add("Action");
                table.Columns.Add("BookType", typeof(int));
                table.Columns.Add("Branch", typeof(short));
                table.Columns.Add("BookingRef", typeof(int));
                table.Columns.Add("BkSeq", typeof(short));
                table.Columns.Add("Surname");
                table.Columns.Add("PinNo");
                table.Columns.Add("ResRecNo", typeof(int));
                table.Columns.Add("Qty", typeof(int));
                table.Columns.Add("Price", typeof(decimal));
                table.Columns.Add("AmountPaid", typeof(decimal));
                table.Columns.Add("BookFrom");
                table.Columns.Add("BookTo");

                table.Columns.Add("CCardNo");
                table.Columns.Add("CCExpiry");
                table.Columns.Add("CCStart");
                table.Columns.Add("CCIssue", typeof(short));
                table.Columns.Add("Title");
                table.Columns.Add("ForeNames");
                table.Columns.Add("PostCode");
                table.Columns.Add("Email");
                table.Columns.Add("AllowEmail", typeof(bool));
                table.Columns.Add("NewsLetter", typeof(char));

                table.Columns.Add("Status");
                table.Columns.Add("AccBranch", typeof(short));
                table.Columns.Add("AccRecNo", typeof(int));
                table.Columns.Add("AccNum");
                table.Columns.Add("AccName");
                table.Columns.Add("CusSeq", typeof(short));
                table.Columns.Add("Address1");
                table.Columns.Add("Address2");
                table.Columns.Add("Address3");
                table.Columns.Add("Address4");
                table.Columns.Add("Town");
                table.Columns.Add("County");
                table.Columns.Add("Telephone");
                table.Columns.Add("BKHNotes");

                table.Columns.Add("ArrTime", typeof(DateTime));
                table.Columns.Add("BName");
                table.Columns.Add("DOB", typeof(DateTime));
                table.Columns.Add("UserDef1", typeof(int));
                table.Columns.Add("UserDef2", typeof(int));

                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("Source", typeof(int));
                table.Columns.Add("FollowUp");

                table.Columns.Add("SesRecNo", typeof(int));
                table.Columns.Add("SesSeq", typeof(short));
                table.Columns.Add("BCDId", typeof(int));
                table.Columns.Add("SesNum", typeof(short));

                table.Columns.Add("IsGiftAid", typeof(bool));
                table.Columns.Add("MobileTel");
                table.Columns.Add("CouponCode");
                table.Columns.Add("JourneyFrom", typeof(int));
                table.Columns.Add("JourneyTo", typeof(int));
                table.Columns.Add("Confirmed", typeof(byte));
                table.Columns.Add("TemplateID", typeof(int));

                table.Columns.Add("SesRecNo2", typeof(int));
                table.Columns.Add("SesSeq2", typeof(short));
                table.Columns.Add("JourneyFrom2", typeof(int));
                table.Columns.Add("JourneyTo2", typeof(int));
                table.Columns.Add("SesRecNo3", typeof(int));
                table.Columns.Add("SesSeq3", typeof(short));
                table.Columns.Add("JourneyFrom3", typeof(int));
                table.Columns.Add("JourneyTo3", typeof(int));

                table.Columns.Add("WebBkgID", typeof(int));
                table.Columns.Add("xmlCaptureQuestions");
                table.Columns.Add("BkdNotes");
                table.Columns.Add("MembCardUsedForValidation");
                table.Columns.Add("CustRef");
                table.Columns.Add("GUID");

                table.Columns.Add("ShopBasketID", typeof(int));

                table.Rows.Add(
                    "N",    //Action
                    0,  //BookType
                    0,  //Branch
                    0,  //BookingRef
                    1,  //BkSeq
                    "Convious", //Surname
                    "", //PinNo
                    339,    //ResRecNo
                    1, //Qty
                    10, //Price
                    10, //AmountPaid
                    "13 Mar 2019 11:46:01", //BookFrom
                    "13 Mar 2019 11:46:01", //BookTo
                    "", //CCardNo
                    "", //CCExpiry
                    "", //CCStart
                    0, //CCIssue
                    "Dr",   //Title
                    "Juozapas", //ForeNames
                    "LT-1235",  //PostCode
                    "juozas@convious.com",  //Email
                    false,  //AllowEmail
                    "N",    //NewsLetter

                    "R", //Status
                    0,  //AccBranch
                    0,  //AccRecNo
                    "", //AccNum
                    "", //AccName
                    0,  //CusSeq
                    "", //Address1
                    "", //Address2
                    "", //Address3
                    "", //Address4
                    "", //Town
                    "", //County
                    "", //Telephone
                    "", //BKHNotes

                    DateTime.UtcNow, //ArrTime
                    "", //BName
                    DateTime.UtcNow,  //DOB
                    0, //UserDef1
                    0,  //UserDef2

                    1,  //UserId
                    0,  //Source
                    "", //FollowUp

                    0,   //SesRecNo
                    0, //SesSeq
                    0, //BCDId
                    0, //SesNum

                    0,  //IsGiftAid
                    "", //MobileTel
                    "", //CouponCode
                    0, //JourneyFrom
                    0, //JourneyTo
                    0, //Confirmed
                    0, //TemplateID

                    0, //SesRecNo2
                    0, //SesSeq2
                    0, //JourneyFrom2
                    0, //JourneyTo2
                    0, //SesRecNo3
                    0, //SesSeq3
                    0, //JourneyFrom3
                    0, //JourneyTo3

                    0, //WebBkgID
                    "", //xmlCaptureQuestions
                    "", //BkdNotes
                    "", //MembCardUsedForValidation
                    "", //CustRef
                    "",  //GUID

                    0  //ShopBasketID
                    );
                var result = client.SaveBookings("<auth token here>", table);

                foreach (DataRow dataRow in result.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.WriteLine(item);
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
