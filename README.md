# log4net
  
Log4Net is a logging framework which helps a developer to store the information to variety of storage areas
Example:
- Console
- File
- DB
- Windows Event
- Trace
- etc..
 
Also it allow to build Custom Appenders through which we can push logs to anywhere we want (Inherit AppenderSkeleton)
- Azure : Storage
- Twilio : SMS
- etc..

It also lets you customize the way the message should be displayed:
- Simple Layout
- XML Layout
- Pattern Layout
- etc..
- Custom Layput (Inheriting LayoutSkeleton)

It also lets you control the filtering:
- LevelMatch
- LevelRange
- Deny
- etc..
- Custom Filter (Inheriting FilterSkeleton)

It also lets you Forward from one Appender to another Appender:
- ForwardingAppender
- BufferingForwardingAppender

Note:
- The above sample is built on .net Core

For more details on log4net, [Click here](https://github.com/ILearny/Standards/wiki/Log4Net)
