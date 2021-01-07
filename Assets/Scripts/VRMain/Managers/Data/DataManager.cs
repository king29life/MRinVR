using UnityEngine;

namespace MRinVR.Data
{
    /// <summary>
    /// データに関する機能を定義します。
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class DataManager : MonoBehaviour
    {
        /// <summary>
        /// API接続サービスの設定情報
        /// </summary>
        [SerializeField]
        private TransferAPIClientSettings m_TransferServiceSettings = null;

        /// <summary>
        /// API接続サービスのクライアントを取得します。
        /// </summary>
        public ITransferAPI TransferService { get; private set; }

        /// <summary>
        /// 初期化処理を実行します。
        /// </summary>
        public void Initialize()
        {
            // API接続サービスのクライアントを生成
            TransferService = new TransferAPIClient()
            {
                Settings = m_TransferServiceSettings,
            };
        }
    }
}