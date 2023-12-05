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

SettingCobfigurationMs içerisinde rabbitmq!ye event publish edecek bir metod kurulmuştur. Örnek olarak ConfigurationCreateEvent oluşturulmuş ve yeni bir setting eklendiğinde kuyruğa gçnderilecek şekilde ayarlanmıştır. Bu kuyruk ise ServiceA tarafından dinlenmiştir. 

 ![ScreenShot](https://i.ibb.co/LdZT6NJ/rabbitmq-implementation.png)<br/>
   ![ScreenShot](https://i.ibb.co/zQZLqbv/Screen-Shot-2023-11-29-at-13-36-37.png)<br/>
 ![ScreenShot](https://i.ibb.co/CV8kD3P/Screen-Shot-2023-12-02-at-13-44-31.png)<br/>

   ![ScreenShot](https://i.ibb.co/ZX54G5k/24242.png)<br/>

## SignalR ile gerçek zamanlı haberleşme

İki mikroservice arasındaki sürekli iletişimi ve data consistancyi sağlamak için signalR yapısı kurulmuştur. SettingConfigurationMS'e signalR produces olarak eklenmiştir. ServiceA ise 15 dakika aralıklarla signalR'a bağlanarak yeni bir işlem yapılığ yapılmadığını kontrol etmektedir. 

 ![ScreenShot](https://i.ibb.co/6ZjNzG5/1-q5-WGt-Tp6k-C5p-Df-PJsx-U0-RA.webp))<br/>
 
 ![ScreenShot](https://i.ibb.co/Z2H43VH/Screen-Shot-2023-12-02-at-13-45-00.png))<br/>
## Kullanılan Teknolojiler

.ner core 5.0

 -Rabbitmq
 -MediatR
 -EntittyFramework
 -xunit
 -SignalR

## Ekran Görüntüleri

Dynamic type dönen endpoint

 ![ScreenShot](https://i.ibb.co/MCc5LQp/Screen-Shot-2023-11-28-at-20-41-17.png)<br/>
 ![ScreenShot](https://i.ibb.co/2ZgS6ww/Screen-Shot-2023-12-02-at-13-46-35.png)<br/>
