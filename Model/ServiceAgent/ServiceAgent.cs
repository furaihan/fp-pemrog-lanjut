using TestingDatabase.Model.DataAccessLayer;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.ServiceAgent
{
    internal abstract class ServiceAgent
    {
        public abstract void FetchData();
        public abstract IEnumerable<object> GetData();

        public static void FlushData<T>(T repo, object obj, Tag.FlushMode mode) where T : IRepository
        {
            if (!(repo is CustomerDAL || repo is HistoryDAL || repo is ReservationDAL))
            {
                throw new ArgumentException("Invalid Argument: repo must be of CustomerDAL, HistoryDAL, or Reservation DAL type", nameof(repo));
            }
            if (!(obj is Customer || obj is History || obj is Reservation))
            {
                throw new ArgumentException("Invalid Argument: obj must be of Customer, History, or Reservation type", nameof(obj));
            }

            try
            {
                switch (mode)
                {
                    case Tag.FlushMode.add:
                        repo.InsertRecord(obj);
                        break;
                    case Tag.FlushMode.update:
                        repo.UpdateRecord(obj);
                        break;
                    case Tag.FlushMode.delete:
                        repo.DeleteRecord(obj);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error di input: {e.Message}");
            }
        }
    }
}
