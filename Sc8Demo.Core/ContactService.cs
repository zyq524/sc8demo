
namespace Sc8Demo.Core
{
    using Sitecore.Analytics;
    using Sitecore.Analytics.Data;
    using Sitecore.Analytics.DataAccess;
    using Sitecore.Analytics.Model;
    using Sitecore.Analytics.Model.Entities;
    using Sitecore.Data;

    public class ContactService
    {
        public Sitecore.Analytics.Tracking.Contact CreateContact(string identifier, string firstName, string lastName, string email, string language)
        {
            var contactRepository = new ContactRepository();

            var contact = contactRepository.LoadContactReadOnly(identifier);
            if (contact == null)
            {

                contact = contactRepository.CreateContact(ID.NewID);
                contact.Identifiers.AuthenticationLevel = AuthenticationLevel.None;
                contact.System.Classification = 0;
                contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                contact.Identifiers.Identifier = identifier;
                contact.System.OverrideClassification = 0;
                contact.System.Value = 0;
                contact.System.VisitCount = 0;

                var contactPreferences = contact.GetFacet<IContactPreferences>("Preferences");
                contactPreferences.Language = language;

                var contactEmailAddresses = contact.GetFacet<IContactEmailAddresses>("Emails");
                contactEmailAddresses.Entries.Create("Preferred").SmtpAddress = email;
                contactEmailAddresses.Preferred = "Preferred";

                var contactPersonalInfo = contact.GetFacet<IContactPersonalInfo>("Personal");
                contactPersonalInfo.FirstName = firstName;
                contactPersonalInfo.Surname = lastName;

                contactRepository.SaveContact(contact, new ContactSaveOptions(true, null));
            }

            Tracker.Current.Session.Identify(identifier);
            return contact;
        }
    }
}
