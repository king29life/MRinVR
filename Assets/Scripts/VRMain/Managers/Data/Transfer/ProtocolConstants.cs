using System;

namespace MRinVR.Data
{
    /// <summary>
    /// プロトコルに関する定数を定義します。
    /// </summary>
    public static class ProtocolConstants
    {
        /// <summary>
        /// 要求ヘッダに設定するドメインIDの名前
        /// </summary>
        public const string DomainHeader = "Domain";

        /// <summary>
        /// 要求および応答データの種類
        /// </summary>
        public const string ContentType = "application/x-msgpack";
    }
}