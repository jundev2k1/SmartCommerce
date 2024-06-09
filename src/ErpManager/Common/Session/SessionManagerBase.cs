// Copyright (c) 2024 - Jun Dev. All rights reserved

using Newtonsoft.Json;

namespace ErpManager.ERP.Common.Session
{
    public class SessionManagerBase
    {
        protected readonly ISession _session;

        public SessionManagerBase(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
        /// <summary>
        /// Set session
        /// </summary>
        /// <param name="key">Session key</param>
        /// <param name="value">Session value</param>
        public void Set(string key, string value)
        {
            _session.SetString(key, value);
        }
        /// <summary>
        /// Set session
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Session key</param>
        /// <param name="value">Session value</param>
        public void Set<T>(string key, T value)
        {
            string serializedValue = JsonConvert.SerializeObject(value);
            Set(key, serializedValue);
        }

        /// <summary>
        /// Get Session (string)
        /// </summary>
        /// <param name="key">Session key</param>
        /// <returns>Session value</returns>
        public string Get(string key)
        {
            return _session.GetString(key).ToStringOrEmpty();
        }
        /// <summary>
        /// Get session
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Session key</param>
        /// <returns>Session value</returns>
        public T Get<T>(string key)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            
            var result = Get(key);
            if (!string.IsNullOrEmpty(result))
                return JsonConvert.DeserializeObject<T>(result);

            return default(T);

            #pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Remove session
        /// </summary>
        /// <param name="key">Session key</param>
        public void Remove(string key)
        {
            var isExist = _session.Get(key);
            if (isExist != null)
                _session.Remove(key);
        }

        /// <summary>
        /// Clear all session
        /// </summary>
        public void ClearAll()
        {
            _session.Clear();
        }
    }
}
