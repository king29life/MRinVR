using System;
using UnityEngine;

namespace MRinVR.Data
{
    /// <summary>
    /// APIの接続設定を定義します。
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Data/TransferAPIClientSettings")]
    public sealed class TransferAPIClientSettings : ScriptableObject
    {
        /// <summary>
        /// GetOperationListの接続文字列
        /// </summary>
        [SerializeField]
        private string getOperationListUri = "https://localhost/api/GetOperationList?code=";

        /// <summary>
        /// GetOperationDataの接続文字列
        /// </summary>
        [SerializeField]
        private string getOperationDataUri = "https://localhost/api/GetOperationData?code=";

        /// <summary>
        /// PostOperationDataの接続文字列
        /// </summary>
        [SerializeField]
        private string postOperationDataUri = "https://localhost/api/PostOperationData?code=";

        /// <summary>
        /// GetOperationListの接続文字列を取得します。
        /// </summary>
        public string GetOperationListUri => getOperationListUri;

        /// <summary>
        /// GetOperationDataの接続文字列を取得します。
        /// </summary>
        public string GetOperationDataUri => getOperationDataUri;

        /// <summary>
        /// PostOperationDataの接続文字列を取得します。
        /// </summary>
        public string PostOperationDataUri => postOperationDataUri;
    }
}
