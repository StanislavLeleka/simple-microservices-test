# simple-microservices-test
asp.net core microservice + docker + spa + signalr 

To run the app you have to change some constants values:
1. Services/Message.Api/Services/HttpComunicationHelper.cs  NOTIFICATION_SERVICE_HOST = host of the notification service 
2. Services/Message.Api/Startup.cs, Services/NotificationService/Startup.cs SPA_HOST = host of the client app
3. SPA/message-spa/src/components/notitfications.js notificationServiceHost = host of the notification service 
