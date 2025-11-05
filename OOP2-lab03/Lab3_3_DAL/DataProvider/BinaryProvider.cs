                using System.IO;
                using System.Runtime.Serialization.Formatters.Binary;

                namespace Lab3_3_DAL.DataProvider
                {
                    
                    public class BinaryProvider : IDataProvider
                    {
                        public void Serialize<T>(T data, string path)
                        {
#pragma warning disable SYSLIB0011
                            using var fs = new FileStream(path, FileMode.Create);
                            var bf = new BinaryFormatter();
                            bf.Serialize(fs, data);
#pragma warning restore SYSLIB0011
                        }

                        public T Deserialize<T>(string path)
                        {
#pragma warning disable SYSLIB0011
                            using var fs = new FileStream(path, FileMode.Open);
                            var bf = new BinaryFormatter();
                            return (T)bf.Deserialize(fs);
#pragma warning restore SYSLIB0011
                        }
                    }
                }
