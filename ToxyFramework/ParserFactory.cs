﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toxy.Parsers;

namespace Toxy
{
    public class ParserFactory
    {
        private ParserFactory() { }
        static Dictionary<string, List<Type>> parserMapping = new Dictionary<string, List<Type>>();

        static ParserFactory()
        {
            var type1=new List<Type>();
            type1.Add(typeof(PlainTextParser));
            parserMapping.Add(".txt", type1);

            var type2 = new List<Type>();
            type2.Add(typeof(PlainTextParser));
            parserMapping.Add(".xml", type2);

            var type3 = new List<Type>();
            type3.Add(typeof(PlainTextParser));
            type3.Add(typeof(CSVParser));
            parserMapping.Add(".csv", type3);

            var type4 = new List<Type>();
            type4.Add(typeof(ExcelParser));
            parserMapping.Add(".xls", type4);

            var type5 = new List<Type>();
            type5.Add(typeof(ExcelParser));
            parserMapping.Add(".xlsx", type5);

            var type6 = new List<Type>();
            type6.Add(typeof(WordParser));
            parserMapping.Add(".docx", type6);

        }

        static string GetFileExtention(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!parserMapping.ContainsKey(fi.Extension))
                throw new NotSupportedException("Extension " + fi.Extension + " is not supported");
            return fi.Extension;
        }
        static object CreateObject(ParserContext context)
        {
             string ext = GetFileExtention(context.Path);
            var types= parserMapping[ext];
            object obj = null;
            bool isFound = false;
            foreach (Type type in types)
            {
                obj = Activator.CreateInstance(type, context);
                if (obj is ITextParser)
                {
                    isFound = true;
                    break;
                }
            }
            if (isFound)
                throw new InvalidDataException(ext + " is not supported");
            return obj;
        }
        public static ITextParser CreateText(ParserContext context)
        {
            object obj = CreateObject(context);
            ITextParser parser = (ITextParser)obj;
            return parser;
        }
        public static ISpreadsheetParser CreateSpreadsheet(ParserContext context)
        {
            object obj = CreateObject(context); 
            ISpreadsheetParser parser = (ISpreadsheetParser)obj;
            return parser;
        }

        public static IDocumentParser CreateDocument(ParserContext context)
        {
            object obj = CreateObject(context);
            IDocumentParser parser = (IDocumentParser)obj;
            return parser;
        }
    }
}
