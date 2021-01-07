using System;
using System.Threading.Tasks;

namespace MRinVR.Data
{
    /// <summary>
    /// WebAPIのインタフェースを定義します。
    /// </summary>
    public interface ITransferAPI
    {
        /// <summary>
        /// 作業のリストを取得します。
        /// </summary>
        //Task<OperationList> GetOperationListAsync(Guid domainID);

        /// <summary>
        /// 作業のデータを取得します。
        /// </summary>
        //Task<OperationData> GetOperationDataAsync(Guid domainId, Guid operationID);

        /// <summary>
        /// 作業のデータを送信します。
        /// </summary>
        //Task PostOperationDataAsync(Guid domainId, OperationData operationData);
    }
}
