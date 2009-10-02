﻿//using System;
//using System.Collections.Generic;
//using NUnit.Framework;
//using Common = SDMX_ML.Framework.Common;
//using Message = SDMX_ML.Framework.Message;
//using Messages = SDMX_ML.Framework.Messages;
//using Query = SDMX_ML.Framework.Query;
//using System.IO;
//using System.Xml.Linq;
//using System.Xml;


//namespace SDMX.Tests
//{
//    [TestFixture]
//    public class QueryMessageTests
//    {
//        [Test]
//        public void Create_QueryMessage_with_CodeListWhere()
//        {
//            Messages.QueryMessage message = new Messages.QueryMessage()
//            {
//                Header = GetHeader(),
//                CodelistWhere = new List<Query.CodelistWhereType>() 
//                { new Query.CodelistWhereType()
//                    {
//                        Codelist = new Query.CodelistType()
//                        {
//                            Id = "KL_PUB_VALUTAKURS"
//                        }
//                    }
//                }
//            };

//            string xml = message.ToXml();

//            bool isValid = Utility.ValidateMessage(xml);

//            Assert.IsTrue(isValid);
//        }

//        [Test]
//        public void Create_QueryMessage_with_DataWhere()
//        {
//            Messages.QueryMessage quryMessage = new Messages.QueryMessage()
//            {
//                Header = GetHeader(),
//                DataWhere = new List<Query.DataWhereType>() 
//                { 
//                    new Query.DataWhereType()
//                    {
//                        And = new Query.AndType()
//                        {
//                            Dimensions = new List<Query.DimensionType>()
//                            {
//                                new Query.DimensionType()
//                                {
//                                     Id = "VAL_KURSTYPE",
//                                     Value = "KBH"
//                                },
//                                new Query.DimensionType()
//                                {
//                                     Id = "VALUTA",
//                                     Value = "USD"
//                                },
//                                 new Query.DimensionType()
//                                {
//                                     Id = "FREQ",
//                                     Value = "D"
//                                }                                
//                            },
//                            Keyfamily = new List<string>() { "DN_VALUTA2" },
//                            DataProvider = new List<string>() { "DN" },
//                            Time = new List<Query.TimeType>()
//                            {
//                                new Query.TimeType() 
//                                { 
//                                    StartTime = new Common.TimePeriodType() { TimePeriod = "2007-11-01" }
//                                }
//                            }
//                        }
//                    }
//                }
//            };
//            Assert.IsTrue(Utility.ValidateMessage(quryMessage.ToXml()));
//        }

//        [Test]
//        public void Can_load_QuerySample()
//        {
//            string samplePath = Utility.GetPathFromProjectBase("lib\\QuerySample.xml");
//            XDocument loadedXml = XDocument.Load(samplePath);

//            Messages.QueryMessage message = new Messages.QueryMessage(loadedXml.ToString());

//            XDocument generatedXml = XDocument.Parse(message.ToXml());

//            //Assert.AreEqual(loadedXml, generatedXml);
//            Assert.IsTrue(Utility.CompareXML(loadedXml, generatedXml));
//        }



//        private Message.HeaderType GetHeader()
//        {

//            Message.HeaderType header = new Message.HeaderType()
//            {
//                Id = "DN_VALUTA2",
//                Test = true,
//                Truncated = false,
//                Name = "Some name",
//                Prepared = DateTime.Now.ToString("s"),
//                Sender = new Message.PartyType()
//                {
//                    Contact = new List<Message.ContactType>() 
//                    { 
//                        new Message.ContactType() 
//                        { 
//                            Name = new Common.TextType() { Text = "Sender name", Lang = "end" },
//                            Telephone = "+45 99999999"
//                        }
//                    }
//                },
//                Receiver = new Message.PartyType()
//                {
//                    Id = "ReceiverId",
//                    Name = new Common.TextType() { Text = "Receiver Name", Lang = "en" },
//                    Contact = new List<Message.ContactType>() 
//                    {                         
//                        new Message.ContactType() 
//                        {   
//                            Name = new Common.TextType() { Text = "Receiver Name", Lang = "en" },
//                            Telephone = "+45 99999999"
//                        }
//                    }
//                }
//            };

//            return header;
//        }

//    }
//}