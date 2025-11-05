namespace Lab3_3_DAL.DataProvider
{
    public interface IDataProvider
    {
        void Serialize<T>(T data, string path);
        T Deserialize<T>(string path);
    }
}
