using log4net.Appender;
using log4net.Core;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Logger.Appenders
{
    public class TwilioAppender : AppenderSkeleton
    {
        TwilioClient _twilio;

        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public override void ActivateOptions()
        {
            base.ActivateOptions();
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            TwilioClient.Init(AccountSid, AuthToken);

            var message = MessageResource.Create(
                to: new PhoneNumber(To),
                from: new PhoneNumber(From),
                body: loggingEvent.MessageObject.ToString()
                );
        }
    }
}
