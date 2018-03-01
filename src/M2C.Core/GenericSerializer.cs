

namespace M2C.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;

    public static class GenericSerializer
    {


        public static void WriteGenericItem<T>(T t, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriter writer;
            InitializeXmlWriter(fileName, out writer);
            serializer.Serialize(writer, t);
            CleanupXmlWriter(ref writer);
        }

        public static T ReadGenericItem<T>(string fileName)
        {
            T t = default(T);
            if (File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(fileName);
                t = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            return t;
        }

        public static void WriteGenericList<T>(List<T> list, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            XmlWriter writer;
            InitializeXmlWriter(fileName, out writer);
            serializer.Serialize(writer, list);
            CleanupXmlWriter(ref writer);
        }

        public static List<T> ReadGenericList<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                List<T> l = new List<T>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                TextReader reader = new StreamReader(fileName);
                l = (List<T>)serializer.Deserialize(reader);
                reader.Close();
                return l;
            }
            else
            {
                return null;
            }

        }

        public static List<T> CreateGenericListFromXmlDoc<T>(XmlDocument xml)
        {
            List<T> l = new List<T>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (MemoryStream stream = new MemoryStream())
            {
                xml.Save(stream);
                stream.Position = 0;
                l = (List<T>)serializer.Deserialize(stream);
            }
            return l;
        }

        public static T CreateGenericItemFromXmlDoc<T>(XmlDocument xml)
        {
            T t = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            {
                xml.Save(stream);
                stream.Position = 0;
                t = (T)serializer.Deserialize(stream);
            }
            return t;
        }

        public static XmlDocument XmlDocFromItem(object o)
        {
            Type t = o.GetType();
            XmlDocument xml = new XmlDocument();

            xml.PreserveWhitespace = false;
            XmlSerializer serializer = new XmlSerializer(t);
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            using (StreamReader reader = new StreamReader(stream))
            {
                serializer.Serialize(writer, t);
                stream.Position = 0;
                xml.Load(stream);
            }
            return xml;
        }

        public static T CloneItem<T>(T item)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc = XmlDocFromGenericItem<T>(item);
            T t = CreateGenericItemFromXmlDoc<T>(xdoc);
            return t;
        }

        public static XmlDocument XmlDocFromGenericItem<T>(T t)
        {
            XmlDocument xml = new XmlDocument();
            xml.PreserveWhitespace = false;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            using (StreamReader reader = new StreamReader(stream))
            {
                serializer.Serialize(writer, t);
                stream.Position = 0;
                xml.Load(stream);
            }
            return xml;
        }

        public static byte[] ItemToByteArray(object o)
        {
            byte[] array = null;
            if (o != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, o);
                    array = stream.ToArray();
                }
            }
            return array;
        }

        public static byte[] GenericItemToByteArray<T>(T t)
        {
            byte[] array = null;
            if (t != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, t);
                    array = stream.ToArray();
                }
            }
            return array;
        }

        public static object ByteArrayToItem(byte[] bytes)
        {
            object o = null;
            if (bytes != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);
                    o = (object)formatter.Deserialize(stream);
                }
            }

            return o;
        }

        public static T ByteArrayToGenericItem<T>(byte[] bytes)
        {
            T t = default(T);
            if (bytes != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);
                    object o = (object)formatter.Deserialize(stream);
                    if (o is T)
                    {
                        t = (T)o;
                    }
                }
            }

            return t;
        }

        public static XmlDocument XmlDocFromGenericList<T>(List<T> list)
        {
            XmlDocument xml = new XmlDocument();
            xml.PreserveWhitespace = false;
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            using (StreamReader reader = new StreamReader(stream))
            {
                serializer.Serialize(writer, list);
                stream.Position = 0;
                xml.Load(stream);
            }
            return xml;
        }

        public static List<T> StringToGenericList<T>(string s)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(s);
            return CreateGenericListFromXmlDoc<T>(xdoc);
        }
        public static T StringToGenericItem<T>(string s)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(s);
            return CreateGenericItemFromXmlDoc<T>(xdoc);

        }

        #region helper methods

        private static void InitializeXmlWriter(string filename, out XmlWriter writer)
        {
            XmlWriterSettings settings;
            CreateSettings(out settings);
            writer = XmlWriter.Create(filename, settings);
        }
        private static void CleanupXmlWriter(ref XmlWriter writer)
        {
            writer.Flush();
            writer.Close();
        }
        private static void CreateSettings(out XmlWriterSettings settings)
        {

            settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Indent = true;
            settings.IndentChars = (" ");
            settings.CheckCharacters = false;
            //settings.Encoding = Encoding.BigEndianUnicode;
        }

        #endregion




        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> source,
                                                    DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }


    }


    #region helper classes

    internal class ObjectShredder<T>
    {
        private FieldInfo[] _fi;
        private PropertyInfo[] _pi;
        private Dictionary<string, int> _ordinalMap;
        private Type _type;

        public ObjectShredder()
        {
            _type = typeof(T);
            _fi = _type.GetFields();
            _pi = _type.GetProperties();
            _ordinalMap = new Dictionary<string, int>();
        }

        public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, table, options);
            }


            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            // now see if need to extend datatable base on the type T + build ordinal map
            table = ExtendTable(table, typeof(T));

            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (options != null)
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), true);
                    }
                }
            }
            table.EndLoadData();
            return table;
        }

        public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                Object[] values = new object[table.Columns.Count];
                while (e.MoveNext())
                {
                    values[table.Columns["Value"].Ordinal] = e.Current;

                    if (options != null)
                    {
                        table.LoadDataRow(values, (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(values, true);
                    }
                }
            }
            table.EndLoadData();
            return table;
        }

        public DataTable ExtendTable(DataTable table, Type type)
        {
            // value is type derived from T, may need to extend table.
            foreach (FieldInfo f in type.GetFields())
            {
                if (!_ordinalMap.ContainsKey(f.Name))
                {
                    DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                        : table.Columns.Add(f.Name, f.FieldType);
                    _ordinalMap.Add(f.Name, dc.Ordinal);
                }
            }
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (!_ordinalMap.ContainsKey(p.Name))
                {
                    DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                        : table.Columns.Add(p.Name, p.PropertyType);
                    _ordinalMap.Add(p.Name, dc.Ordinal);
                }
            }
            return table;
        }

        public object[] ShredObject(DataTable table, T instance)
        {

            FieldInfo[] fi = _fi;
            PropertyInfo[] pi = _pi;

            if (instance.GetType() != typeof(T))
            {
                ExtendTable(table, instance.GetType());
                fi = instance.GetType().GetFields();
                pi = instance.GetType().GetProperties();
            }

            Object[] values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                values[_ordinalMap[f.Name]] = f.GetValue(instance);
            }

            foreach (PropertyInfo p in pi)
            {
                values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
            }
            return values;
        }

    }

    #endregion

}
