

![wordle21222](https://github.com/user-attachments/assets/9da76e21-72bf-4a46-baef-d1b59d11c65b)
![wordllee1](https://github.com/user-attachments/assets/1e6d5804-af11-4711-961d-71be63053267)
![wordlee33](https://github.com/user-attachments/assets/ed40ac20-ea25-402d-912e-e60a42904f90)
![wordll4444](https://github.com/user-attachments/assets/ae6bd5b2-45db-42d0-bac2-d874ffeba6fc)




https://www.youtube.com/watch?v=d4uKw7qlfJk&ab_channel=HasanAKDEN%C4%B0Z

🎮 Oyun Nasıl Çalışıyor?

Kelime Yönetimi: Oyun başlangıcında, tanımlı bir listeden rastgele bir hedef kelime belirlenir.

Kullanıcı Girdisi: Oyuncu tahminleri, standart bir InputField bileşeni aracılığıyla alınır.

Tahmin Değerlendirme: Gönderilen her tahmin, hedef kelime ile karşılaştırılarak her harf için bir durum tespiti yapılır:

Yeşil: Doğru harf, doğru pozisyon.

Sarı: Doğru harf, yanlış pozisyon.

Gri: Yanlış harf.

Oyun Durumu Takibi: Oyuncunun kazanma veya kaybetme durumu, tahmin sayısı ve sonuçlara göre belirlenir. Oyun bittiğinde ilgili bilgilendirme mesajı gösterilir.

🛠️ Kullandığım Araçlar

Geliştirme Ortamı: Unity 2022.3  sürümü

Programlama Dili: C#

Arayüz Bileşenleri: TextMeshPro

📂 Teknik Yapı ve Mimari

Temel Sınıflar ve Görevleri

WordManager.cs
Oyunun çekirdek mantığını barındıran sınıftır.

Fonksiyonları:
wordList üzerinden hedef kelimeyi (currentWord) seçer.

GetStates(string guess) metodu ile tahminleri analiz eder ve harf durumlarını bir liste olarak döndürür. Bu analiz, tekrar eden harfleri doğru şekilde yöneten iki aşamalı bir algoritma kullanır.

ContentController.cs
Oyun akışını ve diğer sınıflar arasındaki veri iletişimini yönetir.

Fonksiyonları:
TMP_InputField olaylarını dinleyerek kullanıcı girdilerini alır.
WordManager'dan alınan analiz sonuçlarını ilgili arayüz bileşenlerine (RowController) iletir.
Mevcut tahmin sırasını (_index) takip eder ve oyunun sonlanma koşullarını denetler.

RowController.cs & CellController.cs
Arayüzün görsel sunumundan sorumludurlar.

Fonksiyonları: RowController, bir tahmin satırındaki CellController nesnelerini yönetir. CellController ise tek bir harf kutucuğunun metin ve renk değerlerini günceller.

Kelime Analiz Algoritması

Tekrar eden harflerin bulunduğu durumlarda doğru sonuç üretmek için iki aşamalı bir algoritma geliştirilmiştir:

Birinci Aşama: Öncelikle, konumları doğru olan harfler (Correct) tespit edilir ve bu harfler sonraki kontrollerde dikkate alınmamak üzere işaretlenir.

İkinci Aşama: Ardından, konumu yanlış ancak kelimede mevcut olan harfler (Contain), henüz kullanılmamış harfler arasından aranarak bulunur.

🚀 Kurulum ve Kullanım Talimatları

Proje dosyalarını yerel bir dizine klonlayın veya indirin.

Projeyi Unity Hub aracılığıyla açın.

Assets/Scenes altındaki ana oyun sahnesini yükleyin.

Sahnede bulunan WordManager GameObject'ini seçin.

Inspector panelindeki Word List dizisine, hepsi aynı uzunlukta olacak şekilde hedef kelimeleri girin.

Unity editöründeki "Play" butonuna basarak uygulamayı başlatın
