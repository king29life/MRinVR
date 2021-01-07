namespace MRinVR.Data
{
    /// <summary>
    /// WebAPIの通信機能を提供します。
    /// </summary>
    public sealed class TransferAPIClient : TransferAPIBase, ITransferAPI
    {
        /// <summary>
        /// 設定情報を取得または設定します。
        /// </summary>
        public TransferAPIClientSettings Settings { get; set; }

        /// <summary>
        /// 作業のリストを取得します。
        /// </summary>
        //public Task<OperationList> GetOperationListAsync(Guid domainID)
        //{
        //    var headers = new Dictionary<string, string>()
        //    {
        //        { ProtocolConstants.DomainHeader, domainID.ToString() },
        //    };
        //    return GetAsync<OperationList>(Settings.GetOperationListUri, headers);
        //}

        /// <summary>
        /// 作業のデータを取得します。
        /// </summary>
        //public Task<OperationData> GetOperationDataAsync(Guid domainID, Guid operationID)
        //{
        //    var headers = new Dictionary<string, string>()
        //    {
        //        { ProtocolConstants.DomainHeader, domainID.ToString() },
        //        { ProtocolConstants.OperationHeader, operationID.ToString() },
        //    };
        //    return GetAsync<OperationData>(Settings.GetOperationDataUri, headers);
        //}

        /// <summary>
        /// 作業のデータを送信します。
        /// </summary>
        //public Task PostOperationDataAsync(Guid domainID, OperationData operationData)
        //{
        //    var headers = new Dictionary<string, string>()
        //    {
        //        { ProtocolConstants.DomainHeader, domainID.ToString() },
        //    };
        //    return PostAsync(Settings.PostOperationDataUri, headers, operationData);
        //}
    }
}
