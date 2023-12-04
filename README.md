# Microservice Poc: Konfiguration microservice Uygulaması

Bu çalışma dinamik bir konfigurasyon yapısı kurmayı hedeflemiştir. Farklı mikroservise projelerinde tutulan  keylerin MicroserviceMs ismini verdiğimiz bir diğer mikroserviseden produce edilecek eventler ile güncel olarak erişilebilir ve kontrol edilebilir hale gelmesi amaçlanmıştır. 


## Mimari Yapı

SettingConfigurationMS ve ServiceA isimli iki mikroservis farklı tasarım kalıpları ile geliştirilmiştir. Oluşturulan mimari yapı ve detayları aşağıdaki gibidir. <br/>
![ScreenShot](https://i.ibb.co/H24sYnD/Screen-Shot-2023-12-02-at-13-43-55.png)
<br/>ServiceA mikroservisinde clean architecture, cqrs implementastonu, MediartR ve Union pattern kullanılmıştır. Katmanlı bir yapı tasarlanmış, command ve queryler ayrılmıştır.

<br/>SettingConfigurationMS mikroservisinde ise rabbitmq implement edilerek event bus oluşturulmuştur.

## Veritabanı

SettingConfigurationMS mikroserviste MongoDb kullanılmıştır. ServiceA için mssql yapısı tasarlanmıştır. <br/>
Çalışmada kullanılan model aşağıdaki gibidir.
 ![ScreenShot](https://i.ibb.co/qx4NcSP/Screen-Shot-2023-12-02-at-13-45-27.png)<br/>

 ## RabbirmQ- EventBus ile microserviceler arası iletişim


 ![ScreenShot](https://i.ibb.co/RzGwx5w/images.png)<br/>
 ![ScreenShot](https://i.ibb.co/CV8kD3P/Screen-Shot-2023-12-02-at-13-44-31.png)<br/>

## SignalR ile gerçek zamanlı haberleşme


## Kullanılan Teknolojiler

.ner core 5.0

 -Rabbitmq
 -MediatR
 -EntittyFramework
 -xunit
 -SignalR

## Ekran Görüntüleri

Dynamic type dönen endpoint

 ![ScreenShot](https://i.ibb.co/5xwfsCb/9999999.png)<br/>
 ![ScreenShot](https://i.ibb.co/hdJJR7w/6666666666.png)<br/>
 ![ScreenShot](https://i.ibb.co/1bbw6bx/96796796.png)<br/>
 ![ScreenShot](https://i.ibb.co/NjDFGt0/7777777.png)<br/>
 ![ScreenShot](https://i.ibb.co/tYpg8B7/74747457.png)<br/>
