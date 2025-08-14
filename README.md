# Audio Steganography - Ses Dosyalarına Gizli Mesaj Gömme

Bu proje, C# ve NAudio kütüphanesi kullanarak WAV formatındaki ses dosyalarına gizli mesaj gömme (steganografi) işlemi yapar. Fibonacci dizisi tabanlı LSB yöntemiyle ses verilerinin belirli bitlerine mesaj gizlenir ve yeni bir ses dosyası oluşturulur.

---

## İçindekiler

- [Proje Hakkında](#proje-hakkında)
- [Özellikler](#özellikler)
- [Başlangıç](#başlangıç)
- [Kullanım](#kullanım)
- [Teknolojiler](#teknolojiler)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)
- [İletişim](#iletişim)

---

## Proje Hakkında

Ses dosyalarına gizli mesaj gömme işlemi, verinin gizliliği ve güvenliği için kullanılan bir tekniktir. Bu proje, WAV dosyalarındaki ses verilerini binary formata çevirir, Fibonacci dizisi kullanarak belirli bitlere mesajı gömer ve yeni bir WAV dosyası oluşturur.

---

## Özellikler

- WAV dosyalarını okuma ve binary formata çevirme
- Fibonacci dizisi tabanlı LSB gizleme algoritması
- Gizli mesajı binary olarak ses dosyasına gömme
- Yeni WAV dosyası oluşturma ve oynatma
- Türkçe karakter kontrolü (Türkçe karakterler desteklenmemektedir)

---

## Başlangıç

### Gereksinimler

- [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework) (Windows Forms uygulaması için)
- [NAudio](https://github.com/naudio/NAudio) kütüphanesi (NuGet üzerinden eklenmeli)

### Kurulum

1. Depoyu klonlayın:

   ```bash
   git clone https://github.com/leventDemirkaya/audioSteganography.git
Visual Studio ile projeyi açın.
NuGet Paket Yöneticisi'nden NAudio paketini yükleyin.
Kullanım
Programı çalıştırın.
Ses Dosyası Ekle butonuna tıklayarak WAV formatında ses dosyaları seçin.
Listeden bir ses dosyası seçin, ses otomatik olarak oynatılacaktır.
Gizlemek istediğiniz mesajı metin kutusuna yazın (Türkçe karakter kullanmayınız).
Mesajı Gizle butonuna tıklayın.
Program, mesajı ses dosyasına gizleyip yeni bir WAV dosyası oluşturacak ve oynatacaktır.
Teknolojiler
C#
Windows Forms
NAudio kütüphanesi
Katkıda Bulunma
Katkılarınızı memnuniyetle karşılarız! Lütfen bir sorun açın veya geliştirme önerilerinizi içeren pull request gönderin.

Lisans
Bu proje MIT Lisansı ile lisanslanmıştır. Detaylar için LICENSE dosyasına bakınız.

İletişim
Levent Demirkaya - GitHub - leventdemirkaya@outlook.com
