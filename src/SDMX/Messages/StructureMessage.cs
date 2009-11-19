using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using SDMX.Parsers;
using System.Xml;
using System.IO;

namespace SDMX
{
    public class StructureMessage : Message
    {  
        public IList<CodeList> CodeLists { get; private set; }
        public IList<Concept> Concepts { get; private set; }
        public IList<KeyFamily> KeyFamilies { get; private set; }
        public IList<HierarchicalCodeList> HierarchicalCodeLists { get; private set; }

        public StructureMessage()
        {
            CodeLists = new List<CodeList>();
            Concepts = new List<Concept>();
            KeyFamilies = new List<KeyFamily>();
            HierarchicalCodeLists = new List<HierarchicalCodeList>();
        }


        private T Filter<T>(IEnumerable<T> list, params Func<T, bool>[] predicates)
        {
            IEnumerable<T> filtered = list;
            foreach (var perdicate in predicates)
            {
                filtered = filtered.Where(perdicate);
                int count = filtered.Count();

                if (count == 0)
                {
                    throw new SDMXException("not found.");
                }
                else if (count == 1)
                {
                    return filtered.Single();
                }                
            }

            throw new SDMXException("Multiple found for the cirteria.");
        }

        public CodeList GetCodeList(ID codeListID, ID agencyID, string version)
        {
            return Filter(CodeLists, c => c.ID == codeListID, c => c.AgencyID == agencyID, c => c.Version == version);
        }

        //private CodeList GCL(ID codeListID, ID agencyID, string version)
        //{
        //    Contract.AssertNotNull(() => codeListID);
            
        //    var codeLists = CodeLists.Where(c => c.ID == codeListID && c.AgencyID == agencyID);

        //    int count = codeLists.Count();
        //    if (count == 0)
        //    {
        //        return null;
        //    }
        //    if (count == 1)
        //    {
        //        return codeLists.Single();
        //    }
        //    else
        //    {
        //        if (version == null)
        //        {
        //            throw new SDMXException("Multipe codelists found and version is null.");    
        //        }

        //        codeLists = codeLists.Where(c => c.Version == version);

        //        count = codeLists.Count();
        //        if (count == 0)
        //        {
        //            return null;  
        //        }
        //        else if (count == 1)
        //        {
        //            return codeLists.Single();
        //        }
        //        else
        //        {
        //            throw new SDMXException("Multiple code lists found with the same version.");
        //        }
        //    }
        //}

        public static StructureMessage Parse(string text)
        {
            var map = new StructureMessageMap();

            StructureMessage message;
            using (var reader = XmlReader.Create(new StringReader(text)))
            {
                message = map.ReadXml(reader);
            }

            return message;
        }

        public static StructureMessage Load(string fileName)
        {
            var map = new StructureMessageMap();

            StructureMessage message;
            using (var reader = XmlReader.Create(fileName))
            {
                message = map.ReadXml(reader);
            }

            return message;
        }

        public void Save(string fileName)
        {   
            var map = new StructureMessageMap();

            var settings = new XmlWriterSettings() { Indent = true };
            using (var writer = XmlWriter.Create(fileName, settings))
            {
                map.WriteXml(writer, this);
            }
        }

        public override string ToString()
        {
            var map = new StructureMessageMap();
            var sb = new StringBuilder();

            var settings = new XmlWriterSettings() { Indent = true };
            using (var writer = XmlWriter.Create(sb, settings))
            {
                map.WriteXml(writer, this);
            }

            return sb.ToString();
        }

        public Concept GetConcept(ID conceptID, ID agencyID, string version)
        {
            return Filter(Concepts, c => c.ID == conceptID, c => c.AgencyID == agencyID, c => c.Version == version);
        }


    }
}