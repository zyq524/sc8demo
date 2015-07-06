
namespace Sc8Demo.Core
{
    using Sitecore.Analytics;
    using Sitecore.Analytics.Model.Entities;

    public class ContactService
    {
        public Sitecore.Analytics.Tracking.Contact CreateContact(string identifier, string firstName, string lastName, string email, string language)
        {
            Tracker.Current.Session.Identify(identifier);

            var contactPreferences = Tracker.Current.Contact.GetFacet<IContactPreferences>("Preferences");
            contactPreferences.Language = language;

            var contactEmailAddresses = Tracker.Current.Contact.GetFacet<IContactEmailAddresses>("Emails");
            contactEmailAddresses.Entries.Create("Preferred").SmtpAddress = email;
            contactEmailAddresses.Preferred = "Preferred";

            var personalInfo = Tracker.Current.Contact.GetFacet<IContactPersonalInfo>("Personal");
            personalInfo.FirstName = firstName;
            personalInfo.Surname = lastName;

            return Tracker.Current.Contact;
        }
    }
}
