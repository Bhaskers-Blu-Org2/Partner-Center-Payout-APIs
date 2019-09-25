﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PartnerCenterPayoutAPISampleCode
{
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// Contains actions or methods that can be performed related to Partner Center Payout - Payments.
    /// </summary>
    public class Payments
    {
        private static HttpClient _httpClient = new HttpClient();
        private static string domain = "https://api.partner.microsoft.com/";
        private static string basePath = "v1.0/payouts/";
        private static string resource = "payments";

        /// <summary>
        /// Creates a new Partner Center Payout Payments request.
        /// </summary>
        /// <param name="accessToken">AAD token generated by the UserCredentialTokenGenerator</param>
        /// <returns>Standard Http Response from the API</returns>
        public static HttpResponseMessage CreateRequest(string accessToken)
        {
            // Add your odata filter string below if any. 
            // SUPPORTED $filter fields are - payoutStatusUpdateTS, enrollmentParticipantId, programName, payoutOrderType, paymentId
            // Example filter string - "?$filter=payoutStatusUpdateTS le 2019-09-25T23:11:55.647Z and (enrollmentParticipantId eq 'XXXXXXX') and (programName eq 'Azure Marketplace') and (payoutOrderType eq 'SELL') and (paymentId eq '000000000000')";

            string filterString = "";
            string createPaymentsRequestURI = domain + basePath + resource + filterString;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, createPaymentsRequestURI);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = _httpClient.SendAsync(requestMessage).Result;

            return response;
        }

        /// <summary>
        /// Gets the status of an existing Partner Center Payout Payments request.
        /// </summary>
        /// <param name="accessToken">AAD token generated by the UserCredentialTokenGenerator</param>
        /// <param name="requestId">requestId</param>
        /// <returns>Standard Http Response from the API</returns>
        public static HttpResponseMessage GetRequest(string accessToken, string requestId)
        {
            var paymentsStatusUrl = domain + basePath + resource + "/" + requestId;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, paymentsStatusUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = _httpClient.SendAsync(requestMessage).Result;

            return response;
        }

        /// <summary>
        /// Deletes an existing Partner Center Payout Payments request.
        /// </summary>
        /// <param name="accessToken">AAD token generated by the UserCredentialTokenGenerator</param>
        /// <param name="requestId">requestId</param>
        /// <returns>Standard Http Response from the API</returns>
        public static HttpResponseMessage DeleteRequest(string accessToken, string requestId)
        {
            string deletePaymentsRequestURI = domain + basePath + resource + "/" + requestId;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, deletePaymentsRequestURI);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = _httpClient.SendAsync(requestMessage).Result;

            return response;
        }
    }
}