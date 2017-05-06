using JWT;
using Newtonsoft.Json;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.Models.Common;
using System;
using System.Collections.Generic;
using ProArch.FieldOrbit.BusinessLayer.Extensions;
using JWT.Algorithms;
using JWT.Serializers;

namespace ProArch.FieldOrbit.BusinessLayer.Security
{
    public class TokenManager
    {
        private const int EXPIRYTIME = 10000;//Seconds
        private const string SECRETKEY = "PROARCH";//Access Key Confidential
        private const string REFRESHSECRETKEY = "PROREFRESH";//Refresh Key Confidential

        public static TokenHolder GenerateToken(EmployeeToken employeeInfo)
        {
            TokenHolder tokenHolder = CreateToken(employeeInfo);
            return tokenHolder;
        }

        public static TokenHolder RefreshToken(string token)
        {
            EmployeeToken employeeInfo = Decode(token, REFRESHSECRETKEY);
            TokenHolder tokenHolder = CreateToken(employeeInfo);
            return tokenHolder;
        }

        public static EmployeeToken DecodeToken(string token)
        {
            EmployeeToken employeeInfo = Decode(token, SECRETKEY);
            return employeeInfo;
        }

        private static TokenHolder CreateToken(EmployeeToken employeeInfo)
        {
            if (employeeInfo.VerifyObjectNull(throwEdit: false))
            {
                throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "Invalid Data", Message = "Data should not be null." } }) };
            }

            TokenHolder tokenHolder = new TokenHolder();
            var currentTime = (long)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            var payload = new Dictionary<string, object>();
            payload.Add("userInfo", employeeInfo);
            payload.Add("exp", currentTime + EXPIRYTIME);

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            tokenHolder.AccessToken = encoder.Encode(payload, SECRETKEY);

            var refreshPayload = new Dictionary<string, object>();
            refreshPayload.Add("userInfo", employeeInfo);
            refreshPayload.Add("CurrentDate", DateTime.Now.ToString());

            tokenHolder.RefreshToken = encoder.Encode(payload, REFRESHSECRETKEY);
            return tokenHolder;
        }

        private static EmployeeToken Decode(string token, string securityKey)
        {
            EmployeeToken employeeInfo = null;

            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            string jsonPayload = decoder.Decode(token, SECRETKEY, verify: true);

            Dictionary<string, object> payload = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonPayload);
            if (payload.ContainsKey("userInfo"))
            {
                string userInfoData = payload["userInfo"].ToString();
                employeeInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeToken>(userInfoData);
            }
            return employeeInfo;
        }
    }
}
