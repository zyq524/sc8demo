
namespace SC8Demo.Web.WFFM
{
    using System;
    using Sc8Demo.Core;
    using SC8Demo.EXM;
    using Sitecore.Data;
    using Sitecore.Form.Core.Client.Data.Submit;
    using Sitecore.Form.Core.Controls.Data;
    using Sitecore.Form.Submit;

    public class SendRegisterConfirmationAction : ISaveAction
    {
        private ContactService contactService = new ContactService();
        private DispatchService dispatchService = new DispatchService();

        public void Execute(ID formid, AdaptedResultList fields, params object[] data)
        {
            string email=string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;

            foreach (AdaptedControlResult field in fields)
            {
                if (field.FieldID == "{4ADF830B-CDFB-415D-AD78-0098CE32BC62}")
                {
                    email = field.Value;
                }
                else if (field.FieldID == "{1DBD36AF-6438-43B6-90A6-562321E5FB20}")
                {
                    firstName = field.Value;
                }
                else if (field.FieldID == "{59111201-17F6-4121-8D22-395A876FD731}")
                {
                    lastName = field.Value;
                }
            }
            var contact = this.contactService.CreateContact(Guid.NewGuid().ToString(), firstName, lastName, email, Sitecore.Context.Language.Name);

            this.dispatchService.SendTriggeredMessageToXDB(Guid.Parse("{F4319C24-BD2C-4450-93F1-32922FA4EEA4}"), contact.ContactId);
        }
    }
}