
namespace SC8Demo.EXM
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Modules.EmailCampaign.Recipients;

    public class DispatchService
    {
        public void SendTriggeredMessageToXDB(Guid messageId, Guid contactId, bool usePreferredLanguage = false,
        IDictionary<string, object> customPersonTokens = null)
        {

            RecipientId recipientId = RecipientRepository.GetDefaultInstance().ResolveRecipientId("xdb:" + contactId);

            Sitecore.Modules.EmailCampaign.Application.Application.Instance.EmailDispatch.SendTriggered(messageId, recipientId, usePreferredLanguage, customPersonTokens);
        }

        public void SendTriggeredMessageToSitecoreUser(Guid messageId, Guid contactId, bool usePreferredLanguage = false,
        IDictionary<string, object> customPersonTokens = null)
        {

            RecipientId recipientId = RecipientRepository.GetDefaultInstance().ResolveRecipientId("xdb:" + contactId);

            Sitecore.Modules.EmailCampaign.Application.Application.Instance.EmailDispatch.SendTriggered(messageId, recipientId, usePreferredLanguage, customPersonTokens);
        }
    }
}
