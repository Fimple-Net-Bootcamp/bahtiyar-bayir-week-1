@import "https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;700&display=swap";
<style>
    p{
        display : inline;
    }
    .vurgu{
        font-weight:bold; 
        font-style:italic;
    }
</style>

# Kütüphane Uygulaması
<p>
Bu projede 1. haftada istenen ödeve karşılık bir konsol uygulaması olarak kütüphane yönetim sistemi geliştirilmiştir. Projede güncel teknolojilerden;
 
- AutoMapper" Version=12.0.1
- AutoMapper.Extensions.Microsoft.DependencyInjection Version=12.0.1
- FluentValidation Version=11.8.1
- EntityFrameworkCore Version=7.0.14
- EntityFrameworkCore.InMemory Version=7.0.14
- DependencyInjection Version=8.0.0
- Hosting Version=8.0.0

kullanılmıştır. <br><br>
</p>
 

<p>Projede sınıflar, <p class="vurgu">Host</p> sınıfına ait <p class="vurgu">CreateDefaultBuilder().ConfigureServices()</p> metoduyla bir servis konfigüre edilimiş ve bağımlılıkardan dependency injection ile kurtarılmıştır.<br><br>
Konfigürasyondan sonra <p class= "vurgu">.Build()</p> metodu ile host build edilip <p class = "vurgu">.Services.GetReqiredServices&lt;T	&gt;()</p> metoduyla IManager arayüzünden kütüphane yönetim sınıfı Manager'a erişilmiştir. Projenin işleyiş şeması aşağıdaki gibidir.
</p>
<div style ="height : 50px;"></div>
<p>Uygulamada içerisinde veriler bir InMemory DB oluşturularak orada saklandı. İçerideki hazır veriler rasgele "https://www.mockaroo.com/" adresinden oluşturuldu. Çalışmada,Manager > Conrollers > Queries/Commands > DB şeklinde bir hiyerarşik yapı oluşturulması hedeflendi.</p>
<div style ="height : 50px;"></div>


<center><img src="Img/Diagram/diagram.svg"></img></center>

## Ekran görüntüleri
<p>Menüler içerisinden okunabilirlik için sadece bazıları koyulmuştur.</p>

###### Ana Ekran
<img src="Img/SC/page1.PNG" alt="Ekran görüntüsü 1"></img>
###### Ödünç alma ekranı
<img src="Img/SC/page2.PNG" alt="Ekran görüntüsü 1"></img>
###### Ödünç alma kayıtları
<img src="Img/SC/page3.PNG" alt="Ekran görüntüsü 1"></img>
###### Kayıtlı kitaplar listesi
<img src="Img/SC/page4.PNG" alt="Ekran görüntüsü 1"></img>
###### Üye Aktif/Pasif yapma ekranı
<img src="Img/SC/page5.PNG" alt="Ekran görüntüsü 1"></img>
###### Yazarlar listesi
<img src="Img/SC/page6.PNG" alt="Ekran görüntüsü 1"></img>
###### Ödünç alma ekranı